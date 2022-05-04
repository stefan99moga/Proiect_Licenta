$(document).ready(function () {

    $('.update-cart-item').click(function (e) {
        e.preventDefault();
        $.ajaxSetup({
            headers: {
                'access-control-allow-credentials': true,
                'access-control-allow-origin': 'https://localhost:7119',
                'content-type': 'application/json;charset=UTF-8'
            }
        });

        var prod_id = $(this).closest('.product_data').find('.prod_id').val();
        var qty = $(this).closest('.product_data').find('.qty-input').val();

        data = {
            'prod_id': prod_id,
            'prod_qty': qty,
        }

        $.ajax({
            method: 'POST',
            url: 'update-cart-item',
            data: data,
            success: function (response) {
                window.location.reload();
                alert('Product updated!');
            }
        });
    });


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

    //Increment si decrement quantity 

    //$('#remove-hover' + i).click(function () {
    //    //afiseaza totalul produselor din cos
    //    var cantitate = parseFloat($(this).closest('.product_data').find('#calcul-cantitate' + i).val());
    //    var pret = parseFloat($(this).closest('.product_data').find('#price' + i).val());
    //    var total = pret * cantitate;
    //    $('#total' + i).html(total);
    //});

});