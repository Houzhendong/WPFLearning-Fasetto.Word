using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window
    {
        /// <summary>
        /// The view model for this window
        /// </summary>
        private DialogWindowViewModel viewModel;

        public DialogWindowViewModel ViewModel
        {
            get => viewModel;
            set
            {
                viewModel = value;
                DataContext = viewModel;
            }
        }

        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
