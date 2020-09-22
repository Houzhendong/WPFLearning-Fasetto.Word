using System;
using System.Reflection;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class RelayParameterizedCommand : ICommand
    {
        private Action<object> action;

        public RelayParameterizedCommand(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// the event that is fired when the <see cref="CanExecute(object)"/>value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
