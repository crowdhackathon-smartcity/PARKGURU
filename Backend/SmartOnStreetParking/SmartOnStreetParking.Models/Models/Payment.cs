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

    [Table("Payments")]
    public class Payment
    {

        /// <summary>
        /// The Id of the record
        /// </summary>        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Pay_Id")]
        public long Id { get; set; }

     
        [Column("Pay_ParkingSpotId")]
        public long ParkingSpotId { get; set; }

        [Column("Pay_MemberId")]
        public long MemberId { get; set; }

        [Column("Pay_APIKey")]
        public string APIKey { get; set; }

        [Column("Pay_VehiclePlate")]
        public string VehiclePlate { get; set; }

        [Column("Pay_Start")]
        public DateTime Start { get; set; }

        [Column("Pay_Duration")]
        public int Duration { get; set; }

        [Column("Pay_Ticket")]
        [JsonIgnore]
        public string TicketAsJson { get; set; }

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
