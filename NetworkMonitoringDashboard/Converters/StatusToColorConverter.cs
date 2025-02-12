using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NetworkMonitoringDashboard.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isOnline)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom(
                    isOnline ? "#4CAF50" : "#F44336"));
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}