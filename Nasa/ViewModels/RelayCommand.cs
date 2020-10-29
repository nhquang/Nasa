using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nasa.ViewModels
{
    class RelayCommand : ICommand
    {
        private Action<object> actionWithParam_;
        private Action action_;
        private bool canExecute_;
        public RelayCommand(Action<object> action, bool canExecute)
        {
            actionWithParam_ = action;
            canExecute_ = canExecute;
        }
        public RelayCommand(Action action, bool canExecute)
        {
            action_ = action;
            canExecute_ = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute_;
        }

        public void Execute(object parameter)
        {
            if (actionWithParam_ != null)
                actionWithParam_(parameter);
            else
                action_();
        }
    }
}
