using Fasetto.Word.Core;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        } 
    }
}
