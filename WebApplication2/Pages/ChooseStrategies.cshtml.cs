using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApplication2.Pages
{
    public class Strategy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UAVCount { get; set; }
        public string MaxDuration { get; set; }
        public string MaxRange { get; set; }
        public string TransmissionSpeed { get; set; }
    }

    // public class ChooseStrategiesModel : PageModel
    // {
    //     public List<Strategy> Strategies { get; set; }

    //     public void OnGet()
    //     {
    //         Strategies = new List<Strategy>
    //         {
    //             new Strategy
    //             {
    //                 Id = 1,
    //                 Name = "Thuật toán 1",
    //                 Description = "Sử dụng UAV với thuật toán định tuyến tối ưu...",
    //                 UAVCount = 13,
    //                 MaxDuration = "5 giờ",
    //                 MaxRange = "10km",
    //                 TransmissionSpeed = "50Mbps"
    //             },
    //             new Strategy
    //             {
    //                 Id = 2,
    //                 Name = "Thuật toán 2",
    //                 Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
    //                 UAVCount = 10,
    //                 MaxDuration = "1.5 giờ",
    //                 MaxRange = "8km",
    //                 TransmissionSpeed = "40Mbps"
    //             },
    //             new Strategy
    //             {
    //                 Id = 3,
    //                 Name = "Thuật toán 3",
    //                 Description = "Sử dụng mô hình học máy để tối ưu hóa...",
    //                 UAVCount = 15,
    //                 MaxDuration = "2.5 giờ",
    //                 MaxRange = "12km",
    //                 TransmissionSpeed = "60Mbps"
    //             }
    //         };
    //     }
    // }

    public class ChooseStrategiesModel : PageModel
    {
        public List<UAV> UAVs { get; set; }
        public string GeoJsonData { get; set; }
        public string OsmData { get; set; } // For storing raw OSM data
        public List<Strategy> Strategies { get; set; }

        public void OnGet()
        {
            // Retrieve UAV data and GeoJSON data from session
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;  // Use an empty string if null
            OsmData = HttpContext.Session.GetString("OsmData") ?? string.Empty;  // Use an empty string if null


            // Add strategies (you can keep your existing logic here for strategies)
            Strategies = new List<Strategy>
            {
                new Strategy
                {
                    Id = 1,
                    Name = "Thuật toán 1",
                    Description = "Sử dụng UAV với thuật toán định tuyến tối ưu...",
                    UAVCount = UAVs.Count,  // Display number of UAVs uploaded
                    MaxDuration = "5 giờ",
                    MaxRange = "10km",
                    TransmissionSpeed = "50Mbps"
                },
                new Strategy
                {
                    Id = 2,
                    Name = "Thuật toán 2",
                    Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
                    UAVCount = UAVs.Count,  // Display number of UAVs uploaded
                    MaxDuration = "1.5 giờ",
                    MaxRange = "8km",
                    TransmissionSpeed = "40Mbps"
                },
                new Strategy
                {
                    Id = 3,
                    Name = "Thuật toán 3",
                    Description = "Sử dụng mô hình học máy để tối ưu hóa...",
                    UAVCount = UAVs.Count,  // Display number of UAVs uploaded
                    MaxDuration = "2.5 giờ",
                    MaxRange = "12km",
                    TransmissionSpeed = "60Mbps"
                }
            };
        }
    }
}
