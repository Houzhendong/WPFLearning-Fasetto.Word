using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// the isbusy attached property for anything that want to flag if the control is busy
    /// </summary>
    public class PanelChildMargin : BaseAttachedProperties<PanelChildMargin, string> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            panel.Loaded += (s, ee) =>
            {
                foreach (FrameworkElement child in panel.Children)
                {
                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
                }
            };
        }
    }
}
