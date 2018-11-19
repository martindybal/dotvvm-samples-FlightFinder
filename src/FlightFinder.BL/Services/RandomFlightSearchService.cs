using System;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.BL.Models;

namespace FlightFinder.BL.Services
{
    internal class RandomFlightSearchService : IFlightSearchService
    {
        protected internal Random random = new Random();

        public Task<Itinerary[]> SearchAsync(SearchCriteria criteria)
        {
            var results = Enumerable.Range(0, random.Next(1, 5))
                .Select(_ => new Itinerary
                {
                    Price = random.Next(100, 2000),
                    Outbound = new FlightSegment
                    {
                        Airline = RandomAirline(),
                        FromAirportCode = criteria.FromAirport,
                        ToAirportCode = criteria.ToAirport,
                        DepartureTime = criteria.OutboundDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                        ReturnTime = criteria.OutboundDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                        DurationHours = 2 + random.Next(10),
                        TicketClass = TicketClassData.Get(criteria.TicketClass)
                    },
                    Return = new FlightSegment
                    {
                        Airline = RandomAirline(),
                        FromAirportCode = criteria.ToAirport,
                        ToAirportCode = criteria.FromAirport,
                        DepartureTime = criteria.ReturnDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                        ReturnTime = criteria.ReturnDate.AddHours(random.Next(24)).AddMinutes(5 * random.Next(12)),
                        DurationHours = 2 + random.Next(10),
                        TicketClass = TicketClassData.Get(criteria.TicketClass)
                    },
                })
                .ToArray();

            return Task.FromResult(results);
        }

        private string RandomAirline() => SampleData.Airlines[random.Next(SampleData.Airlines.Length)];

    }
}