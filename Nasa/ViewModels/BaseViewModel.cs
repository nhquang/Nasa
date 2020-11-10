using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Nasa.ViewModels
{
    
    class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            Cameras = new ObservableCollection<string>();
            Cameras.Add("Front Hazard Avoidance Cam");
            Cameras.Add("Rear Hazard Avoidance Cam");
            Visibility1 = "Visible";
            Visibility2 = "Hidden";
            Visibility3 = "Hidden";
            
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

        private string visibility1_;

        public string Visibility1
        {
            get { return visibility1_; }
            set { visibility1_ = value; OnPropertyChanged(nameof(Visibility1)); }
        }

        private string visibility2_;

        public string Visibility2
        {
            get { return visibility2_; }
            set { visibility2_ = value; OnPropertyChanged(nameof(Visibility2)); }
        }

        private string visibility3_;

        public string Visibility3
        {
            get { return visibility3_; }
            set { visibility3_ = value; OnPropertyChanged(nameof(Visibility3)); }
        }

        private ObservableCollection<MarsPhoto> photoURLs_;

        protected ObservableCollection<MarsPhoto> PhotosURLs
        {
            get { return photoURLs_; }
            set { photoURLs_ = value; OnPropertyChanged(nameof(photoURLs_)); }
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
