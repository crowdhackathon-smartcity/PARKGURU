using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models.ViewModels
{
    public class Payment_ViewModel
    {        
        public long MemberId { get; set; }
        [Display(Name = "Developer")]
        public String MemberName { get; set; }
        public long MuncipId { get; set; }
        [Display(Name = "City")]
        public String MuncipName { get; set; }
        [Display(Name = "Plate Number")]
        public String Plate { get; set; }
        [Display(Name = "Duration")]
        public int Duration { get; set; }
        [Display(Name = "Date/Time")]
        public DateTime Date { get; set; }
        [Display(Name = "Price")]
        public Decimal Price { get; set; }
    }
}
