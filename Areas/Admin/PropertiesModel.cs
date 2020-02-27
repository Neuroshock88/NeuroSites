using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Admin
{
    public class PropertiesModel
    {
        /// <summary>
        /// gets or sets the home page content
        /// </summary>

        public PropertiesModel() {
            HomePageContent = new List<string>();
        }

        public List<string> HomePageContent { get; set; }
    }
}