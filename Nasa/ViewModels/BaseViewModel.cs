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
            
            Visibility1 = "Visible";
            Visibility2 = "Hidden";
            Visibility3 = "Hidden";
            SelectedDate = $"{DateTime.Now.Month}/{DateTime.Now.Day - 1}/{DateTime.Now.Year} 12:00:00 AM";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        
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

        
        private string selectedDate_;

        public string SelectedDate
        {
            get { return selectedDate_; }
            set { selectedDate_ = value; OnPropertyChanged(nameof(SelectedDate)); }
        }

        public string formatDate(string date)
        {
            var parts = date.Split(' ').ToList()[0].Split('/');

            return new StringBuilder($"{parts[2]}-{parts[0]}-{parts[1]}").ToString();
        }
    }
}
