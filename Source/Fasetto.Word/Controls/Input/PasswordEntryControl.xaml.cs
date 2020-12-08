using Fasetto.Word.Core;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// TextEntryControl.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        /// <summary>
        /// the label width of the control
        /// </summary>
        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto,LabelWidthChangedCallback));

        /// <summary>
        /// called when the label has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue; 
            }
            catch
            {
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
            {
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
            }
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
            {
                viewModel.NewPassword = NewPassword.SecurePassword;
            }
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
            {
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
            }
        }
    }
}
