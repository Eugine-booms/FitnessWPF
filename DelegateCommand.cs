using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessWPF
{
    public class DelegateCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
        public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
        {

        }
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFun)
        {
            canExecute = canExecuteFun;
            execute = executeAction;
        }
    }
}
