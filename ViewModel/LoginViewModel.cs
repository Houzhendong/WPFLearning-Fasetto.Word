using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word
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
        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (paramter) => await Login(paramter));
        }

        /// <summary>
        /// attempts to log the user in 
        /// </summary>
        /// <param name="paramter">the <see cref="SecureString"/> passed in form the view for the user password</param>
        /// <returns></returns>
        public async Task Login(object paramter)
        {
            await Task.Delay(500);

            var pass = (paramter as IHavePassword).SecurePassword.Unsecure();
        }
    }

}
