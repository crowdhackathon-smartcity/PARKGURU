using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartOnStreetParking.Web.Models
{
    public class AddZoneViewModel: Zone
    {

        

        public TimeItemViewModel D1 { get; set; }
        public TimeItemViewModel D2 { get; set; }
        public TimeItemViewModel D3 { get; set; }
        public TimeItemViewModel D4 { get; set; }
        public TimeItemViewModel D5 { get; set; }
        public TimeItemViewModel D6 { get; set; }
        public TimeItemViewModel D7 { get; set; }


        public AddZoneViewModel()
        {
            D1 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Sunday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D2 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Monday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D3 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Tuesday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D4 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Wednesday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D5 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Thursday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D6 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Friday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D7 = new TimeItemViewModel() { Checked = true, Days = DayOfWeek.Saturday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
        }
    }

    public class TimeItemViewModel: ParkingTimeTable
    {
        public bool Checked { get; set; }
        

    }
}