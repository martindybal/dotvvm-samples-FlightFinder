using System.Collections.Generic;
using DotVVM.Framework.ViewModel;
using FlightFinder.BL.Models;

namespace FlightFinder.Web.Controls.SearchResults
{
    public class SearchResultsModel
    {
        public IList<Itinerary> Results { get; set; } = new List<Itinerary>();
        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<SortOrderData> SortOrders => SortOrderData.All;
        public SortOrder SortOrder { get; set; }
    }
}