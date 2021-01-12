
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for each chat message thread item's attachment in a chat thread
    /// </summary>
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The thumbnail URL of this 
        /// </summary>
        private string thumbnailUrl;

        #endregion
        /// <summary>
        /// The title of this image file
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The original file name of the attachment
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The file size in bytes of this attachment
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// The thumbnail URL of this attachment
        /// </summary>
        public string ThumbnailUrl 
        {
            get => thumbnailUrl;
            set
            {
                if (value == thumbnailUrl)
                    return;
                thumbnailUrl = value;

                Task.Delay(2000).ContinueWith(t => LocalFilePath = LocalFilePath = "/Images/Logo/Sample.jpg");
            }
        }

        /// <summary>
        /// The local file path on this machine to the downloaded thumbnail 
        /// </summary>
        public string LocalFilePath { get; set; }
    }
}
