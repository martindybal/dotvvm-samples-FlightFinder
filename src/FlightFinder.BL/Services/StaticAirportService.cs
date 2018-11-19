using System.Threading.Tasks;
using FlightFinder.BL.Models;

namespace FlightFinder.BL.Services
{
    internal class StaticAirportService : IAirportService
    {
        public Task<Airport[]> GetAllAirportsAsync()
        {
            return Task.FromResult(SampleData.Airports);
        }
    }
}