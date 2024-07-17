namespace MyWebDbApp.Models
{
    using System;
    using System.Collections.Generic;

    public class WeeklyOccupancyViewModel
    {
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
        public List<Occupancy> Occupancies { get; set; }
    }
}
