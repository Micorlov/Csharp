using OpenQA.Selenium;

namespace MichaelTest
{
    public class PageElements
    {
        public By SearchField { get; } = By.Id("twotabsearchtextbox");
        public By SearchSubmitButton { get; } = By.Id("nav-search-submit-button");
        public By FirstPriceBeforeTheDecimalPoint { get; } = By.XPath("//*[@id=\"search\"]/div[1]/div[1]/div/span[1]/div[1]/div[3]/div/div/div/div/div/div/div/div[2]/div/div/div[3]/div[1]/div/div[1]/div[1]/a/span/span[2]/span[2]");
        public By FirstPriceAfterTheDecimalPoint { get; } = By.XPath("//*[@id=\"search\"]/div[1]/div[1]/div/span[1]/div[1]/div[3]/div/div/div/div/div/div/div/div[2]/div/div/div[3]/div[1]/div/div[1]/div[1]/a/span/span[2]/span[3]");


    }
}
