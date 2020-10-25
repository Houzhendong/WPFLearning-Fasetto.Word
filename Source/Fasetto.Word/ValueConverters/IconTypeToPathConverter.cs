using Fasetto.Word.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;

namespace Fasetto.Word
{
    public class IconTypeToPathConverter: BaseValueConverter<IconTypeToPathConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((IconType)value)
            {
                case IconType.File:
                    return Application.Current.FindResource("IconFile");
                case IconType.Picture:
                    return Application.Current.FindResource("IconPicture");
                case IconType.None:
                    return null;
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
