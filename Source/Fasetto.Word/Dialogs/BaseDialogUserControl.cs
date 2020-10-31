using Fasetto.Word.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class BaseDialogUserControl :UserControl
    {
        #region Private Member

        /// <summary>
        /// the dialog window we will be contained within
        /// </summary>
        private DialogWindow dialogWindow;
        #endregion

        #region Public Commands

        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public properties

        /// <summary>
        /// the minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; }

        /// <summary>
        /// the minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight{ get; set; }

        /// <summary>
        /// the height of the title bar
        /// </summary>
        public int TitleHeight { get; set; }

        /// <summary>
        /// the title of the dialog 
        /// </summary>
        public string Title { get; set; }
        #endregion

        public BaseDialogUserControl()
        {
            if(!DesignerProperties.GetIsInDesignMode(this))
            {
                dialogWindow = new DialogWindow();
                dialogWindow.ViewModel = new DialogWindowViewModel(dialogWindow);

                CloseCommand = new RelayCommand(() => dialogWindow.Close());
            }
        }

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    dialogWindow.ViewModel.Title = viewModel.Title ?? Title;

                    dialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    dialogWindow.ShowDialog();
                }
                finally
                {

                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }
    }
}
