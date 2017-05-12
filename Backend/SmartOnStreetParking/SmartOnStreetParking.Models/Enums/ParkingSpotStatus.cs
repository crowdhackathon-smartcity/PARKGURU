using System.ComponentModel.DataAnnotations;

namespace SmartOnStreetParking.Models.Enums
{
    public enum ParkingSpotStatus : int
    {
        [Display(Name = "Hidden")]
        Hidden = 0,
        [Display(Name = "Visible")]
        Visible = 1,
        [Display(Name = "Bookable")]
        Bookable = 2
    };
}
