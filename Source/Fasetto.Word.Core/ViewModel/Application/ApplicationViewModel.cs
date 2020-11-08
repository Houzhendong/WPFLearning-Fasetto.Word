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
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.LoginPage;

        public bool SideMenuVisiable { get; set; } = false;

        public bool SettingsMenuVisible { get; set; } = false;

        /// <summary>
        /// navigates to the specified page
        /// </summary>
        /// <param name="page"></param>
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideMenuVisiable = page == ApplicationPage.Chat;
        }
    }
}
