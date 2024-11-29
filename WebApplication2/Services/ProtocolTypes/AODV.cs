using System;
using WebApplication2.Models;

namespace WebApplication2.Services.ProtocolTypes;


public class AODVProtocol
{
    private Dictionary<int, UAV> network;

    public AODVProtocol(Dictionary<int, UAV> network)
    {
        this.network = network;
    }

    // Khởi tạo RREQ
    public void SendRREQ(int sourceId, int destinationId)
    {
        Packet rreq = new Packet(Packet.PacketType.RREQ, sourceId, destinationId, GetNextSequenceNumber(sourceId), 0);
        BroadcastPacket(sourceId, rreq);
    }

    // Xử lý RREQ tại UAV
    public void ProcessRREQ(int currentNodeId, Packet rreq)
    {
        UAV currentNode = network[currentNodeId];

        if (currentNodeId == rreq.DestinationId)
        {
            // Nếu là UAV đích, gửi RREP trở lại nguồn
            SendRREP(currentNodeId, rreq.SourceId, rreq.HopCount);
        }
        else
        {
            // Cập nhật bảng định tuyến
            currentNode.UpdateRoute(rreq.SourceId, rreq.SourceId, rreq.HopCount);
            // Phát tiếp RREQ
            rreq.HopCount++;
            BroadcastPacket(currentNodeId, rreq);
        }
    }

    // Gửi RREP
    private void SendRREP(int sourceId, int destinationId, int hopCount)
    {
        Packet rrep = new Packet(Packet.PacketType.RREP, sourceId, destinationId, GetNextSequenceNumber(sourceId), hopCount);
        UnicastPacket(destinationId, rrep);
    }

    // Phát gói tin trong mạng
    private void BroadcastPacket(int currentNodeId, Packet packet)
    {
        foreach (var neighbor in GetNeighbors(currentNodeId))
        {
            ProcessRREQ(neighbor, packet);
        }
    }

    private void UnicastPacket(int destinationId, Packet packet)
    {
        // Gửi gói tin đến UAV đích
        Console.WriteLine($"Unicast packet from {packet.SourceId} to {destinationId}");
    }

    private List<int> GetNeighbors(int nodeId)
    {
        // Tạm giả lập: Mọi UAV kết nối với mọi UAV khác
        return new List<int>(network.Keys);
    }

    private int GetNextSequenceNumber(int nodeId)
    {
        return new Random().Next(1, 1000);
    }

    public List<UAV> GetUAVs()
    {
        return network.Values.ToList(); // Convert dictionary to list for easy handling in Razor
    }

}