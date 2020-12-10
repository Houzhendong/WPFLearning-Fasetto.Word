using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage(ChatMessageListViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
