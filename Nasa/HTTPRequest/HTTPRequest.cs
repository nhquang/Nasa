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
        /// <param name="URI">string</param>
        /// <param name="parameters">Dictionary</param>
        /// <returns name="HttpWebRequest"></returns>
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
        /// <param name="request">HttpWebRequest</param>
        /// <returns name="Task<string>"></returns>
        public static async Task<string> getData(HttpWebRequest request)
        {
            var jsonResponse = string.Empty;
            try
            {
                using (var response = await request.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                        {
                            jsonResponse = await sr.ReadToEndAsync();
                            sr.Close();
                        }
                        stream.Close();
                    }
                    response.Close();
                }
                return jsonResponse;
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        
    }
}
