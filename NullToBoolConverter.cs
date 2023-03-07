using System;
using System.Globalization;
using System.Windows.Data;

namespace _06_Ticketsystem_WPF
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Konkret: in value ist der selektierte Mitarbeiter
            if (value != null)
                return true;
            else
                return false;

            //oder kürzer:
            //return value != null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //wird in unserem Fall nicht benötigt
            return Binding.DoNothing;
        }
    }
}
