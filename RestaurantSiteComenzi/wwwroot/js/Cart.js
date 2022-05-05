$(document).ready(function () {

    //stergere produs din cos
    $('.deleteCartBtn').click(function (e) {
        e.preventDefault();

        $.ajaxSetup({
            headers: {
                'access-control-allow-credentials': true,
                'access-control-allow-origin': 'https://localhost:7119',
                'content-type': 'application/json;charset=UTF-8'
            }
        });

        var prod_delete_id = $(this).closest('.product_data').find('.prod_id').val();

        $.ajax({
            url: 'https://localhost:44305/api/Cart/' + prod_delete_id,
            type: "Delete",
            contentType: "application/json",
            success: function () {
                alert("Produs șters din coș.");
                window.location.reload();
            }
        });
    });

    //adugare cantitate produs in db
    $('.increment-btn').click(function (e) {
        e.preventDefault();
        var product_id = $(this).closest('.product_data').find('.prod_id').val();
        var inc_value = $(this).closest('.product_data').find('.qty-input').val();
        var cos_id = $(this).closest('.product_data').find('.data-cos-id').val();
        var value = parseInt(inc_value, 10);
        value = isNaN(value) ? 0 : value;
        if (value < 10) {
            value++;
            $(this).closest('.product_data').find('.qty-input').val(value);
            $.ajax({
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'https://localhost:44305/api/Cart/UpdateQtyCart',
                data:
                    '{"id":' + cos_id + 
                    ', "user_id":' + '"' + user_id + '"' +
                    ', "Produs_id":' + product_id +
                    ', "Quantity":' + value + '}'
            });
            location.reload();
        }
    });

    //scadere cantitate produs in db
    $('.decrement-btn').click(function (e) {
        e.preventDefault();
        var product_id = $(this).closest('.product_data').find('.prod_id').val();
        var inc_value = $(this).closest('.product_data').find('.qty-input').val();
        var cos_id = $(this).closest('.product_data').find('.data-cos-id').val();
        var value = parseInt(inc_value, 10);
        value = isNaN(value) ? 0 : value;
        if (value > 1) {
            value--;
            $(this).closest('.product_data').find('.qty-input').val(value);
            $.ajax({
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'https://localhost:44305/api/Cart/UpdateQtyCart',
                data:
                    '{"id":' + cos_id +
                    ', "user_id":' + '"' + user_id + '"' +
                    ', "Produs_id":' + product_id +
                    ', "Quantity":' + value + '}'
            });
            location.reload();
        }
    });

});