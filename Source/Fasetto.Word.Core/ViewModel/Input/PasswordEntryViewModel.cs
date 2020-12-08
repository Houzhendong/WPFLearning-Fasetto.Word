using System.Security;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the view model for a password entry to edit a string value
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The fake password display string
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The fake password display string
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// The new password display string
        /// </summary>
        public string NewPasswordHintText{ get; set; }

        /// <summary>
        /// The new password display string
        /// </summary>
        public string ConfirmPasswordHintText{ get; set; }

        /// <summary>
        /// the current saved password 
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// the current non-commit edited password 
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// the current non-commit edited confirmed password 
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }
        #endregion

        #region Public Commands

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }
        #endregion

        #region Command Methods

        public void Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

            Editing = true; 
        }

        public void Cancel()
        {
            Editing = false;
        }

        public void Save()
        {
            var storePassword = "Testing";

            if (storePassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current passwrod is invalid",
                    OKText = "OK"
                });
                return;
            }

            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and comfirm password do not match",
                    OKText = "OK"
                });
                return;
            }

            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
            {
                CurrentPassword.AppendChar(c);
            }

            var actualNewPassword = NewPassword.Unsecure();
            var actualCurrentPassword = CurrentPassword.Unsecure();
            var actualConfirmPassword = ConfirmPassword.Unsecure();

            Editing = false;
        }
        #endregion
    }
}
