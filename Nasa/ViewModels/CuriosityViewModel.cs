using System;
using System.Collections.Generic;
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

        private string image_;

        public string Image
        {
            get { return image_; }
            set { image_ = value; OnPropertyChanged(nameof(Image)); }
        }
        



        public CuriosityViewModel()
        {
            SeePhotos = new RelayCommand(() => execute(), true);
            
        }
        async Task execute()
        {
            var args = new Dictionary<string, string>();
            args.Add("earth_date", "2020-10-22");
            args.Add("camera", "FHAZ");
            args.Add("api_key", Encryption.decryption(ConfigurationSettings.AppSettings["APIkey"].Trim()));
            
            var request = HTTPRequest.createRequest($"{ ConfigurationSettings.AppSettings["root"].Trim() }curiosity/photos", args);
            var data = await HTTPRequest.getData(request);
            
            var photos = JsonConvert.DeserializeObject<Photos>(data);
            Image = photos.photos[0].img_src;
            
        }
    }
}
