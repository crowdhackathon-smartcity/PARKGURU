using SmartOnStreetParking.API.AuthorizeAPIRequest;
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
    //[BasicAuthentication]
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
        /// <param name="SearchSpotsRequest">The class that contains requested parameters</param>
        /// <returns>The array of parking spots</returns>
        [ResponseType(typeof(List<ParkingSpotResponse>))]
        [HttpPost]
        public IHttpActionResult SearchSpots(SearchSpotsRequest SearchSpotsRequest)
        {

            return Ok(_APIRepository.SearchSpots(SearchSpotsRequest));
        }

        /// <summary>
        /// Calculates the price to park at requested parking spot for the requested duration
        /// </summary>
        /// <param name="CalcTicketsRequest">The class that contains requested parameters</param>
        /// <returns>Parking spot calculated pricing class</returns>
        [ResponseType(typeof(SpotTicketsResponse))]
        [HttpPost]
        public IHttpActionResult CalcSpotTickets(CalcTicketsRequest CalcTicketsRequest)
        {

            return Ok(_APIRepository.CalcSpotTickets(CalcTicketsRequest));
        }


    }
}
