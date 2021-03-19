//-----------------------------------------------------------------------
// <copyright file="ResultPage.cs" company=">Team International">
// Copyright (c) 2021 All rights reserverd.
// </copyright>
// <author>David López</author>
// <date>2021/03/18</date>
namespace TechnicalTest.Pages
{
    using OpenQA.Selenium;

    /// <summary>
    /// Initialize an instance of class <see cref="ResultPage"/>
    /// </summary>
    public class ResultPage
    {
        /// <summary>
        /// The Driver
        /// </summary>
        private readonly IWebDriver _driver;

        /// <summary>
        /// Create an instance of class <see cref="ResultPage"/>
        /// </summary>
        /// <param name="driver">The driver</param>
        public ResultPage(IWebDriver driver) => _driver = driver;

        /// <summary>
        /// Label Result
        /// </summary>
        public IWebElement LabelResult => _driver.FindElement(By.XPath("//*[@class='mb-3']"));
    }
}
