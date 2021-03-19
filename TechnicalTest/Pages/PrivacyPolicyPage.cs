//-----------------------------------------------------------------------
// <copyright file="PrivacyPolicyPage.cs" company=">Team International">
// Copyright (c) 2021 All rights reserverd.
// </copyright>
// <author>David López</author>
// <date>2021/03/18</date>
namespace TechnicalTest.Pages
{
    using OpenQA.Selenium;

    /// <summary>
    /// Create an instance of class <see cref="PrivacyPolicyPage"/>
    /// </summary>
    class PrivacyPolicyPage
    {
        /// <summary>
        /// The driver
        /// </summary>
        private readonly IWebDriver _driver;

        /// <summary>
        /// Create an instance of class <see cref="PrivacyPolicyPage"/>
        /// </summary>
        /// <param name="driver">The driver</param>
        public PrivacyPolicyPage(IWebDriver driver) => _driver = driver;

        /// <summary>
        /// Text Who Are We
        /// </summary>
        public IWebElement TextWhoAreWe => _driver.FindElement(By.XPath("//strong[text() = 'Who are we?']/parent::p"));
    }
}
