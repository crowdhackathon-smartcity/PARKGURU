using System.ComponentModel.DataAnnotations;

namespace SmartOnStreetParking.Models.Enums
{
    public enum ParkingSpotStatus : int
    {
        [Display(Name = "Hidden", ResourceType = typeof(Resources.Resources))]
        Hidden = 0,
        [Display(Name = "Visible", ResourceType = typeof(Resources.Resources))]
        Visible = 1,
        [Display(Name = "Bookable", ResourceType = typeof(Resources.Resources))]
        Bookable = 2
    };
}
