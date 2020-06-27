using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Merch
{
    public class Default
    {
        public PropertiesModel Properties = new PropertiesModel();

        private void SetSettings() {
            Properties.MerchURL = "https://merch.streamelements.com/neuroshock88";
        }
    }
}