﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Threading;

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


        private ObservableCollection<BitmapSource> photos_;

        public ObservableCollection<BitmapSource> Photos
        {
            get { return photos_; }
            set { photos_ = value; OnPropertyChanged(nameof(Photos)); }
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


        public CuriosityViewModel() : base()
        {
            try
            {
                SeePhotos = new RelayCommand(() => execute(), true);
                Cameras = new ObservableCollection<string>();
                Cameras.Add("Front Hazard Avoidance Cam");
                Cameras.Add("Rear Hazard Avoidance Cam");
                Cameras.Add("Mast Cam");
                SelectedCamera = 0;
                
            }
            catch(Exception ex)
            {
                Logs logs = new Logs();
                logs.writeException(ex);
            }
        }
        async Task execute()
        {
            try
            {
                Photos = new ObservableCollection<BitmapSource>();
                Visibility1 = "Hidden";
                Visibility3 = "Hidden";
                Visibility2 = "Visible";
                
                var args = new Dictionary<string, string>();
                


                args.Add("earth_date", formatDate(SelectedDate));
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

                var request = HTTPRequest.createRequest($"{ ConfigurationSettings.AppSettings["Mars"].Trim() }", args);

                
                var data = await HTTPRequest.getData(request);

                var photos = JsonConvert.DeserializeObject<Photos>(data);


                if (photos.photos.Count != 0)
                {
                    foreach (var item in photos.photos)
                    {
                        Photos.Add(new BitmapImage(new Uri(item.img_src)));
                    }
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
    }
}
