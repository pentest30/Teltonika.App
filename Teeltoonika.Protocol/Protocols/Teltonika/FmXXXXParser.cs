using System;
using System.Collections.Generic;
using System.Linq;
using Teeltoonika.Protocol.Commands.Commands;

namespace Teeltoonika.Protocol.Protocols.Teltonika
{
    public class FmxxxxParser : IFMParserProtocol
    {

        public List<CreateTeltonikaGps> DecodeAvl(List<byte> receiveBytes, string imei)
        {
            receiveBytes.Skip(4).Take(4).ToList().ForEach(delegate(byte b)
            {
            });
            int numberOfData = Convert.ToInt32(receiveBytes.Skip(9).Take(1).ToList()[0]);
            
            var results = new List<CreateTeltonikaGps>();
            int tokenAddress = 10;
            for (int n = 0; n < numberOfData; n++)
            {
                CreateTeltonikaGps gpsData = new CreateTeltonikaGps();
                string hexTimeStamp = string.Empty;
                receiveBytes.Skip(tokenAddress).Take(8).ToList().ForEach(delegate(byte b)
                {
                    hexTimeStamp += String.Format("{0:X2}", b);
                });
                long timeSt = Convert.ToInt64(hexTimeStamp, 16);

                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime dateTime = origin.AddMilliseconds(Convert.ToDouble(timeSt));
                int priority = Convert.ToInt32(receiveBytes.Skip(tokenAddress + 8).Take(1).ToList()[0]);

                string longt = string.Empty;
                receiveBytes.Skip(tokenAddress + 9).Take(4).ToList().ForEach(delegate(byte b)
                {
                    longt += String.Format("{0:X2}", b);
                });
                double longtitude = ((double) Convert.ToInt32(longt, 16)) / 10000000;

                string lat = string.Empty;
                receiveBytes.Skip(tokenAddress + 13).Take(4).ToList().ForEach(delegate(byte b)
                {
                    lat += String.Format("{0:X2}", b);
                });
                double latitude = ((double) Convert.ToInt32(lat, 16)) / 10000000;

                string alt = string.Empty;
                receiveBytes.Skip(tokenAddress + 17).Take(2).ToList().ForEach(delegate(byte b)
                {
                    alt += String.Format("{0:X2}", b);
                });
                int altitude = Convert.ToInt32(alt, 16);

                string ang = string.Empty;
                receiveBytes.Skip(tokenAddress + 19).Take(2).ToList().ForEach(delegate(byte b)
                {
                    ang += String.Format("{0:X2}", b);
                });
                int angle = Convert.ToInt32(ang, 16);
                int satellites = Convert.ToInt32(receiveBytes.Skip(tokenAddress + 21).Take(1).ToList()[0]);

                string sp = string.Empty;
                receiveBytes.Skip(tokenAddress + 22).Take(2).ToList().ForEach(delegate(byte b)
                {
                    sp += String.Format("{0:X2}", b);
                });
                int speed = Convert.ToInt32(sp, 16);

                byte eventIoElementId =
                    (byte) Convert.ToInt32(receiveBytes.Skip(tokenAddress + 24).Take(1).ToList()[0]);
                gpsData.EventIoElementId = eventIoElementId;

                int ioElementInRecord = Convert.ToInt32(receiveBytes.Skip(tokenAddress + 25).Take(1).ToList()[0]);


                if (ioElementInRecord != 0)
                {
                    int currentCursor = tokenAddress + 26;

                    int ioElements_1BQuantity = Convert.ToInt32(receiveBytes.Skip(currentCursor).Take(1).ToList()[0]);


                    for (int io1 = 0; io1 < ioElements_1BQuantity; io1++)
                    {
                        var parameterId =
                            (byte) Convert.ToInt32(receiveBytes.Skip(currentCursor + 1 + io1 * 2).Take(1).ToList()[0]);
                        var ioElement_1B =
                            (byte) Convert.ToInt32(receiveBytes.Skip(currentCursor + 2 + io1 * 2).Take(1).ToList()[0]);
                        gpsData.IoElements_1B.Add(parameterId, ioElement_1B);
                    }
                    currentCursor += ioElements_1BQuantity * 2 + 1;

                    int ioElements_2BQuantity = Convert.ToInt32(receiveBytes.Skip(currentCursor).Take(1).ToList()[0]);

                    for (int io2 = 0; io2 < ioElements_2BQuantity; io2++)
                    {
                        var parameterId =
                            (byte) Convert.ToInt32(receiveBytes.Skip(currentCursor + 1 + io2 * 3).Take(1).ToList()[0]);
                        string value = string.Empty;
                        receiveBytes.Skip(currentCursor + 2 + io2 * 3).Take(2).ToList().ForEach(delegate(byte b)
                        {
                            value += String.Format("{0:X2}", b);
                        });
                        var ioElement_2B = Convert.ToInt16(value, 16);
                        gpsData.IoElements_2B.Add(parameterId, ioElement_2B);
                    }
                    currentCursor += ioElements_2BQuantity * 3 + 1;

                    int ioElements_4BQuantity = Convert.ToInt32(receiveBytes.Skip(currentCursor).Take(1).ToList()[0]);

                    for (int io4 = 0; io4 < ioElements_4BQuantity; io4++)
                    {
                        var parameterId =
                            (byte) Convert.ToInt32(receiveBytes.Skip(currentCursor + 1 + io4 * 5).Take(1).ToList()[0]);
                        string value = string.Empty;
                        receiveBytes.Skip(currentCursor + 2 + io4 * 5).Take(4).ToList().ForEach(delegate(byte b)
                        {
                            value += String.Format("{0:X2}", b);
                        });
                        var ioElement_4B = Convert.ToInt32(value, 16);
                        gpsData.IoElements_4B.Add(parameterId, ioElement_4B);
                    }
                    currentCursor += ioElements_4BQuantity * 5 + 1;

                    int ioElements_8BQuantity = Convert.ToInt32(receiveBytes.Skip(currentCursor).Take(1).ToList()[0]);

                    for (int io8 = 0; io8 < ioElements_8BQuantity; io8++)
                    {
                        var parameterId =
                            (byte) Convert.ToInt32(receiveBytes.Skip(currentCursor + 1 + io8 * 9).Take(1).ToList()[0]);
                        string value = string.Empty;
                        receiveBytes.Skip(currentCursor + 2 + io8 * 9).Take(8).ToList().ForEach(delegate(byte b)
                        {
                            value += String.Format("{0:X2}", b);
                        });
                        var ioElement_8B = Convert.ToInt64(value, 16);
                        gpsData.IoElements_8B.Add(parameterId, ioElement_8B);
                    }

                    tokenAddress += 30 + ioElements_1BQuantity * 2 +
                                    ioElements_2BQuantity * 3 + ioElements_4BQuantity * 5
                                    + ioElements_8BQuantity * 9;
                }
                else
                {
                    tokenAddress += 30;
                }

                //  Data dt = new Data();

                gpsData.Altitude = (short) altitude;
                gpsData.Direction = (short) angle;
                gpsData.Lat = latitude;
                gpsData.Long = longtitude;
                gpsData.Priority = (byte) priority;
                gpsData.Satellite = (byte) satellites;
                gpsData.Speed =speed;
                gpsData.DateTimeUtc = dateTime;
                gpsData.Imei = imei.Substring(0, 15);
                gpsData.DataEventIO = eventIoElementId;
                results.Add(gpsData);
                //  dt.SaveGPSPositionFMXXXX(gpsData);

            }
            //CRC for check of data correction and request again data from device if it not correct
            return results;
        }

        public int GetCRC16(byte[] buffer)
        {
            return GetCRC16(buffer, buffer.Length, 0xA001);
        }
        private int GetCRC16(byte[] buffer, int bufLen, int polynom)
        {
            polynom &= 0xFFFF;
            int crc = 0;
            for (int i = 0; i < bufLen; i++)
            {
                int data = buffer[i] & 0xFF;
                crc ^= data;
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc = (crc >> 1) ^ polynom;
                    }
                    else
                    {
                        crc = crc >> 1;
                    }
                }
            }
            return crc & 0xFFFF;
        }

        
    }
}
