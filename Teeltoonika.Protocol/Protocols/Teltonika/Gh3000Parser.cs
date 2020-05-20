using System;
using System.Collections.Generic;
using Teeltoonika.Protocol.Commands.Commands;

namespace Teeltoonika.Protocol.Protocols.Teltonika
{
    public class Gh3000Parser : IFMParserProtocol
    {
        public Gh3000Parser()
        {
            

        }

        public List<CreateTeltonikaGps> DecodeAvl(List<byte> receiveBytes, string imei)
        {
            throw new NotImplementedException();
        }
    }
}