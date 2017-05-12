using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.Enums
{
    public enum AvailabilityState : int
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "NoSpace")]
        NoSpace = 1,
        [Display(Name = "Limited")]
        Limited = 2,
        [Display(Name = "Medium")]
        Medium = 3,
        [Display(Name = "High")]
        High = 4,
        [Display(Name = "Closed")]
        Closed = 5
    };
}
