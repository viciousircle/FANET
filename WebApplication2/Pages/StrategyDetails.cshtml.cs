using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Pages
{
    public class StrategyDetailsModel : PageModel
    {
        public Strategy SelectedStrategy { get; private set; }

        private static readonly List<Strategy> Strategies = new List<Strategy>
        {
            new Strategy
            {
                Id = 1,
                Name = "Thuật toán 1",
                Description = "Sử dụng UAV với thuật toán định tuyến tối ưu cho tình huống khẩn cấp...",
                UAVCount = 13,
                MaxDuration = "2 giờ",
                MaxRange = "10km",
                TransmissionSpeed = "50Mbps"
            },
            new Strategy
            {
                Id = 2,
                Name = "Thuật toán 2",
                Description = "Sử dụng mạng cảm biến để thu thập dữ liệu...",
                UAVCount = 10,
                MaxDuration = "1.5 giờ",
                MaxRange = "8km",
                TransmissionSpeed = "40Mbps"
            },
            new Strategy
            {
                Id = 3,
                Name = "Thuật toán 3",
                Description = "Sử dụng mô hình học máy để tối ưu hóa chiến lược bao phủ...",
                UAVCount = 15,
                MaxDuration = "2.5 giờ",
                MaxRange = "12km",
                TransmissionSpeed = "60Mbps"
            }
        };

        public IActionResult OnGet(int? strategyId)
        {
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
