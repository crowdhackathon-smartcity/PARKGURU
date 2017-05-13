﻿using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        /// Class Constructor
        /// </summary>
        public ZoneRepository()
        {

        }

        #region Zone
        /// <summary>
        /// Add new zone
        /// </summary>
        public Zone Add(Zone ZoneInfo)
        {
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.Zones.Add(ZoneInfo);
                DBContext.SaveChanges();
            }
            return ZoneInfo;
        }

        /// <summary>
        /// Edit an existing zone.
        /// </summary>
        /// <param name="ZoneInfo">The details of the zone to edit.</param>
        public void Edit(Zone ZoneInfo)
        {
            int ZoneToEdit = 0;
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                ZoneToEdit = DBContext.Zones.Count(v => v.Id == ZoneInfo.Id);
            }
            if (ZoneToEdit > 0)
            {
                using (var DBContext = new SmartOnStreetParkingDbContext())
                {
                    DBContext.Zones.Attach(ZoneInfo);
                    DBContext.Entry(ZoneInfo).State = EntityState.Modified;
                    DBContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Delete an existing zone.
        /// </summary>
        /// <param name="Id">The id of the zone to delete.</param>
        public void Delete(long Id)
        {
            Zone ZoneToDelete = null;
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                ZoneToDelete = DBContext.Zones.Where(v => v.Id == Id).FirstOrDefault();
            }

            if (ZoneToDelete != null)
            {
                using (var DeleteContext = new SmartOnStreetParkingDbContext())
                {
                    DeleteContext.Entry(ZoneToDelete).State = EntityState.Deleted;
                    DeleteContext.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Get all zones
        /// </summary>
        public List<Zone> GetAll()
        {

            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                DBContext.Configuration.ProxyCreationEnabled = false;
                var zones = DBContext.Zones;
                if (zones.Count() == 0)
                    return new List<Zone>();
                else
                    return DBContext.Zones.ToList();
            }
        }

        /// <summary>
        /// Get a specific zone from the database.
        /// </summary>
        /// <param name="Id">The Id of the zone to find.</param>
        /// <returns>If Successfull value wil return the zone object, else null.</returns>
        //public Zone_ViewModel GetById(long Id, string Lang)
        //{
        //    Zone_ViewModel ret = null;
        //    using (var DBContext = new SmartOnStreetParkingDbContext())
        //    {

        //        var Result = DBContext.Zones.Where(u => u.Id == Id).Include(pr => pr.PricingCatalogs).FirstOrDefault();
        //        if (Result == null)
        //        {
        //            throw Utils.GenerateHttpResponse(HttpStatusCode.NotFound, string.Format("Zone with id: {0} not found", Id), "Zone not found");
        //        }
        //        ret = new Zone_ViewModel() { Color = Result.Color, Currency = Result.PricingCatalogs.FirstOrDefault().Currency, Description = Result.Description.ToLocaleString(Lang), Id = Result.Id, IsParkingAllowed = Result.IsParkingAllowed, IsPaying = Result.IsPaying, Municipality = Result.Ventor.Id, MunicipalityParkingText = Result.Ventor.Name.ToLocaleString(Lang), MunicipalityUrl = Result.Ventor.Logo, Name = Result.Name.ToLocaleString(Lang), TimeLimit = Result.TimeLimit, TransactionFee = Result.TransactionFee, Vat = Result.PricingCatalogs.FirstOrDefault().Vat };
        //    }
        //    return ret;
        //}
        /// <summary>
        /// Get a specific zone from the database.
        /// </summary>
        /// <param name="Id">The Id of the zone to find.</param>
        /// <returns>If Successfull value wil return the zone object, else null.</returns>
        //public Zone GetZoneById(long Id)
        //{
        //    Zone ret = null;
        //    using (var DBContext = new SmartOnStreetParkingDbContext())
        //    {

        //        ret = DBContext.Zones.Where(u => u.Id == Id).FirstOrDefault();
        //        if (ret == null)
        //        {
        //            throw Utils.GenerateHttpResponse(HttpStatusCode.NotFound, string.Format("Zone with id: {0} not found", Id), "Zone not found");
        //        }
        //    }
        //    return ret;
        //}
        

        #endregion
    }
}
