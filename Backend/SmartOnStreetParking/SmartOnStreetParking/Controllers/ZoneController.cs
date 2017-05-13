using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Models;
using SmartOnStreetParking.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SmartOnStreetParking.Web.Controllers
{
    public class ZoneController : BaseController
    {
        private readonly IZoneRepository _Repository;

        public ZoneController()
        {
            _Repository = new ZoneRepository();
        }

        public ZoneController(IZoneRepository Repository)
        {
            _Repository = Repository;
        }

        public ActionResult Index()
        {

            List<Zone> RetVal = _Repository.GetAll();
            
            return View(RetVal);
        }



    }

    

}