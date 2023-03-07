using DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace platformWebAPIs.SyncDataServices.http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpclient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpclient,IConfiguration configuration)
        {
            _httpclient = httpclient;
            _configuration = configuration;


        }
        public async Task SendplatformsCommand(PlatfromsReadDto readDto)
        {
            var httpContent =new StringContent(
                JsonSerializer.Serialize(readDto),
                Encoding.UTF8,
                "application/json");
            var response = await _httpclient.PostAsync($"{_configuration["commandServices"]}", httpContent);
            if(response.IsSuccessStatusCode)
                Console.WriteLine("--> sync post to command services was OK ! ");
            else
                Console.WriteLine("--> sync post to command services wasn't OK ");
        }
    }
}

