

// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using System.IO;
// using System.Text.Json;
// using System.Threading.Tasks;

// namespace WebApplication2.Pages
// {
//     public class MapViewerModel : PageModel
//     {
//         [BindProperty]
//         public string GeoJsonData { get; set; }

//         public async Task<IActionResult> OnPostSaveGeoJsonAsync()
//         {
//             // Đọc dữ liệu GeoJSON từ request body
//             using (var reader = new StreamReader(Request.Body))
//             {
//                 var geoJsonData = await reader.ReadToEndAsync();

//                 // Lưu vào session
//                 HttpContext.Session.SetString("GeoJsonData", geoJsonData);

//                 return new JsonResult(new { success = true });
//             }
//         }

//         public IActionResult OnGet()
//         {
//             // Lấy dữ liệu GeoJSON từ session (nếu có)
//             GeoJsonData = HttpContext.Session.GetString("GeoJsonData");

//             return Page();
//         }
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class MapViewerModel : PageModel
    {
        [BindProperty]
        public string GeoJsonData { get; set; }

        public async Task<IActionResult> OnPostSaveGeoJsonAsync()
        {
            // Đọc dữ liệu GeoJSON từ request body
            using (var reader = new StreamReader(Request.Body))
            {
                var geoJsonData = await reader.ReadToEndAsync();

                // Lưu vào session
                HttpContext.Session.SetString("GeoJsonData", geoJsonData);

                return new JsonResult(new { success = true });
            }
        }

        public IActionResult OnGet()
        {
            // Lấy dữ liệu GeoJSON từ session (nếu có)
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData");

            return Page();
        }
    }
}
