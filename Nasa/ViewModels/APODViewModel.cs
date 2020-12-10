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
            clickedLink = new RelayCommand(() => this.clicked(), true);
            APODURL = new BitmapImage();

            HDURL = string.Empty;
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

        public RelayCommand clickedLink
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


        private void clicked()
        {
            Process.Start(HDURL);
        }

        private async Task execute()
        {
            try
            {
                APODURL = new BitmapImage();
                Visibility1 = "Hidden";
                Visibility3 = "Hidden";
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

            }
            catch(Exception ex)
            {
                Logs logs = new Logs();
                logs.writeException(ex);
                Visibility3 = "Visible";
                Visibility2 = "Hidden";
            }
        }
        async Task<BitmapSource> FetchImage(string URLlink)
        {
            try
            {
                BitmapSource bitmapSource = null;
                await Task.Run(() => {
                    
                    var temp = new JpegBitmapDecoder(new Uri(URLlink, UriKind.Absolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    bitmapSource = temp.Frames[0];
                    bitmapSource.Freeze();
                    
                });
                return bitmapSource;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
