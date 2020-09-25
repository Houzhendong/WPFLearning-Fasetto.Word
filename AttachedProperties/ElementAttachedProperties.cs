
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class ElementAttachedProperties
    {
        public static readonly DependencyProperty MouseMoveCommandProperty =
            DependencyProperty.RegisterAttached("MouseMoveCommand", 
                typeof(ICommand), typeof(ElementAttachedProperties),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(MouseMoveCommandChanged)));

        public static void MouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;

            element.MouseMove += Element_MouseMove;
        }

        private static void Element_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;

            ICommand command = GetMouseMoveCommand(element);

            command.Execute(e.GetPosition(element));
        }

        public static void SetMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseMoveCommandProperty, value);
        }

        public static ICommand GetMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseMoveCommandProperty);
        }
    }
}
