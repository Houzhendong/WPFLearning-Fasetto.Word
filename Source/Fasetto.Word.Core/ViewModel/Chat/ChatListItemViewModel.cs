
using System.Drawing;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the least message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// the initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// true if this item is Selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
