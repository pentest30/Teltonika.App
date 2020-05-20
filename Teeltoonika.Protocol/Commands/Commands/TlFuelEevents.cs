using System;
using System.Collections.Generic;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TlFuelEevents:INotification
    {
        public Guid Id { get; set; }
        public List<TLFuelMilstoneEvent> Events { get; set; }
        public List<TLGpsDataEvent> TlGpsDataEvents { get; set; }

    }
}
