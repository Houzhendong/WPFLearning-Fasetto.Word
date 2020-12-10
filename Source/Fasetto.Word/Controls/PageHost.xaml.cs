using Fasetto.Word.Core;
using System;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// PageHost.xaml 的交互逻辑
    /// </summary>
    public partial class PageHost : UserControl
    {
        /// <summary>
        /// the current page to show in the page host
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get { return (ApplicationPage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// Register <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPageProertyChanged));



        public BaseViewModel CurrentPageViewModel
        {
            get { return (BaseViewModel)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPageViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(PageHost), new UIPropertyMetadata());



        /// <summary>
        /// called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        private static object CurrentPageProertyChanged(DependencyObject d, object value)
        {
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);


            //get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //If the current page hasn't changed,just update the view model
            if (newPageFrame.Content is BasePage page && page.ToApplicationPage() == currentPage)
            {
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            //store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //remove current page from new page frame
            newPageFrame.Content = null;

            //move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            //animate out previous page
            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;

                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }
            //set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel); 

            return value;
        }

        public PageHost()
        {
            InitializeComponent();

        }
    }
}
