using System.Collections.Generic;
using System.Threading.Tasks;
using FlightFinder.BL.Models;

namespace FlightFinder.BL.Facades
{
    public interface IFlightSearchFacade
    {
        Task<IList<Airport>> GatAirportsAsync();
        Task<Itinerary[]> Search(SearchCriteria criteria);
    }
}