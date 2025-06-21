using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace KioSchool.Classes
{
    public class SelectedToBrushConverter : IValueConverter
    {
        public Brush SelectedBrush { get; set; } = Brushes.Black;
        public Brush UnselectedBrush { get; set; } = Brushes.Transparent;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isSelected && isSelected) ? SelectedBrush : UnselectedBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class SelectedToForegroundConverter : IValueConverter
    {
        public Brush SelectedBrush { get; set; } = Brushes.White;
        public Brush UnselectedBrush { get; set; } = Brushes.Black;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool isSelected && isSelected) ? SelectedBrush : UnselectedBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

}
