// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Newtonsoft.Json;
// using System.Collections.Generic;
// using System.IO;
// using System.Threading.Tasks;


// namespace WebApplication2.Pages
// {
//     public class AddObjectModel : PageModel
//     {
//         // Lớp UAV đại diện cho mỗi UAV
//         public class UAV
//         {
//             public int Id { get; set; }
//             public float X { get; set; }
//             public float Y { get; set; }
//             public float Z { get; set; }
//         }

//         // Lớp chứa danh sách UAVs
//         public class UAVsList
//         {
//             public List<UAV> UAVs { get; set; }
//         }

//         // Biến chứa tệp JSON được tải lên
//         [BindProperty]
//         public IFormFile JsonFile { get; set; }

//         // Danh sách UAVs sau khi tải tệp lên
//         public List<UAV> UAVs { get; set; }

//         // Phương thức xử lý khi gửi POST
//         public async Task<IActionResult> OnPostAsync()
//         {
//             // Kiểm tra nếu có tệp được tải lên
//             if (JsonFile != null)
//             {
//                 using (var reader = new StreamReader(JsonFile.OpenReadStream()))
//                 {
//                     var json = await reader.ReadToEndAsync();
//                     try
//                     {
//                         // Deserialize JSON thành đối tượng UAVsList
//                         var uavsList = JsonConvert.DeserializeObject<UAVsList>(json);
//                         if (uavsList?.UAVs != null)
//                         {
//                             // Nếu có dữ liệu UAV, gán vào danh sách UAVs
//                             UAVs = uavsList.UAVs;
//                         }
//                         else
//                         {
//                             // Thêm lỗi nếu không có UAVs trong dữ liệu
//                             ModelState.AddModelError("", "Không có UAVs trong dữ liệu JSON.");
//                         }
//                     }
//                     catch (JsonException)
//                     {
//                         // Thêm lỗi nếu tệp JSON không hợp lệ
//                         ModelState.AddModelError("", "Dữ liệu JSON không hợp lệ.");
//                     }
//                 }
//             }

//             // Trả về trang hiện tại sau khi xử lý
//             return Page();
//         }

//         // Phương thức xử lý khi gửi GET
//         public void OnGet()
//         {
//             // Không làm gì trong phương thức này, chỉ cần hiển thị trang mặc định
//         }
//     }
// }

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class AddObjectModel : PageModel
    {
        public class UAV
        {
            public int Id { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
        }

        public class UAVsList
        {
            public List<UAV> UAVs { get; set; }
        }

        [BindProperty]
        public IFormFile JsonFile { get; set; }

        public List<UAV> UAVs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (JsonFile != null)
            {
                using (var reader = new StreamReader(JsonFile.OpenReadStream()))
                {
                    var json = await reader.ReadToEndAsync();
                    try
                    {
                        var uavsList = JsonConvert.DeserializeObject<UAVsList>(json);
                        if (uavsList?.UAVs != null)
                        {
                            UAVs = uavsList.UAVs;
                            HttpContext.Session.SetString("UAVData", JsonConvert.SerializeObject(UAVs));

                        }
                        else
                        {
                            ModelState.AddModelError("", "Không có UAVs trong dữ liệu JSON.");
                        }
                    }
                    catch (JsonException)
                    {
                        ModelState.AddModelError("", "Dữ liệu JSON không hợp lệ.");
                    }
                }
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
