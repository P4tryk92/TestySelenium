using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Support.UI;
namespace Tests
{
    [TestFixture]
    public class FirstTests
    {
        IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            _driver = new FirefoxDriver("./");
        }
        [Test]
        public void checkPhpValidationOfFormTest()
        {
            string campus = "sciHarlingen";
            string degree = "MastersDegree";
            string year = "1990";
            string firstName = "Hans";
            string lastName = "Zimmer";
            string email = "h.zimmer@gmail.com";
            string phone = "8452090189";
            string streetAddress = "Broadway";
            string zipCode = "10036";

            _driver.Navigate().GoToUrl("http://patryk92.stronazen.pl");
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[1]/*[contains(text(), 'Harlingen')]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[2]/*[contains(text(), 'Master')]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[3]/*[contains(text(), '1990')]")).Click();
            _driver.FindElement(By.Id("go-to-step-2")).Click();

            var firstNameInput = _driver.FindElement(By.Id("first-name"));
            firstNameInput.SendKeys(firstName + Keys.Enter);
            var lastNameInput = _driver.FindElement(By.Id("last-name"));
            lastNameInput.SendKeys(lastName + Keys.Enter);
            var emailInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[3]"));
            emailInput.SendKeys(email + Keys.Enter);
            var phoneInput = _driver.FindElement(By.Id("phone"));
            phoneInput.SendKeys(phone + Keys.Enter);
            var streetAddressInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[5]"));
            streetAddressInput.SendKeys(streetAddress + Keys.Enter);
            var zipCodeInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[6]"));
            zipCodeInput.SendKeys(zipCode + Keys.Enter);

            _driver.FindElement(By.XPath(".//*[@id='form-step-2']/select[1]/option[2]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-2']/div/button")).Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.CssSelector("h1"))));

            string _campus = _driver.FindElement(By.XPath("/html/body/span[1]")).Text;
            string _degree = _driver.FindElement(By.XPath("/html/body/span[2]")).Text;
            string _year = _driver.FindElement(By.XPath("/html/body/span[3]")).Text;
            string _firstName = _driver.FindElement(By.XPath("/html/body/span[4]")).Text;
            string _lastName = _driver.FindElement(By.XPath("/html/body/span[5]")).Text;
            string _email = _driver.FindElement(By.XPath("/html/body/span[6]")).Text;
            string _phone = _driver.FindElement(By.XPath("/html/body/span[7]")).Text;
            string _streetAddress = _driver.FindElement(By.XPath("/html/body/span[8]")).Text;
            string _zipCode = _driver.FindElement(By.XPath("/html/body/span[9]")).Text;

            Assert.AreEqual(campus.ToLower(), _campus.ToLower());
            Assert.AreEqual(degree.ToLower(), _degree.ToLower());
            Assert.AreEqual(year.ToLower(), _year.ToLower());
            Assert.AreEqual(firstName.ToLower(), _firstName.ToLower());
            Assert.AreEqual(lastName.ToLower(), _lastName.ToLower());
            Assert.AreEqual(email.ToLower(), _email.ToLower());
            Assert.AreEqual(phone.ToLower(), _phone.ToLower());
            Assert.AreEqual(streetAddress.ToLower(), _streetAddress.ToLower());
            Assert.AreEqual(zipCode.ToLower(), _zipCode.ToLower());
        }


        [Test]
        public void SprawdzeniePoprawnosciValidacjiW_JS()
        {
            string campus = "sciBrownsville";
            string degree = "associateDegree";
            string year = "1985";
            string firstName = "Adam";
            string lastName = "Nowak";
            string email = "adam.nowak@gmail.com";
            string phone = "6403080256";
            string streetAddress = "krakowska";
            string zipCode = "3030";

            _driver.Navigate().GoToUrl("http://patryk92.stronazen.pl");
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[1]/*[contains(text(), 'Harlingen')]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[2]/*[contains(text(), 'Master')]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-1']/select[3]/*[contains(text(), '1990')]")).Click();
            _driver.FindElement(By.Id("go-to-step-2")).Click();

            var firstNameInput = _driver.FindElement(By.Id("first-name"));
            firstNameInput.SendKeys(firstName + Keys.Enter);
            var lastNameInput = _driver.FindElement(By.Id("last-name"));
            lastNameInput.SendKeys(lastName + Keys.Enter);
            var emailInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[3]"));
            emailInput.SendKeys(email + Keys.Enter);
            var phoneInput = _driver.FindElement(By.Id("phone"));
            phoneInput.SendKeys(phone + Keys.Enter);
            var streetAddressInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[5]"));
            streetAddressInput.SendKeys(streetAddress + Keys.Enter);
            var zipCodeInput = _driver.FindElement(By.XPath(".//*[@id='form-step-2']/input[6]"));
            zipCodeInput.SendKeys(zipCode + Keys.Enter);

            _driver.FindElement(By.XPath(".//*[@id='form-step-2']/select[1]/option[2]")).Click();
            _driver.FindElement(By.XPath(".//*[@id='form-step-2']/div/button")).Click();

            StringAssert.StartsWith("http://patryk92.stronazen.pl/result.php", _driver.Url);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}