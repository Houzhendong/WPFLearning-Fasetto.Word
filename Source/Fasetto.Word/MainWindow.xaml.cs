using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fasetto.Word
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            var viewModel = DataContext as WindowViewModel;
            viewModel.DimmableOverlayVisible = true;
            viewModel.OnPropertyChanged(nameof(viewModel.DimmableOverlayVisible));
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            var viewModel = DataContext as WindowViewModel;
            viewModel.DimmableOverlayVisible = false;
            viewModel.OnPropertyChanged(nameof(viewModel.DimmableOverlayVisible));
        }
    }
}
