using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Xunit;

namespace WarmUpTests
{
    public class ElementCheck : IClassFixture<ChromeDriverFixture>
    {
        private readonly ChromeDriverFixture _fixture;

        public ElementCheck(ChromeDriverFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [JsonFileData("data.json")]
        public void CheckElementExists(string url, string xpath, bool expectedResult)
        {
            _fixture.Driver.Navigate().GoToUrl(url);

            bool actualResult;

            try
            {
                var element = _fixture.Driver.FindElement(By.XPath(xpath));
                actualResult = element.Displayed;

            }
            catch (Exception)
            {
                actualResult = false;
            }

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
