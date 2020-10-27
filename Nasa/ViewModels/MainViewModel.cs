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


        private RelayCommand switchingToCuriosityViewCommand_;

        public RelayCommand SwitchingToCuriosityViewCommand
        {
            get { return switchingToCuriosityViewCommand_; }
            set { switchingToCuriosityViewCommand_ = value; }
        }
        private RelayCommand switchingToOpportunityViewCommand_;

        public RelayCommand SwitchingToOpportunityViewCommand
        {
            get { return switchingToOpportunityViewCommand_; }
            set { switchingToOpportunityViewCommand_ = value; }
        }
        private RelayCommand switchingToSpiritViewCommand_;

        public RelayCommand SwitchingToSpiritViewCommand
        {
            get { return switchingToSpiritViewCommand_; }
            set { switchingToSpiritViewCommand_ = value; }
        }


        public MainViewModel()
        {
            SwitchingToCuriosityViewCommand = new RelayCommand(() => curiosity());
            SwitchingToOpportunityViewCommand = new RelayCommand(() => opportunity());
            SwitchingToSpiritViewCommand = new RelayCommand(() => spirit());
            SelectedView = new CuriosityViewModel();
        }
        void curiosity()
        {
            SelectedView = new CuriosityViewModel();
        }
        void opportunity()
        {
            SelectedView = new OpporunityViewModel();
        }
        void spirit()
        {
            SelectedView = new SpiritViewModel();
        }
    }
}
