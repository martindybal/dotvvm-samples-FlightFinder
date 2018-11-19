using Riganti.Selenium.Core.Abstractions;

namespace FlightFinder.Web.Tests.FlightSearch.SearchForm
{
    public class FlightSearchPageObject : PageObjectBase
    {
        public SearchFormControlObject SearchForm { get; }
        
        public FlightSearchPageObject(IBrowserWrapper browser) : base(browser)
        {
            SearchForm = new SearchFormControlObject(browser);
        }
    }
}