$(document).ready(function () {
    var comanda_id;
    $.ajax({
        type: "GET",
        url: "https://localhost:44305/api/Cart?user_id=" + user_ID,
        data: "{}",
        success: function (data) {
            if (data == 0) {
                location.replace('https://localhost:7119/Cos');
            }
            //TOTAL PLATA
            var plata ='Plătiți:'+ data[0].comenzi.total_Plata + ' lei';
            $('#card-btn').html(plata);
            //GET ID
            comanda_id = data[0].comenzi.id;
        }
    });

    $('#card-btn').click(function (e) {
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