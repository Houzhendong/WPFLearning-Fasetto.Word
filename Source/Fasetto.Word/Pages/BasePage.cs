using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel , new()
    {
        #region Private Member

        /// <summary>
        /// the view model associated with this page
        /// </summary>
        private VM viewModel;

        #endregion
        #region Public Properties
        /// <summary>
        /// the animation the play the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// the animation the play the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// the any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// the view model associated with this page
        /// </summary>
        public VM ViewModel
        { 
            get 
            {
                return this.viewModel; 
            }
            set
            {
                if (viewModel == value)
                    return;
                this.viewModel = value;

                this.DataContext = viewModel;
            }
        }

        #endregion

        #region Constructor
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //listen out for the page loading
            this.Loaded += BasePage_Loaded;

            this.ViewModel= new VM();
        }
        #endregion

        #region Animation Load / Unload
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimatIn();
        }

        public async Task AnimatIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }

        public async Task AnimatOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
