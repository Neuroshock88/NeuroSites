using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.IO;
using NeuroSites.Models;
using System.Runtime.Remoting.Messaging;
using Microsoft.CSharp;
using System.CodeDom.Compiler;


namespace NeuroSites.Areas.SuperFightGame
{
    public class Default {
        public PropertiesModel properties;
        public Default()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            properties = new PropertiesModel();
            properties.TheGame = new GameModel();
            if(HttpContext.Current.Request.QueryString.Get("sg") == "true")
            {
                //this is start game functionality
                //build the decks
                //store the players
                //fill the hands
                string[] blackDeck = File.ReadAllText("~/Content/SuperFightGame/BlackDeck.txt").Trim().Split(';');
                string[] whiteDeck = File.ReadAllText("~/Content/SuperFightGame/WhiteDeck.txt").Trim().Split(';');
                foreach (string item in blackDeck)
                {
                    CardModel card = new CardModel();
                    card.CardColor = "black";
                    card.CardText = item;
                    properties.TheGame.BlackDeck.Add(card);
                }
                foreach (string item in whiteDeck)
                {
                    CardModel card = new CardModel();
                    card.CardColor = "white";
                    card.CardText = item;
                    properties.TheGame.WhiteDeck.Add(card);
                }

            }
        }
    }
}