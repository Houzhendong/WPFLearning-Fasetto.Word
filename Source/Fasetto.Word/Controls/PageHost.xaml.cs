using System;
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
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// Register <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPageProertyChanged));

        /// <summary>
        /// called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPageProertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //remove current page from new page frame
            newPageFrame.Content = null;

            //move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            //animate out previous page
            if (oldPageContent is BasePage oldPage)
                oldPage.ShouldAnimateOut = true;

            //set the new page content
            newPageFrame.Content = e.NewValue;
        }

        public PageHost()
        {
            InitializeComponent();

        }
    }
}
