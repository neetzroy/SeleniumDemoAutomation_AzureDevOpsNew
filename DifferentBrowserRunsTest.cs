using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    class DifferentBrowserRunsTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            
        }
        
        [Test]
        public void OpenWebpageFirefox()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            //test: check whether the page opened in firefox or not.
            driver.Manage().Window.Maximize();
            //driver.Close();
        }
        [Test]
        public void OpenWebpageMSEdge()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            //test: check whether the page opened in Edge or not.
            driver.Manage().Window.Maximize();
            //driver.Close();
        }
    }
}
