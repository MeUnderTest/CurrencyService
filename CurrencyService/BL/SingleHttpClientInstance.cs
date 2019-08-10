using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CurrencyService.BL
{
    public class SingleHttpClientInstance
    {
        private static readonly HttpClient httpClient;

        static SingleHttpClientInstance()
        {
            httpClient = new HttpClient();
        }

        public static async Task PostStreamAsync<T>(object content, Uri url, CancellationToken token)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        while (!token.IsCancellationRequested)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();

                            //T rateResponse = JsonConvert.DeserializeObject<T>(jsonResponse);

                            //Console.WriteLine(rateResponse.data.CurrentInterbankRate);

                            await Task.Delay(1000);
                        }
                        throw new TaskCanceledException();
                    }

                }
            }
        }

        public static async Task PostStreamAsync<T>(object content, Uri url)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            using (var httpContent = CreateHttpContent(content))
            {
                request.Content = httpContent;

                using (var response = await httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        // Save to DB
                    }

                }
            }
        }

        private static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }
    }
}