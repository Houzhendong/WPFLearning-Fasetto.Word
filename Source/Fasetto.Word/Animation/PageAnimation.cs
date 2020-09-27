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

    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //add slide form right animation
            sb.AddFadeIn(seconds);

            //start animation
            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //create a storyboard
            var sb = new Storyboard();

            //add slide form right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //add slide form right animation
            sb.AddFadeOut(seconds);

            //start animation
            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            //wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
