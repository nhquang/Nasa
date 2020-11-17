using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Nasa.ViewModels
{
    class APODViewModel : BaseViewModel
    {
        public APODViewModel()
        {
            Command = new RelayCommand(() => this.execute(), true);
            APODURL = new BitmapImage();
        }
        private RelayCommand command_;

        public RelayCommand Command
        {
            get { return command_; }
            set { command_ = value; }
        }

        private string title_;

        public string Title
        {
            get { return title_; }
            set { title_ = value; OnPropertyChanged(nameof(Title)); }
        }

        private BitmapImage apodURL_;

        public BitmapImage APODURL
        {
            get { return apodURL_; }
            set { apodURL_ = value; OnPropertyChanged(nameof(APOD)); }
        }

        

        private async Task execute()
        {
            try
            {
                Visibility1 = "Hidden";
                Visibility3 = "Hidden";
                Visibility2 = "Visible";

                var args = new Dictionary<string, string>();

                args.Add("date", formatDate(SelectedDate));

                args.Add("api_key", Encryption.decryption(ConfigurationSettings.AppSettings["APIkey"].Trim()));

                var request = HTTPRequest.createRequest($"{ ConfigurationSettings.AppSettings["APOD"].Trim() }", args);

                var data = await HTTPRequest.getData(request);

                var apodObject = JsonConvert.DeserializeObject<APOD>(data);


                if (apodObject != null) APODURL = new BitmapImage(new Uri(apodObject.hdurl));
                else Visibility3 = "Visible";
                Visibility2 = "Hidden";

            }
            catch(Exception ex)
            {
                Logs logs = new Logs();
                logs.writeException(ex);
            }
        }
    }
}
