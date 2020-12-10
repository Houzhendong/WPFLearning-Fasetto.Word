using Fasetto.Word.Core;
using System.Diagnostics;

namespace Fasetto.Word
{
    public static class ApplicationPageHelper 
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel =null)
        {
            if (viewModel == null)
            {
                return null;
            }

            switch (page)
            {
                case ApplicationPage.LoginPage:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            if (page is ChatPage)
            {
                return ApplicationPage.Chat;
            }

            if (page is LoginPage)
            {
                return ApplicationPage.LoginPage;
            }

            if (page is RegisterPage)
            {
                return ApplicationPage.Register;
            }

            Debugger.Break();
            return default;
        }
    }
}
