using System;
using System.Collections.Generic;
using System.Text;

namespace Teeltoonika.Protocol.Commands.Commands
{
    public class TlDriverCardEvent
    {
        public string CardNumber { get; set; }
        public Guid? VehicleId { get; set; }
    }
}
