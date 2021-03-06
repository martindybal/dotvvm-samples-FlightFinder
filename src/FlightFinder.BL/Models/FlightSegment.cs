﻿using System;

namespace FlightFinder.BL.Models
{
    public class FlightSegment
    {
        public string Airline { get; set; }
        public string FromAirportCode { get; set; }
        public string ToAirportCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public double DurationHours { get; set; }
        public TicketClassData TicketClass { get; set; }
    }
}
