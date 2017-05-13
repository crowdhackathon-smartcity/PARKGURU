using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartOnStreetParking.Repositories.ParkingSpotImport;

namespace SmartOnStreetParking.Repositories
{
    public class ImportRepository : IImportRepository
    {

        public List<ImportedParkingSpot> GetParkingSpots(string xml, string Mun)
        {
            ParkingSpotImportHandler importHandler = new ParkingSpotImportHandler();
            
            List<ImportedParkingSpot>tmpList = importHandler.GetParkingSpots(xml, Mun);

            Console.Write(tmpList.Count);

            return tmpList;
        }

    }
}
