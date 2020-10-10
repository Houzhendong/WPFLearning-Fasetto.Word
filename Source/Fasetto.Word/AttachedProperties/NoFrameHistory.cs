using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// the isbusy attached property for anything that want to flag if the control is busy
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperties<NoFrameHistory, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
