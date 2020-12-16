using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.SuperFightGame
{
    public class PlayerModel
    {
        /// <summary>
        /// sets the Merch website URL
        /// </summary>
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public List<CardModel> PlayerHand { get; set; }
    }
}