class Message {
    constructor(username, content, when) {
        this.username = username;
        this.content = content;
        this.when = new Date();
    }
}

// userName is declared in the Razor page
const username = userName; // Fixed syntax error
const textInput = document.getElementById("messageText");
const chat = document.getElementById("chat");
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    var currentdate = new Date(); // Fixed variable name
    let when = document.createElement("span");
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + "  "
        + currentdate.toLocaleTimeString('en-us', { hour: 'numeric', minute: 'numeric', second: 'numeric' });
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let when = new Date();
    let message = new Message(username, text, when);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.username === username;

    let container = document.createElement("div");
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement("p");
    sender.className = "sender";
    sender.innerHTML = message.username; // Fixed typo: 'inerHTML' to 'innerHTML'

    let text = document.createElement("p");
    text.innerHTML = message.content;

    let when = document.createElement("span");
    when.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + "  "
        + currentdate.toLocaleTimeString('en-us', { hour: 'numeric', minute: 'numeric', second: 'numeric' });

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
}