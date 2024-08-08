using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace associationWpf.Converter
{
    public class DateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date && parameter is DateTime startDate)
            {
                return date == startDate ? Brushes.Red : Brushes.Black;
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}