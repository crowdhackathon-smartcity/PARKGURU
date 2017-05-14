using Newtonsoft.Json;
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
            D1 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Sunday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D2 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Monday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D3 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Tuesday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D4 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Wednesday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D5 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Thursday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D6 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Friday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
            D7 = new TimeItemViewModel() { Checked = false, Days = DayOfWeek.Saturday, Start = new TimeSpan(0, 0, 0, 0), End = new TimeSpan(1, 0, 0, 0) };
        }

        public List<ParkingTimeTable> CreateTimeTable()
        {
            List<ParkingTimeTable> RetVal = new List<ParkingTimeTable>();
            if (D1.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D1.Days, Start = D1.Start, End = D1.End });
            }
            if (D2.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D2.Days, Start = D2.Start, End = D2.End });
            }
            if (D3.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D3.Days, Start = D3.Start, End = D3.End });
            }
            if (D4.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D4.Days, Start = D4.Start, End = D4.End });
            }
            if (D5.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D5.Days, Start = D5.Start, End = D5.End });
            }
            if (D6.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D6.Days, Start = D6.Start, End = D6.End });
            }
            if (D7.Checked)
            {
                RetVal.Add(new ParkingTimeTable() { Days = D7.Days, Start = D7.Start, End = D7.End });
            }

            return RetVal;
        }

        public void LoadTimeTable()
        {
            List<ParkingTimeTable> Items = JsonConvert.DeserializeObject<List<ParkingTimeTable>>(this.TimeTableAsJson);

            foreach (ParkingTimeTable Item in Items)
            {
                switch (Item.Days)
                {
                    case DayOfWeek.Sunday:
                        D1.Checked = true;
                        D1.Start = Item.Start;
                        D1.End = Item.End;
                        break;
                    case DayOfWeek.Monday:
                        D2.Checked = true;
                        D2.Start = Item.Start;
                        D2.End = Item.End;
                        break;
                    case DayOfWeek.Tuesday:
                        D3.Checked = true;
                        D3.Start = Item.Start;
                        D3.End = Item.End;
                        break;
                    case DayOfWeek.Wednesday:
                        D4.Checked = true;
                        D4.Start = Item.Start;
                        D4.End = Item.End;
                        break;
                    case DayOfWeek.Thursday:
                        D5.Checked = true;
                        D5.Start = Item.Start;
                        D5.End = Item.End;
                        break;
                    case DayOfWeek.Friday:
                        D6.Checked = true;
                        D6.Start = Item.Start;
                        D6.End = Item.End;
                        break;
                    case DayOfWeek.Saturday:
                        D7.Checked = true;
                        D7.Start = Item.Start;
                        D7.End = Item.End;
                        break;
                }
            }

        }
    }

    public class TimeItemViewModel: ParkingTimeTable
    {
        public bool Checked { get; set; }
        

    }
}