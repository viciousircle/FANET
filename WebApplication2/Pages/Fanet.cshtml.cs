using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace WebApplication2.Pages
{
    public class FanetModel : PageModel
    {
        [BindProperty]
        public List<UAV> UAVs { get; set; }

        [BindProperty]
        public double CoverageArea { get; set; } = 100;  // Diện tích vùng phủ sóng mặc định
        [BindProperty]
        public double MaxDistance { get; set; } = 50;  // Khoảng cách tối đa giữa các UAV mặc định

        // Mỗi UAV trong FANET
        public FanetModel()
        {
            UAVs = new List<UAV>
            {
                new UAV(1, 10.0, 20.0, 100.0, 80, "Rescue"),
                new UAV(2, 15.0, 25.0, 100.0, 90, "Surveillance")
            };
        }

        public void OnGet()
        {
            // Hiển thị thông tin UAV hiện tại và mạng FANET
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Lấy giá trị từ Request.Form và đảm bảo rằng không có tham số null
                string missionType = Request.Form["MissionType"];
                if (string.IsNullOrEmpty(missionType))
                {
                    missionType = "Unknown";  // Giá trị mặc định nếu không có input
                }

                // Tạo UAV mới từ dữ liệu đã bind
                var newUav = new UAV(
                    id: Convert.ToInt32(Request.Form["Id"]),
                    x: Convert.ToDouble(Request.Form["X"]),
                    y: Convert.ToDouble(Request.Form["Y"]),
                    z: Convert.ToDouble(Request.Form["Z"]),
                    speed: Convert.ToDouble(Request.Form["Speed"]),
                    missionType: missionType
                );

                UAVs.Add(newUav);
            }

            return Page();  // Quay lại trang sau khi thêm UAV
        }
    }
}
