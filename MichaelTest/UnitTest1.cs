using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; // Add this using statement
using SeleniumExtras.WaitHelpers; // Add this using statement
using NUnit.Framework;
using System;

namespace MichaelTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _acceptCookiesBottun = By.Id("onetrust-accept-btn-handler");
        private readonly By _mainManuLoginButton = By.Id("menu-item-64792");
        private readonly By _emailField = By.Name("email");
        private readonly By _passwordField = By.Name("password");
        private readonly By _loginPageLoginButton = By.CssSelector("body > div > div.login-container > div.login-view > form > div.login-footer > button");

        private const string _login = "micorlov@gmail.com";
        private const string _password = "Mio102030!!";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.is.com/");
        }

        [Test]
        public void Test1()
        {
            var acceptCookiesBottun = driver.FindElement(_acceptCookiesBottun);
            acceptCookiesBottun.Click();

            var mainManuLoginButton = driver.FindElement(_mainManuLoginButton);
            mainManuLoginButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Thread.Sleep(2000);

            var emailField = driver.FindElement(_emailField);
            emailField.Click();
            emailField.SendKeys(_login);
            Thread.Sleep(2000);

            var passwordField = driver.FindElement(_passwordField);
            passwordField.Click();
            passwordField.SendKeys(_password);
            Thread.Sleep(2000);

            var loginPageLoginButton = driver.FindElement(_loginPageLoginButton);
            loginPageLoginButton.Click();
            Thread.Sleep(2000);

            string pageTitle = driver.Title;
            Console.WriteLine("Page title: " + pageTitle);

            // Verify that the page title matches the expected value
            Assert.AreEqual(pageTitle, "ironSource");


        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
