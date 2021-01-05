using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fasetto.Word
{
    /// <summary>
    /// Scroll an items control to the bottom when the data context changed 
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperties<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer control))
                return;

            control.DataContextChanged -= Control_DataContextChanged; 
            control.DataContextChanged += Control_DataContextChanged; 
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }
}
