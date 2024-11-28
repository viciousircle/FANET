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
        // UAV and Strategy Classes
        public class UAV
        {
            public int Id { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
        }

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

        private readonly IWebHostEnvironment _env;

        public ChooseStrategiesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string OSMFilePath { get; set; }
        public List<UAV> UAVs { get; set; } = new List<UAV>();
        public string GeoJsonData { get; set; }
        public string OsmData { get; set; }
        public List<Strategy> Strategies { get; set; }

        // Constructor for initializing Strategies based on UAV count
        private void InitializeStrategies()
        {
            Strategies = new List<Strategy>
            {
                new Strategy
                {
                    Id = 1,
                    Name = "Centralized + AODV + Geographical + Handover",
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

        // Handle file upload and set session data
        public void OnPost(IFormFile osmFile)
        {
            if (osmFile != null && osmFile.Length > 0)
            {
                var filePath = Path.Combine(_env.WebRootPath, "uploads", osmFile.FileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Save the file to server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    osmFile.CopyTo(stream);
                }

                OSMFilePath = filePath;
                OsmData = System.IO.File.ReadAllText(filePath);
            }

            // Retrieve UAVs and GeoJSON data from session
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            // Initialize Strategies
            InitializeStrategies();
        }

        // Handle GET request
        public void OnGet()
        {
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            // Set default values if no file uploaded
            if (string.IsNullOrEmpty(OSMFilePath))
            {
                OSMFilePath = "No file found.";
                OsmData = string.Empty;
            }

            // Initialize Strategies
            InitializeStrategies();
        }
    }
}
