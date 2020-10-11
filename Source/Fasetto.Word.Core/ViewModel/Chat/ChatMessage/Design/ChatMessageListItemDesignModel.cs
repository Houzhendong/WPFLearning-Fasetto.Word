using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the design-time data for <see cref="ChatListItemControl"/>
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        public ChatMessageListItemDesignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "Some design time visual text";
            ProfilePictureRGB = "3099c5";
            SendByMe = true;
            MessageSendTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }
    }
}
