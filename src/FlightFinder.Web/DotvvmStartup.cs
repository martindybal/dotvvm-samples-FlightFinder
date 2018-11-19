using DotVVM.BusinessPack;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.Web
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
            config.DefaultCulture = "en-US";
            config.Debug = false;
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Pages/FlightSearch/FlightSearch.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddMarkupControl("cc", "GreyOutZone", "Controls/GreyOutZone/GreyOutZone.dotcontrol");
            config.Markup.AddMarkupControl("cc", "SearchForm", "Controls/SearchForm/SearchForm.dotcontrol");
            config.Markup.AddMarkupControl("cc", "SearchResultFlightSegment", "Controls/SearchResultFlightSegment/SearchResultFlightSegment.dotcontrol");
            config.Markup.AddMarkupControl("cc", "SearchResults", "Controls/SearchResults/SearchResults.dotcontrol");
            config.Markup.AddMarkupControl("cc", "Shortlist", "Controls/Shortlist/Shortlist.dotcontrol");
            config.Markup.AddMarkupControl("cc", "ShortlistFlightSegment", "Controls/ShortlistFlightSegment/ShortlistFlightSegment.dotcontrol");
            config.Markup.AddMarkupControl("cc", "OrderDialog", "Controls/OrderDialog/OrderDialog.dotcontrol");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddBusinessPack().AddDefaultTempStorages("temp");
        }
    }
}
