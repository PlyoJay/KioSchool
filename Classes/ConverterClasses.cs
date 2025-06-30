using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

    public class PriceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int d)
            {
                // "N0"은 소수점 없이 천 단위 쉼표 포함 형식
                return $"₩{d.ToString("N0", culture)}";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value?.ToString()?.Replace("₩", "").Replace(",", "");
            if (double.TryParse(str, NumberStyles.Any, culture, out double result))
            {
                return result;
            }

            return 0;
        }
    }


    public class EnumEqualsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return parameter;

            return Binding.DoNothing;
        }
    }

    public class EnumEqualityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return false;
            return Equals(values[0], values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // values[1]을 직접 접근할 수 없으므로 Tag 값을 parameter로 넘겨줘야 함
            if ((bool)value && parameter != null)
                return new object[] { parameter, Binding.DoNothing };

            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }


}
