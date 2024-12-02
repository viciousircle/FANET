using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication2.Pages
{
    public class CanvasControlTypeModel : PageModel
    {
        [BindProperty]
        public int NumUAVs { get; set; } = 5;

        [BindProperty]
        public double UAVSpeed { get; set; } = 2;

        [BindProperty]
        public double CommunicationRadius { get; set; } = 80;

        [BindProperty]
        public double PacketLossChance { get; set; } = 5;

        public List<UAV> UAVs { get; set; } = new List<UAV>();

        public IActionResult OnPostUpdateConfig([FromBody] UAVConfig config)
        {
            // Update properties based on the received config
            NumUAVs = config.NumUAVs;
            UAVSpeed = config.Speed;
            CommunicationRadius = config.Radius;
            PacketLossChance = config.PacketLoss;

            // Re-initialize UAVs with the new configuration
            InitializeUAVs();

            // Return updated UAVs as JSON
            return new JsonResult(new { UAVs = UAVs });
        }

        public void OnGet()
        {
            InitializeUAVs();
        }

        private void InitializeUAVs()
        {
            UAVs = new List<UAV>();
            for (int i = 0; i < NumUAVs; i++)
            {
                UAVs.Add(new UAV
                {
                    X = new Random().NextDouble() * 800,  // Random x-coordinate
                    Y = new Random().NextDouble() * 600,  // Random y-coordinate
                    Speed = UAVSpeed,
                    Radius = CommunicationRadius,
                    Altitude = new Random().NextDouble() * 100,  // Random altitude
                    ID = i + 1  // Adding an ID for each UAV
                });
            }
        }

        public class UAVConfig
        {
            public int NumUAVs { get; set; }
            public double Speed { get; set; }
            public double Radius { get; set; }
            public double PacketLoss { get; set; }
        }

        public class UAV
        {
            public int ID { get; set; }  // Unique identifier for each UAV
            public double X { get; set; }
            public double Y { get; set; }
            public double Speed { get; set; }
            public double Radius { get; set; }
            public double Altitude { get; set; }
        }
    }
}
