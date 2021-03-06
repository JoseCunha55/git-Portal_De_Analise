﻿using System;
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
    public class PercentSucesso:IValueConverter 
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            //format the double as a percentage with two decimal points
            //double suc = (Math.Pow((double)value, 1)) * (Math.Pow(Math.E, -(double)value)) / 1;
            return String.Format("{0:P2}", value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Não preciso atualizar o objeto fonte.
            return null;
        }
    } //end of implementation class PercentSucess
}
