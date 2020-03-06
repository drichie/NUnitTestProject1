using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace NUnitTestProject1
{
    public class Dashboard : Dashboard_CSS
    {
        IWebDriver driver;
        public Dashboard(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Landing ClickSignOut()
        {
            driver.FindElement(By.ClassName(ClassSignOut)).Click();
            return new Landing(this.driver);
        }
    }
}
