using System.ComponentModel.Design;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the applicaiton state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Command

        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        #endregion

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
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
