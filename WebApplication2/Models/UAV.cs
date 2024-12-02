using System;
// using WebApplication2.Models;

namespace WebApplication2.Models;

public class UAV
{
    // Thông số cơ bản của UAV
    public string UAVId { get; set; }
    public (double X, double Y, double Z) Position { get; set; }  // Vị trí trong không gian 3D
    public double Speed { get; set; }  // Tốc độ
    public double Direction { get; set; }  // Hướng di chuyển (Đơn vị: độ)
    public double CommunicationRange { get; set; }  // Phạm vi liên lạc
    public double EnergyLevel { get; set; }  // Mức năng lượng

    // Thông số định tuyến
    public Dictionary<string, RouteEntry> RoutingTable { get; set; }  // Bảng định tuyến

    // Thông số chuyển giao
    public double RSSIThreshold { get; set; }  // Ngưỡng tín hiệu
    public List<UAV> NeighborUAVs { get; set; }  // Danh sách UAV lân cận
    public double HandoverDelay { get; set; }  // Thời gian chuyển giao

    // Thông số điều khiển
    public ControlType ControlType { get; set; }  // Loại điều khiển
    public bool IsLeader { get; set; }  // Có phải UAV leader không
    public List<UAV> CandidatesForLeader { get; set; }  // Danh sách các UAV ứng viên cho leader

    // Thông số nhiệm vụ
    public string MissionType { get; set; }  // Loại nhiệm vụ
    public double PayloadWeight { get; set; }  // Trọng tải của UAV
    public int MissionPriority { get; set; }  // Mức độ ưu tiên của nhiệm vụ

    public UAV(string uavId)
    {
        UAVId = uavId;
        RoutingTable = new Dictionary<string, RouteEntry>();
        NeighborUAVs = new List<UAV>();
        CandidatesForLeader = new List<UAV>();
    }

    // Các phương thức cần thiết
    public void UpdatePosition(double x, double y, double z)
    {
        Position = (x, y, z);
    }

    public void AddRoute(string destination, RouteEntry routeEntry)
    {
        RoutingTable[destination] = routeEntry;
    }

    public void AddNeighbor(UAV uav)
    {
        NeighborUAVs.Add(uav);
    }

    public void SetLeaderStatus(bool status)
    {
        IsLeader = status;
    }

    // Method to update an existing route
    public void UpdateRoute(string destination, RouteEntry newRouteEntry)
    {
        if (RoutingTable.ContainsKey(destination))
        {
            RoutingTable[destination] = newRouteEntry;  // Update existing route
        }
        else
        {
            RoutingTable.Add(destination, newRouteEntry);  // Add new route if it doesn't exist
        }
    }
}


public class RouteEntry
{
    public string Destination { get; set; }
    public int HopCount { get; set; }
    public double SequenceNumber { get; set; }
    public DateTime ExpirationTime { get; set; }  // Thời gian tồn tại đường dẫn

    public RouteEntry(string destination, int hopCount, double sequenceNumber, DateTime expirationTime)
    {
        Destination = destination;
        HopCount = hopCount;
        SequenceNumber = sequenceNumber;
        ExpirationTime = expirationTime;
    }
}

public enum ControlType
{
    Centralized,
    Distributed
}