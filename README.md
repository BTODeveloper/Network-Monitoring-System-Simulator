Network Monitoring System Demo
A demonstration dashboard showcasing network monitoring UI/UX patterns using WPF and .NET 8. This project illustrates how enterprise network monitoring tools are built, using simulated data to demonstrate real-time visualization capabilities.

![Screenshot 2025-02-12 145834](https://github.com/user-attachments/assets/49150dc3-57b5-4966-b514-c6e7e9a6264e)


Overview
Built as a proof of concept, this project demonstrates:

Real-time data visualization techniques
Enterprise dashboard UI/UX design
MVVM architecture implementation
Network metrics visualization patterns

Key Features

Bandwidth usage visualization
Latency monitoring display
Server status tracking
Network events logging
NOC-optimized dark theme

Tech Stack

C# / .NET 8.0
WPF
MVVM Architecture
LiveCharts2 for data visualization

Project Structure
CopyNetworkMonitoringDashboard/
├── Models/
│   ├── NetworkMetrics.cs
│   └── ServerStatus.cs
├── ViewModels/
│   ├── ViewModelBase.cs
│   └── MainViewModel.cs
├── Views/
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
├── Services/
│   └── NetworkSimulationService.cs
└── Converters/
    └── StatusToColorConverter.cs
Requirements

.NET 8.0 SDK
Visual Studio 2022 / JetBrains Rider

Getting Started

Clone the repository

bashCopygit clone https://github.com/yourusername/Network-Monitoring-System-Demo.git

Restore NuGet packages

bashCopydotnet restore

Build and run the solution

bashCopydotnet build
dotnet run
Development Notes

Uses MVVM pattern for clean architecture
Implements real-time data simulation
Follows WPF best practices
Modern UI/UX design principles

Additional Resources

WPF Documentation
MVVM Pattern
LiveCharts2
