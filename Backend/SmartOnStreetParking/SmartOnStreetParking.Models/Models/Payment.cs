using Newtonsoft.Json;
using SmartOnStreetParking.Models.ViewModels;
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
    /// Class describing a historical or current parking session
    /// </summary>
    [Table("Payments")]
    public class Payment
    {

        /// <summary>
        /// The db Id of the record
        /// </summary>        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Pay_Id")]
        public long Id { get; set; }

     /// <summary>
     /// Parking spot db Id
     /// </summary>
        [Column("Pay_ParkingSpotId")]
        public long ParkingSpotId { get; set; }
        /// <summary>
        /// The developer/service provider db Id
        /// </summary>
        [Column("Pay_MemberId")]
        public long MemberId { get; set; }
        /// <summary>
        /// The developer/service provider API key
        /// </summary>
        [Column("Pay_APIKey")]
        public string APIKey { get; set; }
        /// <summary>
        /// End user vehicle plate
        /// </summary>
        [Column("Pay_VehiclePlate")]
        public string VehiclePlate { get; set; }
        /// <summary>
        /// Parking session start datetime(UTC)
        /// </summary>
        [Column("Pay_Start")]
        public DateTime Start { get; set; }
        /// <summary>
        /// Parking paid time in minutes
        /// </summary>
        [Column("Pay_Duration")]
        public int Duration { get; set; }

        [Column("Pay_Ticket")]
        [JsonIgnore]
        public string TicketAsJson { get; set; }
        /// <summary>
        /// Parking spot payment requirements(tickets)
        /// </summary>
        [NotMapped]
        public SpotTickets Ticket
        {
            get
            {
                return TicketAsJson == null ? null : JsonConvert.DeserializeObject<SpotTickets>(TicketAsJson);
            }
            set
            {
                if (value == null)
                {
                    TicketAsJson = null;
                }
                else
                {
                    TicketAsJson = JsonConvert.SerializeObject(value);
                }

            }
        }


        [JsonIgnore]
        public virtual Member Member { get; set; }
        [JsonIgnore]
        public virtual ParkingSpot ParkingSpot { get; set; }

    }
}
