using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class BasePopupMenuViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// the bubble background in argb values
        /// </summary>
        public string BubbleBackground { get; set; }

        #endregion

        #region Constructor

        public BasePopupMenuViewModel()
        {
            BubbleBackground = "ffffff"; 
        }
        #endregion
    }
}
