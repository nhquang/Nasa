using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa.ViewModels
{
    
    
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedView;

        public BaseViewModel SelectedView
        {
            get { return _selectedView; }
            set { _selectedView = value; OnPropertyChanged(nameof(SelectedView)); }
        }


        private RelayCommand switchingViewCommand_;

        public RelayCommand SwitchingViewCommand
        {
            get { return switchingViewCommand_; }
            set { switchingViewCommand_ = value; }
        }
        


        public MainViewModel()
        {
            SwitchingViewCommand = new RelayCommand((a) => execute(a), true);
            SelectedView = new CuriosityViewModel();
        }
        void execute(object parameter)
        {
            switch ((string)parameter)
            {
                case "Curiosity":
                    SelectedView = new CuriosityViewModel();
                    break;
                case "APOD":
                    SelectedView = new APODViewModel();
                    break;
            }
        }
        
    }
}
