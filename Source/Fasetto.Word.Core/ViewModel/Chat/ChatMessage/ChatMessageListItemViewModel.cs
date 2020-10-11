
using System;
using System.Drawing;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for each chat list item in the overview chat list
    /// </summary>
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// the display name of this sender of the profile  
        /// </summary>
        public string SenderName { get; set; }

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

        /// <summary>
        /// True if this message was sent by signed in user
        ///</summary>
        public bool SendByMe { get; set; }

        /// <summary>
        /// the time of the message was send
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// the time of the message was send
        /// </summary>
        public DateTimeOffset MessageSendTime { get; set; }

        /// <summary>
        /// True if this message has been read
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;
    }
}
