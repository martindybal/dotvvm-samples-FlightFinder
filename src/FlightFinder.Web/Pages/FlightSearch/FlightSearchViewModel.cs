using System;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.BL.Facades;
using FlightFinder.BL.Models;
using FlightFinder.Web.Controls.OrderDialog;
using FlightFinder.Web.Controls.SearchForm;
using FlightFinder.Web.Controls.SearchResults;
using FlightFinder.Web.Controls.Shortlist;

namespace FlightFinder.Web.Pages.FlightSearch
{
    public class FlightSearchViewModel : MasterPageViewModel
    {
        private readonly IFlightSearchFacade flightSearchFacade;


        public SearchFormModel SearchFormModel { get; set; } = new SearchFormModel();

        public SearchResultsModel SearchResultsModel { get; set; } = new SearchResultsModel();

        public ShortlistModel ShortlistModel { get; set; } = new ShortlistModel();

        public OrderDialogModel OrderDialogModel { get; set; } = new OrderDialogModel();

        public FlightSearchViewModel(IFlightSearchFacade flightSearchFacade)
        {
            this.flightSearchFacade = flightSearchFacade;
        }

        public override async Task Init()
        {
            if (!Context.IsPostBack)
            {
                SearchFormModel.Criteria = new SearchCriteria()
                {
                    FromAirport = "LHR",
                    ToAirport = "SEA",
                    OutboundDate = DateTime.Now.Date,
                    ReturnDate = DateTime.Now.Date.AddDays(7)
                };

                SearchFormModel.Airports = await flightSearchFacade.GatAirportsAsync();
            }

            await base.Init();
        }

        public async Task Search()
        {
            SearchResultsModel.Results = await flightSearchFacade.Search(SearchFormModel.Criteria);

            SortResult();
        }

        public void SortResult()
        {
            switch (SearchResultsModel.SortOrder)
            {
                case SortOrder.Price:
                    SearchResultsModel.Results = SearchResultsModel.Results.OrderBy(r => r.Price).ToArray();
                    break;
                default:
                    SearchResultsModel.Results = SearchResultsModel.Results.OrderBy(r => r.TotalDurationHours).ToArray();
                    break;
            }
        }

        public void AddToShortlist(Itinerary itinerary)
        {
            ShortlistModel.Shortlist.Add(itinerary);
        }
    }
}
