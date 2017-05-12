using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.Enums
{
    public enum MemberType : int
    {
        [Display(Name = "Municipality")]
        Provider = 1,
        [Display(Name = "Developer")]
        Developer = 2
    }
}
