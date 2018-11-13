using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WarmUpTests
{
    public static class TestResult
    {
        public static bool ActualResult(this IWebDriver driver, TestType testType, string expression)
        {
            switch (testType)
            {
                case TestType.XPath:
                    return driver.IsElementVisible(expression);
                default:
                    return false;
            }
        }

    }
}
