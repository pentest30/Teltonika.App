using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Logging;
using Teeltoonika.Protocol.Commands.Commands;
using Teeltoonika.Protocol.Helper;
using Teeltoonika.Protocol.Protocols;

namespace Teltonica.Server
{
    public class AsynchronousIoServer : ConnectionHandler
    {
       
        private readonly IMediator _mediator;
        private readonly ILogger<AsynchronousIoServer> _logger;
        private SemaphoreSlim semaphore;
        public AsynchronousIoServer(IMediator mediator,ILogger<AsynchronousIoServer> logger)
        {
            _mediator = mediator;
            _logger = logger;
            semaphore = new SemaphoreSlim(1);
           
        }
        public override  async Task OnConnectedAsync(ConnectionContext connection)
        {
            
            _logger.LogInformation("new connection: " + connection.ConnectionId + ":" + connection.RemoteEndPoint.AddressFamily);
            var imei = String.Empty;

            while (true)
            {
                try
                {
                    await semaphore.WaitAsync().ConfigureAwait(false);
                    var result = await connection.Transport.Input.ReadAsync().ConfigureAwait(false);
                    var buffer = result.Buffer;
                    StringBuilder builder = new StringBuilder();
                    var receivedData = new List<byte []>();
                    foreach (var segment in buffer)
                    {
                        builder.Append(Encoding.ASCII.GetString(segment.ToArray(), 0 , segment.ToArray().Length));
                        receivedData.Add(segment.ToArray());
                    }
                    var data = builder.ToString();
                    data =  Regex.Replace(data, @"[^\w\.@-]", "", RegexOptions.None);
                    // if the data  received is a valid imei we send to modem 1
                    if (Commonhelper.IsValidImei(data))
                    {
                        byte[] b = {0x01};
                        _logger.LogInformation($"new modem connected with id : {data}");
                        imei = data;
                        var command = new CreateBoxCommand();
                        command.Imei = imei;
                        await _mediator.Send(command).ConfigureAwait(false);
                        await connection.Transport.Output.WriteAsync(b).ConfigureAwait(false);
                    }
                    // if the data received is avl data we parse the avl data and send to the modem the number of data received
                    else
                    {
                        var gpsResult = await ParseAvlDataAsync(imei, receivedData.FirstOrDefault()).ConfigureAwait(false);
                        var events = new TLGpsDataEvents
                        {
                            Id = Guid.NewGuid(),
                            Events = gpsResult
                        };
                        var bytes = Convert.ToByte(gpsResult.Count);
                        await connection.Transport.Output.WriteAsync(new byte[] { 0x00, 0x00, 0x00, bytes }).ConfigureAwait(false);
                        // _semaphore.WaitAsync();
                        _mediator.Publish(events).GetAwaiter();
                        
                    }
                    if (result.IsCompleted)
                    {
                        break;
                    }
                    semaphore.Release();
                    connection.Transport.Input.AdvanceTo(buffer.End);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    _logger.LogError(e.InnerException?.Message);
                    semaphore.Release();
                    break;
                }
            }

            Console.WriteLine(connection.ConnectionId + " disconnected");
        }
        private async Task<List<CreateTeltonikaGps>> ParseAvlDataAsync(string imei, byte[] buffer)
        {
            List<CreateTeltonikaGps> gpsResult = new List<CreateTeltonikaGps>();
            var parser = new DevicesParser(false);
            gpsResult.AddRange(parser.Decode(new List<byte>(buffer), imei));
            // await GeoReverseCodeGpsData(gpsResult);
            LogAvlData(gpsResult);
            return gpsResult;
        }
        private static void LogAvlData(List<CreateTeltonikaGps> gpsResult)
        {
            foreach (var gpsData in gpsResult.OrderBy(x => x.DateTimeUtc))
            {
                Console.WriteLine("Date:" + gpsData.DateTimeUtc + " Latitude: " + gpsData.Lat + " Longitude" +
                                  gpsData.Long + " Speed: " + gpsData.Speed + " Direction: " + gpsData.Direction);
                Console.WriteLine("--------------------------------------------");
                foreach (var io in gpsData.IoElements_1B)
                    Console.WriteLine("Propriété IO (1 byte) : " + (TNIoProperty)io.Key + " Valeur:" + io.Value);
                foreach (var io in gpsData.IoElements_2B)
                    Console.WriteLine("Propriété IO (2 byte) : " + (TNIoProperty)io.Key + " Valeur:" + io.Value);
                foreach (var io in gpsData.IoElements_4B)
                    Console.WriteLine("Propriété IO (4 byte) : " + (TNIoProperty)io.Key + " Valeur:" + io.Value);
                foreach (var io in gpsData.IoElements_8B)
                    Console.WriteLine("Propriété IO (8 byte) : " + (TNIoProperty)io.Key + " Valeur:" + io.Value);
                Console.WriteLine("--------------------------------------------");
            }
        }

    }
}
