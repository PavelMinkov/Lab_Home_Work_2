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
            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(15);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            //fluentWait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.StaleElementReferenceException));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(StaleElementReferenceException));

            Actions actionProvider = new Actions(driver);

            //PRODUCT_1
            //listMenu
            List<IWebElement> listElements = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]")));
            listElements[0].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //listTitleMenu
            listElements = new List<IWebElement>(driver.FindElements(By.ClassName("tile-cats")));
            listElements[0].Click();

            //elementBrandHP
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='HP']/parent::*")));
            IWebElement element = driver.FindElement(By.XPath("//input[@id='HP']/parent::*"));
            element.Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Pavilion']/parent::*")));
            element = driver.FindElement(By.XPath("//input[@id='Pavilion']/parent::*"));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            //listProducts
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[class*='goods-tile__heading']")));

            listElements = new List<IWebElement>(driver.FindElements(By.CssSelector("a[class*='goods-tile__heading']")));
            fluentWait.Until(ExpectedConditions.ElementToBeSelected(listElements[0]));
            listElements[0].Click();

            //elementButtonBuy
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]")));
            element = driver.FindElement(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"));
            actionProvider.MoveToElement(element).Build().Perform();
            element.Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']")));
            element = driver.FindElement(By.CssSelector("div.modal__header button[class*='close']"));
            element.Click();

            //listBreadCrumbs
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            element = driver.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]"));
            element.Click();

            //PRODUCT_2
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //listMenu
            listElements = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]")));
            listElements[1].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //listTitleMenu
            listElements = new List<IWebElement>(driver.FindElements(By.ClassName("tile-cats")));
            listElements[0].Click();

            //elementBrandSamsung
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*")));
            element = driver.FindElement(By.XPath("//input[@id='Samsung']/parent::*"));
            element.Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy M']/parent::*")));
            element = driver.FindElement(By.XPath("//input[@id='Galaxy M']/parent::*"));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            //listProducts
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[class*='goods-tile__heading']")));
            listElements = new List<IWebElement>(driver.FindElements(By.CssSelector("a[class*='goods-tile__heading']")));
            listElements[0].Click();

            //elementButtonBuy
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]")));
            element = driver.FindElement(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"));
            actionProvider.MoveToElement(element).Build().Perform();
            element.Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']")));
            element = driver.FindElement(By.CssSelector("div.modal__header button[class*='close']"));
            element.Click();

            //listBreadCrumbs
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            element = driver.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]"));
            element.Click();

            //PRODUCT_3
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //listMenu
            listElements = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]")));
            listElements[1].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //listTitleMenu
            listElements = new List<IWebElement>(driver.FindElements(By.ClassName("tile-cats")));
            listElements[0].Click();

            //elementBrandSamsung
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*")));
            element = driver.FindElement(By.XPath("//input[@id='Samsung']/parent::*"));
            element.Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy S']/parent::*")));
            element = driver.FindElement(By.XPath("//input[@id='Galaxy S']/parent::*"));
            element.Click();

            //elementSort
            element = driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']"));
            element.Click();

            //listProducts
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[class*='goods-tile__heading']")));
            listElements = new List<IWebElement>(driver.FindElements(By.CssSelector("a[class*='goods-tile__heading']")));
            listElements[0].Click();

            //elementButtonBuy
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]")));
            element = driver.FindElement(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"));
            actionProvider.MoveToElement(element).Build().Perform();
            element.Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']")));
            element = driver.FindElement(By.CssSelector("div.modal__header button[class*='close']"));
            element.Click();

            //listBreadCrumbs
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            element = driver.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]"));
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
            Assert.That(summ, Is.LessThan(50000));

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
