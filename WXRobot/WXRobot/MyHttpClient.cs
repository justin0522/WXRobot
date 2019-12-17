using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using WXRobot.Models;

namespace WXRobot
{
    class MyHttpClient
    {
        private readonly EventLog _logger = new EventLog("Application", Environment.MachineName, "WXRobot");
        private readonly HttpClient _client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
        public MyHttpClient()
        {

        }

        public void Send(string url, RobotMessage message)
        {
            try
            {
                string json = JsonConvert.SerializeObject(message, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                var result = _client.PostAsync(url, new StringContent(json)).Result;
            }
            catch (Exception ex)
            {
                _logger.WriteEntry(ex.ToString());
            }
        }
    }
}
