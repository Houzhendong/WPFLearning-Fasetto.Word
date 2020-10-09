using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// locates view models from the IoC for us in bindging in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// the aplication view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
