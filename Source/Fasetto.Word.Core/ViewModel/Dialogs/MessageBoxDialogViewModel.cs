using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseViewModel
    {
        /// <summary>
        /// The title of the message box
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The message to display
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The text to use for OK button
        /// </summary>
        public string OKText { get; set; }
    }
}
