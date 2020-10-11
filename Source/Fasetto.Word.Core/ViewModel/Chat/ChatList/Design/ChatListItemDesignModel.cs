namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for <see cref="ChatListItemControl"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
            NewContentAvailable = true;
        }
    }
}
