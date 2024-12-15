using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MVVM.Helper.ConverterHelper
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Ja" : "Nein";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = string.Empty;
            if (value is ComboBoxItem)
            {
                stringValue = (value as ComboBoxItem).Content.ToString();
            }
            else
            {
                stringValue = value.ToString();
            }

            return stringValue == "Ja";
        }
    }
}
