using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Support.UI;
using labr5;

namespace labr5
{
    public class Tests
    {
            private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [Test]
        public void EnterA_ShouldSetAValue()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10");
            Assert.AreEqual("10", calculator.GetValueA());
        }

        [Test]
        public void EnterB_ShouldSetBValue()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterB("5");
            Assert.AreEqual("5", calculator.GetValueB());
        }

        [Test]
        public void ClickPlA_ShouldIncrementAValue()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10");

            // Act
            calculator.ClickPlA();

            // Assert
            Assert.AreEqual("11", calculator.GetValueA());
        }

        [Test]
        public void ClickMinA_ShouldDecrementAValue()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10");

            // Act
            calculator.ClickMinA();

            // Assert
            Assert.AreEqual("9", calculator.GetValueA());
        }

        [Test]
        public void ClickPlB_ShouldIncrementBValue()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterB("5");

            // Act
            calculator.ClickPlB();

            // Assert
            Assert.AreEqual("6", calculator.GetValueB());
        }

        [Test]
        public void ClickMinB_ShouldDecrementBValue()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterB("5");

            // Act
            calculator.ClickMinB();

            // Assert
            Assert.AreEqual("4", calculator.GetValueB());
        }

        [Test]
        public void DoublePlusA()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("1");
            calculator.ClickPlA();
            calculator.ClickPlA();
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }

        [Test]
        public void DoubleMinusA()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("3");
            calculator.ClickMinA();
            calculator.ClickMinA();
            string result = calculator.GetResult();
            Assert.AreEqual("1", result);
        }

        [Test]
        public void ClickOperations_ShouldSelectOperation()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            string operation = "+";

            // Act
            calculator.ClickOperations(operation);
            string selectedOperation = new SelectElement(_driver.FindElement(calculator._operation)).SelectedOption.Text;

            // Assert
            Assert.AreEqual(operation, selectedOperation);
        }

        [Test]
        public void OperatorMinus()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperations("-");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }

        [Test]
        public void OperatorUmnogit()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("3");
            calculator.EnterB("1");
            calculator.ClickOperations("*");
            string result = calculator.GetResult();
            Assert.AreEqual("3", result);
        }

        [Test]
        public void OperatorDelit()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("2");
            calculator.ClickOperations("/");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }

        [Test]
        public void OperatorPlus2()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("-2");
            calculator.ClickOperations("+");
            string result = calculator.GetResult();
            Assert.AreEqual("2", result);
        }

        [Test]
        public void OperationUmnogit2()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("-4");
            calculator.EnterB("-2");
            calculator.ClickOperations("*");
            string result = calculator.GetResult();
            Assert.AreEqual("8", result);
        }

        [Test]
        public void OperationDelenieNaNol()
        {
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("4");
            calculator.EnterB("0");
            calculator.ClickOperations("/");
            string result = calculator.GetResult();
            Assert.AreEqual("null", result);
        }

        [Test]
        public void GetResult_ShouldReturnCorrectResult()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10").EnterB("5");

            // Act
            calculator.ClickOperations("+");

            // Assert
            Assert.AreEqual("15", calculator.GetResult());
        }

        [Test]
        public void GetResultAll_ShouldReturnAllResults()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10").EnterB("5").ClickOperations("+");

            // Act
            string result = calculator.GetResultAll();

            // Assert
            Assert.AreEqual("10 + 5 = 15", result);
        }

        [Test]
        public void GetResultB_ShouldReturnResultForB()
        {
            // Arrange
            CalculatePage calculator = new CalculatePage(_driver);
            calculator.EnterA("10");

            // Act
            calculator.EnterB("5").ClickPlB();

            // Assert
            Assert.AreEqual("6", calculator.GetResultB());
        }
    }
}