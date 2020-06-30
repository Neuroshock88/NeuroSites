using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.Twitch
{
    public class Default
    {
        public PropertiesModel Properties = new PropertiesModel();
        Default()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            Properties.TwitchURL = "https://www.twitch.tv/neuroshock88";
        }
    }
}