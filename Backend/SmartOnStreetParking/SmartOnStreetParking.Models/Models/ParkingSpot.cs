using Newtonsoft.Json;
using SmartOnStreetParking.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{

    /// <summary>
    /// The provider parking spot model
    /// </summary>
    [Table("ParkingSpots")]
    public class ParkingSpot
    {

        /// <summary>
        /// The Id of the record
        /// </summary>        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Spot_Id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of parking spot
        /// </summary>        
        [Column("Spot_Name")]
        public string Name { get; set; }

        /// <summary>
        /// Any additional info of parking spot
        /// </summary>        
        [Column("Spot_Info")]
        public string Info { get; set; }


        /// <summary>
        /// The address of parking spot
        /// </summary>        
        [Column("Spot_Address")]
        public string Address { get; set; }

        /// <summary>
        /// The Zone Id
        /// </summary>        
        [Column("Spot_ZoneId")]
        public long ZoneId { get; set; }


        /// <summary>
        /// DbGeography of parking spot(Location)
        /// </summary>        
        [Column("Spot_Location")]
        [JsonIgnore]
        public DbGeography Location { get; set; }

        /// <summary>
        /// DbGeometry of parking spot
        /// </summary>        
        [Column("Spot_Edges")]
        [JsonIgnore]
        public DbGeometry GISEdges { get; set; }


        /// <summary>
        /// The type of stored Geometry
        /// </summary>        
        [Column("Spot_GeometryType")]
        public GeometryType GeometryType { get; set; }


        /// <summary>
        /// Coordinates of venue boundaries
        /// </summary>        
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<Coordinate> GeometryEdges
        {
            get { return GISEdges != null ? GISEdges.ToEdges() : new List<Coordinate>(); }
            set { GISEdges = value.ToGeometry(GeometryType); Location = value.FirstOrDefault().ToGeography(); }
        }


        /// <summary>
        /// The current availability state
        /// </summary>        
        [Column("Spot_CurrentAvailabilityState")]
        public AvailabilityState CurrentAvailabilityState { get; set; }


        /// <summary>
        /// The parking spot street view json
        /// </summary>        
        [Column("Spot_StreetView")]
        public string StreetView { get; set; }

        /// <summary>
        /// The parking spot capacity
        /// </summary>        
        [Column("Spot_Capacity")]
        public int Capacity { get; set; }


        /// <summary>
        /// Is parking spot visible to API
        /// </summary>        
        [Column("Spot_Visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Is record deleted
        /// </summary>        
        [Column("Spot_Deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Record creation timestamp
        /// </summary>        
        [Column("Spot_DateCreated")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The external reference Id(Should be referenced to the parking provider SpotId during import procedure)
        /// </summary>        
        [Column("Spot_ReferenceId")]
        public string ReferenceId { get; set; }


        [JsonIgnore]
        public virtual Zone Zone { get; set; }


    }
}
