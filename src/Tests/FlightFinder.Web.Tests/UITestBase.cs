using OpenQA.Selenium;
using Riganti.Selenium.AssertApi;
using Riganti.Selenium.Core;
using Riganti.Selenium.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Xunit.Sdk;

namespace FlightFinder.Web.Tests
{
    public abstract class UITestBase : SeleniumTest
    {
        protected UITestBase()
            : base(new TestOutputHelper())
        {
            CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo("en-US");
        }
        
        public static By SelectByDataUiId(string dataUiId) => By.CssSelector($"[data-ui='{dataUiId}']");
        
        protected void RunInAllBrowsers(string pageUrl, Action<BrowserWrapper> action)
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(pageUrl);
                action(browser as BrowserWrapper);
            });
        }

        protected void RunInAllBrowsers(string pageUrl, string controlUiId, Action<IBrowserWrapper, IElementWrapper> action)
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(pageUrl);
                var control = browser.Single(controlUiId, SelectByDataUiId);
                action(browser, control);
            });
        }

        protected void RunInAllBrowsers(Action<IBrowserWrapper> action)
        {
            AssertApiSeleniumTestExecutorExtensions.RunInAllBrowsers(this, action);
        }
    }
}
