using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace GoogleBrowser
{
    [TestFixture]
    public class BasicGoogleSearchTest
    {
        private IWebDriver driver;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability("browserstack.user", "verhellep1");
            capability.SetCapability("browserstack.key", "4qjcdestxzk8wYe6vppB");

            capability.SetCapability("browser", "IE");
            capability.SetCapability("browser_version", "11.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("resolution", "1280x1024");

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            SetDriverSettings(driver);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleSearch()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("google this and that" + Keys.Enter);
        }




        private void SetDriverSettings(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
        } 
    }
}
