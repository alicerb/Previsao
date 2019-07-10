using Amazon.Runtime;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Previsao.Api.Util
{
    public static class ApiClient
    {
        public static JObject GetResponse(String queryString)
        {
            using (var client = new WebClient())
            {
                var apiKey = ClientConfig.ApiKey;
                var apiUrl = ClientConfig.ApiUrl;
                Trace.WriteLine("<HTTP - GET - " + queryString + " >");
                string url;
                if (!string.IsNullOrEmpty(apiKey))
                    url = apiUrl + queryString + "&APPID=" + apiKey;
                else
                    url = apiUrl + queryString;

                var response = client.DownloadString(url);
                var parsedResponse = JObject.Parse(response);
                return parsedResponse;
            }
        }
    }
}
