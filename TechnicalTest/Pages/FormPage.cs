//-----------------------------------------------------------------------
// <copyright file="FormPage.cs" company=">Team International">
// Copyright (c) 2021 All rights reserverd.
// </copyright>
// <author>David López</author>
// <date>2021/03/18</date>
namespace TechnicalTest.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Create an instance of class <see cref="FormPage"/>
    /// </summary>
    public class FormPage
    {
        /// <summary>
        /// The driver
        /// </summary>
        private readonly IWebDriver _driver;

        /// <summary>
        /// Create an instance of class <see cref="FormPage"/>
        /// </summary>
        /// <param name="driver">The driver</param>
        public FormPage(IWebDriver driver) => _driver = driver;


        #region TextBox

        /// <summary>
        /// Textbox First Name
        /// </summary>
        public IWebElement TextBoxFirstName => _driver.FindElement(By.Id("firstName"));

        /// <summary>
        /// Textbox Last Name
        /// </summary>
        public IWebElement TextBoxLastName => _driver.FindElement(By.Name("lastName"));

        /// <summary>
        /// Textbox Cell Phone
        /// </summary>
        public IWebElement TextBoxCellPhone => _driver.FindElement(By.XPath("//*[@type='tel']"));

        /// <summary>
        /// Textbox Username
        /// </summary>
        public IWebElement TextBoxUsername => _driver.FindElement(By.Id("username"));

        /// <summary>
        /// Textbox Age
        /// </summary>
        public IWebElement TextBoxAge => _driver.FindElement(By.Name("age"));

        /// <summary>
        /// Textbox Email
        /// </summary>
        public IWebElement TextBoxEmail => _driver.FindElement(By.Id("email"));

        /// <summary>
        /// Textbox Address
        /// </summary>
        public IWebElement TextBoxAddress => _driver.FindElement(By.Id("address"));

        /// <summary>
        /// Textbox Address2
        /// </summary>
        public IWebElement TextBoxAddress2 => _driver.FindElement(By.Id("address2"));

        #endregion

        #region Validator

        /// <summary>
        /// Validator First Name
        /// </summary>
        public IWebElement ValidatorFirstName => _driver.FindElement(By.XPath("//*[@id='firstName']/following-sibling::div"));

        /// <summary>
        /// Validator Last Name
        /// </summary>
        public IWebElement ValidatorLastName => _driver.FindElement(By.XPath("//*[@name='lastName']/following-sibling::div"));

        /// <summary>
        /// Validator Cellphone
        /// </summary>
        public IWebElement ValidatorCellPhone => _driver.FindElement(By.XPath("//*[@type='tel']/following-sibling::div"));

        /// <summary>
        /// Validator Username
        /// </summary>
        public IWebElement ValidatorUsername => _driver.FindElement(By.XPath("//*[@id='username']/following-sibling::div"));

        /// <summary>
        /// Validator Age
        /// </summary>
        public IWebElement ValidatorAge => _driver.FindElement(By.XPath("//*[@name='age']/following-sibling::div"));

        /// <summary>
        /// Validator Email
        /// </summary>
        public IWebElement ValidatorEmail => _driver.FindElement(By.XPath("//*[@id='email']/following-sibling::div"));

        /// <summary>
        /// Validator Address
        /// </summary>
        public IWebElement ValidatorAddress => _driver.FindElement(By.XPath("//*[@id='address']/following-sibling::div"));

        /// <summary>
        /// Validator State
        /// </summary>
        public IWebElement ValidatorState => _driver.FindElement(By.XPath("//*[@id='state']/following-sibling::div"));

        /// <summary>
        /// Validator City
        /// </summary>
        public IWebElement ValidatorCity => _driver.FindElement(By.XPath("//*[@id='city']/following-sibling::div"));

        /// <summary>
        /// Validator Terms
        /// </summary>
        public IWebElement ValidatorTerms => _driver.FindElement(By.XPath("//*[@id='agree-terms-conditions']/following-sibling::div"));

        #endregion

        #region DropDown

        /// <summary>
        /// Dropdown Country
        /// </summary>
        public IWebElement DropDownCountry => _driver.FindElement(By.Id("country"));

        /// <summary>
        /// Dropdown State
        /// </summary>
        public IWebElement DropDownState => _driver.FindElement(By.Id("state"));

        /// <summary>
        /// Dropdown City
        /// </summary>
        public IWebElement DropDownCity => _driver.FindElement(By.Id("city"));

        #endregion

        #region Others

        /// <summary>
        /// Chechbox Terms And Conditions
        /// </summary>
        public IWebElement CheckBoxTermsAndConditions => _driver.FindElement(By.XPath("//label[@for='agree-terms-conditions']"));

        /// <summary>
        /// Button Send
        /// </summary>
        public IWebElement ButtonSend => _driver.FindElement(By.XPath("//*[contains(text(), 'Send')]"));

        /// <summary>
        /// Link Privacy
        /// </summary>
        public IWebElement LinkPrivacy => _driver.FindElement(By.XPath("//*[contains(text(), 'Privacy')]"));

        #endregion

        /// <summary>
        /// Fills the form with the information sent
        /// </summary>
        /// <param name="firstName">The first name</param>
        /// <param name="lastName">The last name</param>
        /// <param name="cellPhone">The cell phone number</param>
        /// <param name="userName">The username</param>
        /// <param name="age">The age</param>
        /// <param name="email">The email</param>
        /// <param name="address">The adress</param>
        /// <param name="address2">The optional address</param>
        /// <param name="country">The country</param>
        /// <param name="state">The state</param>
        /// <param name="city">The city</param>
        public void FillForm(string firstName, string lastName, string cellPhone, string userName, int age, string email, string address, string address2, string country, string state, string city)
        {
            // Ingresa el texto en el campo First name
            this.TextBoxFirstName.SendKeys(firstName);

            // Ingresa el texto en el campo Last name
            this.TextBoxLastName.SendKeys(lastName);

            // Ingresa el texto en el campo CellPhone
            this.TextBoxCellPhone.SendKeys(cellPhone);

            // Ingresa el texto en el campo Username
            this.TextBoxUsername.SendKeys(userName);

            // Ingresa el texto  en el campo Age
            this.TextBoxAge.SendKeys(age.ToString());

            // Ingresa el texto en el campo Email
            this.TextBoxEmail.SendKeys(email);

            // Ingresa el texto en el campo Address
            this.TextBoxAddress.SendKeys(address);

            // Ingresa el texto en el campo Address 2
            this.TextBoxAddress2.SendKeys(address2);

            // Selecciona el elemento de la lista desplegable Country
            new SelectElement(this.DropDownCountry).SelectByText(country);

            // Selecciona el elemento de la lista desplegable State
            new SelectElement(this.DropDownState).SelectByText(state);

            // Selecciona el elemento de la lista desplegable State
            new SelectElement(this.DropDownCity).SelectByText(city);

            // Habilita el elemento "I agree to the terms and conditions"
            new Actions(_driver).MoveToElement(this.CheckBoxTermsAndConditions, 1, 1).Click().Perform();

            // Click en el botón Send
            this.ButtonSend.Click();
        }

        /// <summary>
        /// Goes to the privacy page
        /// </summary>
        public void GoToPrivacyPage()
        {
            // Ingresa el texto "User FirstName" en el campo First name
            this.LinkPrivacy.Click();

            // Cambia a la pestaña adecuada
            _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        }
    }
}
