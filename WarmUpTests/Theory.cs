using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Xunit;

namespace WarmUpTests
{
    public class Theory : IClassFixture<ChromeDriverFixture>
    {
        private readonly ChromeDriverFixture _fixture;

        public Theory(ChromeDriverFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [JsonFileData("data.json")]
        public void CheckElementExists(string url, TestType type, string xpath, bool expectedResult)
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



        [Theory]
        [JsonFileData("data.json")]
        public void CheckElementExists2(TestObject testObject)
        {
            _fixture.Driver.Navigate().GoToUrl(testObject.Path);
            var actualResult = _fixture.Driver.ActualResult(testObject.TestType, testObject.Expression);
            Assert.Equal(testObject.Expectation, actualResult);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new TestObject("Shop", TestType.XPath, "https://shop.edintattoo.co.uk", true,
                        "//h1[contains(text(), 'Shop')]")
                },

                new object[]
                {
                    new TestObject("Shop", TestType.XPath, "https://shop.edintattoo.co.uk", false,
                        "//h1[contains(text(), 'Shop')]")
                }
            };

    }
}
