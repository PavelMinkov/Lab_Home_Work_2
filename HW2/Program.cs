using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HW2
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            WebDriverWait fluentWait = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(5));
            fluentWait.PollingInterval = TimeSpan.FromSeconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(ElementClickInterceptedException));

            Actions actionProvider = new Actions(driver);

            //PRODUCT_1
            //listMenu
            driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]"))[0].Click();


            //listTitleMenu
            driver.FindElements(By.ClassName("tile-cats"))[0].Click();

            //elementBrandHP
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='HP']/parent::*"))).Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Pavilion']/parent::*"))).Click();

            //elementSort
            driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']")).Click();

            //listProducts
            IList<IWebElement> listElements= driver.FindElements(By.CssSelector("span.goods-tile__title"));
            listElements[0].Click();
            //fluentWait.Until(drv => drv.FindElement(By.XPath("//li[contains(@class,'catalog')][1]//span[@class='goods-tile__title']"))).Click();

            //elementButtonBuy
            actionProvider.MoveToElement(driver.FindElement(By.CssSelector("p[class*='product-prices__b']"))).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"))).Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']"))).Click();

            //elementLogo
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo"))).Click();

            //PRODUCT_2

            //listMenu
            driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]"))[1].Click();

            //listTitleMenu
            driver.FindElements(By.ClassName("tile-cats"))[0].Click();

            //elementBrandSamsung
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*"))).Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy M']/parent::*"))).Click();

            //elementSort
            driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']")).Click();

            //listProducts
            listElements = driver.FindElements(By.CssSelector("span.goods-tile__title"));
            listElements[0].Click();

            //elementButtonBuy
            actionProvider.MoveToElement(driver.FindElement(By.CssSelector("p[class*='product-prices__bi']"))).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"))).Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']"))).Click();

            //elementLogo
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo"))).Click();

            //PRODUCT_3

            //listMenu
            driver.FindElements(By.XPath("//ul[contains(@class,'menu-categories_type_main')]/li[contains(@class,'menu-categories')]"))[1].Click();

            //listTitleMenu
            driver.FindElements(By.ClassName("tile-cats"))[0].Click();

            //elementBrandSamsung
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Samsung']/parent::*"))).Click();

            //elementModel
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Galaxy S']/parent::*"))).Click();

            //elementSort
            driver.FindElement(By.CssSelector("select[class*='select'] option[value*='expensive']")).Click();

            //listProducts
            listElements = driver.FindElements(By.CssSelector("span.goods-tile__title"));
            listElements[1].Click();

            //elementButtonBuy
            actionProvider.MoveToElement(driver.FindElement(By.CssSelector("p.product-prices__big"))).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]"))).Click();

            //elementCartClose
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.modal__header button[class*='close']"))).Click();

            //elementLogo
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.header__logo"))).Click();

            //check quantity
            String quantity = driver.FindElement(By.XPath("//span[contains(@class,'counter')]")).Text;
            Console.WriteLine(quantity);
            Assert.IsTrue(quantity.Contains("3"));

            //check summ products
            driver.FindElement(By.XPath("//li[contains(@class,'cart')]")).Click();

            int summ = int.Parse(driver.FindElement(By.XPath("//div[@class='cart-receipt__sum-price']/span[1]")).Text);
            Console.WriteLine(summ);
            Assert.That(summ, Is.LessThan(70000));

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
