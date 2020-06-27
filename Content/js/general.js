//redirect url if controller is in the name
if (window.location.href.includes("/Default/Index")) {
    window.location.href = "/";
}
setTimeout(function () {
    if (document.querySelector(".twoseven-ext-tab-media-modal") != null) {
        document.querySelector(".twoseven-ext-tab-media-modal").parentElement.parentElement.removeChild(document.querySelector(".twoseven-ext-tab-media-modal").parentElement);
    }
}, 50);