using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageJoke.Data;

namespace PageJoke;

public class Tests
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        var repository = new Repository();
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(repository.MainUrl);
        _driver.Manage().Window.Maximize();
        Thread.Sleep(5000);
    }

    [Test]
    public void QatarAirways1()
    {
        var repository = new Repository();
        var mainPage = new MainPage(_driver);
        mainPage.InsertData(repository.From, repository.To).ChooseFlight();
        Assert.AreEqual(repository.TestUrl, _driver.Url);
    }

    [Test]
    public void QatarAirways2()
    {
        var repository = new Repository();
        var mainPage = new MainPage(_driver);
        mainPage.Clicks().CheckInfo(repository.Origin, repository.Destination);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Close();
    }
}