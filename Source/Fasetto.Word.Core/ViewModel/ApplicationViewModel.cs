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
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.LoginPage;

        public bool SideMenuVisiable { get; set; } = false;
    }
}
