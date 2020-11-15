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

        public TextEntryViewModel Password { get; set; }

        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Public Command

        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        #endregion

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);

            //TODO : remove this when the real run envirment
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Luke Malpass" };
            UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "Luke" };
            Password = new TextEntryViewModel { Label = "Password", OriginalText = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "test@email.com" };
        }

        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }

        public void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }

    }
}
