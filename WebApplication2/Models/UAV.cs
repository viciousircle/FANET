using System;
// using WebApplication2.Models;

namespace WebApplication2.Models;

public class UAV
{
    public int Id { get; set; }
    public double[] Position { get; set; } // [x, y, z]
    public double Energy { get; set; }
    public List<int> Neighbors { get; set; }
    public double CoverageRadius { get; set; }
    public double Speed { get; set; }
    public Dictionary<int, RouteTableEntry> RoutingTable { get; private set; }

    public UAV(int id, double energy, double[] position, double coverageRadius, double speed)
    {
        Id = id;
        Energy = energy;
        Position = position;
        CoverageRadius = coverageRadius;
        Speed = speed;
        Neighbors = new List<int>();
        RoutingTable = new Dictionary<int, RouteTableEntry>();
    }

    public void UpdateRoute(int destinationId, int nextHop, int hopCount)
    {
        if (!RoutingTable.ContainsKey(destinationId) || RoutingTable[destinationId].HopCount > hopCount)
        {
            RoutingTable[destinationId] = new RouteTableEntry(destinationId, nextHop, hopCount, DateTime.Now.AddMinutes(5));
        }
    }

    public string ToJson()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
}
