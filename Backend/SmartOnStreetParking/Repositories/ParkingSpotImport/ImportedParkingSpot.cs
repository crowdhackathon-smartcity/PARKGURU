using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartOnStreetParking.Models;

namespace SmartOnStreetParking.Repositories.ParkingSpotImport
{
    /// <summary>
    /// a structure used to transfer the initial imported xml values between classes
    /// </summary>
    public struct ParkigSpotInitialValues
    {
        public string refIDValue;
        public double fromLatValue;
        public double fromLngValue;
        public double toLatValue;
        public double toLngValue;
        public double fromNoValue;
        public double toNoValue;
        public int capacityValue;
        public string streetValue;
    }

    public class ImportedParkingSpot
    {

        /// <summary>
        /// Constructor used to pass the initial imported xml values
        /// ///for further processing
        /// </summary>
        /// <param name="PSDefaultValues"></param>
        public ImportedParkingSpot(ParkigSpotInitialValues PSDefaultValues)
        {
            processInitialValues(PSDefaultValues);
        }

        /// <summary>
        /// initialize the process of evaluating and changing the default values
        /// </summary>
        /// <param name="PSDefaultValues"></param>
        void processInitialValues(ParkigSpotInitialValues PSDefaultValues)
        {
        
            //get the Location from the Street Address
            //========================================
            ParkingSpotImportHelper helperClass = new ParkingSpotImportHelper();
            ParkingSpotLocation location = helperClass.GetLocationFromAddress(string.Format("{0} {1}", PSDefaultValues.streetValue, PSDefaultValues.fromNoValue));
            From_Latidute = location.Latidute;
            From_Longitude = location.Longitude;
            //========================================

            //get the Location To from the Street Address
            //========================================
            location = helperClass.GetLocationFromAddress(string.Format("{0} {1}", PSDefaultValues.streetValue, PSDefaultValues.toNoValue));
            To_Latidute = location.Latidute;
            To_Longitude = location.Longitude;
            //========================================

            //Create the Full Address
            //=======================
            string fullAddress = string.Format("{0} {1}", PSDefaultValues.streetValue, PSDefaultValues.fromNoValue);
            if (PSDefaultValues.toNoValue > 0)
            {
                fullAddress = string.Format("{0}-{1}", fullAddress, PSDefaultValues.toNoValue);
            }
            StreetAddress = fullAddress;
            //=======================

            //TODO: Fill the Capacity if Empty
            Capacity = PSDefaultValues.capacityValue;

            ReferenceId = PSDefaultValues.refIDValue;

            Edges = new List<Coordinate>();
            Coordinate from_coordObject = new Coordinate(From_Latidute, From_Longitude);
            Edges.Add(from_coordObject);

            if (To_Latidute > 0 && To_Longitude>0)
            {
                Coordinate to_coordObject = new Coordinate(To_Latidute, To_Longitude);
                Edges.Add(to_coordObject);
            }

            
        }

        /// <summary>
        /// Array of Coordinate objects with from & to long/lat info
        /// </summary>
        public List<Coordinate>Edges { get; set; }

        /// <summary>
        /// The external reference Id
        /// </summary>        
        public string ReferenceId { get; set; }

        /// <summary>
        /// The full Street Address (xxx 1-4)
        /// </summary>        
        public string StreetAddress { get; set; }

        /// <summary>
        /// The Coordinate Latidute as returned by Google from Street search
        /// </summary>        
        public double From_Latidute { get; set; }

        /// <summary>
        /// The Coordinate Longitude as returned by Google from Street search
        /// </summary>        
        public double From_Longitude { get; set; }

        /// <summary>
        /// The Coordinate Latidute as returned by Google from Street search
        /// </summary>        
        public double To_Latidute { get; set; }

        /// <summary>
        /// The Coordinate Latidute as returned by Google from Street search
        /// </summary>        
        public double To_Longitude { get; set; }

        /// <summary>
        /// The Coordinate Latidute as returned by Google from Street search
        /// </summary>        
        public int Capacity { get; set; }

    }
}
