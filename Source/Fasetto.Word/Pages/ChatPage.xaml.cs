using Fasetto.Word.Core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var textbox = sender as TextBox;

            if (e.Key == Key.Enter && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                var index = textbox.CaretIndex;

                textbox.Text = textbox.Text.Insert(index, Environment.NewLine);
                textbox.CaretIndex = index + Environment.NewLine.Length;

                e.Handled = true;
            }
        }
    }
}
