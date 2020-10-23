using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nasa
{
    class RelayCommand : ICommand
    {
        private Action action_;
        public RelayCommand(Action action)
        {
            action_ = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action_();
        }
    }
}
