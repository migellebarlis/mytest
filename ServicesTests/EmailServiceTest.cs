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
    public void EmailInput_RejectsInvalidEmail()
    {
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        var title = driver.Title;
        Assert.AreEqual("Web form", title);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.CssSelector("#my-text-id"));
        var submitButton = driver.FindElement(By.TagName("button"));

        textBox.SendKeys("Selenium");
        submitButton.Click();

        var message = driver.FindElement(By.Id("message"));
        var value = message.Text;
        Assert.AreEqual("Received!", value);
    }

    [Test]
    public void EmailInput_AcceptsValidEmail()
    {
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        var title = driver.Title;
        Assert.AreEqual("Web form", title);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.CssSelector("#my-text-id"));
        var submitButton = driver.FindElement(By.TagName("button"));

        textBox.SendKeys("Selenium");
        submitButton.Click();

        var message = driver.FindElement(By.Id("message"));
        var value = message.Text;
        Assert.AreEqual("Received!", value);
    }
}