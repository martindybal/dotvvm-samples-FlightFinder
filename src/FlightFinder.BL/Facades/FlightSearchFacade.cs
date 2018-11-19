using FlightFinder.BL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightFinder.BL.Services;

namespace FlightFinder.BL.Facades
{
    public class FlightSearchFacade : IFlightSearchFacade
    {
        private readonly IFlightSearchService flightSearchService;
        private readonly IAirportService airportService;

        public FlightSearchFacade(IFlightSearchService flightSearchService, IAirportService airportService)
        {
            this.flightSearchService = flightSearchService;
            this.airportService = airportService;
        }

        public async Task<IList<Airport>> GatAirportsAsync()
        {
            await LookBusy();

            return await airportService.GetAllAirportsAsync();
        }


        public async Task<Itinerary[]> Search(SearchCriteria criteria)
        {
            await LookBusy();

            return await flightSearchService.SearchAsync(criteria);
        }

        private static Task LookBusy() => Task.Delay(TimeSpan.FromMilliseconds(500));
    }
}
