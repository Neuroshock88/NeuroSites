//redirect url if controller is in the name
if (window.location.href.includes("/Default/Index")) {
    window.location.href = "/";
}
setTimeout(function () {
    document.getElementById("twoseven-ext-tab-media-modal").parentElement.style.display = "none";
}, 500);

var ogScrollPosition = 0;
function ToggleHeaderButtonState(x) {
    if (window.outerWidth <= 1000) {
        x.classList.toggle("change");
        if (x.classList.contains("change")) {
            ogScrollPosition = window.scrollY;
            document.querySelector(".header__mobile-nav-list-container").style.opacity = 1;
            document.querySelector("body").style.overflow = "hidden";
            document.querySelector(".header__mobile-nav-list-container").style.top = window.scrollY + "px";
        } else {
            document.querySelector(".header__mobile-nav-list-container").style.opacity = 0;
            document.querySelector("body").style.overflow = "";
        }
    }
}

function Navigate(item) {
    if (item.getAttribute("data-link") != "") {
        window.location.href = window.location.protocol + "//" + window.location.host + "/" + item.getAttribute("data-link");
        if (document.querySelector(".header__mobile-button-container .container").classList.contains("change")) {
            ToggleHeaderButtonState(document.querySelector(".header__mobile-button-container .container"));
        }
    }
}