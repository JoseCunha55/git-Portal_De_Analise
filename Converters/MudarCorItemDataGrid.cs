using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace Portal_De_Analise.Converters
{
    public class MudarCorItemDataGrid: IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal number;
            number = (decimal)value;
            if(number <=35)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (number>35 && number<60)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                return new SolidColorBrush(Colors.Green); ;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Não preciso atualizar o objeto fonte.
            return null;
        }

    }
}
