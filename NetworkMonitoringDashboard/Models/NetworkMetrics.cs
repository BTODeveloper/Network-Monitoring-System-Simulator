using System;

namespace NetworkMonitoringDashboard.Models
{
    public class NetworkMetrics
    {
        public DateTime Timestamp { get; set; }
        public double Bandwidth { get; set; }        // in Mbps
        public double Latency { get; set; }          // in ms
        public double PacketLoss { get; set; }       // percentage
        public string ServerName { get; set; }
        public bool IsConnected { get; set; }
    }
}