using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartOnStreetParking.Web.Controllers
{
    [Authorize]
    public class TicketsController : BaseController
    {
        private readonly ITicketRepository _Repository;

        public TicketsController()
        {
            _Repository = new TicketRepository();
        }

        public TicketsController(ITicketRepository Repository)
        {
            _Repository = Repository;
        }
       
        
        // GET: Tickets
        public ActionResult Index()
        {
            List<Ticket> RetVal = _Repository.GetByMember(GetMember().Id);
            return View(RetVal);
        }


        public ActionResult Add()
        {
            Ticket ViewModel = new Ticket();

            //ViewModel.MemberId = GetMember().Id;
            //ViewModel.ParkingMaxDuration = 360;
            //ViewModel.IsPayingZone = true;
            ViewBag.ZoneList = LoadZones(GetMember().Id);
            return View(ViewModel);
        }


        private List<SelectListItem> LoadZones(long MemberId)
        {
            List<SelectListItem> SelectItems = new List<SelectListItem>();

            IGeneralRepository GenRep = new GeneralRepository();
            List<dynamic> ZoneResults = GenRep.GetZonesLight(GetMember().Id);

            ZoneResults.ForEach((v) =>
            {
                SelectItems.Add(new SelectListItem()
                {
                    Value = v.Id.ToString(),
                    Text = v.Name
                });
            });
            return SelectItems;
        }
    }
}