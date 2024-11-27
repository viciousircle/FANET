using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication2.Pages
{
    public class StrategyDetailsModel : PageModel
    {
        public Strategy SelectedStrategy { get; set; }

        private readonly List<Strategy> Strategies = new List<Strategy>
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
            if (!strategyId.HasValue || strategyId.Value < 1 || strategyId.Value > Strategies.Count)
            {
                return RedirectToPage("/Error"); // Redirect to an error page for invalid IDs
            }

            SelectedStrategy = Strategies.Find(s => s.Id == strategyId.Value);

            return Page();
        }
    }
}
