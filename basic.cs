using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestProject1
{
    public class basic
    {
        IWebDriver driver; 

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver("C:/Users/ACER/Documents/files/session");
        }

        [Test]
        public void UserSignIn()
        {
            driver.Navigate().GoToUrl("https://cisdev.racami.com/CISDEV7/login/acompany");
            driver.FindElement(By.Id("inputUsername")).SendKeys("drichie");
            driver.FindElement(By.Id("inputPassword")).SendKeys("Testing!123"); 
            driver.FindElement(By.Id("btnSignIn")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[type='text']")).SendKeys("Acompany");
            driver.FindElement(By.XPath("span[contains(text(), 'Search')]]")).Click();
            driver.FindElement(By.CssSelector("span[innerText='Go']")).Click();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
