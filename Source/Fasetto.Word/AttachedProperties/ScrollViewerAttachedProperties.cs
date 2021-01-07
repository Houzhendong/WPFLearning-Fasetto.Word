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
    public class AutoScrollToBottomProperty : BaseAttachedProperties<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer control))
                return;

            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
            {
                scroll.ScrollToEnd();
            }
        }
    }

    public class ScrollToBottomOnLoadProperty : BaseAttachedProperties<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer scroll)) 
                return;
            scroll.DataContextChanged -= Scroll_DataContextChanged;
            scroll.DataContextChanged += Scroll_DataContextChanged;
        }

        private void Scroll_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }
}
