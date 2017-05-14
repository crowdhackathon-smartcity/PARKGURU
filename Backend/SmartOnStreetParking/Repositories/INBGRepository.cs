using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface INBGRepository
    {
        void GetBanks();
        Boolean MakeTransaction(string NBGAuthID, string NBGAuthToken, string FromIBAN, string ToIBAN, string currency, double ammount);
    }
}
