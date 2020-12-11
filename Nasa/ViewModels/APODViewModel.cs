using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Nasa.ViewModels
{
    class APODViewModel : BaseViewModel
    {

        public APODViewModel()
        {
            Command = new RelayCommand(() => this.execute(), true);
            ClickedLink = new RelayCommand((a) => this.click(a), true);
            APODURL = new BitmapImage();


            LinkVisibility = "Hidden";
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

        private BitmapSource apodURL_;

        public BitmapSource APODURL
        {
            get { return apodURL_; }
            set { apodURL_ = value; OnPropertyChanged(nameof(APODURL)); }
        }

        private RelayCommand clickedLink_;

        public RelayCommand ClickedLink
        {
            get { return clickedLink_; }
            set { clickedLink_ = value; }
        }

        private string hdurl_;

        public string HDURL
        {
            get { return hdurl_; }
            set { hdurl_ = value; OnPropertyChanged(nameof(HDURL)); }
        }

        private string linkVisibility_;

        public string LinkVisibility
        {
            get { return linkVisibility_; }
            set { linkVisibility_ = value; OnPropertyChanged(nameof(LinkVisibility)); }
        }

        private void click(object param)
        {
            var temp = param as string;
            if(!string.IsNullOrEmpty(temp)) System.Diagnostics.Process.Start(temp);
        }

        private async Task execute()
        {
            try
            {
                APODURL = new BitmapImage();
                HDURL = string.Empty;
                Title = string.Empty;

                Visibility1 = "Hidden";
                Visibility3 = "Hidden";
                LinkVisibility = "Hidden";
                Visibility2 = "Visible";
                
                var args = new Dictionary<string, string>();

                args.Add("date", formatDate(SelectedDate));

                args.Add("api_key", Encryption.decryption(ConfigurationSettings.AppSettings["APIkey"].Trim()));

                var request = HTTPRequest.createRequest($"{ ConfigurationSettings.AppSettings["APOD"].Trim() }", args);

                var data = await HTTPRequest.getData(request);

                var apodObject = JsonConvert.DeserializeObject<APOD>(data);

                if (apodObject?.hdurl != null)
                {
                    APODURL = await FetchImage(apodObject.hdurl);

                    Title = apodObject.title;
                    HDURL = apodObject.hdurl;
                }
                else Visibility3 = "Visible";
                Visibility2 = "Hidden";
                LinkVisibility = "Visible";
            }
            catch(Exception ex)
            {
                Logs logs = new Logs();
                logs.writeException(ex);
                Visibility3 = "Visible";
                Visibility2 = "Hidden";
            }
        }
        
    }
}
