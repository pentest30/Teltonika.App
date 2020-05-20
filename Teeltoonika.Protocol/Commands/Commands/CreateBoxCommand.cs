using System;
using MediatR;

namespace Teeltoonika.Protocol.Commands.Commands
{
   public class CreateBoxCommand :IRequest
   {
        public string Imei { get; set; }
        public DateTime? LastValidGpsDataUtc { get; set; }
        public string Address { get; set; }
    }
}
