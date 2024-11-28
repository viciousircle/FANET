using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class AddObjectModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public AddObjectModel(IWebHostEnvironment env)
        {
            _env = env;
        }

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
        public bool UploadSuccess { get; set; }

        public IActionResult OnGet()
        {
            UAVs = HttpContext.Session.GetString("UAVData") != null
                ? JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData"))
                : new List<UAV>();

            return Page();
        }

        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (JsonFile == null || JsonFile.Length == 0)
        //     {
        //         ModelState.AddModelError("", "Please upload a valid JSON file.");
        //         return Page();
        //     }

        //     using (var reader = new StreamReader(JsonFile.OpenReadStream()))
        //     {
        //         var json = await reader.ReadToEndAsync();
        //         try
        //         {
        //             var uavsList = JsonConvert.DeserializeObject<UAVsList>(json);
        //             if (uavsList?.UAVs == null || uavsList.UAVs.Count == 0)
        //             {
        //                 ModelState.AddModelError("", "The JSON file does not contain UAV data.");
        //                 return Page();
        //             }
        //             UAVs = uavsList.UAVs;
        //             HttpContext.Session.SetString("UAVData", JsonConvert.SerializeObject(UAVs));
        //         }
        //         catch (JsonException)
        //         {
        //             ModelState.AddModelError("", "Invalid JSON format.");
        //         }
        //     }

        //     return Page();
        // }


        public async Task<IActionResult> OnPostAsync()
        {
            if (JsonFile == null || JsonFile.Length == 0)
            {
                ModelState.AddModelError("", "Please upload a valid JSON file.");
                return Page();
            }

            using (var reader = new StreamReader(JsonFile.OpenReadStream()))
            {
                try
                {
                    var json = await reader.ReadToEndAsync();
                    UAVs = JsonConvert.DeserializeObject<List<UAV>>(json);

                    if (UAVs == null || UAVs.Count == 0)
                    {
                        ModelState.AddModelError("", "The JSON file does not contain valid UAV data.");
                        return Page();
                    }

                    HttpContext.Session.SetString("UAVData", JsonConvert.SerializeObject(UAVs));
                }
                catch
                {
                    ModelState.AddModelError("", "Invalid JSON format.");
                    return Page();
                }
            }

<<<<<<< HEAD
            return RedirectToPage();
=======
            return Page();
        }

        public async Task<IActionResult> OnPostSaveGeoJsonAsync()
        {
            var geoJsonData = await new StreamReader(Request.Body).ReadToEndAsync();
            HttpContext.Session.SetString("GeoJsonData", geoJsonData); // Save the GeoJSON data
            return new JsonResult(new { success = true });
        }


        public IActionResult OnGet()
        {
            GeoJsonData = HttpContext.Session.GetString("GeoJsonData");
            UAVs = JsonConvert.DeserializeObject<List<UAV>>(HttpContext.Session.GetString("UAVData") ?? "[]");
            return Page();
>>>>>>> parent of e38838a (Trans parameter to step 2)
        }
    }
}
