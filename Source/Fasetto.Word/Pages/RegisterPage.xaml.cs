using Fasetto.Word.Core;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public RegisterPage(RegisterViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// the secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
