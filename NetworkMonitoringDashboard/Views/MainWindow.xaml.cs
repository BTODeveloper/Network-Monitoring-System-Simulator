using System.Windows;
using NetworkMonitoringDashboard.ViewModels;

namespace NetworkMonitoringDashboard.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}