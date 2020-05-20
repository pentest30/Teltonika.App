using System.Collections.Generic;
using MediatR;
using Teltonika.Core;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TLGpsDataEvents : SLCommand, INotification
    {
        public List<CreateTeltonikaGps> Events { get; set; }
    }
}
