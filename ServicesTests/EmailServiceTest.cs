using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ServicesTests;

public class EmailServiceTest
{
    private ChromeDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(@"/Users/migellejosebarlis/webdriver");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }

    [Test]
    public void NavigateToWebsite_ReturnsWebsiteName()
    {
        driver.Navigate().GoToUrl("https://mail.google.com/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

        var title = driver.Title;
        
        Assert.AreEqual("Gmail", title);
    }

    [Test]
    public void NavigateToWebsite_ReturnsEmailInput()
    {
        driver.Navigate().GoToUrl("https://mail.google.com/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

        var textBox = driver.FindElement(By.CssSelector("#identifierId"));

        Assert.IsNotNull(textBox);
    }

    [Test]
    public void NavigateToWebsite_RejectsInvalidEmail()
    {
        driver.Navigate().GoToUrl("https://mail.google.com/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

        var textBox = driver.FindElement(By.CssSelector("#identifierId"));
        var submitButton = driver.FindElement(By.CssSelector("#identifierNext > div > button"));

        textBox.SendKeys("test @gmail.com");
        submitButton.Click();

        var message = driver.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div.eKnrVb > div > div.j663ec > div > form > span > section > div > div > div.d2CFce.cDSmF.cxMOTc > div > div.LXRPh > div.dEOOab.RxsGPe > div"));
        var value = message.Text;

        Assert.AreEqual("Enter a valid email or phone number", value);
    }

    [Test]
    public void NavigateToWebsite_RejectsNonExistingEmail()
    {
        driver.Navigate().GoToUrl("https://mail.google.com/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

        var textBox = driver.FindElement(By.CssSelector("#identifierId"));
        var submitButton = driver.FindElement(By.CssSelector("#identifierNext > div > button"));

        textBox.SendKeys("test@gmail.com");
        submitButton.Click();

        var message = driver.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div.eKnrVb > div > div.j663ec > div > form > span > section > div > div > div.d2CFce.cDSmF.cxMOTc > div > div.LXRPh > div.dEOOab.RxsGPe > div"));
        var value = message.Text;

        Assert.AreEqual("Couldn’t find your Google Account", value);
    }
}