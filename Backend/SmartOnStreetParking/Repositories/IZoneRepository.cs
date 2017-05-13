using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartOnStreetParking.Repositories
{
    public interface IZoneRepository
    {
        Zone Add(Zone ZoneInfo);

        void Edit(Zone ZoneInfo);

        void Delete(long Id);

        List<Zone> GetAll();
    }
}
