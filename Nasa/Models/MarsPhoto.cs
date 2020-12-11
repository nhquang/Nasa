using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    class Photos
    {
        private List<MarsPhoto> photos_;

        public List<MarsPhoto> photos
        {
            get { return photos_; }
            set { photos_ = value; }
        }

    }
    class MarsPhoto
    {
        public long id { get; set; }
        public long sol { get; set; }
        public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Rover rover { get; set; }
    }
    class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }

    }
    class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }

    }
}
