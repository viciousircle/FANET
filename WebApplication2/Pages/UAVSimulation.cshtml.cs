using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.Models;
using WebApplication2.Services.ProtocolTypes;
using WebApplication2.Services;

namespace WebApplication2.Pages
{
    public class UAVSimulationModel : PageModel
    {
        private readonly UAVData _uavDataService;
        public List<UAV> UAVs { get; set; }

        public UAVSimulationModel(UAVData uavDataService)
        {
            _uavDataService = uavDataService;
        }

        public void OnGet()
        {
            // Đọc dữ liệu UAV từ file JSON
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uavData.json");
            UAVs = _uavDataService.LoadUAVsFromFile(filePath);
        }

        [HttpGet]
        public IActionResult OnGetUpdatedUAVs()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uavData.json");
            var updatedUAVs = _uavDataService.LoadUAVsFromFile(filePath);
            return new JsonResult(updatedUAVs); // Trả về UAVs dưới dạng JSON
        }
    }
}
