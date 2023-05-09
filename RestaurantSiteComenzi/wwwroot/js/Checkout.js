$(document).ready(function () {

    //Check if user has products in cart
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44305/api/Cart?user_id=' + user_ID,
        dara: '',
        success: function (data) {
            if (data.length == 0) {
                location.replace('https://localhost:7119/Cos');
            }
        }
    });

    //dropdownlist adresa
    $.ajax({
        type: "GET",
        url: "/Checkout/GetAdresses",
        data: "{}",
        success: function (data) {
            if (data.length > 0) {
                var s = '<option value="-1">Selectați adresa</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].oras + " " + data[i].strada + " " + data[i].numar + " " + data[i].bloc + " " + data[i].scara + " " + data[i].apartament + '</option>';
                }
                $("#adreseDropdown").html(s);
            } else {
                var s = '<option value="-1">Nu aveți adresa adaugată!</option>';
                $("#adreseDropdown").html(s);
            }

        }
    });

    //dropdownlist tip plata
    $.ajax({
        type: "GET",
        url: "/Checkout/GetTipPlata",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Selectați metoda de plată</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].id + '">' + data[i].tipul_Platii + '</option>';
            }
            $("#tipPlataDropdown").html(s);
        }
    });

    $('#addTempOrder').click(function (e) {
        e.preventDefault();

        var adresa_aleasa = $('#adreseDropdown').val();
        var tip_plata_aleasa = $('#tipPlataDropdown').val();
        var stare_Comanda_ID = 0;

        if (adresa_aleasa == -1 || tip_plata_aleasa == -1) {
            alert('Câmpuri necompletate!');
        }



        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: 'https://localhost:44305/api/Comenzi/',
            data:
                '{"User_id":' + '"' + user_ID + '"' +
                ', "adress_ID":' + adresa_aleasa +
                ', "tip_Plata_ID":' + tip_plata_aleasa +
                ', "stare_Comanda_ID":' + stare_Comanda_ID + '}',
            success: function (response) {
                window.location.href = '/Checkout/CheckOrder';
            }
        });

    });

});