using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// a view model for login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Property

        /// <summary>
        /// the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the users password
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// a flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// the command to register for a new account 
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (paramter) => await Login(paramter));
            RegisterCommand = new RelayCommand(async () => await Register());
        }

        /// <summary>
        /// the user to the register page
        /// </summary>
        /// <returns></returns>
        private async Task Register()
        {
            IoC.Get<ApplicationViewModel>().SideMenuVisiable ^= true;

            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;

            await Task.Delay(1);
        }

        /// <summary>
        /// attempts to log the user in 
        /// </summary>
        /// <param name="paramter">the <see cref="SecureString"/> passed in form the view for the user password</param>
        /// <returns></returns>
        public async Task Login(object paramter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
             {
                 await Task.Delay(500);

                 var email = this.Email;
                 var pass = (paramter as IHavePassword).SecurePassword.Unsecure();
             });
        }
    }

}
