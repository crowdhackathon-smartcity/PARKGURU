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

     
        [Column("Pay_SpotId")]
        public long SpotId { get; set; }

        [Column("Pay_DevId")]
        public long DevId { get; set; }

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
        public Ticket Ticket
        {
            get
            {
                return TicketAsJson == null ? null : JsonConvert.DeserializeObject<Ticket>(TicketAsJson);
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

        [NotMapped]
        public List<Ticket> Tickets { get; set; }

        [JsonIgnore]
        public virtual Member Member { get; set; }
        [JsonIgnore]
        public virtual ParkingSpot ParkingSpot { get; set; }

    }
}
