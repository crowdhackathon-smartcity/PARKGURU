using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface IGeneralRepository
    {
        List<dynamic> GetZonesLight(Int64 MemberId);
    }
}
