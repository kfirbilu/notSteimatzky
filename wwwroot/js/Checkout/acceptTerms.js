function acceptTerms() {

    $('#terms').change(function () {
        if (!$(this).is(':checked')) {
            //Check if the check box is selected
            //If the check box not selected
            $('#placeOrder').prop('disabled', true);
            $('#placeOrder').css("background-color", "#d1b4b4");
        } else {
            ////If the check box selected
            $('#placeOrder').prop('disabled', false);
            $('#placeOrder').css("background-color", "#0e3fa9");
        }
    });
}