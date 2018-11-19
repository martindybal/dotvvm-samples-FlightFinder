using System.Threading.Tasks;
using FlightFinder.BL.Models;

namespace FlightFinder.BL.Services
{
    public interface IFlightSearchService
    {
        Task<Itinerary[]> SearchAsync(SearchCriteria criteria);
    }
}