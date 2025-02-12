using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;
using NetworkMonitoringDashboard.Models;
using NetworkMonitoringDashboard.Services;
using System.Windows.Media;

namespace NetworkMonitoringDashboard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NetworkSimulationService _simulationService;
        private readonly Timer _updateTimer;
        private SeriesCollection _bandwidthSeries;
        private SeriesCollection _latencySeries;
        private ObservableCollection<ServerStatus> _servers;
        private ObservableCollection<NetworkMetrics> _recentMetrics;

        public SeriesCollection BandwidthSeries
        {
            get => _bandwidthSeries;
            set => SetProperty(ref _bandwidthSeries, value);
        }

        public SeriesCollection LatencySeries
        {
            get => _latencySeries;
            set => SetProperty(ref _latencySeries, value);
        }

        public ObservableCollection<ServerStatus> Servers
        {
            get => _servers;
            set => SetProperty(ref _servers, value);
        }

        public ObservableCollection<NetworkMetrics> RecentMetrics
        {
            get => _recentMetrics;
            set => SetProperty(ref _recentMetrics, value);
        }

        public MainViewModel()
        {
            _simulationService = new NetworkSimulationService();
            InitializeCollections();
            InitializeCharts();
            
            // Update every second
            _updateTimer = new Timer(UpdateMetrics, null, 0, 1000);
        }

        private void InitializeCollections()
        {
            Servers = new ObservableCollection<ServerStatus>
            {
                new ServerStatus { ServerName = "US-EAST-01", Location = "New York", IsOnline = true },
                new ServerStatus { ServerName = "EU-WEST-01", Location = "London", IsOnline = true },
                new ServerStatus { ServerName = "AP-SOUTH-01", Location = "Singapore", IsOnline = true }
            };
            
            RecentMetrics = new ObservableCollection<NetworkMetrics>();
        }

        private void InitializeCharts()
        {
            // Bandwidth Chart
            var bandwidthLine = new LineSeries
            {
                Title = "Bandwidth Usage",
                Values = new ChartValues<double>(),
                PointGeometry = null,
                LineSmoothness = 0,
                StrokeThickness = 2,
                Stroke = Brushes.LightGreen,
                Fill = Brushes.Transparent
            };

            BandwidthSeries = new SeriesCollection { bandwidthLine };

            // Latency Chart
            var latencyLine = new LineSeries
            {
                Title = "Response Time",
                Values = new ChartValues<double>(),
                PointGeometry = null,
                LineSmoothness = 0,
                StrokeThickness = 2,
                Stroke = Brushes.Orange,
                Fill = Brushes.Transparent
            };

            LatencySeries = new SeriesCollection { latencyLine };
        }

        private void UpdateMetrics(object state)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var metrics = _simulationService.GenerateMetrics();
                UpdateCharts(metrics);
                UpdateServerStatus(metrics);
            });
        }

        private void UpdateCharts(NetworkMetrics metrics)
        {
            var bandwidthLine = (LineSeries)BandwidthSeries[0];
            var latencyLine = (LineSeries)LatencySeries[0];

            bandwidthLine.Values.Add(metrics.Bandwidth);
            latencyLine.Values.Add(metrics.Latency);

            if (bandwidthLine.Values.Count > 30)
                bandwidthLine.Values.RemoveAt(0);
            if (latencyLine.Values.Count > 30)
                latencyLine.Values.RemoveAt(0);

            RecentMetrics.Insert(0, metrics);
            while (RecentMetrics.Count > 10)
                RecentMetrics.RemoveAt(RecentMetrics.Count - 1);
        }

        private void UpdateServerStatus(NetworkMetrics metrics)
        {
            foreach (var server in Servers)
            {
                server.LastChecked = DateTime.Now;
                server.ResponseTime = _simulationService.GenerateLatency();
                server.IsOnline = server.ResponseTime < 1000; // Offline if latency > 1000ms
                server.Status = server.IsOnline ? "Online" : "Offline";
            }
        }
    }
}