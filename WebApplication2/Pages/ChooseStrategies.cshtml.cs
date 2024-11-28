using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebApplication2.Pages
{
    public class ChooseStrategiesModel : PageModel
    {
        public class UAV
        {
            public int Id { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
        }

        public class UAVsList
        {
            public List<UAV> UAVs { get; set; }
        }
        private readonly IWebHostEnvironment _env;

        public ChooseStrategiesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string OSMFilePath { get; set; }
        public List<UAV> UAVs { get; set; } = new List<UAV>();
        public string GeoJsonData { get; set; }
        public string OsmData { get; set; } // For storing raw OSM data
        public List<Strategy> Strategies { get; set; }

        // Handle file upload
        public void OnPost(IFormFile osmFile)
        {
            if (osmFile != null && osmFile.Length > 0)
            {
                var filePath = Path.Combine(_env.WebRootPath, "uploads", osmFile.FileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    osmFile.CopyTo(stream);
                }

                OSMFilePath = filePath;
                OsmData = System.IO.File.ReadAllText(filePath);
            }

            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            Strategies = new List<Strategy>
        {
            new Strategy
            {
                Id = 1,
                Name = "Thuật toán 1",
                Description = "Sử dụng UAV với thuật toán định tuyến tối ưu...",
                UAVCount = UAVs.Count,
                MaxDuration = "5 giờ",
                MaxRange = "10km",
                TransmissionSpeed = "50Mbps"
            },
            new Strategy
            {
                Id = 2,
                Name = "Thuật toán 2",
                Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
                UAVCount = UAVs.Count,
                MaxDuration = "1.5 giờ",
                MaxRange = "8km",
                TransmissionSpeed = "40Mbps"
            },
            new Strategy
            {
                Id = 3,
                Name = "Thuật toán 3",
                Description = "Sử dụng mô hình học máy để tối ưu hóa...",
                UAVCount = UAVs.Count,
                MaxDuration = "2.5 giờ",
                MaxRange = "12km",
                TransmissionSpeed = "60Mbps"
            }
        };
        }

        public void OnGet()
        {
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            if (string.IsNullOrEmpty(OSMFilePath))
            {
                OSMFilePath = "No file found.";
                OsmData = string.Empty;
            }

            Strategies = new List<Strategy>
        {
            new Strategy
            {
                Id = 1,
                Name = "Thuật toán 1",
                Description = "Sử dụng UAV với thuật toán định tuyến tối ưu...",
                UAVCount = UAVs.Count,
                MaxDuration = "5 giờ",
                MaxRange = "10km",
                TransmissionSpeed = "50Mbps"
            },
            new Strategy
            {
                Id = 2,
                Name = "Thuật toán 2",
                Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
                UAVCount = UAVs.Count,
                MaxDuration = "1.5 giờ",
                MaxRange = "8km",
                TransmissionSpeed = "40Mbps"
            },
            new Strategy
            {
                Id = 3,
                Name = "Thuật toán 3",
                Description = "Sử dụng mô hình học máy để tối ưu hóa...",
                UAVCount = UAVs.Count,
                MaxDuration = "2.5 giờ",
                MaxRange = "12km",
                TransmissionSpeed = "60Mbps"
            }
        };
        }
    }

}