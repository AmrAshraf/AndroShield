$(document).ready(function () {
    function setUserNameInNav() {
        var userEmail = document.getElementById("emailTxt").innerHTML;
        document.getElementById("userEmail").innerHTML = userEmail;
    }

    function buttonClicked(buttonID) {
        if (buttonID = document.getElementById("aboutNav"))
            window.location.assign("http://localhost:61422/Web%20Forms/aboutPage.aspx");
    }

});

