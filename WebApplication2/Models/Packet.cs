using System;

namespace WebApplication2.Models;

public class Packet
{
    public enum PacketType { RREQ, RREP, Hello }
    public PacketType Type { get; set; }
    public int SourceId { get; set; }
    public int DestinationId { get; set; }
    public int SequenceNumber { get; set; }
    public int HopCount { get; set; }

    public Packet(PacketType type, int sourceId, int destinationId, int sequenceNumber, int hopCount)
    {
        Type = type;
        SourceId = sourceId;
        DestinationId = destinationId;
        SequenceNumber = sequenceNumber;
        HopCount = hopCount;
    }
}
