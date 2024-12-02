using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Services.ProtocolTypes
{
    public class AODVProtocol
    {
        private Dictionary<int, UAV> network;

        // public AODVProtocol(Dictionary<int, UAV> network)
        // {
        //     this.network = network;
        // }

        // // Khởi tạo RREQ
        // public void SendRREQ(int sourceId, int destinationId)
        // {
        //     Packet rreq = new Packet(Packet.PacketType.RREQ, sourceId, destinationId, GetNextSequenceNumber(sourceId), 0);
        //     BroadcastPacket(sourceId, rreq);
        // }

        // Xử lý RREQ tại UAV
        // public void ProcessRREQ(int currentNodeId, Packet rreq)
        // {
        //     UAV currentNode = network[currentNodeId];

        //     if (currentNodeId == rreq.DestinationId)
        //     {
        //         SendRREP(currentNodeId, rreq.SourceId, rreq.HopCount);
        //     }
        //     else
        //     {
        //         currentNode.UpdateRoute(rreq.SourceId.ToString(), new RouteEntry(rreq.SourceId.ToString(), rreq.HopCount, rreq.SequenceNumber, DateTime.Now.AddMinutes(5)));

        //         rreq.HopCount++;
        //         BroadcastPacket(currentNodeId, rreq);
        //     }
        // }

        private void SendRREP(int sourceId, int destinationId, int hopCount)
        {
            Packet rrep = new Packet(Packet.PacketType.RREP, sourceId, destinationId, GetNextSequenceNumber(sourceId), hopCount);
            UnicastPacket(destinationId, rrep);
        }

        // private void BroadcastPacket(int currentNodeId, Packet packet)
        // {
        //     foreach (var neighbor in GetNeighbors(currentNodeId))
        //     {
        //         if (!neighbor.HasReceivedPacket(packet))
        //         {
        //             neighbor.MarkPacketAsProcessed(packet);
        //             ProcessRREQ(neighbor.UAVId, packet);
        //         }
        //     }
        // }

        private void UnicastPacket(int destinationId, Packet packet)
        {
            Console.WriteLine($"Unicast packet from {packet.SourceId} to {destinationId}");
        }

        private List<UAV> GetNeighbors(int nodeId)
        {
            return network.Values.Where(uav => uav.UAVId != nodeId.ToString()).ToList();
        }

        private int GetNextSequenceNumber(int nodeId)
        {
            return new Random().Next(1, 1000);
        }

        public List<UAV> GetUAVs()
        {
            return network.Values.ToList();
        }
    }
}
