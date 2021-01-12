using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModle for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties
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
        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        public void OpenMessage()
        {
            if (Name.Equals("Jesse"))
            {
                IoC.Application.GoToPage(ApplicationPage.LoginPage, new LoginViewModel
                {
                    Email = "Jesse@google.com"
                });
                return;
            }

            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                AttachmentMenu = new ChatAttachmentPopupMenuViewModel
                {
                    Content = new MenuViewModel
                    {
                        Items = new List<MenuItemViewModel>(new[]
                        {
                            new MenuItemViewModel { Text = "Attach a file...", Type = MenuItemType.Header },
                            new MenuItemViewModel { Text = "From Computer", Icon = IconType.File },
                            new MenuItemViewModel { Text = "From Pictures", Icon = IconType.Picture },
                        })
                    }
                },

                Items = new System.Collections.ObjectModel.ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message =Message,
                        Initials = Initials,
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName ="Luke",
                        SendByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName ="Parnell",
                        SendByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message =Message,
                        Initials = Initials,
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName ="Luke",
                        SendByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName ="Parnell",
                        SendByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message =Message,
                        Initials = Initials,
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName ="Luke",
                        SendByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        ImageAttchment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere",
                        },
                        MessageSendTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName ="Parnell",
                        SendByMe = false,
                    },
                }
            });
        }
    }
}
