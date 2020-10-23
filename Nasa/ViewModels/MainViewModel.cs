using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    class MainViewModel : BaseViewModel
    {
        

        private RelayCommand command_;

        public RelayCommand Command
        {
            get { return command_; }
            set { command_ = value; }
        }


        public MainViewModel()
        {

        }

        
    }
}
