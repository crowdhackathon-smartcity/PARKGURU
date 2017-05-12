using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartOnStreetParking.Web.Utils.Exceptions
{
    public class NotFoundException: Exception
    {
        public string Entity { get; set; }

        public Int64 EntityId { get; set; }


        public NotFoundException(string entity, Int64 entityId):base()
        {
            Entity = entity;
            EntityId = entityId;
        }
    }
}