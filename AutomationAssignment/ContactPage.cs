using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationAssignment
{
    class ContactPage
    {
        public ContactPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "g3-name")]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "g3-email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "contact-form-comment-g3-comment")]
        public IWebElement Comment { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#contact-form-3 > form > p.contact-submit > button")]
        public IWebElement SubmitButton { get; set; }
    }
}
