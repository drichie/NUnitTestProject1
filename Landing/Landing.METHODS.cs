using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;


namespace NUnitTestProject1
{
    public class Landing : Landing_CSS
    {
        IWebDriver driver;
        private Dashboard _dash;
        public Landing(IWebDriver driver)
        {
            this.driver = driver;
            _dash = new Dashboard(driver);
        }

        public void GoToLandingPage()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //IWebElement SignInBtn = driver.FindElement(By.Id(IdSubmitBtn));
            //Assert.IsTrue(SignInBtn.Displayed);
        }
        public void ClickSignInLink()
        {
            driver.FindElement(By.ClassName(SignInLink)).Click();
        }

        public void EnterEmail(string EmailAd)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id(IdEmail)).SendKeys(EmailAd);
           
        }
        public void EnterPass(string Pass)
        {
            driver.FindElement(By.Id(IdPass)).SendKeys(Pass); ;
        }

        public void ClickSubmitLogin()
        {
            driver.FindElement(By.Id(IdSubmitBtn)).Click();
        }

        public Dashboard UserSignIn()
        {
            EnterEmail(EmailAd);
            EnterPass(Pass);
            ClickSubmitLogin();
            return new Dashboard(this.driver);
        }
        public void LoginCredentialsExcel()
        {
            List<string> data = new List<string>();
            data = Servers.general.loadCsvFile(Fpath);
            for(int i = 0;i<data.Count;i++)
            {
                var values = data[i].Split(Dlimiter);
                EnterEmail(values[0]);
                EnterPass(values[1]);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                ClickSubmitLogin();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _dash.ClickSignOut();
            }
        }
    }
}
