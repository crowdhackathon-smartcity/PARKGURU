using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartOnStreetParking.Repositories;
using System.Collections.Generic;
using System.IO;
using SmartOnStreetParking.Models;
using SmartOnStreetParking.Models.ViewModels;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestImport()
        {
            Console.WriteLine("Base Dir:" + AppDomain.CurrentDomain.BaseDirectory);
            //Open the XML File
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\StreetParking.xml";
            if (File.Exists(filePath))
            {
                string xml = File.ReadAllText(filePath);
                if (xml.Length > 0)
                {
                    IImportRepository mYREP = new ImportRepository();
                    List<SmartOnStreetParking.Repositories.ParkingSpotImport.ImportedParkingSpot> PSList =  mYREP.GetParkingSpots(xml, "Athens");

                    Console.Write("Number of imported Parking spots: {0}", PSList.Count);
                }

            }
            
        }


        [TestMethod]
        public void TestFind()
        {
            SearchSpotsRequest SearchSpotsRequest = new SearchSpotsRequest();
            SearchSpotsRequest.Longitude = 23.7356535;
            SearchSpotsRequest.Latitude = 37.9828735;
            SearchSpotsRequest.SearchDistance = 1000;
            SearchSpotsRequest.Duration = 120;
            SearchSpotsRequest.VehiclePlate = "KPH5144";
            IAPIRepository _APIRepository = new APIRepository();

           List<ParkingSpotResponse> ForMitsos= _APIRepository.SearchSpots(SearchSpotsRequest);
        }

        [TestMethod]
        public void TestCalcTickets()
        {
            CalcTicketsRequest CalcTicketsRequest = new CalcTicketsRequest();
            CalcTicketsRequest.SpotId = 1;
            CalcTicketsRequest.Duration = 135;
            CalcTicketsRequest.VehiclePlate = "KPH5144";
            IAPIRepository _APIRepository = new APIRepository();

            SpotTicketsResponse ForMitsos = _APIRepository.CalcSpotTickets(CalcTicketsRequest);
        }

        [TestMethod]
        public void TestUpdateSpatialData()
        {

            long RecordId = 1;
            List<Coordinate> TempEdges = new List<Coordinate>();
            TempEdges.Add(new Coordinate(37.9828735, 23.7356535));
            TempEdges.Add(new Coordinate(37.9833332, 23.7353771));
            IAPIRepository Repository = new APIRepository();
            Repository.UpdateDummyRecordWithSpatial(1, TempEdges);

        }

    }
}
