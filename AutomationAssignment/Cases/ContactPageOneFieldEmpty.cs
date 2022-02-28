
using ClassLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Web;

[assembly: Parallelizable(ParallelScope.All)]

namespace AutomationAssignment.Cases
{
    [TestFixture]
    class ContactPageOneFieldEmpty
    {
        IWebDriver driver;
        List<User> usersList = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("User_OneEmptyField.json"));
        string screenShotDirectory = Directory.GetCurrentDirectory() + @"\FieldEmptyTestScreenshots\";
        string pageURL = ((dynamic)JsonConvert.DeserializeObject(File.ReadAllText("config_File.json"))).ContactPageURL;
        int screenshotsCounter;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(pageURL);
        }

        [OneTimeSetUp]
        public void InitializeOnce()
        {
            screenshotsCounter = 1;
        }

        [Test, Category("Negative Tests")]
        public void OneEmptyField_SubmitFailed_ReturnTrue()
        {
            ContactPage contactPage = new ContactPage(driver);

            foreach(User user in usersList)
            {
                contactPage.Name.Clear();
                contactPage.Name.SendKeys(user.Name);

                contactPage.Email.Clear();
                contactPage.Email.SendKeys(user.Email);

                contactPage.Comment.Clear();
                contactPage.Comment.SendKeys(user.Comment);
                contactPage.SubmitButton.Click();
                if (!driver.Url.Equals(pageURL))
                {
                    createScreenshotsFile();
                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenShotDirectory + "screenshot" + (screenshotsCounter++) + ".png", ScreenshotImageFormat.Png);
                    Assert.Fail("Submit fail expected!");
                }
            }
            Assert.Pass();
        }
     
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        public void createScreenshotsFile()
        {
            if (!Directory.Exists(screenShotDirectory))
            {
                Directory.CreateDirectory(screenShotDirectory);
            }
        }
    }
}
