using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApplication2.Pages
{
    public class StrategyDetailsModel : PageModel
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

        private readonly IWebHostEnvironment _env;

        public StrategyDetailsModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public Strategy SelectedStrategy { get; private set; }
        private List<Strategy> Strategies { get; set; }

        // Đọc chiến lược từ JSON
        private List<Strategy> ReadStrategiesFromJson()
        {
            var filePath = Path.Combine(_env.WebRootPath, "data", "Strategies.json");
            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Strategy>>(jsonData);
            }
            return new List<Strategy>();
        }

        public IActionResult OnGet(int? strategyId)
        {
            // Đọc dữ liệu từ JSON
            Strategies = ReadStrategiesFromJson();

            // Validate the input parameter
            if (!strategyId.HasValue || strategyId.Value < 1 || strategyId.Value > Strategies.Count)
            {
                // Redirect to an error page or display a friendly message
                return RedirectToPage("/Error");
            }

            // Find the strategy using LINQ for clarity
            SelectedStrategy = Strategies.FirstOrDefault(s => s.Id == strategyId.Value);

            // If somehow the strategy was not found, redirect to an error page
            if (SelectedStrategy == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
