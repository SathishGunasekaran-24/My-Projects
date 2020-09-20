using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC_1
{
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();

        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44365/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}