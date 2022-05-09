$(document).ready(function () {
    var comanda_id;

    $.ajax({
        type: "GET",
        url: "https://localhost:44305/api/Cart?user_id=" + user_ID,
        data: "{}",
        success: function (data) {
            //PRODUSE
            var p = '';
            for (var i = 0; i < data.length; i++) {
                 p += '<dd class="col-sm-4">' + data[i].produs.nume_Produs + '</dd> <dd class="col-sm-8"> ' + data[i].quantity + ' buc</dd>';
            }            
            $("#produse").html(p);
            //ADRESA
            var a = '<dd class="col-sm-4">Oras:</dd> <dd class="col-sm-8"> ' + data[0].comenzi.adrese.oras + '</dd><dd class="col-sm-4">Strada:</dd><dd class="col-sm-8"> ' + data[0].comenzi.adrese.strada + '</dd></dd><dd class="col-sm-4">Numar:</dd><dd class="col-sm-8"> ' + data[0].comenzi.adrese.numar + '</dd></dd><dd class="col-sm-4">Bloc:</dd><dd class="col-sm-8"> ' + data[0].comenzi.adrese.bloc + '</dd></dd><dd class="col-sm-4">Scara:</dd><dd class="col-sm-8"> ' + data[0].comenzi.adrese.scara + '</dd></dd><dd class="col-sm-4">Apartament:</dd><dd class="col-sm-8"> ' + data[0].comenzi.adrese.apartament + '</dd></dd>';
            $('#adresa').html(a);
            //TIP PLATA
            var t = data[0].comenzi.tip_plata.tipul_Platii;
            $('#tip-plata').html(t);
            //TOTAL PLATA
            var plata = data[0].comenzi.total_Plata + ' lei';
            $('#total-plata').html(plata);
            //GET ID
            comanda_id = data[0].comenzi.id;
        }
    });

    $('#back-to-cart').click(function (e) {
        e.preventDefault();

        $.ajax({
            type: 'Delete',
            url: 'https://localhost:44305/api/Comenzi/' + comanda_id,
            contentType: 'application/json',
            success: function () {
                window.location.href = '/Cos';
            }
        });
    });

    $('.back-to-checkout').click(function (e) {
        e.preventDefault();

        $.ajax({
            type: 'Delete',
            url: 'https://localhost:44305/api/Comenzi/' + comanda_id,
            contentType: 'application/json',
            success: function () {
                window.location.href = '/Checkout';
            }
        });
    });

    $('#sendOrder').click(function (e) {
        e.preventDefault();

        $.ajax({
            method: 'POST',
            url: 'https://localhost:44305/api/Comenzi/OrderSent',
            data:
                '{ "User_id":' + '"' + user_ID + '"' +
                ', "id":' + comanda_id +
                '}',
            contentType: 'application/json',
            success: function () {

                window.location.href = 'https://localhost:7119/Checkout/OrderSent';
            }
        });
    });


});