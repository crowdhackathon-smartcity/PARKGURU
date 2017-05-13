using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartOnStreetParking.Repositories.ParkingSpotImport
{
    /// <summary>
    /// Import Handler Class
    /// </summary>
    public class ParkingSpotImportHandler
    {
        /// <summary>
        ///reading the xml and create the parkingSpot model classes
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="Mun"></param>
        public List<ImportedParkingSpot> GetParkingSpots(string xml, string Mun)
        {
            List<ImportedParkingSpot> tmpList = null;

            try
            {
                tmpList = new List<ImportedParkingSpot>();

                XElement mainXMLElement = XElement.Parse(xml);


                foreach (XElement firstLevelElement in mainXMLElement.Elements("ParkingSpot"))
                {
                    //use the structure to retrieve and pass
                    //the default xml values
                    ParkigSpotInitialValues pSInitialValues;
                    pSInitialValues.capacityValue = 0;
                    pSInitialValues.fromLatValue = 0;
                    pSInitialValues.fromLngValue = 0;
                    pSInitialValues.fromNoValue = 0;
                    pSInitialValues.toLatValue = 0;
                    pSInitialValues.toLngValue = 0;
                    pSInitialValues.toNoValue = 0;
                    pSInitialValues.refIDValue = string.Empty;
                    pSInitialValues.streetValue = string.Empty;
                    pSInitialValues.capacityValue = 0;

                    pSInitialValues.refIDValue = firstLevelElement.Element("RefID").Value;
                    if (firstLevelElement.Element("Street") != null)
                    {
                        pSInitialValues.streetValue = firstLevelElement.Element("Street").Value;
                    }

                    if (firstLevelElement.Element("capacity") != null)
                    {
                        pSInitialValues.capacityValue = int.Parse(firstLevelElement.Element("capacity").Value);
                    }

                    //From
                    if (firstLevelElement.Element("From") != null)
                    {
                        XElement fromElement = firstLevelElement.Element("From");

                        XElement numNode = fromElement.Element("Number");
                        //retrieve the from address Number
                        if (numNode != null)
                        {
                            pSInitialValues.fromNoValue = double.Parse(numNode.Value);
                        }

                        if (fromElement.Element("Coord") != null)
                        {
                            XElement latNode = fromElement.Element("Coord").Element("lat");
                            XElement lngNode = fromElement.Element("Coord").Element("lng");
                            //retrieve the coordinate values
                            if (latNode != null)
                            {
                                pSInitialValues.fromLatValue = double.Parse(latNode.Value);
                            }
                            if (lngNode != null)
                            {
                                pSInitialValues.fromLngValue = double.Parse(lngNode.Value);
                            }

                        }
                    }
                    //To
                    if (firstLevelElement.Element("To") != null)
                    {
                        XElement toElement = firstLevelElement.Element("To");

                        XElement numNode = toElement.Element("Number");
                        //retrieve the To address Number
                        if (numNode != null)
                        {
                            pSInitialValues.toNoValue = double.Parse(numNode.Value);
                        }

                        if (toElement.Element("Coord") != null)
                        {
                            XElement latNode = toElement.Element("Coord").Element("lat");
                            XElement lngNode = toElement.Element("Coord").Element("lng");

                            //retrieve the coordinate values
                            if (latNode != null)
                            {
                                pSInitialValues.toLatValue = double.Parse(latNode.Value);
                            }
                            if (lngNode != null)
                            {
                                pSInitialValues.toLngValue = double.Parse(lngNode.Value);
                            }

                        }
                    }

                    //Complete the Model class creation process
                    ImportedParkingSpot PSpot = new ImportedParkingSpot(pSInitialValues);

                    //Add the Parking Spot to the List
                    tmpList.Add(PSpot);

                }
            }
            catch(Exception ex)
            {

            }

            return tmpList;
            
            

        }
    }
}