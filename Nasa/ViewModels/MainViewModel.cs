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
            SwitchingViewCommand = new RelayCommand((a) => curiosity(a), true);
            SelectedView = new CuriosityViewModel();
        }
        void curiosity(object parameter)
        {
            if (parameter.ToString().Equals("Curiosity"))
                SelectedView = new CuriosityViewModel();
            else if (parameter.ToString().Equals("Opportunity"))
                SelectedView = new OpporunityViewModel();
            else
                SelectedView = new SpiritViewModel();
        }
        
    }
}
