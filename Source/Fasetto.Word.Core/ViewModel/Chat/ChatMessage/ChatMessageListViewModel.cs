using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for the overview chat list 
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {

        /// <summary>
        /// the command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible{ get; set; }


        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        /// <summary>
        /// when the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true; 
        }
    }
}
