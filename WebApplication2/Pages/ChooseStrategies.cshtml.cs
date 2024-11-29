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
        public List<Strategy> Strategies { get; set; } = new List<Strategy>();

        // Đọc dữ liệu từ JSON
        private List<T> ReadDataFromJson<T>(string fileName)
        {
            var filePath = Path.Combine(_env.WebRootPath, "data", fileName);
            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
            return new List<T>();
        }

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

            // Đọc dữ liệu UAV từ JSON
            UAVs = ReadDataFromJson<UAV>("UAVData.json");

            // Đọc dữ liệu chiến lược từ JSON
            Strategies = ReadDataFromJson<Strategy>("Strategies.json");

            // Retrieve GeoJSON data from session
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;
        }

        public void OnGet()
        {
            // Đọc UAVs và Strategies từ JSON
            UAVs = ReadDataFromJson<UAV>("UAVData.json");
            Strategies = ReadDataFromJson<Strategy>("Strategies.json");

            // Retrieve GeoJSON data from session
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData") ?? string.Empty;

            // Set default values if no file uploaded
            if (string.IsNullOrEmpty(OSMFilePath))
            {
                OSMFilePath = "No file found.";
                OsmData = string.Empty;
            }
        }
    }
}
