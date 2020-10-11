﻿using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// a base class to run any animation method when a boolean is set to true and reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperties<Parent, bool>
        where Parent: BaseAttachedProperties<Parent,bool>, new()
    {

        public bool FirstLoad { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get the framework element
            if (!(sender is FrameworkElement element))
                return;
            
            //don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            if (FirstLoad)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    element.Loaded -= onLoaded;

                    DoAnimation(element, (bool)value);

                    FirstLoad = false;
                };

                element.Loaded += onLoaded;
            }
            {
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// the animation method that is fired when the value changes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        { 
            
        }
    }

    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }
}