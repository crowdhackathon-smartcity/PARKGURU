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
        [Display(Name = "Unknown", ResourceType = typeof(Resources.Resources))]
        Unknown = 0,
        [Display(Name = "NoSpace", ResourceType = typeof(Resources.Resources))]
        NoSpace = 1,
        [Display(Name = "Limited", ResourceType = typeof(Resources.Resources))]
        Limited = 2,
        [Display(Name = "Medium", ResourceType = typeof(Resources.Resources))]
        Medium = 3,
        [Display(Name = "High", ResourceType = typeof(Resources.Resources))]
        High = 4,
        [Display(Name = "Closed", ResourceType = typeof(Resources.Resources))]
        Closed = 5
    };
}
