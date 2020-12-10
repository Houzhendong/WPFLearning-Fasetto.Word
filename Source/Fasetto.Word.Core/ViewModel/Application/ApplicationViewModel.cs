using System.Collections.Specialized;
using System.ComponentModel.Design;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the applicaiton state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public bool SideMenuVisiable { get; set; } = true;

        /// <summary>
        /// The view model to use for the current page when the current page changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool SettingsMenuVisible { get; set; } = false;

        /// <summary>
        /// navigates to the specified page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;

            CurrentPageViewModel = viewModel;

            CurrentPage = page;

            //Fire off a CurrentPage Changed event
            OnPropertyChanged(nameof(CurrentPage));

            SideMenuVisiable = page == ApplicationPage.Chat;
        }
    }
}
