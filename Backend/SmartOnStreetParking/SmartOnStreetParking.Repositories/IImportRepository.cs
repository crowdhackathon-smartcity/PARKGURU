using SmartOnStreetParking.Repositories.ParkingSpotImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface IImportRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="Mun"></param>
        List<ImportedParkingSpot> GetParkingSpots(string xml, string Mun);
    }
}
