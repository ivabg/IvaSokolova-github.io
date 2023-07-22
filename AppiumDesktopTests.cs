

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Linq;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
        private const string AppiumUrl = "http://127.0.0.1:4723/wd/hub";

        private const string appLocation = @"C:\Users\ivaso\Downloads\Retake-Exam-Taskboard-Resources\TaskBoard.DesktopClient.Net6"; 

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void Setup()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [Test]
        public void Test_Assert_The_Name_Open()
        {
            var changeUrl = driver.FindElementById("textBoxApiUrl");
            changeUrl.Clear();
            changeUrl.SendKeys("https://taskboard.iva.repl.co/api");
            var connect = driver.FindElementById("buttonConnect");
            connect.Click();
            var searchField = driver.FindElementById("textBoxSearchText");
            searchField.Clear();
            searchField.SendKeys("open");
            var search = driver.FindElementById("buttonSearch");
            search.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var result = driver.FindElementById("listViewTasks\"]/Group[@Name=\"Open");
            
            Assert.That(result.Text, Is.EqualTo("Open"));
            
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
