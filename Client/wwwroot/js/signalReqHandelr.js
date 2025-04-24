// Establish the SignalR connection (URL must match your ChatHub route)
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub") // FIXED: should match what you set in app.MapHub<ChatHub>("/chatHub")
    .build();

// Register the ReceiveMessage handler
connection.on("ReceiveMessage", addMessageToChat); // FIXED typo: addMessageTochat ➜ addMessageToChat

// Start the connection
connection.start()
    .catch(function (err) {
        console.error(err.toString()); // FIXED: error logging syntax
    });

// Function to send message to the hub
function sendMessageToHub(message) {
    connection.invoke("SendMessage", message)
        .catch(function (err) {
            console.error(err.toString());
        });
}
