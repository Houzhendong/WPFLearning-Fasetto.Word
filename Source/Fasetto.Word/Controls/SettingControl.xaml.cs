using Fasetto.Word.Core;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// SettingControl.xaml 的交互逻辑
    /// </summary>
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();

            DataContext = IoC.Settings;
        }

        private void TextEntryControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
