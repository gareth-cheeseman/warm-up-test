using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WarmUpTests
{
    public static class StatusCheck
    {
        public static long CheckStatus(this HttpClient httpClient, string path)
        {
            var response = httpClient.GetAsync(path).Result;
            return (long) response.StatusCode;
        }
    }
}

