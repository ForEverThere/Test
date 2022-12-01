using OpenQA.Selenium;

namespace PageJoke;

public class InfoPage
{
    private IWebDriver _driver;
    public InfoPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public By CloseAds = By.XPath("/html/body/div[9]/div[3]/div/div[1]/header/section[2]/div/div/a");
    public By OriginField = By.XPath("/html/body/div[9]/main/div[2]/div/div[3]/div/div/div[1]/div[2]/span[1]/input");
    public By OriginList = By.XPath("/html/body/div[9]/main/div[2]/div/div[3]/div/div/div[1]/div[2]/span[1]/div");
    public By DestinationField = By.XPath("/html/body/div[9]/main/div[2]/div/div[3]/div/div/div[2]/div[2]/span[1]/input");
    public By DestinationList = By.XPath("/html/body/div[9]/main/div[2]/div/div[3]/div/div/div[2]/div[2]/span[1]/div");
    public By CheckRequirements = By.XPath("/html/body/div[9]/main/div[2]/div/div[3]/div/div/div[4]/button");
}