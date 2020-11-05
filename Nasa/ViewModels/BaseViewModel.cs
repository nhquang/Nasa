using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa.ViewModels
{
    
    class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            Cameras = new ObservableCollection<string>();
            Cameras.Add("Front Hazard Avoidance Cam");
            Cameras.Add("Rear Hazard Avoidance Cam");
            Visibility = "Visible";
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        /*private DesignerSerializationVisibilityAttribute visibility_;

        public DesignerSerializationVisibilityAttribute Visibility
        {
            get { return visibility_; }
            set { visibility_ = value; OnPropertyChanged(nameof(Visibility)); }
        }*/

        private string visibility;

        public string Visibility
        {
            get { return visibility; }
            set { visibility = value; OnPropertyChanged(nameof(Visibility)); }
        }


        private Photos photos_;

        protected Photos photos
        {
            get { return photos_; }
            set { photos_ = value; OnPropertyChanged(nameof(photos)); }
        }
        private ObservableCollection<string> cameras_;

        public ObservableCollection<string> Cameras
        {
            get { return cameras_; }
            set { cameras_ = value; OnPropertyChanged(nameof(Cameras)); }
        }
        private int selectedCamera_;

        public int SelectedCamera
        {
            get { return selectedCamera_; }
            set { selectedCamera_ = value; OnPropertyChanged(nameof(SelectedCamera)); }
        }
        private string selectedDate_;

        public string SelectedDate
        {
            get { return selectedDate_; }
            set { selectedDate_ = value; OnPropertyChanged(nameof(SelectedDate)); }
        }
    }
}
