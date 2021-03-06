﻿using System.Collections.Generic;

namespace FlightFinder.BL.Models
{
    public class SortOrderData
    {
        public string Name { get; set; }

        public SortOrder Value { get; set; }

        public static IList<SortOrderData> All { get; } = new[]
        {
            new SortOrderData() { Name = "Cheapest", Value = SortOrder.Price }, 
            new SortOrderData() { Name = "Fastest", Value = SortOrder.Duration }
        };
    }
}