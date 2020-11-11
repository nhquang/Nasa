using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Nasa.ViewModels
{
    class CuriosityViewModel : BaseViewModel
    {
        private RelayCommand seePhotos_;

        public RelayCommand SeePhotos
        {
            get { return seePhotos_; }
            set { seePhotos_ = value; }
        }

        public CuriosityViewModel() : base()
        {
            SeePhotos = new RelayCommand(() => execute(), true);
            Cameras.Add("Mast Cam");
            SelectedCamera = 0;
            SelectedDate = "10/12/2020 12:00:00 AM";

        }
        async Task execute()
        {
            Visibility1 = "Hidden";
            Visibility3 = "Hidden";
            Photos = new ObservableCollection<string>();
            var args = new Dictionary<string, string>();
            var parts = SelectedDate.Split(' ').ToList()[0].Split('/');
            
            
            args.Add("earth_date", $"{parts[2]}-{parts[0]}-{parts[1]}");
            switch (SelectedCamera)
            {
                case 0:
                    args.Add("camera", "FHAZ");
                    break;
                case 1:
                    args.Add("camera", "RHAZ");
                    break;
                case 2:
                    args.Add("camera", "MAST");
                    break;
            }
            args.Add("api_key", Encryption.decryption(ConfigurationSettings.AppSettings["APIkey"].Trim()));
            
            var request = HTTPRequest.createRequest($"{ ConfigurationSettings.AppSettings["root"].Trim() }curiosity/photos", args);

            Visibility2 = "Visible";
            var data = await HTTPRequest.getData(request);
            
            var photos = JsonConvert.DeserializeObject<Photos>(data);


            if (photos.photos.Count != 0)
                Photos = new ObservableCollection<string>(photos.photos.Select(i => i.img_src));
            else { Visibility3 = "Visible"; }

            Visibility2 = "Hidden";
            
        }
    }
}
