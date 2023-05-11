using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;


namespace MichaelTest
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private PageElements pageElements;

        private const string _keyboard = "keyabord";
        private const string _french = "french";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            pageElements = new PageElements();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1OpenAmazonPageAndSearchForKeyBoard()
        {
            driver.Navigate().GoToUrl(MainPageElements.WebUnderTest);
            Thread.Sleep(TimeSpan.FromSeconds(TimeOut.TimeOutBeforeTest));
            ActionPage.UserTapsOnTheSearchField(driver, pageElements, wait);
            ActionPage.UserTapsSendTextKeyboard(driver, pageElements, wait, _keyboard);
            ActionPage.UserTapsOnTheSearchSubmitButton(driver, pageElements, wait);
            string price = ActionPage.GetFirstPriceTextToLog(driver, pageElements, wait);
            ActionPage.PopUP(driver, price);
            Thread.Sleep(TimeSpan.FromSeconds(TimeOut.TimeOutAfterClick));
        }

        [Test]
        public void Test2OpenAmazonPageAndSearchForFrance()
        {
            driver.Navigate().GoToUrl(MainPageElements.WebUnderTest);
            Thread.Sleep(TimeSpan.FromSeconds(TimeOut.TimeOutBeforeTest));
            ActionPage.UserTapsOnTheSearchField(driver, pageElements, wait);
            ActionPage.UserTapsSendTextFrance(driver, pageElements, wait, _french);
            ActionPage.UserTapsOnTheSearchSubmitButton(driver, pageElements, wait);
            string price = ActionPage.GetFirstPriceTextToLog(driver, pageElements, wait); // i have some issue with x path sorry i don't have time to fix it
            ActionPage.PopUP(driver, price);
            Thread.Sleep(TimeSpan.FromSeconds(TimeOut.TimeOutAfterClick));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
