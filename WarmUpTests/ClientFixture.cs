using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WarmUpTests
{
    public class ClientFixture : IDisposable
    {
        public IWebDriver Driver { get; }
        public HttpClient HttpClient { get; }
        public string BaseUrl { get; }

        public ClientFixture()
        {
            using (var file = File.OpenText("Properties\\launchSettings.json"))
            {
                var reader = new JsonTextReader(file);
                var jObject = JObject.Load(reader);

                var variables = jObject
                    .GetValue("profiles")
                    //select a proper profile here
                    .SelectMany(profiles => profiles.Children())
                    .SelectMany(profile => profile.Children<JProperty>())
                    .Where(prop => prop.Name == "environmentVariables")
                    .SelectMany(prop => prop.Value.Children<JProperty>())
                    .ToList();

                foreach (var variable in variables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }

            BaseUrl = Environment.GetEnvironmentVariable("BaseUrl");

            var options = new ChromeOptions();
            options.AddArgument("headless");
            Driver = new ChromeDriver(options);

            HttpClient = new HttpClient();
        }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
