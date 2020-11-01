using System.Collections.Generic;
using System.Dynamic;
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
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        /// <summary>
        /// The command for the user click send button 
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisible{ get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();

            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            SendCommand = new RelayCommand(Send);
        }

        /// <summary>
        /// when the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true; 
        }

        public void PopupClickaway()
        {
            AttachmentMenuVisible = false;
        }

        public void Send()
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for writing a nice message",
                OKText = "OK"
            });
        }
    }
}
