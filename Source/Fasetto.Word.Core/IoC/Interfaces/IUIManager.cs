using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The UI manager that handles any UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Display a single message box to user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
