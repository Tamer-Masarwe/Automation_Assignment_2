using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationAssignment
{
    class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menu-item-8")]
        public IWebElement Home { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-9")]
        public IWebElement About { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-10")]
        public IWebElement Contact { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-10593")]
        public IWebElement Speaking { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-9165")]
        public IWebElement Books { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-6846")]
        public IWebElement Bdd { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-6832")]
        public IWebElement Development { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-6835")]
        public IWebElement Testing { get; set; }

        [FindsBy(How = How.Id, Using = "menu-item-6849")]
        public IWebElement Python { get; set; }
    }
}
