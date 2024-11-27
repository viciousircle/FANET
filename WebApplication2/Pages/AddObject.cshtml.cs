

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
//         public class UAV
//         {
//             public int Id { get; set; }
//             public float X { get; set; }
//             public float Y { get; set; }
//             public float Z { get; set; }
//         }

//         public class UAVsList
//         {
//             public List<UAV> UAVs { get; set; }
//         }

//         [BindProperty]
//         public IFormFile JsonFile { get; set; }

//         public List<UAV> UAVs { get; set; }

//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (JsonFile != null)
//             {
//                 using (var reader = new StreamReader(JsonFile.OpenReadStream()))
//                 {
//                     var json = await reader.ReadToEndAsync();
//                     try
//                     {
//                         var uavsList = JsonConvert.DeserializeObject<UAVsList>(json);
//                         if (uavsList?.UAVs != null)
//                         {
//                             UAVs = uavsList.UAVs;
//                             HttpContext.Session.SetString("UAVData", JsonConvert.SerializeObject(UAVs));

//                         }
//                         else
//                         {
//                             ModelState.AddModelError("", "Không có UAVs trong dữ liệu JSON.");
//                         }
//                     }
//                     catch (JsonException)
//                     {
//                         ModelState.AddModelError("", "Dữ liệu JSON không hợp lệ.");
//                     }
//                 }
//             }

//             return Page();
//         }

//         public void OnGet()
//         {
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

        [BindProperty]
        public IFormFile JsonFile { get; set; }

        public List<UAV> UAVs { get; set; }

        [BindProperty]
        public string GeoJsonData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (JsonFile == null)
            {
                ModelState.AddModelError("", "Please upload a valid JSON file.");
                return Page();
            }

            using (var reader = new StreamReader(JsonFile.OpenReadStream()))
            {
                var json = await reader.ReadToEndAsync();
                try
                {
                    UAVs = JsonConvert.DeserializeObject<List<UAV>>(json);
                    if (UAVs == null || UAVs.Count == 0)
                    {
                        ModelState.AddModelError("", "The JSON file does not contain UAV data.");
                        return Page();
                    }
                    HttpContext.Session.SetString("UAVData", JsonConvert.SerializeObject(UAVs));
                }
                catch (JsonException)
                {
                    ModelState.AddModelError("", "Invalid JSON format.");
                }
            }

            return Page();
        }

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
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData");
            return Page();
        }
    }
}
