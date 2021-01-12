using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fasetto.Word
{
    /// <summary>
    /// the isbusy attached property for anything that want to flag if the control is busy
    /// </summary>
    public class ClipFromBorderProperty : BaseAttachedProperties<ClipFromBorderProperty, bool> 
    {
        private RoutedEventHandler borderLoadedEventHandler;
        private SizeChangedEventHandler borderSizeChangedEventHandler;

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (sender as FrameworkElement);

            if(!(element.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            borderLoadedEventHandler = (s1, e1) => BorderOnChanged(s1, e1,element);

            borderSizeChangedEventHandler = (s1, e1) => BorderOnChanged(s1, e1,element);

            if ((bool)e.NewValue)
            {
                border.Loaded += borderLoadedEventHandler;
                border.SizeChanged += borderSizeChangedEventHandler;
            }
            else
            {
                border.Loaded -= borderLoadedEventHandler;
                border.SizeChanged -= borderSizeChangedEventHandler;
            }
        }

        private void BorderOnChanged(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            var border = sender as Border;

            //Check we have an actual size
            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            //Setup the new child clipping area
            var rect = new RectangleGeometry();

            //Match the corner radius with the borders corner radius
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            //Set rectangle size to match child's actual size
            rect.Rect = new Rect(child.RenderSize);

            child.Clip = rect;
        }
    }
}
