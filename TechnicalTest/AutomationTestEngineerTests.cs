//-----------------------------------------------------------------------
// <copyright file="AutomationTestEngineerTests.cs" company=">Team International">
// Copyright (c) 2021 All rights reserverd.
// </copyright>
// <author>David López</author>
// <date>2021/03/18</date>
namespace TechnicalTest
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using System.Text.RegularExpressions;
    using TechnicalTest.Pages;

    /// <summary>
    /// Initialize an instance of class AutomationTestEngineerTests
    /// </summary>
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class AutomationTestEngineerTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        /// <summary>
        /// The driver
        /// </summary>
        private readonly IWebDriver _driver;

        /// <summary>
        /// Create an instance of class AutomationTestEngineerTests
        /// </summary>
        public AutomationTestEngineerTests() => _driver = new TWebDriver();

        /// <summary>
        /// Setup actions before running test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://sdetteamintl.z22.web.core.windows.net/");
        }

        /// <summary>
        /// Check the title of the form page
        /// </summary>
        [Test]
        public void CheckTheTitleOfTheFormPage()
        {
            // Valida el texto del título de la página del formulario
            Assert.AreEqual("Test for Automation Test Engineer - form", _driver.Title);
        }

        /// <summary>
        /// Check the validation messages of all required fields
        /// </summary>
        [Test]
        public void CheckTheValidationMessagesOfAllRequiredFields()
        {
            FormPage formPage = new FormPage(_driver);

            // Click en el botón Send
            formPage.ButtonSend.Click();

            // Verifica el texto del validador para el campo First name
            Assert.AreEqual("Valid first name is required.", formPage.ValidatorFirstName.Text);

            // Verifica el texto del validador para el campo Last name
            Assert.AreEqual("Valid last name is required.", formPage.ValidatorLastName.Text);

            // Verifica el texto del validador para el campo CellPhone
            Assert.AreEqual("Please enter your cellphone.", formPage.ValidatorCellPhone.Text);

            // Verifica el texto del validador para el campo Username
            Assert.AreEqual("Your username is required.", formPage.ValidatorUsername.Text);

            // Verifica el texto del validador para el campo Age
            Assert.AreEqual("Please enter your age.", formPage.ValidatorAge.Text);

            // Verifica el texto del validador para el campo Email
            Assert.AreEqual("Please enter a valid email address for shipping updates.", formPage.ValidatorEmail.Text);

            // Verifica el texto del validador para el campo Address
            Assert.AreEqual("Please enter your shipping address.", formPage.ValidatorAddress.Text);

            // Verifica el texto del validador para el campo State
            Assert.AreEqual("Please provide a valid state.", formPage.ValidatorState.Text);

            // Verifica el texto del validador para el campo City
            Assert.AreEqual("Please provide a valid city.", formPage.ValidatorCity.Text);

            // Verifica el texto del validador para el campo I agree to the terms and conditions
            Assert.AreEqual("Please mark as accepted", formPage.ValidatorTerms.Text);
        }

        /// <summary>
        /// Chack the title of the result page
        /// </summary>
        [Test]
        public void CheckTheTitleOfTheResultPage()
        {
            FormPage formPage = new FormPage(_driver);

            formPage.FillForm(
                firstName: "User FirstName", 
                lastName: "User LastName", 
                cellPhone: "123456", 
                userName: "userName", 
                age: 25, 
                email: "user@teamEmail.net", 
                address: "User Main Address", 
                address2: "User Aditional Address", 
                country: "United States", 
                state: "Florida", 
                city: "Lake Mary");

            // Valida el texto del título de la página resultante
            Assert.AreEqual("Test for Automation Test Engineer - result", _driver.Title);
        }

        /// <summary>
        /// Check the success message of the result page
        /// </summary>
        [Test]
        public void CheckTheSuccessMessageOfTheResultPage()
        {
            FormPage formPage = new FormPage(_driver);

            formPage.FillForm(
                firstName: "User FirstName",
                lastName: "User LastName",
                cellPhone: "123456",
                userName: "userName",
                age: 25,
                email: "user@teamEmail.net",
                address: "User Main Address",
                address2: "User Aditional Address",
                country: "United States",
                state: "Florida",
                city: "Lake Mary");

            ResultPage resultPage = new ResultPage(_driver);

            // Valida el texto del mensaje de respuesta
            Assert.AreEqual("Your profile was sent successfully!", resultPage.LabelResult.Text);
        }

        /// <summary>
        /// Check content of who area we message
        /// </summary>
        [Test]
        public void CheckWhoAreWeMessage()
        {
            FormPage formPage = new FormPage(_driver);

            PrivacyPolicyPage privacyPolicyPage = new PrivacyPolicyPage(_driver);

            // Ingresa a la página Privacy
            formPage.GoToPrivacyPage();

            // Obtiene el texto del parrafo Who are we?
            string contentWhoAreWe = Regex.Match(privacyPolicyPage.TextWhoAreWe.Text, @"(?<=\n).*").Value;

            // Realiza la validación del texto
            Assert.AreEqual("TEAM International Services Inc. further referred to as “we,” “us” or “our”, " +
                "is a custom software development consultancy headquartered at 1145 TownPark Avenue, Suite 2201, " +
                "Lake Mary, FL 32746, USA. We operate through our subsidiaries located in Ukraine, Poland, and Colombia.",
               contentWhoAreWe);
        }

        /// <summary>
        /// Actions after each test
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Cierra el navegador
            _driver.Quit();
        }
    }
}
