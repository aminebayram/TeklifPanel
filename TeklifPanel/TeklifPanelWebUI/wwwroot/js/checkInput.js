$(document).ready(function () {
    $("#email").on("keyup", function () {
        var currentValue = $("#email").val();
        $("#email").val(currentValue.toLowerCase());
    });

    function validateEmailInput(inputElement) {
        var inputValue = inputElement.value;
        var regex = /^[a-zA-Z0-9@._-]*$/;

        if (!regex.test(inputValue)) {
            document.getElementById("error-message").textContent = "Türkçe karakter kullanmayınız.";
            inputElement.value = inputValue.replace(/[ğüşıöçĞÜŞİÖÇ]/g, ''); // Türkçe karakterleri temizle
        } else {
            document.getElementById("error-message").textContent = "";
        }
    }
});