using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Security;
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
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => items;
            set
            {
                if (items == value)
                    return;

                items = value;
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(items);
            }
        }

        /// <summary>
        /// The chat thred items for the list that inclode any search filtering 
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; } 

        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        public string SearchText
        {
            get => searchText;
            set 
            {
                if (searchText == value)
                    return;

                searchText = value;

                if(string.IsNullOrEmpty(searchText))
                {
                    Search();
                }
            }
        }

        public bool AttachmentMenuVisible{ get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The message text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// The last search text in this list
        /// </summary>
        protected string lastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string searchText;

        protected ObservableCollection<ChatMessageListItemViewModel> items;

        protected bool searchIsOpen;

        public bool SearchIsOpen
        {
            get => searchIsOpen;
            set
            {
                if (searchIsOpen == value)
                    return;

                searchIsOpen = value;

                if (!searchIsOpen)
                    SearchText = string.Empty;
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand OpenSearchCommand { get; set; }
        public ICommand CloseSearchCommand { get; set; }
        public ICommand ClearSearchCommand { get; set; }

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();

            PopupClickawayCommand = new RelayCommand(PopupClickaway);

            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
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
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSendTime = DateTime.UtcNow,
                SendByMe = true
            };

            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        public void Search()
        {
            if((string.IsNullOrEmpty(lastSearchText) && string.IsNullOrEmpty(searchText)) ||
                string.Equals(lastSearchText,searchText))
            { 
                return; 
            }

            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(items);

                lastSearchText = SearchText;

                return;
            }

            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(items.Where(item => item.Message.ToLower().Contains(SearchText)));

            lastSearchText = SearchText;
        }
        public void CloseSearch() => SearchIsOpen = false;

        public void OpenSearch() => SearchIsOpen = true;

        public void ClearSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                SearchText = string.Empty;
            }
            else
            {
                SearchIsOpen = false;
            }
        }


    }
}
