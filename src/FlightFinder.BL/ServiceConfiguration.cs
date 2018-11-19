using FlightFinder.BL.Facades;
using FlightFinder.BL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.BL
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFlightFinderBL(this IServiceCollection services)
        {
            services.AddTransient<IFlightSearchService, RandomFlightSearchService>();
            services.AddTransient<IAirportService, StaticAirportService>();
            services.AddTransient<IFlightSearchFacade, FlightSearchFacade>();
            return services;
        }
    }
}