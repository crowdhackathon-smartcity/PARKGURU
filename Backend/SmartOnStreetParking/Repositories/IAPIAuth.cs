﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public interface IAPIAuth
    {

        bool ValidateAPIRequest(string Key, string Secret);
    }
}