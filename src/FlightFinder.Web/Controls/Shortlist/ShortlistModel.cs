using System.Collections.Generic;
using System.Linq;
using FlightFinder.BL.Models;

namespace FlightFinder.Web.Controls.Shortlist
{
    public class ShortlistModel
    {
        public List<Itinerary> Shortlist { get; set; } = new List<Itinerary>();
        public decimal TotalPrice => Shortlist.Sum(itinerary => itinerary.Price);

        public void RemoveFromShortlist(Itinerary itinerary)
        {
            Shortlist.Remove(itinerary);
        }
    }
}