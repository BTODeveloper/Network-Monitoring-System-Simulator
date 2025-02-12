using System;
using NetworkMonitoringDashboard.Models;

namespace NetworkMonitoringDashboard.Services
{
    public class NetworkSimulationService
    {
        private readonly Random _random = new Random();
        private double _lastBandwidth = 50;
        private double _lastLatency = 20;

        public NetworkMetrics GenerateMetrics()
        {
            // Simulate somewhat realistic network fluctuations
            _lastBandwidth += _random.NextDouble() * 20 - 10;
            _lastBandwidth = Math.Max(10, Math.Min(100, _lastBandwidth));

            _lastLatency += _random.NextDouble() * 10 - 5;
            _lastLatency = Math.Max(5, Math.Min(200, _lastLatency));

            return new NetworkMetrics
            {
                Timestamp = DateTime.Now,
                Bandwidth = _lastBandwidth,
                Latency = _lastLatency,
                PacketLoss = _random.NextDouble() * 2,
                ServerName = "Main Server",
                IsConnected = true
            };
        }

        public double GenerateLatency()
        {
            return _random.NextDouble() * 100 + 20;
        }
    }
}