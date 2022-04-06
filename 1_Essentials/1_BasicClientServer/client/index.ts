import * as signalR from "@microsoft/signalr";

// create connection
let connection = new signalR.HubConnectionBuilder()
.configureLogging(signalR.LogLevel.Trace)
.withUrl("/hub/view")
.build();

// on view update message from client
connection.on("viewCountUpdate", (value: number) => {
    var counter = document.getElementById("viewCounter");
    counter.innerText = value.toString();
});

// notify server we're watching
function notify(){
    connection.send("notifyWatching");
}

// start the connection
function startSuccess(){
    console.log("Connected.");
    notify();
}
function startFail(){
    console.log("Connection failed.");
}

connection.start().then(startSuccess, startFail);