using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Match the label width of all text entry controls inside this panel 
    /// </summary>
    public class TextEntryWidthMatcher : BaseAttachedProperties<TextEntryWidthMatcher, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = (sender as Panel);

            //call setwidths initially
            SetWidths(panel);

            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                panel.Loaded -= onLoaded;

                SetWidths(panel);

                foreach (FrameworkElement child in panel.Children)
                {
                    if (!(child is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidths(panel);
                    };
                }
            };

            panel.Loaded += onLoaded;
        }

        private void SetWidths(Panel panel)
        {
            var maxSize = 0d;
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                control.LabelWidth = (GridLength)(new GridLengthConverter().ConvertFromString(maxSize.ToString()));
            }
        }
    }
}
