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

    

});