using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using NeuroSites.Models;
using NeuroSites.Areas.SuperFightGame;

namespace NeuroSites.Controllers
{
    public class AjaxController : Controller
    {
        [HttpGet]
        public string NewGame()
        {
            string ret = "error";

            string jsonfile = System.IO.File.ReadAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"));
            if (!string.IsNullOrEmpty(jsonfile))
            {
                List<PlayerModel> players = new List<PlayerModel>();
                string jsonData = JsonConvert.SerializeObject(players);
                System.IO.File.WriteAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"), jsonData);
                ret = "success";
            }

            return ret;
        }
        [HttpGet]
        public string AddPlayer(string playerName)
        {
            string ret = "error";

            string jsonfile = System.IO.File.ReadAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"));
            if (!string.IsNullOrEmpty(jsonfile))
            {
                List<PlayerModel> players = JsonConvert.DeserializeObject<List<PlayerModel>>(jsonfile);
                if(players != null)
                {
                    foreach(PlayerModel player in players)
                    {
                        if(playerName.ToLower() == player.PlayerName.ToLower())
                        {
                            ret = "samenameerror";
                            return ret;
                        }
                    }
                    if (!string.IsNullOrEmpty(playerName))
                    {
                        PlayerModel newPlayer = new Areas.SuperFightGame.PlayerModel();
                        newPlayer.PlayerName = playerName;
                        players.Add(newPlayer);
                        string jsonData = JsonConvert.SerializeObject(players);
                        System.IO.File.WriteAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"), jsonData);
                        ret = "success";
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        public string GetPlayers()
        {
            string ret = "error";

            string jsonfile = System.IO.File.ReadAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"));
            if (!string.IsNullOrEmpty(jsonfile))
            {
                List<PlayerModel> players = JsonConvert.DeserializeObject<List<PlayerModel>>(jsonfile);
                if (players != null)
                {
                    string jsonData = JsonConvert.SerializeObject(players);
                    System.IO.File.WriteAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"), jsonData);
                    ret = jsonData;
                }
            }
            return ret;
        }

        [HttpGet]
        public string SetPlayerID(string id, string playerName)
        {
            string ret = "error";

            string jsonfile = System.IO.File.ReadAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"));
            if (!string.IsNullOrEmpty(jsonfile))
            {
                List<PlayerModel> players = JsonConvert.DeserializeObject<List<PlayerModel>>(jsonfile);
                if (players != null)
                {
                    players.Find(x => x.PlayerName == playerName).PlayerID = id;
                    string jsonData = JsonConvert.SerializeObject(players);
                    System.IO.File.WriteAllText(Server.MapPath("/Content/SuperFightGame/currentGame.json"), jsonData);
                    ret = jsonData;
                }
            }
            return ret;

        }
    }
}