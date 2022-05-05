$(document).ready(function () {

    $('.addToCartBtn').click(function (e) {
        e.preventDefault();

        var product_id = $(this).closest('.product_data').find('.prod_id').val();
        var product_qty = $(this).closest('.product_data').find('.qty-input').val();

        $.ajaxSetup({
            headers: {
                'access-control-allow-credentials': true,
                'access-control-allow-origin': 'https://localhost:7119',
                'content-type': 'application/json;charset=UTF-8'
             }
        });

        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: 'https://localhost:44305/api/Cart/AddToCart',
            data:
                '{"User_id":' + '"' + user_id + '"' +
                ', "Produs_id":' + product_id +
                ', "Quantity":' + product_qty + '}',
            success: function (response) {
                alert('Produsul a fost adăugat');
            },
            error: function (xhr, status, error) {
                var result = xhr.responseText;
                var resultSplit = result.split("HEADERS");
                alert(resultSplit[0]);
            }
        });

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