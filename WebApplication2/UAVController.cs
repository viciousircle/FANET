using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication2;

[Route("api/[controller]")]
[ApiController]
public class UAVController : ControllerBase
{
    private readonly FANETNetwork _network;

    // Constructor để inject FANETNetwork vào Controller
    public UAVController(FANETNetwork network)
    {
        _network = network;
    }

    // Phương thức xử lý yêu cầu GET đến /api/uav/simulate
    [HttpGet("simulate")]
    public IActionResult Simulate()
    {
        _network.SimulateNetwork();  // Gọi phương thức mô phỏng mạng FANET
        return Ok("Mạng FANET đã được mô phỏng!");
    }

    // Phương thức xử lý yêu cầu POST để thêm UAV vào mạng
    [HttpPost("add")]
    public IActionResult AddUAV([FromBody] UAV uav)
    {
        if (uav == null || !uav.IsValid())
        {
            return BadRequest("Thông tin UAV không hợp lệ.");
        }
        _network.UAVs.Add(uav);  // Thêm UAV vào danh sách UAV trong mạng
        return Ok($"UAV {uav.Id} đã được thêm vào mạng!");
    }

    // Phương thức xử lý yêu cầu GET để lấy trạng thái của mạng FANET
    [HttpGet("status")]
    public IActionResult GetNetworkStatus()
    {
        var status = _network.UAVs.Select(uav => new { uav.Id, uav.X, uav.Y, uav.Z }).ToList();
        return Ok(status);  // Trả về trạng thái các UAV trong mạng
    }
}
