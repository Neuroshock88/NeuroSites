using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.SuperFightGame
{
    public class PropertiesModel
    {
        /// <summary>
        /// sets the Merch website URL
        /// </summary>
        public List<PlayerModel> Players { get; set; }
        public GameModel TheGame { get; set; }

    }
}