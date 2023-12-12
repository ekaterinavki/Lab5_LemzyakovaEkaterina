using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace labr5
{
    public class CalculatePage
    {
        private readonly IWebDriver _driver;
        private readonly TimeSpan _timeout= TimeSpan.FromSeconds(7);

        private readonly By _logo = By.TagName("h1");
        private readonly By _a = By.XPath("//input[@ng-model='a']");
        private readonly By _buttonPlusOne = By.XPath("//button[@ng-click='inca()']");
        private readonly By _buttonMinusOne = By.XPath("//button[@ng-click='deca()']");
        private readonly By _b = By.XPath("//input[@ng-model='b']");
        private readonly By _buttonPlOne = By.XPath("//button[@ng-click='incb()']");
        private readonly By _buttonMsOne = By.XPath("//button[@ng-click='decb()']");
        public readonly By _operation = By.TagName("select");
        private readonly By _result = By.TagName("b");

        public CalculatePage(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            try
            {
                new WebDriverWait(_driver, _timeout).Until(driv => driv.FindElement(_logo));
            }
            catch
            {
                Console.WriteLine("Ошибка загрузки страницы");
            }
        }
        
        public CalculatePage EnterA(string a)
        {
            _driver.FindElement(_a).Clear();
            _driver.FindElement(_a).SendKeys(a);
            return this;
        }

        public CalculatePage EnterB(string b)
        {
            _driver.FindElement(_b).Clear();
            _driver.FindElement(_b).SendKeys(b);
            return this;
        }

        public CalculatePage ClickPlA()
        {
            _driver.FindElement(_buttonPlusOne).Click();
            return this;
        }

        public string GetValueA()
        {
            IWebElement el = _driver.FindElement(By.XPath("//input[@ng-model='a']"));
            return el.GetAttribute("value");
        }

        public string GetValueB()
        {
            IWebElement el = _driver.FindElement(By.XPath("//input[@ng-model='b']"));
            return el.GetAttribute("value");
        }

        public CalculatePage ClickMinA()
        {
            _driver.FindElement(_buttonMinusOne).Click();
            return this;
        }
        
        public CalculatePage ClickPlB()
        {
            _driver.FindElement(_buttonPlOne).Click();
            return this;
        }

        public CalculatePage ClickMinB()
        {
            _driver.FindElement(_buttonMsOne).Click();
            return this;
        }

        public CalculatePage ClickOperations(string operation)
        {
            _driver.FindElement(_operation).Click();
            _driver.FindElement(By.XPath($".//option[@value='{operation}']")).Click();
            return this;
        }

        public string GetResult()
        {
            return _driver.FindElement(_result).Text.Split(' ').Last();
        }

        public string GetResultAll()
        {
            return _driver.FindElement(_result).Text;
        }

        public string GetResultB()
        {
            return _driver.FindElement(_result).Text.Split(' ')[2];
        }
    }
}
