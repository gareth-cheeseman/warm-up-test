using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WarmUpTests
{
    public static class ElementCheck
    {
        public static bool IsElementVisible(this IWebDriver driver,string path, By by)
        {

            driver.Navigate().GoToUrl(path);

            try
            {
                var element = driver.FindElement(by);
                return element.Displayed;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
