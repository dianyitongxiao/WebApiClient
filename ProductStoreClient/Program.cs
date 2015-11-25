using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunAsync().Wait();
            //RunAsync_Create().Wait();
            RunAsync_Update().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2614/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("Videoes/644F0096-0158-4C67-92C6-6A6E0A0FA2FD");
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        VideoDTO videoDTO = await response.Content.ReadAsAsync<VideoDTO>();
                        Console.Write(videoDTO.id);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
        }

        static async Task RunAsync_Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2614/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    VideoDTO video = new VideoDTO { title = "test-2", author = "shen", url = "http://www.baidu.com", conver = "conver", description = "", categoryId = "", views = 0, comments = 0 };
                    HttpResponseMessage response = await client.PostAsJsonAsync("Videoes", video);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        VideoDTO videoDTO = await response.Content.ReadAsAsync<VideoDTO>();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
        }

        static async Task RunAsync_Update()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2614/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    VideoDTO video = new VideoDTO { title = "shen-demo" };
                    HttpResponseMessage response = await client.PutAsJsonAsync("Videoes/ca161757-8196-4454-ae26-d0d70e9cb679", video);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        VideoDTO videoDTO = await response.Content.ReadAsAsync<VideoDTO>();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
        }

    }
}
