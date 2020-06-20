using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Zpeedy_core_3.Helpers
{
    [ValueConversion(typeof(bool?), typeof(bool))]
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool?))
            {
                throw new InvalidOperationException("The target must be a nullable boolean");
            }
            bool? b = (bool?)value;
            return b.HasValue && !b.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(value as bool?);
        }
    }
}
