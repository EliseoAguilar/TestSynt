using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestSyntCli.Models;

namespace TestSyntCli
{
    public class ApiClient : IApiClient
    {

        private readonly ILogger<ApiClient> logger;

        private readonly HttpClient httpClient;

        public ApiClient(ILogger<ApiClient> logger)
        {
            this.logger = logger;
            httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            //response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<MessageModel> PostAsync<T>(Uri requestUrl, T content)
        {
            var response = await httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            //response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MessageModel>(data);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
