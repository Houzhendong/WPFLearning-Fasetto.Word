using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PropertyChanged;

namespace Fasetto.Word.Core
{
    public class BaseDialogViewModel : BaseViewModel 
    {
        #region Public Properties

        /// <summary>
        /// The title of this dialog window
        /// </summary>
        public string Title { get; set; }

        #endregion
    }
}
