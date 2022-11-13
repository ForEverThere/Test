using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebJoke;

public class Tests
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://www.qatarairways.com/en/homepage.html");
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void OpenSite()
    {
        _driver.FindElement((By.Id("cookie-close-accept-all"))).Click();
        _driver.FindElement((By.XPath("//*[@id='bw-from']"))).SendKeys("Barcelona");
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[2]/div[1]/div[2]/span[1]/div/div[2]/div[3]/div/strong[1]"))).Click();
        _driver.FindElement((By.XPath("//*[@id='bw-to']"))).SendKeys("Adana");
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[2]/div[2]/div[2]/span[1]/div/div[2]/div[3]/div/strong[1]"))).Click();
        _driver.FindElement((By.XPath("//*[@id='tripType']"))).Click();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _driver.FindElement((By.XPath("//*[@id='onewayTrip']"))).Click();
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[4]/div[4]/div/div"))).Click();
        Thread.Sleep(2000);
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[4]/div[4]/div/div[2]/div[2]/div[1]/table/tbody/tr[3]/td[6]"))).Click();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[4]/div[4]/div/div[2]/div[3]/div[2]/button[2]"))).Click();
        _driver.FindElement((By.XPath("//*[@id='flights-search-from']/div[11]/div[4]/button"))).Click();
        Thread.Sleep(15000);
        _driver.FindElement((By.XPath("/html/body/app-root/div/booking-flight-selection-page/div/booking-flight-result-card[1]/div/div/div[3]/div/div[1]/a"))).Click();
        Thread.Sleep(2000);
        _driver.FindElement((By.CssSelector("#fare-details-swiper-0001 > div > booking-fare-card:nth-child(1) > div > div:nth-child(5) > button"))).Click();
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Close();
    }
}