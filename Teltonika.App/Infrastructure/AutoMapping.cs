using AutoMapper;
using Teeltoonika.Protocol.Commands.Commands;
using Teltonika.App.Models;

namespace Teltonika.App.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateTeltonikaGps, TrackingVehicleViewModel>().ReverseMap();
            CreateMap<CreateTeltonikaGps, TLGpsDataEvent>();
            CreateMap<TLGpsDataEvent, TrackingVehicleViewModel>().ReverseMap();

        }
    }
}
