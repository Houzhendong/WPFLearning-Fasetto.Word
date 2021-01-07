using System;
using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for <see cref="ChatListControl"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        public ChatMessageListDesignModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "I'm about to wipe the old server. We need to update the old server to Windows 2016",
                    ProfilePictureRGB = "3099c5",
                    MessageSendTime =DateTimeOffset.UtcNow,
                    SendByMe= false,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSendTime =DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SendByMe= true,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "the new server is up, Go to 192.168.1.1.\r\nUsername is admin, password is P8ssw0rd!",
                    ProfilePictureRGB = "3099c5",
                    MessageSendTime =DateTimeOffset.UtcNow,
                    SendByMe= false,
                },
            };
        }
    }
}
