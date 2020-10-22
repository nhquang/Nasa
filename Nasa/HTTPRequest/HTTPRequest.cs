using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nasa
{
    class HTTPRequest
    {
        
        
        public static HttpWebRequest createRequest(string URI, Dictionary<string,string> parameters)
        {

            try
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (i == 0) URI += "?";
                    else URI += parameters.ElementAt(i).Key + "=" + parameters.ElementAt(i).Value;
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                
                

                request.Method = "GET";
                return request;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public static async void getData(HttpWebRequest request)
        {
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                        {
                            var jsonResponse = await sr.ReadToEndAsync();
                        }
                    }
                }
                
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
