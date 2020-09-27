using System;
using System.Reflection;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class RelayCommand : ICommand
    {
        private Action action;

        public RelayCommand(Action a)
        {
            action = a;
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
            action();
        }
    }
}
