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
    public class MessageBoxDialogDesignModel :MessageBoxDialogViewModel 
    {
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        public MessageBoxDialogDesignModel()
        {
            Title = "xxx";
            Message = "Design time Message are fun";
        }
    }
}
