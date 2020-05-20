using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Teeltoonika.Protocol.Commands.Commands;
using Teltonika.App.Models;

namespace Teltonika.App.Hubs
{
    public class ApplicationHub : Hub, INotificationHandler<TLGpsDataEvents>
    {
        private readonly IMapper _mapper;

        public ApplicationHub(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task Handle(TLGpsDataEvents notification, CancellationToken cancellationToken)
        {
            var lastEvent = notification.Events.OrderBy(x => x.DateTimeUtc).LastOrDefault(); 
            var @event = _mapper.Map<TrackingVehicleViewModel>(lastEvent);
             return SignalRHubManager.Clients.Client(SignalRHubManager.ConnectionId).SendAsync("trackingVehicle",@event , cancellationToken: cancellationToken);

        }
        public override Task OnConnectedAsync()
        {
            SignalRHubManager.ConnectionId = Context.ConnectionId;
            SignalRHubManager.Clients = Clients;
            return base.OnConnectedAsync();
        }
    }
}
