using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Photos photos_;

        public Photos photos
        {
            get { return photos_; }
            set { photos_ = value; OnPropertyChanged(nameof(photos)); }
        }

        private RelayCommand command_;

        public RelayCommand Command
        {
            get { return command_; }
            set { command_ = value; }
        }


        public MainViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
