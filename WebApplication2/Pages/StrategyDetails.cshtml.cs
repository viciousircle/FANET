using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class StrategyDetailsModel : PageModel
    {
        public string SelectedStrategy { get; set; }
        public string StrategyDescription { get; set; }

        public void OnGet(int? strategyId)
        {
            if (!strategyId.HasValue)
            {
                SelectedStrategy = "Chiến lược không hợp lệ.";
                StrategyDescription = "Không có mô tả chiến lược nào được tìm thấy.";
                return;
            }

            // Retrieve strategy details
            switch (strategyId.Value)
            {
                case 1:
                    SelectedStrategy = "Option 1: Thuật toán 1";
                    StrategyDescription = "Sử dụng UAV với thuật toán định tuyến tối ưu cho tình huống khẩn cấp...";
                    break;
                case 2:
                    SelectedStrategy = "Option 2: Thuật toán 2";
                    StrategyDescription = "Sử dụng mạng cảm biến để thu thập dữ liệu...";
                    break;
                case 3:
                    SelectedStrategy = "Option 3: Thuật toán 3";
                    StrategyDescription = "Sử dụng mô hình học máy để tối ưu hóa chiến lược bao phủ...";
                    break;
                default:
                    SelectedStrategy = "Chiến lược không hợp lệ.";
                    StrategyDescription = "Không có mô tả chiến lược nào được tìm thấy.";
                    break;
            }
        }
    }
}
