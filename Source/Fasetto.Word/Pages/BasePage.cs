using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using Fasetto.Word.Core;
using System.Windows.Media;

namespace Fasetto.Word
{
    public class BasePage : UserControl 
    { 
        /// <summary>
        /// the view model associated with this page
        /// </summary>
        private object viewModel;

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
        /// a flag to indicate if theis page should animate out on load
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// the view model associated with this page
        /// </summary>
        public object ViewModelObject
        { 
            get 
            {
                return this.viewModel; 
            }
            set
            {
                if (viewModel == value)
                    return;
                viewModel = value;

                OnViewModelChanged();

                DataContext = viewModel;
            }
        }

        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //listen out for the page loading
            this.Loaded += BasePage_Loaded;
        }

        #region Animation Load / Unload
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimatOut();
            else
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

        protected virtual void OnViewModelChanged() { }
    }

    public class BasePage<VM> : BasePage
        where VM : BaseViewModel , new()
    {
        #region Private Member

        #endregion

        #region Public Properties

        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        public BasePage() : base()
        {
            ViewModel = IoC.Get<VM>();
        }

        public BasePage(VM viewModel) : base()
        {
            if (viewModel != null)
            {
                ViewModel = viewModel;
            }
            else
            {
                ViewModel = IoC.Get<VM>();
            }
        }
        #endregion
    }
}
