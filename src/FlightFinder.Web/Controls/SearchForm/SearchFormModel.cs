using System;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;
using FlightFinder.BL.Models;

namespace FlightFinder.Web.Controls.SearchForm
{
    public class SearchFormModel
    {
        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<Airport> Airports { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<TicketClassData> TicketClasses => TicketClassData.All;

        public SearchCriteria Criteria { get; set; }
        public DateTime Today { get; set; } = DateTime.Today;
    }
}