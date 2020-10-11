using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for the overview chat list 
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        /// <summary>
        /// the display name of this chat list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}
