using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using WebApplication2.Models; // Ensure to reference the UAV model namespace

namespace WebApplication2.Pages
{
    public class AddObjectModel : PageModel
    {
        // List of UAV objects, initialized to avoid null reference issues
        public List<UAV> UAVs { get; set; } = new List<UAV>();

        [BindProperty]
        public IFormFile JsonFile { get; set; }

        public string GeoJsonData { get; set; }

        // Action to handle file upload and parsing
        public async Task<IActionResult> OnPostAsync()
        {
            if (JsonFile == null || JsonFile.Length == 0)
            {
                ModelState.AddModelError("JsonFile", "Please upload a valid UAV JSON file.");
                return Page();
            }

            // Parse UAV data from the uploaded file
            try
            {
                using (var stream = new MemoryStream())
                {
                    await JsonFile.CopyToAsync(stream);
                    stream.Position = 0;
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        UAVs = JsonConvert.DeserializeObject<List<UAV>>(json) ?? new List<UAV>();  // Handle null response from JSON deserialization
                    }
                }
            }
            catch (JsonException ex)
            {
                ModelState.AddModelError("JsonFile", $"Invalid JSON file: {ex.Message}");
                return Page();
            }

            return Page();
        }

        // Handler to save GeoJSON data
        public async Task<IActionResult> OnPostSaveGeoJsonAsync([FromBody] object geoJsonData)
        {
            if (geoJsonData == null)
            {
                return new JsonResult(new { success = false, message = "GeoJSON data is required." });
            }

            try
            {
                // Save the GeoJSON to a file or database
                await System.IO.File.WriteAllTextAsync("savedMap.geojson", geoJsonData.ToString());

                GeoJsonData = geoJsonData.ToString();
                return new JsonResult(new { success = true });
            }
            catch (IOException ex)
            {
                return new JsonResult(new { success = false, message = $"Error saving GeoJSON: {ex.Message}" });
            }
        }
    }
}

