using Fasetto.Word.Core;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        public ChatPage(ChatMessageListViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }


        protected override void OnViewModelChanged()
        {
            if (ChatMessageList == null)
            {
                return;
            }

            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);
        }
    }
}
