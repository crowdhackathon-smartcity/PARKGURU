using SmartOnStreetParking.Models;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Utils;
using SmartOnStreetParking.Web.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartOnStreetParking.Web.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {

        private readonly IMemberRepository _Repository;

        public MemberController()
        {
            _Repository = new MemberRepository();
        }

        public MemberController(IMemberRepository Repository)
        {
            _Repository = Repository;
        }


        public ActionResult Edit()
        {
            //throw new NotFoundException("Edit Zone", Id);

            Member MemberInfo = _Repository.GetById(GetMember().Id);

            if (MemberInfo == null)
            {
                throw new NotFoundException("Edit Member", GetMember().Id);
            }


            //AddZoneViewModel ViewModel = new AddZoneViewModel()
            //{
            //    Color = ZoneInfo.Color,
            //    Deleted = false,
            //    IsPayingZone = ZoneInfo.IsPayingZone,
            //    MemberId = ZoneInfo.MemberId,
            //    Name = ZoneInfo.Name,
            //    ParkingMaxDuration = ZoneInfo.ParkingMaxDuration,
            //    Info = ZoneInfo.Info,
            //    Visible = true,
            //    DateCreated = DateTime.UtcNow,
            //    TimeTableAsJson = ZoneInfo.TimeTableAsJson,

            //};
            
            return View(MemberInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member MemberInfo)
        {
            if (!ModelState.IsValid) { return View(MemberInfo); }

           _Repository.Edit(MemberInfo);

            return RedirectToAction("Index");
        }
    }
}