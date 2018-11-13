using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Xunit;

namespace WarmUpTests
{
    public class Theory : IClassFixture<ClientFixture>
    {
        private readonly ClientFixture _fixture;

        public Theory(ClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [JsonFileData("data.json")]
        public void CheckPage(TestObject testObject)
        {
            object  actualResult; 

            switch (testObject.TestType)
            {
                case TestType.XPath:
                    actualResult =  _fixture.Driver.IsElementVisible(testObject.Path ,testObject.Expression); break;
                case TestType.HttpStatusCode:
                    actualResult = _fixture.HttpClient.CheckStatus(testObject.Path); break;
                default:
                    actualResult = false; break;
            }

            Assert.Equal(testObject.Expectation, actualResult);
        }

    }
}
