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
    class GetTitleofthePage
    {

        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize(); //3. solves the issue 2.

        }
        [Test]
        public void GetTitleTest()
        {

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Url); //url is set in "driver.Url"

            //1.TO GET THE TITLE OF THE WEBPAGE when u hover on tab.
            String title = driver.Title; //title is in "driver.Title
            TestContext.Progress.WriteLine(title); //get title and stored in a var
           
            driver.Close(); //jus close one w/w
            //driver.Quit(); //close all the w/ws opened ny automation

            //2. RUN it :output : pass but webpage opened in minimised w/w

            //4. INFO :to get page source.
            //driver.PageSource();

        }

    }
}
