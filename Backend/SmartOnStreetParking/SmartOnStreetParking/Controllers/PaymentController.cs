using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.ViewModels;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartOnStreetParking.Web.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentRepository _Repository;

        public PaymentController()
        {
            _Repository = new PaymentRepository();
        }

        public PaymentController(IPaymentRepository Repository)
        {
            _Repository = Repository;
        }

        public ActionResult View()
        {

            List<Payment> RetVal = _Repository.GetAll();
            List<Payment_ViewModel> Ret = new List<Payment_ViewModel>();
            foreach (var itm in RetVal)
            {
                Payment_ViewModel i = new Payment_ViewModel();
                i.MemberId = itm.MemberId;
                i.MemberName = itm.Member.Name;
                i.MuncipId = itm.ParkingSpot.Zone.Member.Id;
                i.MuncipName = itm.ParkingSpot.Zone.Member.Name;
                i.Plate = itm.VehiclePlate;
                i.Duration = itm.Duration;
                i.Date = itm.Start;
                i.Price = itm.Ticket.Price;
                Ret.Add(i);
            }
            return View(Ret);
        }
    }
}