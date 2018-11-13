using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WarmUpTests
{
    public class ChromeDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; }
        public HttpClient HttpClient { get; }

        public ChromeDriverFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");
            Driver = new ChromeDriver();

            HttpClient = new HttpClient();
        }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
