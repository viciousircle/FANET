using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2;
public class FanetModel
{
    public List<UAV> UAVs { get; set; } = new List<UAV>();
    public double CoverageArea { get; set; }  // Diện tích vùng phủ sóng của FANET
    public double MaxDistance { get; set; }   // Khoảng cách tối đa giữa các UAV trong FANET

    // Kiểm tra kết nối giữa hai UAV
    public bool CheckConnectivity(UAV uav1, UAV uav2)
    {
        double distance = Math.Sqrt(Math.Pow(uav1.X - uav2.X, 2) + Math.Pow(uav1.Y - uav2.Y, 2) + Math.Pow(uav1.Z - uav2.Z, 2));
        return distance <= MaxDistance;
    }

    // Mô phỏng kết nối mạng giữa các UAV
    public void SimulateNetwork()
    {
        foreach (var uav1 in UAVs)
        {
            foreach (var uav2 in UAVs)
            {
                if (uav1.Id != uav2.Id && CheckConnectivity(uav1, uav2))
                {
                    Console.WriteLine($"UAV {uav1.Id} có thể kết nối với UAV {uav2.Id}");
                }
            }
        }
    }
}