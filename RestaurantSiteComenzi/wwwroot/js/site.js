$(document).ready(function () {

    //Sorteaza produsele din meniu
    $('#category').before(function () {
        var url = window.location.href
        var parts = url.split("=")
        var route = parts[parts.length - 1]

        switch (route) {
            case "pizza":
                $("#P").addClass('active');
                $("#dropdownMenuButton").html('Pizza');
                break;
            case "desert":
                $("#D").addClass('active');
                $("#dropdownMenuButton").html('Desert');
                break;
            case "bautura":
                $("#B").addClass('active');
                $("#dropdownMenuButton").html('Bautură');
                break;
            default:
                $("#all").addClass('active');
                $("#dropdownMenuButton").html('Toate');
                break;
        }
    });

    //adugare cantitate produs
    $('.increment-btn').click(function (e) {
        e.preventDefault();

        var inc_value = $(this).closest('.product_data').find('.qty-input').val();
        var value = parseInt(inc_value, 10);
        value = isNaN(value) ? 0 : value;
        if (value < 10) {
            value++;
            $(this).closest('.product_data').find('.qty-input').val(value);
        }
    });

    //scadere cantitate produs
    $('.decrement-btn').click(function (e) {
        e.preventDefault();

        var dec_value = $(this).closest('.product_data').find('.qty-input').val();
        var value = parseInt(dec_value, 10);
        value = isNaN(value) ? 0 : value;
        if (value > 1) {
            value--;
            $(this).closest('.product_data').find('.qty-input').val(value);
        }
    });

});