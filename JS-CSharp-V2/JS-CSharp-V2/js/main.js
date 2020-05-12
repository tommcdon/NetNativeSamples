// Your code here!
"use strict";

window.onload = function () {
    document.getElementById("helloButton").onclick = function (eventInfo) {
        var userName = document.getElementById("nameInput").value;
        var greetingString = "Hello, " + userName + "!";

        var t = new RuntimeComponent1.Class1();
        var s = t.getFoo("foo");
        console.debug(s);

        greetingString += s;
        document.getElementById("greetingOutput").innerText = greetingString;
    }
}