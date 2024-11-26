using System;
using System.Collections.Generic;


namespace WebApplication2;

public class FANETNetwork
{
    public List<UAV> UAVs { get; set; } = new List<UAV>();

    // Kiểm tra kết nối giữa hai UAVs
    public bool CheckConnectivity(UAV uav1, UAV uav2)
    {
        double distance = Math.Sqrt(Math.Pow(uav1.X - uav2.X, 2) + Math.Pow(uav1.Y - uav2.Y, 2) + Math.Pow(uav1.Z - uav2.Z, 2));
        return distance < 1000; // Ví dụ: kết nối nếu khoảng cách < 1000m
    }

    // Mô phỏng kết nối mạng
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

