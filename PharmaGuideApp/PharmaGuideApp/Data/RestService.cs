using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PharmaGuideApp.Models;
using System.Diagnostics;

namespace PharmaGuideApp.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<BrandInfo> BrandInfo { get; private set; }

        public RestService()
        {
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            //  client.DefaultRequestHeaders.Add( ("Content-Type", "application/json");

        }

        public async Task<List<BrandInfo>> GetBrandInfoAsync()
        {
            BrandInfo = new List<BrandInfo>();
            //// RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            //var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var baseUri = new Uri("http://10.0.3.2:80/infoapi/api/");

            var uri = new Uri(baseUri, "brandinfos/getallbrandinfos");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    BrandInfo = JsonConvert.DeserializeObject<List<BrandInfo>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return BrandInfo;
        }

        public async void SaveBrandInfoAsync(BrandInfo item, bool isNewItem = true)
        {
            var baseUri = new Uri("http://10.0.3.2:80/infoapi/api/");

            var uri = new Uri(baseUri, "brandinfos/PostBrandInfo");

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                //if (isNewItem)
                //{
                response = await client.PostAsync(uri, content);
                //  bool x =Convert.ToBoolean( response);
                //}
                //else
                //{
                //    response = await client.PutAsync(uri, content);
                //}
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
