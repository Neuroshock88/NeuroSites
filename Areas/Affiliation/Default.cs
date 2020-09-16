using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Affiliation
{
    public class Default {
        public PropertiesModel Properties;
        public Default()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            Properties = new PropertiesModel();
            Properties.TwitchURL = "https://www.twitch.tv/neuroshock88";
        }
    }
}