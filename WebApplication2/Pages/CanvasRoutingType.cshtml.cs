using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class CanvasRoutingTypeModel : PageModel
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

        public void OnGet()
        {
            InitializeUAVs();
        }

        public void OnPost()
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
                    Altitude = new Random().NextDouble() * 100  // Random altitude
                });
            }
        }

        public class UAV
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Speed { get; set; }
            public double Radius { get; set; }
            public double Altitude { get; set; }
        }
    }
}
