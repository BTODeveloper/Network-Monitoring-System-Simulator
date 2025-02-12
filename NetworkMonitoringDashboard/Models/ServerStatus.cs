using System;

namespace NetworkMonitoringDashboard.Models
{
    public class ServerStatus
    {
        public bool IsOnline { get; set; }
        public string Status { get; set; }
        public DateTime LastChecked { get; set; }
        public double ResponseTime { get; set; }     // in ms
        public string ServerName { get; set; }
        public string Location { get; set; }
    }
}