using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class StatisticsModel : PageModel
    {
        public string SelectedStrategyName { get; set; }
        public string StrategyDescription { get; set; }
        public int CoveragePercentage { get; set; }
        public int UAVCount { get; set; }
        public string TransmissionSpeed { get; set; }
        public string Conclusion { get; set; }

        // Before and after values for comparison
        public string BeforeCoverage { get; set; }
        public string AfterCoverage { get; set; }
        public string BeforeTransmissionSpeed { get; set; }
        public string AfterTransmissionSpeed { get; set; }
        public string BeforeUAVCount { get; set; }
        public string AfterUAVCount { get; set; }
        public string BeforeMaxDuration { get; set; }
        public string AfterMaxDuration { get; set; }

        // QoS metrics before and after values
        public string BeforeLatency { get; set; }
        public string AfterLatency { get; set; }
        public string BeforeBandwidth { get; set; }
        public string AfterBandwidth { get; set; }
        public string BeforePacketLoss { get; set; }
        public string AfterPacketLoss { get; set; }
        public string BeforeThroughput { get; set; }
        public string AfterThroughput { get; set; }

        // Simulating the retrieval of data
        public void OnGet()
        {
            // These would typically come from a database or be dynamically calculated
            SelectedStrategyName = "Option 2: Thuật toán 2";
            StrategyDescription = "Sử dụng mạng cảm biến để thu thập dữ liệu...";
            CoveragePercentage = 85; // Example: 85% coverage
            UAVCount = 13; // Number of UAVs in the network
            TransmissionSpeed = "40Mbps"; // Data transmission speed
            Conclusion = "Chiến lược này cung cấp mức độ bao phủ ổn định, thích hợp cho các tình huống cứu hộ và thu thập dữ liệu...";

            // Simulate before and after values for comparison
            BeforeCoverage = "50%";
            AfterCoverage = "85%";
            BeforeTransmissionSpeed = "25Mbps";
            AfterTransmissionSpeed = "40Mbps";
            BeforeUAVCount = "8 UAVs";
            AfterUAVCount = "13 UAVs";
            BeforeMaxDuration = "1 giờ";
            AfterMaxDuration = "2 giờ";

            // Simulate QoS metrics before and after algorithm
            BeforeLatency = "200 ms"; // Example latency before algorithm
            AfterLatency = "120 ms"; // Example latency after algorithm
            BeforeBandwidth = "30 Mbps"; // Example bandwidth before algorithm
            AfterBandwidth = "50 Mbps"; // Example bandwidth after algorithm
            BeforePacketLoss = "5%"; // Example packet loss before algorithm
            AfterPacketLoss = "1%"; // Example packet loss after algorithm
            BeforeThroughput = "15 Mbps"; // Example throughput before algorithm
            AfterThroughput = "35 Mbps"; // Example throughput after algorithm
        }
    }
}
