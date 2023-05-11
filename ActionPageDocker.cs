using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;

namespace MichaelTest
{
    public class ActionPage
    {
        public static void UserTapsOnTheSearchField(IWebDriver driver, PageElements pageElements, WebDriverWait wait)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.SearchField)).Click();
            }
            catch (NoSuchElementException)
            {
                // Element not found, send driver refresh command
                driver.Navigate().Refresh();
                wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.SearchField)).Click();
            }
        }

        public static void UserTapsSendTextKeyboard(IWebDriver driver, PageElements pageElements, WebDriverWait wait, String keyboard)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.SearchField)).SendKeys(keyboard);
        }

        public static void UserTapsSendTextFrance(IWebDriver driver, PageElements pageElements, WebDriverWait wait, String _french)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.SearchField)).SendKeys(_french);
        }

        public static void UserTapsOnTheSearchSubmitButton(IWebDriver driver, PageElements pageElements, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.SearchSubmitButton)).Click();
        }

        public static string GetFirstPriceTextToLog(IWebDriver driver, PageElements pageElements, WebDriverWait wait)
        {
            try
            {
                string FirstPriceBeforeTheDecimalPoint = wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.FirstPriceBeforeTheDecimalPoint)).GetAttribute("innerText");
                FirstPriceBeforeTheDecimalPoint = FirstPriceBeforeTheDecimalPoint.Replace("\n", "").Replace("\r", ""); // Remove newline characters

                string FirstPriceAfterTheDecimalPoint = wait.Until(ExpectedConditions.ElementToBeClickable(pageElements.FirstPriceAfterTheDecimalPoint)).GetAttribute("innerText");
                FirstPriceAfterTheDecimalPoint = FirstPriceAfterTheDecimalPoint.Replace("\n", "").Replace("\r", ""); // Remove newline characters

                string price = $"{FirstPriceBeforeTheDecimalPoint}{FirstPriceAfterTheDecimalPoint}";
                LogToFile(price);
                return price;
            }
            catch (Exception ex)
            {
                LogToFile($"Error: {ex.Message}");
                return null;
            }
        }

        public static void LogToFile(string text)
        {
            string filePath = @"/Users/michaelorlov/Projects/MichaelTest/PriceOfTheFirstKeyBoard.txt";
            //File.WriteAllText(filePath, $"The Price of the first Keyboard is: {text}$");
            File.WriteAllText(filePath, $"Date: {DateTime.Now}, The Price of the first Keyboard is: {text}$");
            
        }


        public static void PopUP(IWebDriver driver, string text)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.alert('The first price of the keyboard is: {text}$');");
        }
    }
}
