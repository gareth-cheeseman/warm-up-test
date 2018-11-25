using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Xunit;

namespace WarmUpTests
{
    public class Theory : IClassFixture<Fixture>
    {
        private readonly Fixture _fixture;

        public Theory(Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [JsonFileData("data.json")]
        public void CheckPage(TestObject testObject)
        {
            object  actualResult;
            var completeUrl = _fixture.BaseUrl + testObject.Path;

            switch (testObject.TestType)
            {
                case TestType.CssSelector:
                    actualResult = _fixture.Driver.IsElementVisible(completeUrl, testObject.Expression.CssSelector()); break;
                case TestType.XPath:
                    actualResult =  _fixture.Driver.IsElementVisible(completeUrl, testObject.Expression.XPath()); break;
                case TestType.HttpStatusCode:
                    actualResult = _fixture.HttpClient.CheckStatus(completeUrl); break;
                default:
                    actualResult = false; break;
            }

            Assert.Equal(testObject.Expectation, actualResult);
        }

    }
}
