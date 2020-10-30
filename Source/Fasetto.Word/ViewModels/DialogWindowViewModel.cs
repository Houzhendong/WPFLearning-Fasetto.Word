using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// the content to host inside the dialog
        /// </summary>
        public Control Content { get; set; }

        #endregion

        public DialogWindowViewModel(Window window) : base(window)
        {
            TitleHeight = 30;
        }
    }
}
