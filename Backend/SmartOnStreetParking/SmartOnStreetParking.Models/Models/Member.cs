using Newtonsoft.Json;
using SmartOnStreetParking.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{
    [Table("Members")]
    public class Member
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Member_Id")]
        public long Id { get; set; }

        [Column("Member_Name")]
        public string Name { get; set; }

        [Column("Member_Info")]
        public string Info { get; set; }

        [Column("Member_Logo")]
        public string Logo { get; set; }

        [Column("Member_Address")]
        public string Address { get; set; }

        [Column("Member_PostalCode")]
        public string PostalCode { get; set; }

        [Column("Member_Country")]
        public string Country { get; set; }

        [Column("Member_Phone")]
        public string Phone { get; set; }

        [Column("Member_Email")]
        public string Email { get; set; }

        [Column("Member_ContactName")]
        public string ContactName { get; set; }

        [Column("Member_ApiKey")]
        public string ApiKey { get; set; }

        [Column("Member_ApiSecret")]
        public string ApiSecret { get; set; }

        [Column("Member_Type")]
        public MemberType Type { get; set; }

        [Column("Member_RevenuePercentAsDev")]
        public decimal RevenuePercentAsDev { get; set; }

        [Column("Member_RevenuePercentAsProv")]
        public decimal RevenuePercentAsProv { get; set; }

        



        [JsonIgnore]
        public virtual ICollection<Zone> Zones { get; set; }
    }




}
