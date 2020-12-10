using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for <see cref="ChatListControl"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>()
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "JA",
                    Message = "Hi dude, here is your new icons.",
                    ProfilePictureRGB = "fe4503",
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "Third View Model",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "Forth View Model",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true,
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "Fifth View Model",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "Sixth View Model",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Name = "Parnell",
                    Initials = "PL",
                    Message = "Seventh View Model",
                    ProfilePictureRGB = "00d405",
                    IsSelected = true,
                },
            };
        }
    }
}
