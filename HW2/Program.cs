using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(15);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.StaleElementReferenceException));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //product_2
            List<IWebElement> listMenu = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'type_main')]/li[contains(@class,'menu-categories')]")));
            listMenu[0].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            List<IWebElement> listTitleMenu = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='tile-cats']")));
            listTitleMenu[0].Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'hp')]")));
            //IWebElement elementBrandHP = driver.FindElement(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'hp')]"));
            //elementBrandHP.Click();

            //IWebElement elementSort = driver.FindElement(By.XPath("//select[contains(@class,'select')]/option[contains(@value,'expensive')]"));
            //elementSort.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            List<IWebElement> listProducts = new List<IWebElement>(fluentWait.Until(x => x.FindElements(By.XPath("//li[contains(@class,'catalog')]//span[@class='goods-tile__title'][last()]"))));
            listProducts[4].Click();

            IWebElement elementButtonBuy = fluentWait.Until(x => x.FindElement(By.XPath("//app-buy-button//button[contains(@class,'buy-button')]/span[contains(@class,'buy-button')]")));
            elementButtonBuy.Click();

            IWebElement elementContinueBuy = fluentWait.Until(x => x.FindElement(By.XPath("//div[contains(@class,'modal__header')]//button[contains(@class,'close')]")));
            elementContinueBuy.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            IWebElement listBreadCrumbs = fluentWait.Until(x => x.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]")));
            listBreadCrumbs.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[contains(@class,'type_main')]/li[contains(@class,'menu-categories')]")));
            List<IWebElement> listMenu1 = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'type_main')]/li[contains(@class,'menu-categories')]")));
            listMenu1[1].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


            //product_2
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='tile-cats']")));
            List<IWebElement> listTitleMenu1 = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='tile-cats']")));
            listTitleMenu1[0].Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'samsung')]")));
            //IWebElement elementBrandSamsung = driver.FindElement(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'samsung')]"));
            //elementBrandSamsung.Click();

            List<IWebElement> listProducts1 = new List<IWebElement>(fluentWait.Until(x => x.FindElements(By.XPath("//li[contains(@class,'catalog')]//span[@class='goods-tile__title'][last()]"))));
            listProducts1[4].Click();

            IWebElement elementButtonBuy1 = fluentWait.Until(x => x.FindElement(By.XPath("//app-buy-button//button[contains(@class,'buy-button')]/span[contains(@class,'buy-button')]")));
            elementButtonBuy1.Click();

            IWebElement elementContinueBuy1 = fluentWait.Until(x => x.FindElement(By.XPath("//div[contains(@class,'modal__header')]//button[contains(@class,'close')]")));
            elementContinueBuy1.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            IWebElement listBreadCrumbs1 = fluentWait.Until(x => x.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]")));
            listBreadCrumbs1.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //product_3
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[contains(@class,'type_main')]/li[contains(@class,'menu-categories')]")));
            List<IWebElement> listMenu2 = new List<IWebElement>(driver.FindElements(By.XPath("//ul[contains(@class,'type_main')]/li[contains(@class,'menu-categories')]")));
            listMenu2[1].Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='tile-cats']")));
            List<IWebElement> listTitleMenu2 = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='tile-cats']")));
            listTitleMenu2[0].Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'samsung')]")));
            //IWebElement elementBrandSamsung1 = driver.FindElement(By.XPath("//a[@class='checkbox-filter__link'][contains(@href,'samsung')]"));
            //elementBrandSamsung1.Click();

            List<IWebElement> listProducts2 = new List<IWebElement>(fluentWait.Until(x => x.FindElements(By.XPath("//li[contains(@class,'catalog')]//span[@class='goods-tile__title'][last()]"))));
            listProducts2[3].Click();

            IWebElement elementButtonBuy2 = fluentWait.Until(x => x.FindElement(By.XPath("//app-buy-button//button[contains(@class,'buy-button')]/span[contains(@class,'buy-button')]")));
            elementButtonBuy2.Click();

            IWebElement elementContinueBuy2 = fluentWait.Until(x => x.FindElement(By.XPath("//div[contains(@class,'modal__header')]//button[contains(@class,'close')]")));
            elementContinueBuy2.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@class,'breadcrumbs__link')]")));
            IWebElement listBreadCrumbs2 = fluentWait.Until(x => x.FindElement(By.XPath("(//a[contains(@class,'breadcrumbs__link')])[1]")));
            listBreadCrumbs2.Click();

            String quantity = driver.FindElement(By.XPath("//span[contains(@class,'counter')]")).Text;
            Console.WriteLine(quantity);
            Assert.IsTrue(quantity.Contains("3"));

            IWebElement elementCart = fluentWait.Until(x => x.FindElement(By.XPath("//li[contains(@class,'cart')]")));
            elementCart.Click();

            int summ = int.Parse(driver.FindElement(By.XPath("//div[@class='cart-receipt__sum-price']/span[1]")).Text);
            Console.WriteLine(summ);
            Assert.That(summ, Is.LessThan(50000));

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
