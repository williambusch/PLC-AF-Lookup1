using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace PLC_AF_Lookup
{
    class PIWebAPIClient
    {
        private HttpClient client;
        //constructor
        public PIWebAPIClient(bool kerberos)
        {
            //kerberos authentication
            if (kerberos)
                client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            /*****basic authentication*************/
            else
            {
                client = new HttpClient();
                string authInfo = Convert.ToBase64String(Encoding.ASCII.GetBytes("william.busch:temp"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            }
            client.Timeout = new TimeSpan(0, 0, 60);
        }

        public async Task<JObject> GetAsync(string uri)
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = "Response status code does not indicate success: " + (int)response.StatusCode;
                throw new HttpRequestException(responseMessage + "\r\n" + content);
            }
            return JObject.Parse(content);
        }

        public async Task<JObject> PostAsync(string uri, string request)
        {
            HttpResponseMessage response = 
                await client.PostAsync(uri, new StringContent(request,Encoding.UTF8,"application/json"));
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = "Response status code does not indicate success: " + (int)response.StatusCode;
                throw new HttpRequestException(responseMessage + "\r\n" + content);
            }
            return JObject.Parse(content);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
