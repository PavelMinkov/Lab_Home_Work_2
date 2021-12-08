using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace HW1
{
    [TestFixture]
    class Program
    {

        readonly IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://rozetka.com.ua/ua/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ExecuteTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            WebDriverWait fluentWait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromSeconds(250),
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException),typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException));

            Actions actionProvider = new Actions(driver);

            //PRODUCT_1
            //listMenu
            IList<IWebElement> listElements = driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]"));
            listElements[0].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //listTitleMenu
            listElements = driver.FindElements(By.ClassName("tile-cats"));
            listElements[0].Click();

            //elementBrandHP
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='HP']/parent::*")));
            element.Click();

            //elementModel
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Pavilion']/parent::*")));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //elementAddToCart
            //element = fluentWait.Until(drv => drv.FindElement(By.XPath("//li[contains(@class,'catalog')][1]//button[contains(@class,'buy-button')]")));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            //element.Click();
            try
            {
                element = fluentWait.Until(drv => drv.FindElement(By.XPath("//li[contains(@class,'catalog')][1]//button[contains(@class,'buy-button')]")));
                element.Click();
            }
            catch (StaleElementReferenceException )
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                element.Click();
            }

            //elementLogo
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo")));
            element.Click();

            //PRODUCT_2
            //listMenu
            try
            {
                element = fluentWait.Until(drv => drv.FindElement(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')][1]")));
            }
            catch (StaleElementReferenceException)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                element.Click();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //listTitleMenu
            listElements = driver.FindElements(By.ClassName("tile-cats"));
            listElements[0].Click();

            //elementBrandSamsung
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*")));
            element.Click();

            //elementModel
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy M']/parent::*")));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //elementAddToCart
            element = fluentWait.Until(drv => drv.FindElement(By.XPath("//li[contains(@class,'catalog')][1]//button[contains(@class,'buy-button')]")));
            element.Click();

            //elementLogo
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo")));
            element.Click();

            //PRODUCT_3
            //listMenu
            try
            {
                element = fluentWait.Until(drv => drv.FindElement(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')][1]")));
            }
            catch (StaleElementReferenceException)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                element.Click();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //listTitleMenu
            listElements = driver.FindElements(By.ClassName("tile-cats"));
            listElements[0].Click();

            //elementBrandSamsung
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*")));
            element.Click();

            //elementModel
            element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy S']/parent::*")));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //elementAddToCart
            element = fluentWait.Until(drv => drv.FindElement(By.XPath("//li[contains(@class,'catalog')][1]//button[contains(@class,'buy-button')]")));
            element.Click();

            //elementLogo
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo")));
            element.Click();

            //check quantity
            String quantity = driver.FindElement(By.XPath("//span[contains(@class,'counter')]")).Text;
            Console.WriteLine(quantity);
            Assert.IsTrue(quantity.Contains("3"));

            //check summ products
            element = driver.FindElement(By.XPath("//li[contains(@class,'cart')]"));
            element.Click();

            int summ = int.Parse(driver.FindElement(By.XPath("//div[@class='cart-receipt__sum-price']/span[1]")).Text);
            Console.WriteLine(summ);
            Assert.That(summ, Is.LessThan(60000));

            //make screenshot
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(@"D:\Паша\EPAM\LAB\HomeWork\HW2\SeleniumTestingScreenshot.jpg", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

    }
}
