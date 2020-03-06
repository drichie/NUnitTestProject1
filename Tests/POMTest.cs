using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace NUnitTestProject1
{
    public class POMTest

    {
        IWebDriver driver;
        protected AventStack.ExtentReports.ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        protected void OneTimeSetup()
        {
            var dir = "C:\\Users\\ACER\\Documents\\files\\session\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _extent.Flush();
        }
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver("C:/Users/ACER/Documents/files/session");
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void PassingTest1()
        {
            driver.Url = "http://blog.testproject.io/";

            try
            {
                Assert.IsTrue(driver.Title.Contains("Blog"));
                _test.Pass("Assertion passed");
                _test.Log(Status.Pass, "Pass");
            }
            catch (AssertionException)
            {
                _test.Pass("Walang BLog na word");
                _test.Log(Status.Fail, "Fail");
                throw;
            }

        }
        [Test]
        public void FailedTest1()
        {
            driver.Url = "http://blog.testproject.io/";


            try
            {
                Assert.IsTrue(driver.Title.Contains("Rm"));
                _test.Pass("status pass,pass");
                _test.Log(Status.Pass, "Pass");
            }
            catch (AssertionException)
            {
                _test.Fail("status fail,fail");
                _test.Log(Status.Fail, "Fail");
                throw;
            }

        }
        [Test]
        public void LoginSingleUser()
        {
            Landing _landPage = new Landing(driver);
            _landPage.GoToLandingPage();
            _landPage.ClickSignInLink();
            _landPage.UserSignIn();

            Dashboard _dash = new Dashboard(driver);
            _dash.ClickSignOut();
            //IWebElement WelcomeMessage = driver.FindElement(By.ClassName("info-account"));
            //Assert.IsTrue(WelcomeMessage.Text.Contains("Welcome to your account"));
        }
        [Test]
        public void LoginMultipleUser()
        {
            Landing _landPage = new Landing(driver);
            _landPage.GoToLandingPage();
            _landPage.ClickSignInLink();
            _landPage.LoginCredentialsExcel();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}