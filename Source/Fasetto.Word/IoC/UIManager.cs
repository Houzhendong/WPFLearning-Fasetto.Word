using Fasetto.Word.Core;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(() => 
            {
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    new DialogWindow().ShowDialog();
                }
                finally
                {

                    tcs.TrySetResult(true);
                }
            });
            });


            return tcs.Task;
        } 
    }
}
