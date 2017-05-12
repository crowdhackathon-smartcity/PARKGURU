using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartOnStreetParking.Web.Utils
{
    public class BaseController: Controller
    {

        /// <summary>
        /// Default Error handling for controller.
        /// </summary>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();

                Exception ex = filterContext.Exception;
                //do something with these details here

                filterContext.ExceptionHandled = true;
                //if (ex is System.Web.Http.HttpResponseException)
                //{
                //    if ((ex as System.Web.Http.HttpResponseException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                //    {
                //        filterContext.Result = RedirectToAction("NoDataError", "Pages");
                //    }
                //    else if ((ex as System.Web.Http.HttpResponseException).Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //    {
                //        filterContext.Result = RedirectToAction("BadRequestError", "Pages");
                //    }
                //}
                //else
                //{
                //    //log.Error(ex.Message, ex);
                    TempData["CustomError"] = ex.Message;
                    filterContext.Result = RedirectToAction("InternalServerError", "Pages");
                //}

                base.OnException(filterContext);
            }
        }
    }
}