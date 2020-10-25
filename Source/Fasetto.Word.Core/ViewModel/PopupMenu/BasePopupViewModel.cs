using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// the bubble background in argb values
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// the content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }
        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            BubbleBackground = "ffffff"; 
        }
        #endregion
    }
}
