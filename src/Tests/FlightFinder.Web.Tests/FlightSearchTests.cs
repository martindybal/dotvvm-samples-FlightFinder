using FlightFinder.BL.Models;
using FlightFinder.Web.Tests.FlightSearch.SearchForm;
using Riganti.Selenium.Core.Abstractions;
using System;
using Xunit;

namespace FlightFinder.Web.Tests
{
    public class FlightSearchTests : UITestBase
    {
        [Fact]
        public void SearchFlightForBestConferenceTest()
        {
            RunInAllBrowsers(SearchFlightForBestConference);
        }

        private void SearchFlightForBestConference(IBrowserWrapper wrapper, FlightSearchPageObject page)
        {
            page.SearchForm.From = "Prague";
            page.SearchForm.To = "London Heathrow";

            page.SearchForm.Depart = new DateTime(2018, 11, 21);
            page.SearchForm.Return = new DateTime(2018, 11, 24);

            page.SearchForm.TicketClass = TicketClassData.Get(TicketClass.Business);

            page.SearchForm.Search();
        }

        [Fact]
        public void SearchFormDepart_AfterLoad_IsSetForToday_Fact()
        {
            RunInAllBrowsers(SearchFormDepart_AfterLoad_IsSetForToday);
        }

        private void SearchFormDepart_AfterLoad_IsSetForToday(IBrowserWrapper wrapper, FlightSearchPageObject page)
        {
            Assert.Equal(DateTime.Today, page.SearchForm.Depart);
        }

        [Fact]
        public void SearchFormReturn_AfterLoad_IsSetForTodayPlus7_Fact()
        {
            RunInAllBrowsers(SearchFormReturn_AfterLoad_IsSetForTodayPlus7);
        }

        private void SearchFormReturn_AfterLoad_IsSetForTodayPlus7(IBrowserWrapper wrapper, FlightSearchPageObject page)
        {
            Assert.Equal(DateTime.Today.AddDays(7), page.SearchForm.Return);
        }


        protected void RunInAllBrowsers(Action<IBrowserWrapper, FlightSearchPageObject> action)
        {
            base.RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(string.Empty);
                var flightSearchPageObject = new FlightSearchPageObject(browser);
                action(browser, flightSearchPageObject);
            });
        }
    }
}