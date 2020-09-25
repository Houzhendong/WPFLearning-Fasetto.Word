using System.Collections.Generic;

namespace Fasetto.Word
{
    /// <summary>
    /// A ViewModle for the overview chat list 
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
