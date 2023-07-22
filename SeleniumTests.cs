using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace SeleniumTests
{
    public class SeleniumTests
    {

        private const string url = "https://taskboard--ivabg.repl.co/";
        private WebDriver driver;
        private char @class;

        [OneTimeSetUp]
        public void OpenBrowser()
        {

            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [Test]
        public void Test_Assert_The_First_Task_From_The_Board()
        {
            
            driver.Navigate().GoToUrl(url);
            var taskBoard = driver.FindElement(By.XPath("//a[@href='/boards']"));
            taskBoard.Click();

          
            var titleCell = driver.FindElement(By.XPath("//td[contains(.,'Project skeleton')]"));
            Assert.That(titleCell.Text, Is.EqualTo("Project skeleton"));
        
        }

        [Test]
        public void Test_Search_Task_HomePage()
        {
            
            driver.Navigate().GoToUrl(url);
            var Search = driver.FindElement(By.XPath("//a[@href='/tasks/search']"));
            Search.Click();

            Thread.Sleep(500);

            
            var textBoxKeyword = driver.FindElement(By.XPath("//input[@id='keyword']"));
            textBoxKeyword.SendKeys("home");

            var buttonSearch = driver.FindElement(By.XPath("//button[@id='search']"));
            buttonSearch.Click();

            
            var title = driver.FindElement(By.XPath("//td[contains(.,'Home page')]"));
            Assert.That(title.Text, Is.EqualTo("Home page"));

           
        }

        [Test]
        public void Test_Search_Non_existing_Task()
        {
            driver.Navigate().GoToUrl(url);
            var Search = driver.FindElement(By.XPath("//a[@href='/tasks/search']"));
            Search.Click();

            Thread.Sleep(500);


            var textBoxKeyword = driver.FindElement(By.Id("keyword"));
            textBoxKeyword.SendKeys("missing{randnum}");

            var buttonSearch = driver.FindElement(By.CssSelector("button#search"));
            buttonSearch.Click();

            
            var searchResults = driver.FindElement(By.CssSelector("div#searchResult"));
            Assert.That(searchResults.Text, Is.EqualTo("No tasks found."));
        }

        [Test]
        public void Test_Create_InvalidTask()
        {
            
            driver.Navigate().GoToUrl(url);
            var create = driver.FindElement(By.PartialLinkText("Create"));
            create.Click();

            Thread.Sleep(500);

            var buttonCreate = driver.FindElement(By.CssSelector("button#create"));
            buttonCreate.Click();
            var errorMsg = driver.FindElement(By.CssSelector("div.err"));
            Assert.That(errorMsg.Text, Is.EqualTo("Error: Title cannot be empty!"));
        }


        [Test]
        public void Test_CreateNew_Task()
        {
            
            driver.Navigate().GoToUrl(url);
            var create = driver.FindElement(By.PartialLinkText("Create"));
            create.Click();

            Thread.Sleep(500);
            
            
            

           
            var titleBox = driver.FindElement(By.CssSelector("input#title"));
            titleBox.Clear();
            titleBox.SendKeys("New Task");

            var text = driver.FindElement(By.CssSelector("textarea#description"));
            text.Clear();
            text.SendKeys("New Task Description");


            var buttonCreate = driver.FindElement(By.CssSelector("button#create"));
            buttonCreate.Click();

            
            var all_tasks = driver.FindElements(By.XPath("/html/body/main/div/div[1]"));
            var lastTask = all_tasks.Last();

            var title_field = lastTask.FindElement(By.CssSelector("tr.title > td"));
            Assert.That(title_field.Text, Is.EqualTo("New Task"));

            var description_box = lastTask.FindElement(By.CssSelector("tr.description > td"));
            Assert.That(description_box.Text, Is.EqualTo("New Task Description"));

        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            this.driver.Quit();
        }
    }
}



