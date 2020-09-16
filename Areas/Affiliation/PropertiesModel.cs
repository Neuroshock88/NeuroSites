using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Affiliation
{
    public class PropertiesModel
    {
        /// <summary>
        public PropertiesModel() {
            TwitchURL = "";
        }
        /// <summary>
        /// sets the Merch website URL
        /// </summary>
        public string TwitchURL { get; set; }
    }
}