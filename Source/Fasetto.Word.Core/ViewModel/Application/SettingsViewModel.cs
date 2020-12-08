using System;
using System.ComponentModel.Design;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the applicaiton state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel UserName { get; set; }

        public PasswordEntryViewModel Password { get; set; }

        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for the logout button
        /// </summary>
        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Command

        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public ICommand ClearuserDataCommand { get; set; }
        #endregion

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogoutCommand = new RelayCommand(Logout);
            ClearuserDataCommand = new RelayCommand(ClearUserData);

            //TODO : remove this when the real run envirment

            LogoutButtonText = "Logout";
        }

        public void Logout()
        {
            ClearUserData();
            //Go to login page
            IoC.Application.GoToPage(ApplicationPage.LoginPage);
        }

        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }

        public void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }

        public void ClearUserData()
        {
            Name = null;
            UserName = null;
            Password = null;
            Email = null;
        }

    }
}
