using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{

    /// <summary>
    /// The provider parking spot model
    /// </summary>
    [Table("Zones")]
    public class Zone
    {

        /// <summary>
        /// The Id of the record
        /// </summary>        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Zone_Id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of zone
        /// </summary>        
        [Column("Zone_Name")]
        public string Name { get; set; }

        /// <summary>
        /// The zone color
        /// </summary>        
        [Column("Zone_Color")]
        public string Color { get; set; }


        /// <summary>
        /// Any additional info of parking zone
        /// </summary>        
        [Column("Zone_Info")]
        public string Info { get; set; }

        /// <summary>
        /// The Member Id that zone belongs to
        /// </summary>        
        [Column("Zone_MemberId")]
        public long MemberId { get; set; }

        //public virtual


        /// <summary>
        /// Max allowed parking duration
        /// </summary>        
        [Column("Zone_ParkingMaxDuration")]
        public int ParkingMaxDuration { get; set; }


        /// <summary>
        /// Serialized TimeTable
        /// </summary>        
        [Column("Zone_TimeTable")]
        [JsonIgnore]
        public string TimeTableAsJson
        {
            get;set;
        }

/// <summary>
/// The Discount By Availability State. Takes effect when DiscountType==ByAvailabilityState
/// </summary>  
[NotMapped]
        public List<ParkingTimeTable> ParkingTimeTable
        {
            get
            {
                return TimeTableAsJson == null? new List<ParkingTimeTable>() :  JsonConvert.DeserializeObject<List<ParkingTimeTable>>(TimeTableAsJson);
            }
            set
            {
                try
                {
                    if (value == null)
                    {
                        TimeTableAsJson = null;
                    }
                    else
                    {
                        TimeTableAsJson = JsonConvert.SerializeObject(value);
                    }


                }
                catch
                { }

            }
        }


        /// <summary>
        /// Is paying parking zone
        /// </summary>        
        [Column("Zone_IsPayingZone")]
        public bool IsPayingZone { get; set; }


        /// <summary>
        /// Is zone visible to API
        /// </summary>        
        [Column("Zone_Visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Is record deleted
        /// </summary>        
        [Column("Zone_Deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Record creation timestamp
        /// </summary>        
        [Column("Zone_DateCreated")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The external reference Id(Should be referenced to the parking provider SpotId during import procedure)
        /// </summary>        
        [Column("Zone_ReferenceId")]
        public string ReferenceId { get; set; }


        [JsonIgnore]
        public virtual ICollection<ParkingSpot> ParkingSpots { get; set; }

        [JsonIgnore]
        public virtual Member Member{ get; set; }


        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }


    }
}
