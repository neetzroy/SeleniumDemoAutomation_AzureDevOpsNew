using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        //locate by XPath,CSS, ID, classname, name, tagname, linktext.

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise";

        }
        [Test]
        public void LocatorTest()
        {
            //1.find the web element textbox used to enter username : its ID is "username".
            //2.send a text value in that textbox.        
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy"); //1&2
            driver.FindElement(By.Id("username")).Clear(); //3.clear the contents.
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty"); //4.again pass a new text value in that textbox.
            driver.FindElement(By.Name("password")).SendKeys("123456"); //5.find the password textbox and pass the value


            //6. now click on the Sign In button
            //use css selector & xpath : if no id, no name, no class
            //css syntax : tagname[attribute = 'value'] 
            //Tagname is html tags,Attributes are id,type,name,class,value etc. Value is the value present in these attributes.

            //Eg web element:Sign In button : <input id="signInBtn" type="submit" name="signin" class="btn btn-info btn-md" value="Sign In">
            driver.FindElement(By.CssSelector("input[value = 'Sign In']")).Click(); //tagname:input, attribute:value, value:Sign In.

            //OR

            //XPath syntax : //tagname[@attribute = 'value']
            //driver.FindElement(By.XPath("//input[@value= 'Sign In']")).Click();



        }
    }
}
