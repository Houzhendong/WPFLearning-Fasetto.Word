using Fasetto.Word.Core;
using System.Security;

namespace Fasetto.Word
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel> ,IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        /// <summary>
        /// the secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword; 
    }
}
