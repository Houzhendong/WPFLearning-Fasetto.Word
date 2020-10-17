﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Fasetto.Word
{
    public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            else
                return (bool)value ? HorizontalAlignment.Left : HorizontalAlignment.Right;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
