using System.Collections.Generic;
using Teeltoonika.Protocol.Commands.Commands;

namespace Teeltoonika.Protocol
{
    public interface IFMParserProtocol
    {
        List<CreateTeltonikaGps> DecodeAvl(List<byte> receiveBytes, string imei);
    }
}