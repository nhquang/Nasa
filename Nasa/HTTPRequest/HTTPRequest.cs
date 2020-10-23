using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nasa
{
    static class HTTPRequest
    {
        
        /// <summary>
        /// Creates a HTTP request based on URI and parameters
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static HttpWebRequest createRequest(string URI, Dictionary<string,string> parameters)
        {

            try
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (i == 0) URI += "?";
                    else URI += "&";

                    URI += parameters.ElementAt(i).Key + "=" + parameters.ElementAt(i).Value;
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

        /// <summary>
        /// Sends the request, and waits for the response
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<List<MarsPhoto>> getData(HttpWebRequest request)
        {
            List<MarsPhoto> marsPhoto = null;
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                        {
                            var jsonResponse = await sr.ReadToEndAsync();
                            marsPhoto = JsonConvert.DeserializeObject<List<MarsPhoto>>(jsonResponse);
                            sr.Close();
                        }
                        stream.Close();
                    }
                    response.Close();
                }
                return marsPhoto;
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
