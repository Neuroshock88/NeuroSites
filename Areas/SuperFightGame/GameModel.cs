using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeuroSites.Areas.SuperFightGame
{
    public class GameModel
    {
        /// <summary>
        /// sets the Merch website URL
        /// </summary>
        public int Round { get; set; }
        public bool HasStarted { get; set; }
        public List<CardModel> WhiteDeck { get; set; }
        public List<CardModel> BlackDeck { get; set; }
    }
}