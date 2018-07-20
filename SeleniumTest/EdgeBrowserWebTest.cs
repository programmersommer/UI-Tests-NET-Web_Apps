using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class EdgeBrowserWebTest
    {

        // Install NuGet packages Selenium.WebDriver and SeleniumExtras.WaitHelpers

        [TestMethod]
        public void TestWebSite()
        {
            try
            {
                using (var driver = new EdgeDriver(@"D:\AutomationUI-master\SeleniumTest"))
                {
                    driver.Navigate().GoToUrl
                        (@"https://www.onliner.by/");
                    var link = driver.FindElement(By.PartialLinkText("Публичный"));
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
                    screenshot.SaveAsFile(@"D:\screen.png", ScreenshotImageFormat.Png);
                }
            }
            catch (Exception ee)
            {

            }
        }
    }
}
