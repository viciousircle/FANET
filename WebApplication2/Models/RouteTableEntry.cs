using System;

namespace WebApplication2.Models;

public class RouteTableEntry
{
    public int DestinationId { get; set; }
    public int NextHop { get; set; }
    public int HopCount { get; set; }
    public DateTime ExpiryTime { get; set; } // Thời gian hết hạn

    public RouteTableEntry(int destinationId, int nextHop, int hopCount, DateTime expiryTime)
    {
        DestinationId = destinationId;
        NextHop = nextHop;
        HopCount = hopCount;
        ExpiryTime = expiryTime;
    }
}
