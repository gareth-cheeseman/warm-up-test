using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace WarmUpTests
{
    public static class ElementCheck
    {
        public static bool IsElementVisible(this IWebDriver driver,string path, By by)
        {

            driver.Navigate().GoToUrl(path);

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible((by)));
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
