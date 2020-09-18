using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// a base attached property to replace the vanilla WPF attached property
    /// </summary>
    /// <typeparam name="PropertyClass">the parent class to be the attached property</typeparam>
    /// <typeparam name="PropertyType">the type of this attached property</typeparam>
    public abstract class BaseAttachedProperties<PropertyClass, PropertyType>
        where PropertyClass : BaseAttachedProperties<PropertyClass,PropertyType>, new ()
    {

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// a singleton instance of our parent class
        /// </summary>
        public static PropertyClass Instance { get; set; } = new PropertyClass();

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(PropertyType), typeof(BaseAttachedProperties<PropertyClass, PropertyType>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChaned)));

        private static void OnValuePropertyChaned(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);

            Instance.ValueChanged(d, e);
        }

        public static PropertyType GetValue(DependencyObject d) => (PropertyType)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, PropertyType value) => d.SetValue(ValueProperty, value);

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
    }

}
