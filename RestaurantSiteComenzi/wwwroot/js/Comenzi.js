$(document).ready(function () {
    //dropdown list stare comanda
    $.ajax({
        type: "GET",
        url: "/Comenzi/GetStareComanda" ,
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Selectați statusul comenzii</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].id + '">' + data[i].nume + '</option>';
            }
            $("#stareComandaDropdown").html(s);
        }
    });

    $('#saveOrderChanges').click(function (e) {
        e.preventDefault();

        var status_ales = $('#stareComandaDropdown').val();
        
        if (status_ales == -1) {
            alert('Câmp necompletat!');
        }

        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: 'https://localhost:44305/api/Comenzi/'  + comanda_id,
            data: '{"stare_Comanda_ID":' + status_ales + '}',
            success: function (response) {
                window.location.href = '/Comenzi';
            }
        });

    });
});