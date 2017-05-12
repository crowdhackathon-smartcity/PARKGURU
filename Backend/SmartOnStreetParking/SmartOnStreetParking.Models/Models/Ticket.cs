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

    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Ticket_Id")]
        [JsonIgnore]
        public long Id { get; set; }


        [Column("Ticket_SN")]
        public string SN { get; set; }

        [Column("Ticket_Duration")]
        public int Duration { get; set; }

        [Column("Ticket_Price")]
        public decimal Price { get; set; }


        [JsonIgnore]
        [Column("Ticket_ZoneId")]
        public long ZoneId { get; set; }

        [JsonIgnore]
        public virtual Zone Zone{ get; set; }


    }
}
