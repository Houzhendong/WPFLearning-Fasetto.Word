using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    public enum PageAnimation
    {
        None = 0,

        /// <summary>
        /// the page slides in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// the page slides out and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft = 2,
    }

    public static class FrameworkElementAnimations
    {

        #region Slide In From Left
        
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideFromLeft(seconds, element.ActualWidth,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideToLeft(seconds, element.ActualWidth,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide In From Right

        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideFromRight(seconds, element.ActualWidth,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideToRight(seconds, element.ActualWidth,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide In From Bottom 

        public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideFromBottom(seconds, element.ActualHeight,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideToBottom(seconds, element.ActualHeight,keepMargin : keepMargin);

            //add slide form right animation
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion
    
        #region Fade In/Out 

        public static async Task FadeIn(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task FadeOut(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));

            element.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
