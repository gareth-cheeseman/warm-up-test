using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WarmUpTests
{
    public class ChromeDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; }

        public ChromeDriverFixture()
        {
            var options = new ChromeOptions();
                options.AddArgument("headless");
            
            Driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
