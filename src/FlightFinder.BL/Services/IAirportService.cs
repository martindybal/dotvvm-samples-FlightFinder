using System.Threading.Tasks;
using FlightFinder.BL.Models;

namespace FlightFinder.BL.Services
{
    public interface IAirportService
    {
        Task<Airport[]> GetAllAirportsAsync();
    }
}