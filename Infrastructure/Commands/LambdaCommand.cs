using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Infrastructure.Commands
{
    class LambdaCommand : Base.Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> exicute, Func<object, bool> canExicute = null)
        {
            _execute = exicute ?? throw new ArgumentNullException(nameof(exicute));
            _canExecute = canExicute;
        }

        public override bool CanExecute(object parameter)
        {
            if (_canExecute != null) 
                return _canExecute(parameter);
            return true;
            //Сокращенная запись
            //return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter) => _execute?.Invoke(parameter);
       
    }
}
