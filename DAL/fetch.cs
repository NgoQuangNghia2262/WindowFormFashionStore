using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class fetch
    {
        private static fetch instance;
        public static fetch Instance
        {
            get { if (instance == null) { instance = new fetch(); } return fetch.instance; }
            private set { fetch.instance = value; }
        }

        private fetch() { }
        private async Task<object> send(string url , HttpMethod method , object content = null)
        {
            using (HttpClient http = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage();
                req.Method = method;
                req.RequestUri = new Uri(url);
                if (content != null)
                {
                    string jsonData = JsonConvert.SerializeObject(content);
                    req.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }
                HttpResponseMessage res = await http.SendAsync(req);
                string resJson = await res.Content.ReadAsStringAsync();
                object obj = JsonConvert.DeserializeObject(resJson);
                return obj;
            }
        }
        public Task<object> Get(string url)
        {
            return send(url,HttpMethod.Get);
        }
        public Task<object> Post(string url , object content)
        {
            return send(url,HttpMethod.Post,content);
        }
        public Task<object> Put(string url, object content)
        {
            return send(url, HttpMethod.Put, content);
        }
        public Task<object> Delete(string url, object content)
        {
            return send(url, HttpMethod.Delete, content);
        }
    }
}
