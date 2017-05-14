using SmartOnStreetParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface IMemberRepository
    {
        Member GetById(long Id);

        void Edit(Member MemberInfo);
    }
}
