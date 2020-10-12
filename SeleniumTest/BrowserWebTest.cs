using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class BrowserWebTest
    {

        // Install NuGet packages Selenium.WebDriver and SeleniumExtras.WaitHelpers
        // Download driver 
        // for Chrome from https://sites.google.com/a/chromium.org/chromedriver/
        // for Edge from https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
        // for Mozilla from https://github.com/mozilla/geckodriver/releases

        [TestMethod]
        public void TestWebSite()
        {
            try
            {
                // you can use EdgeDriver or FirefoxDriver
                using (var driver = new ChromeDriver(Directory.GetCurrentDirectory()))
                {
                    driver.Navigate().GoToUrl(@"https://thecodinglove.com/");
                    var link = driver.FindElement(By.PartialLinkText("Next"));
                    var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
                    ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);

                    // install DotNetSeleniumExtras.WaitHelpers NuGet package
                    var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(link));
                    link.Click();

                    // hack to wait until page loaded
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("p")));
                    var screenshot = driver.GetScreenshot();

                    // .NET Core does not support image manipulation, so only Portable Network Graphics(PNG) format is supported
                    screenshot.SaveAsFile("ScreenShot1.png", ScreenshotImageFormat.Png);
                }
            }
            catch (Exception ee)
            {
                Assert.Fail(ee.Message);
            }
        }
    }
}
