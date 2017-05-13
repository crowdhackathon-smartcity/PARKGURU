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

            return View(RetVal);
        }
    }
}