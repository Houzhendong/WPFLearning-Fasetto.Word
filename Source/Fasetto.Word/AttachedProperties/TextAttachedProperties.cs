using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fasetto.Word
{
    /// <summary>
    /// Focuses this element on load 
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperties<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            control.Loaded += (s, se) => control.Focus();
        }
    }

    public class FocusAndSelectProperty : BaseAttachedProperties<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender is TextBoxBase control))
            {
                if ((bool)e.NewValue)
                {
                    control.Focus();
                    control.SelectAll();
                }
            }
            if (sender is PasswordBox password)
            { 
                if ((bool)e.NewValue)
                {
                    password.Focus();
                    password.SelectAll();
                }
            }
        }
    }
}
