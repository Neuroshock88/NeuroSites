var playerID;
var messageSet = false;
var playerAdded = false;
var players = [];
setTimeout(function () {
    var playerList = document.querySelector(".playerlist");
    document.querySelector("button[name='addNewPlayer']").addEventListener("click", function () { AddNewPlayer() });
    document.querySelector("button[name='newGame']").addEventListener("click", function () { NewGame() });
    setInterval(function () { FetchPlayers(); }, 1500); 
    
}, 50);

//add localstorage bit to note PC so we can have  start new game vote and a voting system in general

function AddNewPlayer() {
    var playerName = document.querySelector("[name='newPlayerName']");
    if (!playerName) return;
    playerName = playerName.value;
    if (playerName != "") {
        var addplayerXHR = new XMLHttpRequest();
        addplayerXHR.open("GET", "/Ajax/AddPlayer?playerName=" + playerName);
        addplayerXHR.send();
        addplayerXHR.onreadystatechange = function () {
            if (addplayerXHR.readyState == 4 && addplayerXHR.status == 200) {
                var data = addplayerXHR.response;
                if (data != null) {                    
                    if (data == "success") {
                        var playerList = document.querySelector(".playerlist");
                        //set localstoragebit
                        playerID = "superfight_" + Date.now();
                        if (playerList.children.length == 0) {
                            //this is player 1
                            window.localStorage.setItem("superfight_firstplayer", playerID);
                        }
                        //we have the player added to the file!
                        var entry = document.createElement("li");
                        entry.innerHTML = playerName;
                        playerList.appendChild(entry);
                        window.localStorage.setItem("superfightgame-id", playerID);
                        document.querySelector("[name='newPlayerName']").parentElement.removeChild(document.querySelector("[name='newPlayerName']"));
                        document.querySelector("button[name='addNewPlayer']").parentElement.removeChild(document.querySelector("button[name='addNewPlayer']"));
                        playerAdded = true;
                        SetPlayerID(playerID, playerName);
                        FetchPlayers();
                    } else if (data == "samenameerror") {
                        alert("That Name is in use, try again!");
                        document.querySelector("[name='newPlayerName']").value = "";
                        document.querySelector("[name='newPlayerName']").focus();
                    }
                }
            }
        }
    }
}
function SetPlayerID(playerID, playerName) {
    var newGameXHR = new XMLHttpRequest();
    newGameXHR.open("GET", "/Ajax/SetPlayerID?id=" + playerID + "&playerName=" + playerName);
    newGameXHR.send();
    newGameXHR.onreadystatechange = function () {
        if (newGameXHR.readyState == 4 && newGameXHR.status == 200) {
            var data = newGameXHR.response;
            if (data != null) {
                //this will return an updated player list after setting the player id
                players = JSON.parse(data);
            }
        }
    }
}
function NewGame() {
    var newGameXHR = new XMLHttpRequest();
    newGameXHR.open("GET", "/Ajax/NewGame");
    newGameXHR.send();
    newGameXHR.onreadystatechange = function () {
        if (newGameXHR.readyState == 4 && newGameXHR.status == 200) {
            var data = newGameXHR.response;
            if (data != null) {
                if (data == "success") {
                    //we have the player added to the file!
                    var playerList = document.querySelector(".playerlist");
                    while (playerList.firstChild) {
                        playerList.removeChild(playerList.firstChild);
                    }
                    if (document.querySelector(".playermessage")) {
                        document.querySelector(".playermessage").parentElement.removeChild(document.querySelector(".playermessage"));
                    }
                    window.localStorage.removeItem("superfightgame-id");
                    window.localStorage.removeItem("superfight_firstplayer");
                }
            }
        }
    }
}


function CheckPlayerStatus() {
    if (players != null) {
        var you = players.find(ele => ele.PlayerId = playerID);
        if (!you) return false;
        if (you.playerID == window.localStorage.getItem("superfight_firstplayer")) {
            //you get the button
            //show who gets the button so ppl know who theyre waiting on
            messageSet = true;
            document.querySelector(".newplayer")
            var theSpan = document.createElement("span");
            theSpan.classList.add("playermessage");
            theSpan.innerHTML = "Once Everyone is ready, Click that start button to begin!"
            document.querySelector(".newplayer").appendChild(theSpan);
        } else {
            //you get the relax message
            document.querySelector(".newplayer")
            var theSpan = document.createElement("span");
            theSpan.classList.add("playermessage");
            theSpan.innerHTML = "Just sit back and relax until everyones ready..... " + players.find(ele => ele.PlayerId = window.localStorage.getItem("superfight_firstplayer")) + " has the start button!"
            document.querySelector(".newplayer").appendChild(theSpan);
            document.querySelector("button[name='startGame']").style.display = "none";
            messageSet = true;
        }
    }
}

function FetchPlayers() {
    var addplayerXHR = new XMLHttpRequest();
    addplayerXHR.open("GET", "/Ajax/GetPlayers");
    addplayerXHR.send();
    addplayerXHR.onreadystatechange = function () {
        if (addplayerXHR.readyState == 4 && addplayerXHR.status == 200) {
            var data = addplayerXHR.response;
            if (data != null) {
                if (data != "error" && data != "") {
                    //we have the player added to the file!
                    var playerList = document.querySelector(".playerlist");
                    while (playerList.firstChild) {
                        playerList.removeChild(playerList.firstChild);
                    }
                    data = JSON.parse(data);
                    if (document.querySelector(".playermessage")) {
                        document.querySelector(".playermessage").parentElement.removeChild(document.querySelector(".playermessage"));
                        messageSet = false;
                    }

                    for (var i = 0; i < data.length; i++) {
                        var entry = document.createElement("li");
                        entry.innerHTML = data[i].PlayerName;
                        playerList.appendChild(entry);
                    }
                    CheckPlayerStatus();
                } else if (data == "samenameerror") {
                    alert("That Name is in use, try again!");
                    document.querySelector("[name='newPlayerName']").value = "";
                    document.querySelector("[name='newPlayerName']").focus();
                }
            }
        }
    }
}