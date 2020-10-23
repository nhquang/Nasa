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
        private ObservableCollection<MarsPhoto> marsPhotos_;

        public ObservableCollection<MarsPhoto> MarsPhotos
        {
            get { return marsPhotos_; }
            set { marsPhotos_ = value; }
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
