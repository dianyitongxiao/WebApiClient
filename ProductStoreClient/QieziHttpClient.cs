using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductStoreClient
{
    public static class QieziHttpClient<T>
    {
        private static HttpClient client;
        private static T model;

        static QieziHttpClient()
        {
            model = default(T);
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2614/");
        }

        private static void Init()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T Get(string requestUri)
        {
            model = default(T);
            RunAsync_Get(requestUri).Wait();
            return model;
        }

        private static async Task RunAsync_Get(string requestUri)
        {
            try
            {
                Init();
                HttpResponseMessage response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    model = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception ex)
            {
                //todo:log
            }
        }

        public static T Post(string requestUri, T modelView)
        {
            model = default(T);
            RunAsync_Post(requestUri, modelView).Wait();
            return model;
        }

        private static async Task RunAsync_Post(string requestUri, T modelView)
        {
            try
            {
                Init();
                HttpResponseMessage response = await client.PostAsJsonAsync(requestUri, modelView);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception ex)
            {
                //todo:log
            }
        }

        public static T Put(string requestUri, T modelView)
        {
            model = default(T);
            RunAsync_Put(requestUri, modelView).Wait();
            return model;
        }

        private static async Task RunAsync_Put(string requestUri, T modelView)
        {
            try
            {
                Init();
                HttpResponseMessage response = await client.PutAsJsonAsync(requestUri, modelView);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    model = await response.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception ex)
            {
                //todo:log
            }
        }
    }
}
