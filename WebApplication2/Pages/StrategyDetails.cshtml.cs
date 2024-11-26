using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class StrategyDetailsModel : PageModel
    {
        public string SelectedStrategy { get; set; }
        public string StrategyDescription { get; set; }
        public int StrategyId { get; set; }

        public void OnGet(int strategyId)
        {
            // Lấy thông tin chi tiết chiến lược từ session hoặc database
            switch (strategyId)
            {
                case 1:
                    SelectedStrategy = "Option 1: Thuật toán 1";
                    StrategyDescription = "Sử dụng UAV với thuật toán định tuyến tối ưu cho tình huống khẩn cấp. Ưu điểm: Tốc độ nhanh, phạm vi rộng, xử lý tình huống linh hoạt. Nhược điểm: Cần nhiều UAV, yêu cầu phần cứng mạnh mẽ.";
                    break;
                case 2:
                    SelectedStrategy = "Option 2: Thuật toán 2";
                    StrategyDescription = "Sử dụng mạng cảm biến để thu thập dữ liệu và phân tích theo thời gian thực. Ưu điểm: Chính xác, dễ triển khai trong các khu vực hẹp. Nhược điểm: Phụ thuộc vào mạng cảm biến, chi phí triển khai cao.";
                    break;
                case 3:
                    SelectedStrategy = "Option 3: Thuật toán 3";
                    StrategyDescription = "Sử dụng mô hình học máy để tối ưu hóa chiến lược bao phủ. Ưu điểm: Tự động hóa quá trình ra quyết định, giảm thiểu sai sót con người. Nhược điểm: Cần dữ liệu đào tạo lớn, chi phí tính toán cao.";
                    break;
                default:
                    SelectedStrategy = "Chiến lược không hợp lệ.";
                    StrategyDescription = "Không có mô tả chiến lược nào được tìm thấy.";
                    break;
            }
        }
    }
}
