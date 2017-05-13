using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartOnStreetParking.Web.Extensions;
using SmartOnStreetParking.Web.Utils;
using System.Globalization;

namespace SmartOnStreetParking.Web.Controllers
{
    public class DashboardController : BaseController

    {
        private readonly IDashboardRepository _Repository;
        public DashboardController()
        {
            _Repository = new DashboardRepository(); 
        }

        public DashboardController(IDashboardRepository Repository)
        {
            _Repository = Repository;
        }


        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            // use the logged in user's vendor.
            Member CurrentMember = ApplicationCache.GetMember(Convert.ToInt64(User.Identity.GetProperty("Member_Id")));
            ViewBag.MemberId = CurrentMember.Id;
            return View();
        }

        [HttpGet]
        public string GetTotalZones()
        {
            return _Repository.GetZonesCount().ToString();
        }

        
    }
}