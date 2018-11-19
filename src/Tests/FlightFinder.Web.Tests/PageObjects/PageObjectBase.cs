using OpenQA.Selenium;
using Riganti.Selenium.Core.Abstractions;
using System;
using System.Globalization;

namespace FlightFinder.Web.Tests.FlightSearch.SearchForm
{
    public class PageObjectBase
    {
        protected readonly IBrowserWrapper browser;
        public PageObjectBase(IBrowserWrapper browser)
        {
            this.browser = browser;
        }

        protected IElementWrapper GetControlByUiId(string uiid)
        {
            return browser.Single(uiid, UITestBase.SelectByDataUiId);
        }

        protected string GetTextBoxValue(IElementWrapper textBox)
        {
            return textBox.GetText();
        }

        protected void SetTextBoxValue(IElementWrapper textBox, string value)
        {
            textBox.Click();
            textBox.Clear();
            textBox.SendKeys(Keys.Escape);

            textBox.SendKeys(value);
            textBox.SendEnterKey();
        }

        protected string GetComboBoxValue(IElementWrapper comboBox)
        {
            return GetTextBoxValue(comboBox.Single("input"));
        }

        protected void SetComboBoxValue(IElementWrapper comboBox, string value)
        {
            SetTextBoxValue(comboBox.Single("input"), value);
        }

        protected DateTime GetDatePickerValue(IElementWrapper datePicker)
        {
            var datePickerText = GetTextBoxValue(datePicker.Single("input"));
            return DateTime.ParseExact(datePickerText, "D", CultureInfo.CurrentCulture);
        }
        
        protected void SetDatePickerValue(IElementWrapper datePicker, DateTime value)
        {
            var textBox = datePicker.Single("input");
            textBox.Click();
            textBox.Clear();
            textBox.SendKeys(Keys.Escape);

            textBox.SendKeys(value.ToString("D"));
            textBox.SendEnterKey();
        }
    }
}