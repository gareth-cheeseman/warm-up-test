using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WarmUpTests
{
    public static class SelectorMethods
    {
        public static By XPath(this string expression)
        {
            return By.XPath(expression);
        }

        public static By CssSelector(this string expression)
        {
            return By.CssSelector(expression);
        }
    }
}
