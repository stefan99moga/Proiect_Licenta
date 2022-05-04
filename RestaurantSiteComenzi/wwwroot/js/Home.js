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
            url: 'https://localhost:44305/api/Cart',
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

});