using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Models;
using SmartOnStreetParking.Web.Utils;
using SmartOnStreetParking.Web.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SmartOnStreetParking.Web.Controllers
{
    [Authorize]
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

        public ActionResult Add()
        {
            AddZoneViewModel ViewModel = new AddZoneViewModel();

            ViewModel.MemberId = GetMember().Id;
            ViewModel.ParkingMaxDuration = 360;
            ViewModel.IsPayingZone = true;

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddZoneViewModel ZoneInfo)
        {
            if (!ModelState.IsValid) { return View(ZoneInfo); }

            Zone ZoneModel = new Zone()
            {
                Color = ZoneInfo.Color,
                Deleted = false,
                IsPayingZone = ZoneInfo.IsPayingZone,
                MemberId = ZoneInfo.MemberId,
                Name = ZoneInfo.Name,
                ParkingMaxDuration = ZoneInfo.ParkingMaxDuration,
                Info = ZoneInfo.Info,
                Visible = true,
                DateCreated = DateTime.UtcNow,
                ParkingTimeTable = ZoneInfo.CreateTimeTable()
            };

            _Repository.Add(ZoneModel);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            //throw new NotFoundException("Edit Zone", Id);

            Zone ZoneInfo = _Repository.GetById(Id);

            if (ZoneInfo == null)
            {
                throw new NotFoundException("Edit Zone", Id);
            }


            AddZoneViewModel ViewModel = new AddZoneViewModel()
            {
                Color = ZoneInfo.Color,
                Deleted = false,
                IsPayingZone = ZoneInfo.IsPayingZone,
                MemberId = ZoneInfo.MemberId,
                Name = ZoneInfo.Name,
                ParkingMaxDuration = ZoneInfo.ParkingMaxDuration,
                Info = ZoneInfo.Info,
                Visible = true,
                DateCreated = DateTime.UtcNow,
                TimeTableAsJson = ZoneInfo.TimeTableAsJson,
          
            };
            ViewModel.LoadTimeTable();
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddZoneViewModel ZoneInfo)
        {
            if (!ModelState.IsValid) { return View(ZoneInfo); }

            Zone ZoneModel = new Zone()
            {
                Id=ZoneInfo.Id,
                Color = ZoneInfo.Color,
                Deleted = false,
                IsPayingZone = ZoneInfo.IsPayingZone,
                MemberId = ZoneInfo.MemberId,
                Name = ZoneInfo.Name,
                ParkingMaxDuration = ZoneInfo.ParkingMaxDuration,
                Info = ZoneInfo.Info,
                Visible = ZoneInfo.Visible,
                DateCreated = DateTime.UtcNow,
                ParkingTimeTable = ZoneInfo.CreateTimeTable()
            };

            _Repository.Edit(ZoneModel);

            return RedirectToAction("Index");
        }
    }




   
    

}