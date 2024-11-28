using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebApplication2.Pages
{
    public class ChooseStrategiesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ChooseStrategiesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string OSMFilePath { get; set; }
        public List<UAV> UAVs { get; set; } = new List<UAV>();
        public string GeoJsonData { get; set; }
        public string OsmData { get; set; } // For storing raw OSM data
=======
using System.Collections.Generic;

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

    public class ChooseStrategiesModel : PageModel
    {
>>>>>>> parent of e38838a (Trans parameter to step 2)
        public List<Strategy> Strategies { get; set; }

        // Handle file upload
        public void OnPost(IFormFile osmFile)
        {
<<<<<<< HEAD
            if (osmFile != null && osmFile.Length > 0)
            {
                // Path to save the uploaded file
                var filePath = Path.Combine(_env.WebRootPath, "uploads", osmFile.FileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    osmFile.CopyTo(stream);
                }

                // Save the OSM file path and read the content
                OSMFilePath = filePath;
                OsmData = System.IO.File.ReadAllText(filePath);
            }

            // Reload UAVs and GeoJSON data
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            // Define strategies
=======
>>>>>>> parent of e38838a (Trans parameter to step 2)
            Strategies = new List<Strategy>
            {
                new Strategy
                {
                    Id = 1,
                    Name = "Thuật toán 1",
                    Description = "Sử dụng UAV với thuật toán định tuyến tối ưu...",
<<<<<<< HEAD
                    UAVCount = UAVs.Count,
=======
                    UAVCount = 13,
>>>>>>> parent of e38838a (Trans parameter to step 2)
                    MaxDuration = "5 giờ",
                    MaxRange = "10km",
                    TransmissionSpeed = "50Mbps"
                },
                new Strategy
                {
                    Id = 2,
                    Name = "Thuật toán 2",
                    Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
<<<<<<< HEAD
                    UAVCount = UAVs.Count,
=======
                    UAVCount = 10,
>>>>>>> parent of e38838a (Trans parameter to step 2)
                    MaxDuration = "1.5 giờ",
                    MaxRange = "8km",
                    TransmissionSpeed = "40Mbps"
                },
                new Strategy
                {
                    Id = 3,
                    Name = "Thuật toán 3",
                    Description = "Sử dụng mô hình học máy để tối ưu hóa...",
<<<<<<< HEAD
                    UAVCount = UAVs.Count,
=======
                    UAVCount = 15,
>>>>>>> parent of e38838a (Trans parameter to step 2)
                    MaxDuration = "2.5 giờ",
                    MaxRange = "12km",
                    TransmissionSpeed = "60Mbps"
                }
            };
        }

        // Load data when the page is accessed (GET)
        public void OnGet()
        {
            // Retrieve UAV data and GeoJSON data from session
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            // Handle previously uploaded OSM data
            if (string.IsNullOrEmpty(OSMFilePath))
            {
                OSMFilePath = "No file found.";
                OsmData = string.Empty;
            }

            // You can also load strategies if needed
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
    }
}
