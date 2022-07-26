
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumLearning
{
    public class EndToEndFlow
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";

            //IMPLICIT WAIT -global
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Test]
        public void EToETests()
        {

            //ecommerce website process

            String[] expectedproducts = { "iphone X", "Blackberry" }; //to check the products present.
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            //for the checkbox
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input"));
            //for the Sign in btn
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); //wait condn for checkout btn to be visible.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if (expectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click(); //click on Add btn
                }
                //TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text); //print all products
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click(); //part text coz checkout number changes.
            //now driver goes to next page ie cart page.

            //next test story : check whether the products that are selected and added are showing in the checkout page. (iphn x & blackberry) or some item missing.
            //step1- grab the 2 products from the cart page - for that inspect, take one common selector
            IList<IWebElement> cartItems = driver.FindElements(By.CssSelector("h4 a")); //2 itmes from the cart page

            String[] actualProducts = new string[expectedproducts.Length];
            for (int i = 0; i < cartItems.Count; i++)
            {
                actualProducts[i] = cartItems[i].Text;
            }

            Assert.AreEqual(expectedproducts, actualProducts);

            //test story: now we have correct products in the cart page.
            //so click on the checkout button in the cart page
            driver.FindElement(By.CssSelector(".btn-success")).Click(); //onclick, control goes to next page with country selection

            //driver is in the country sel page
            driver.FindElement(By.Id("country")).SendKeys("ind");

            //use the explicit wait to see the drop down options to come up - here "wait" is the obj declared above.
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India"))); //wait till 8secs

            //now click on the option India
            driver.FindElement(By.LinkText("India")).Click();

            //test story : (in the country sel page) Select the I Agree checkbox and click on the purchase button and see the success msg.
            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click(); //checkbox
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click(); //purchase btn
            String alertMsg = driver.FindElement(By.CssSelector(".alert-success")).Text; //succcess msg

            StringAssert.Contains("Success", alertMsg); //check the msg has the word "success" in it.

            driver.Close();

        }
    }

    public class Base
    {
    }
}
