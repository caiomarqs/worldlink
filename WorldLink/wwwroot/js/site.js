// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let alertButton = document.getElementById("alert-button")
let alertDiv = document.getElementById("custom-alert")

if (alertButton && alertDiv) {
    alertButton.addEventListener("click", (e) => {
        e.preventDefault();

        if (alertDiv.classList.contains("hidden")) {
            alertDiv.classList.remove("hidden")
        }
        else {
            alertDiv.classList.add("hidden")
        }

    })
}
