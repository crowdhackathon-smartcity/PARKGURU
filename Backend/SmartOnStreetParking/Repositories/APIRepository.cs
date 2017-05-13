﻿using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class APIRepository : IAPIRepository
    {

        public bool UpdateDummyRecordWithSpatial(long SpotId, List<Coordinate> Edges)
        {
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                var ParkingSpot = DBContext.ParkingSpots.Where(u => u.Id == SpotId).FirstOrDefault();
                if (ParkingSpot != null)
                {
                    ParkingSpot.GeometryEdges = Edges;
                    DBContext.SaveChanges();

                }

            }
            return true;
        }

        public List<ParkingSpotResponse> SearchSpots(SearchSpotsRequest SearchSpotsRequest)
        {
            List<ParkingSpotResponse> Ret = new List<ParkingSpotResponse>();

            Coordinate Point = new Coordinate(SearchSpotsRequest.Latitude, SearchSpotsRequest.Longitude);
            DbGeography SearchLocation = Point != null ? Point.ToGeography() : null;
            DbGeometry Circle = SearchLocation != null ? DbGeometry.FromBinary(SearchLocation.Buffer(2).AsBinary(), SearchLocation.CoordinateSystemId) : null; ;
            DbGeometry CloseCircle = SearchLocation != null ? DbGeometry.FromBinary(SearchLocation.Buffer(20).AsBinary(), SearchLocation.CoordinateSystemId) : null;


            using (var DBContext = new SmartOnStreetParkingDbContext())
            {


                var ParkingSpots = DBContext.ParkingSpots
                    .Include("Zone")
                    .Include("Zone.Tickets")
                    .Include("Zone.Member")
                    .Where(vn => vn.Location.Distance(SearchLocation) < SearchSpotsRequest.SearchDistance && vn.Zone != null);


                foreach (var ParkingSpot in ParkingSpots)
                {
                    ParkingSpotResponse ParkingSpotResponse = new ParkingSpotResponse()
                    {
                        ParkingMaxDuration = ParkingSpot.Zone.ParkingMaxDuration,
                        Id = ParkingSpot.Id,
                        GeometryType = ParkingSpot.GeometryType,
                        GeometryEdges = ParkingSpot.GeometryEdges,
                        CurrentAvailabilityState = ParkingSpot.CurrentAvailabilityState,
                        Address = ParkingSpot.Address,
                        Capacity = ParkingSpot.Capacity,
                        Info = ParkingSpot.Info,
                        Name = ParkingSpot.Name,
                        ParkingTimeTable = ParkingSpot.Zone.ParkingTimeTable,
                        ProviderId = ParkingSpot.Zone.MemberId,
                        ProviderLogo = ParkingSpot.Zone.Member.Logo,
                        ProviderName = ParkingSpot.Zone.Member.Name,
                        StreetView = ParkingSpot.StreetView,
                        Tickets = CalcSpotTickets(ParkingSpot.Zone, SearchSpotsRequest.Duration, SearchSpotsRequest.VehiclePlate),
                        ZoneId = ParkingSpot.ZoneId,
                        ZoneInfo = ParkingSpot.Zone.Info,
                        ZoneIsPaying = ParkingSpot.Zone.IsPayingZone,
                        ZoneName = ParkingSpot.Zone.Name,
                        ZoneColor = ParkingSpot.Zone.Color

                    };
                    if (ParkingSpot.GISEdges.Intersects(Circle))
                    {
                        ParkingSpotResponse.AtLocation = true;
                        ParkingSpotResponse.LocationDistance = 0;
                    }
                    else if (ParkingSpot.GISEdges.Intersects(CloseCircle))
                    {
                        ParkingSpotResponse.NearLocation = true;
                        ParkingSpotResponse.LocationDistance = 20;

                    }
                    else
                        ParkingSpotResponse.LocationDistance = Math.Max(21, ParkingSpot.Location.Distance(SearchLocation).Value);


                    Ret.Add(ParkingSpotResponse);
                }


            }


            return Ret;
        }


        private SpotTickets CalcSpotTickets(Zone Zone, int Duration,string VehiclePlate)
        {
            SpotTickets Ret = new SpotTickets();
            Ret.Tickets = new List<Ticket>();
            if (Zone.ParkingMaxDuration < Duration)
                return Ret;
            
            while (Duration>0)
            {
                var BestTicket = Zone.Tickets.Where(u => u.Duration > Duration).OrderBy(i => i.Duration).FirstOrDefault();
                if (BestTicket == null)
                    BestTicket = Zone.Tickets.Where(u => u.Duration <= Duration).OrderByDescending(i => i.Duration).FirstOrDefault();

                if (BestTicket == null)
                    break;
                Ret.Tickets.Add(new Ticket {Duration=BestTicket.Duration, Price=BestTicket.Price, SN=BestTicket.SN });
                Ret.Price = Ret.Price + BestTicket.Price;
                Duration = Duration - BestTicket.Duration;
            }

            return Ret;
        }


        public Payment CheckPlate(string VehiclePlate, string APIKey)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                var Payments = DBContext.Payments.Where(o => o.VehiclePlate.Contains(VehiclePlate) && o.APIKey == APIKey && o.Start <= DateTime.UtcNow).ToList();


                return Payments.Where(o => o.Start>= DateTime.UtcNow.AddMinutes(-o.Duration)).FirstOrDefault();
            }

        }


        public List<Payment> GetPayments(string VehiclePlate, string APIKey)
        {
            
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                return DBContext.Payments.Where(o => o.VehiclePlate.Contains(VehiclePlate) && o.APIKey == APIKey).ToList();
            }

        }

        public Payment Pay(PayRequest PayRequest)
        {

            
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {

                Member Member = DBContext.Members.Where(u => u.ApiKey == PayRequest.APIkey).FirstOrDefault();
                var Payment = new Payment()
                {
                    APIKey = PayRequest.APIkey,
                    MemberId= Member.Id,
                    Duration = PayRequest.SpotTickets.Tickets.Select(i => i.Duration).DefaultIfEmpty().Sum(),
                    ParkingSpotId=PayRequest.SpotId,
                    VehiclePlate= PayRequest.VehiclePlate,
                    Ticket= PayRequest.SpotTickets,
                    Start=DateTime.UtcNow

                    
                };

                DBContext.Payments.Add(Payment);
                DBContext.SaveChanges();
                return Payment;
            }
            
        }

        public SpotTickets CalcSpotTickets(CalcTicketsRequest CalcTicketsRequest)
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {


                var ParkingSpot = DBContext.ParkingSpots
                    .Include("Zone")
                    .Include("Zone.Tickets")
                    .Include("Zone.Member")
                    .Where(vn => vn.Id == CalcTicketsRequest.SpotId  && vn.Zone != null ).FirstOrDefault();
                if (ParkingSpot == null)
                    return null;
                else
                    return CalcSpotTickets(ParkingSpot.Zone, CalcTicketsRequest.Duration, CalcTicketsRequest.VehiclePlate);


            }

        }
    }
}
