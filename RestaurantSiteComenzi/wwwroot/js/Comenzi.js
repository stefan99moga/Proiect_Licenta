$(document).ready(function () {
    //dropdown list stare comanda
    $.ajax({
        type: "GET",
        url: "/Comenzi/GetStareComanda" ,
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Selectați statusul comenzii</option>';
            for (var i = 1; i < data.length; i++) {
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
            return false;
        }

        if (confirm("Sunteți sigur că doriți să salvați starea comenzii?")) {
            $.ajax({
                method: 'POST',
                contentType: "application/json; charset=utf-8",
                url: 'https://localhost:44305/api/Comenzi/' + comanda_id,
                data: '{"stare_Comanda_ID":' + status_ales + '}',
                success: function (response) {
                    window.location.href = '/Comenzi';
                }
            });
        }
    });

    $("#search").on("click", function () {
        var user_input = $("#SearchID").val();
        if (user_input < 0) {
            alert("Valoarea introdusa trebuie sa fie pozitiva!");
        }

        if (isNaN(user_input)) {
            alert('Valoarea introdusa trebuie sa fie numerica!')
        }
    });
});