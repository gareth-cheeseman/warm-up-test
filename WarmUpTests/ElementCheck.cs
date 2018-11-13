using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WarmUpTests
{
    public static class ElementCheck
    {
        public static bool IsElementVisible(this IWebDriver driver, string expression)
        {
           
            try
            {
                var element = driver.FindElement(By.XPath(expression));
                return element.Displayed;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
