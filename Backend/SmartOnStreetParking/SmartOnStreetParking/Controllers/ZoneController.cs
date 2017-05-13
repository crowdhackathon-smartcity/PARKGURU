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

        public ActionResult Add()
        {
            AddZoneViewModel ViewModel = new AddZoneViewModel();

            ViewModel.MemberId = GetMember().Id;


            return View(ViewModel);
        }

        /// <summary>
        /// Add a new bank account to the database.
        /// </summary>
        /// <param name="AccountInfo">The details of the new account.</param>
        /// <returns>ActionResult</returns>
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Add(AccountSettings_ViewModel AccountInfo)
        //{
        //    if (!ModelState.IsValid) { return View(AccountInfo); }

        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountSettings_ViewModel, AccountSettings>());
        //    var mapper = config.CreateMapper();
        //    AccountSettings NewAccount = mapper.Map<AccountSettings_ViewModel, AccountSettings>(AccountInfo);

        //    _Repository.Add(NewAccount);

        //    if (AccountInfo.Type == BankingAccountType.Bank)
        //    {

        //        return RedirectToAction(BankingControllerIndex.BankIndex);
        //    }
        //    else
        //    {
        //        return RedirectToAction(BankingControllerIndex.PaypalIndex);
        //    }
        //}

    }

    

}