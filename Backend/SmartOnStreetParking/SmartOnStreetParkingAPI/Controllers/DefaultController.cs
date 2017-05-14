using SmartOnStreetParking.API.AuthorizeAPIRequest;
using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.ViewModels;
using SmartOnStreetParking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SmartOnStreetParking.API.Controllers
{
    //[MyAuthorizationFilter]
    public class DefaultController : ApiController
    {

        private readonly IAPIRepository _APIRepository;


        public DefaultController()
        {
            _APIRepository = new APIRepository();
        }

        public DefaultController(IAPIRepository Repository)
        {
            _APIRepository = Repository;
        }


        /// <summary>
        /// Search for parkings spots at requested location and radius
        /// </summary>
        /// <param name="SearchSpotsRequest">The class that contains the input parameters</param>
        /// <returns>The array of parking spots</returns>
        [ResponseType(typeof(List<ParkingSpotResponse>))]
        [HttpPost]
        public IHttpActionResult SearchSpots(SearchSpotsRequest SearchSpotsRequest)
        {

            return Ok(_APIRepository.SearchSpots(SearchSpotsRequest));
        }




        /// <summary>
        /// Transfer money from Developer's registered bank account to 3rd bank account
        /// </summary>
        /// <param name="DevAPIKey">The Dev API Key</param>
        /// <param name="DevApiSecret">The Developer API Secret</param>
        /// <param name="DestinationIBAN">The 3rd bank account</param>
        /// <param name="Amount">Amount</param>
        /// <param name="CurrencyCode">Currency Code</param>
        /// <returns>Http status 200 on success, http exception on fail</returns>
        [HttpGet]
        public IHttpActionResult TransferMoney(string DevAPIKey, string DevApiSecret,string DestinationIBAN, double Amount, string CurrencyCode )
        {

            return Ok(_APIRepository.TransferMoney( DevAPIKey,  DevApiSecret,  DestinationIBAN,  Amount,  CurrencyCode));
        }


        /// <summary>
        /// Check if a vehicle plate has a valid active payment
        /// </summary>
        /// <param name="VehiclePlate">The vehicle plate</param>
        /// <param name="APIKey">The Developer API Key</param>
        /// <returns>The active payment, null if no active payments exists</returns>
        [ResponseType(typeof(Payment))]
        [HttpGet]
        public IHttpActionResult CheckPlate(string VehiclePlate, string APIKey)
        {

            return Ok(_APIRepository.CheckPlate(VehiclePlate, APIKey));
        }

        /// <summary>
        /// Get parking history of a vehicle plate
        /// </summary>
        /// <param name="VehiclePlate">The vehicle plate</param>
        /// <param name="APIKey">The Developer API Key</param>
        /// <returns>List of payments class</returns>
        [ResponseType(typeof(List<Payment>))]
        [HttpGet]
        public IHttpActionResult GetPayments(string VehiclePlate,string APIKey)
        {

            return Ok(_APIRepository.GetPayments( VehiclePlate,  APIKey));
        }

        /// <summary>
        /// Vehicle plate payment for a period of time at a specific parking spot
        /// </summary>
        /// <param name="PayRequest">The class that contains the input parameters</param>
        /// <returns>The payment class</returns>
        [ResponseType(typeof(Payment))]
        [HttpPost]
        public IHttpActionResult Pay(PayRequest PayRequest)
        {

            return Ok(_APIRepository.Pay(PayRequest));
        }

        /// <summary>
        /// Calculates the price to park at requested parking spot for the requested duration
        /// </summary>
        /// <param name="CalcTicketsRequest">The class that contains the input parameters</param>
        /// <returns>Parking spot calculated pricing class</returns>
        [ResponseType(typeof(SpotTickets))]
        [HttpPost]
        public IHttpActionResult CalcSpotTickets(CalcTicketsRequest CalcTicketsRequest)
        {

            return Ok(_APIRepository.CalcSpotTickets(CalcTicketsRequest));
        }


    }
}
