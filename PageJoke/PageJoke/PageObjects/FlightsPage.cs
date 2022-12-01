using OpenQA.Selenium;

namespace PageJoke;

public class FlightsPage
{
    private IWebDriver _driver;
    public FlightsPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public By FlightType = By.XPath("/html/body/app-root/div/booking-flight-selection-page/div/booking-flight-result-card[1]/div/div/div[3]/div/div[1]/a");
    public By FlightTypeCost = By.XPath("/html/body/app-root/div/booking-flight-selection-page/div/booking-flight-result-card[1]/div/booking-fare-details/div/div/booking-fare-card[1]/div/div[2]/button");
}