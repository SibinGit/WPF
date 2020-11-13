using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_MVVM_Template.Commands
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            execute?.Invoke(parameter);
        }
    }
}
