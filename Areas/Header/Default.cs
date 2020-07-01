using NeuroSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeuroSites.Areas.Header
{
    public class Default
    {
        public PropertiesModel Properties;
        public Default()
        {
            Properties = new PropertiesModel();
        }

    }
}