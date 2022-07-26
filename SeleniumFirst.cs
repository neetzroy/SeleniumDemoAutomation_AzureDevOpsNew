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
    public class SeleniumFirst
    {
        IWebDriver driver;  //6.declared globally to access in other methods.

        [SetUp]
        public void StartBrowser()
        {
            //1.STEPS to invoke chrome browser
            //2.to overcome browser update versions compatibility issues
            //3.need a WEBDRIVERMANAGER to be installed from nuget packages.
            //4.the below 2 steps are common for every sel test fw.
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(); //7.obj is declared above globally to solve the issue 5.

        }
        [Test]
        public void InvokeBrowser()
        {
            //Driver.??    //5.not getting options. so need to declare the driver obj globally
            driver.Url = "https://rahulshettyacademy.com/#/index"; //8. build the proj and run it.
        }
    }
}
