using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageJoke;

public class MainPage
{
    private readonly IWebDriver _driver;

    #region Locators for test 1
    private By _cookies = By.Id("cookie-close-accept-all");
    private By _fromField = By.XPath("//*[@id='bw-from']");
    private By _fromList = By.XPath("//*[@id='flights-search-from']/div[2]/div[1]/div[2]/span[1]/div/div[2]/div[3]/div/strong[1]");
    private By _toField = By.XPath("//*[@id='bw-to']");
    private By _toList = By.XPath("//*[@id='flights-search-from']/div[2]/div[2]/div[2]/span[1]/div/div[2]/div[3]/div/strong[1]");
    private By _tripList = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[3]/div/div/ul/li[2]/a");
    private By _tripType = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[3]/div/button");
    private By _dateList = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[4]/div[4]/div/div");
    private By _concreteDate = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[4]/div[4]/div/div[2]/div[2]/div[1]/table/tbody/tr[4]/td[1]");
    private By _confirmDate = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[4]/div[4]/div/div[2]/div[3]/div[2]/button[2]");
    private By _showFlights = By.XPath("/html/body/div[8]/main/div/div/div/hero-component/div[3]/div/div/div/div/div[1]/div/div/div[5]/div[11]/div[4]/button");
    #endregion

    #region Locators for test 2
    private By _bookMenu = By.XPath("/html/body/div[8]/div[2]/div/header/div/div/div/div/nav/div[4]/ul[1]/li[2]/a");
    private By _requirements = By.XPath("/html/body/div[8]/div[2]/div/header/div/div/div/div/nav/div[4]/ul[1]/li[2]/div/ul/li[4]/ul/li[2]/a");
    #endregion
    public MainPage(IWebDriver driver)
    {
        _driver = driver;
    }
    #region Test1
    public MainPage InsertData(string fromCountry, string toCountry)
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _driver.FindElement(_cookies).Click();
        _driver.FindElement(_fromField).SendKeys(fromCountry);
        _driver.FindElement(_fromList).Click();
        _driver.FindElement(_toField).SendKeys(toCountry);
        _driver.FindElement(_toList).Click();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _driver.FindElement(_tripType).Click();
        Thread.Sleep(2000);
        _driver.FindElement(_tripList).Click();
        Thread.Sleep(2000);
        _driver.FindElement(_dateList).Click();
        _driver.FindElement(_concreteDate).Click();
        _driver.FindElement(_confirmDate).Click();
        _driver.FindElement(_showFlights).Click();
        Thread.Sleep(1000);
        return new MainPage(_driver);
    }
    public FlightsPage ChooseFlight()
    {
        var flightsPage = new FlightsPage(_driver);
        Thread.Sleep(10000);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _driver.FindElement(flightsPage.FlightType).Click();
        Thread.Sleep(2000);
        _driver.FindElement(flightsPage.FlightTypeCost).Click();
        return new FlightsPage(_driver);
    }
    #endregion

    #region Test2
    public MainPage Clicks()
    {
        _driver.FindElement(_cookies).Click();
        _driver.FindElement(_bookMenu).Click();
        _driver.FindElement(_requirements).Click();
        return new MainPage(_driver);
    }

    public InfoPage CheckInfo(string origin, string destination)
    {
        var infoPage = new InfoPage(_driver);
        WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
        wait.Until(_driver => _driver.FindElement(infoPage.CloseAds));
        _driver.FindElement(infoPage.CloseAds);
        _driver.FindElement(infoPage.OriginField).SendKeys(origin);
        Thread.Sleep(5000);
        _driver.FindElement(infoPage.OriginList).Click();
        _driver.FindElement(infoPage.DestinationField).SendKeys(destination);
        _driver.FindElement(infoPage.DestinationList).Click();
        _driver.FindElement(infoPage.CheckRequirements).Click();
        return new InfoPage(_driver);
    }
    #endregion
}