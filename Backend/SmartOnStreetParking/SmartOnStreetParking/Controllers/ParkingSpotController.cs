using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.Enums;
using SmartOnStreetParking.Repositories;
using SmartOnStreetParking.Web.Models;
using SmartOnStreetParking.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartOnStreetParking.Web.Controllers
{
    [Authorize]
    public class ParkingSpotController : BaseController
    {

        private readonly IParkingSpotRepository _Repository;

        public ParkingSpotController()
        {
            _Repository = new ParkingSpotRepository();
        }

        public ParkingSpotController(IParkingSpotRepository Repository)
        {
            _Repository = Repository;
        }


        // GET: ParkingSpot
        public ActionResult Index()
        {
            List<ParkingSpot> RetVal = _Repository.GetByMember(GetMember().Id);

            return View(RetVal);
        }

        public ActionResult Add()
        {
            AddParkingSpotViewModel ViewModel = new AddParkingSpotViewModel();
            ViewModel.CurrentAvailabilityState = AvailabilityState.High;
            ViewModel.GeometryType = GeometryType.Polygon;
            //ViewModel.MemberId = GetMember().Id;
            //ViewModel.ParkingMaxDuration = 360;
            //ViewModel.IsPayingZone = true;

            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddParkingSpotViewModel SpotInfo)
        {
            if (!ModelState.IsValid) { return View(SpotInfo); }

            var Settings = new JsonSerializerSettings();
            Settings.ContractResolver = new CustomContractResolver();
            List<Coordinate> Edges = string.IsNullOrEmpty(SpotInfo.StringEdges) ? null : JsonConvert.DeserializeObject<List<Coordinate>>(SpotInfo.StringEdges, Settings);
            if (Edges.Count > 0)
            {
                if (Edges[0].Latitude!= Edges[Edges.Count-1].Latitude || Edges[0].Longitude != Edges[Edges.Count - 1].Longitude)
                {
                    Edges.Add(Edges[0]);
                }
            }
            


            ParkingSpot SpotModel = new ParkingSpot
            {
                Address = SpotInfo.Address,
                Capacity = SpotInfo.Capacity,
                CurrentAvailabilityState = SpotInfo.CurrentAvailabilityState,
                DateCreated = DateTime.UtcNow,
                Deleted = false,
                
                GeometryType = SpotInfo.GeometryType,
                Info = SpotInfo.Info,
                Location = SpotInfo.Location,
                Name = SpotInfo.Name,
                StreetView = SpotInfo.StreetView,
                Visible = true,
                ZoneId = SpotInfo.ZoneId
            };

            //   SpotModel.GeometryEdges = Edges;
            _Repository.Add(SpotModel, Edges);
            //Zone ZoneModel = new Zone()
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
            //    ParkingTimeTable = ZoneInfo.CreateTimeTable()
            //};

            //_Repository.Add(ZoneModel);

            return RedirectToAction("Index");
        }


    }

    public class CustomContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public CustomContractResolver()
        {
            this.PropertyMappings = new Dictionary<string, string>
            {
                {"Longitude", "lng"},
                {"Latitude", "lat"}
            };
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}