using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Animation helper for <see cref="StoryBorad"/>
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">the storyboard to add animation to</param>
        /// <param name="seconds">the time animation will take</param>
        /// <param name="offset">the distance to right to start from</param>
        /// <param name="deceleration">the rate of leceleration</param>
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">the storyboard to add animation to</param>
        /// <param name="seconds">the time animation will take</param>
        /// <param name="offset">the distance to right to start from</param>
        /// <param name="deceleration">the rate of leceleration</param>
        public static void AddSlideFromLeft(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }


        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">the storyboard to add animation to</param>
        /// <param name="seconds">the time animation will take</param>
        public static void AddFadeIn(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">the storyboard to add animation to</param>
        /// <param name="seconds">the time animation will take</param>
        /// <param name="offset">the distance to right to start from</param>
        /// <param name="deceleration">the rate of leceleration</param>
        public static void AddSlideToLeft(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = deceleration,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        public static void AddSlideToRight(this Storyboard storyBoard, float seconds, double offset, float deceleration = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = deceleration,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">the storyboard to add animation to</param>
        /// <param name="seconds">the time animation will take</param>
        public static void AddFadeOut(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }
    }
}
