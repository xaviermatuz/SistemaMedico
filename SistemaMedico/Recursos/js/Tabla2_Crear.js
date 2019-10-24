//Add event handler.
$("body").on("click", "#btnaddcdf", function () {
    var txtresultado = $("#txtresultado2");
    var txtfyl = $("#txtfyl2");
    var txtevento = $("#txtevento2");
    var txtatleta = $('#atleta').val();
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $.ajax({
        type: "POST",
        url: "/HistorialMedico/InsertarCDF",
        data: '{Evento: "' + txtevento.val() + '",FechayLugar: "' + txtfyl.val() + '",Resultado: "' + txtresultado.val() + '", ID_Atleta: "' + txtatleta + '", Fecha_de_Registro: "' + fecha + '", Estado: "' + true + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var row = $("#tblCDF tr:last-child");
            if ($("#tblCDF tr:last-child span").eq(0).html() != "&nbsp;") {
                row = row.clone();
            }
            addrow2(r.ID, r.ID_Atleta, r.Resultado, r.FechayLugar, r.Evento);
            txtresultado.val("");
            txtfyl.val("");
            txtevento.val("");
        }
    });
});

function addrow2(id, idatleta, resultado, fyl, evento) {
    campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td>' +
        '<td style="display:none;">' + idatleta + '</td> <td style="text-align:center;">' + evento + '</td> ' +
        '<td style="text-align:center;">' + fyl + '</td> <td style="text-align:center;">' + resultado + '</td>' +
        '<td style="text-align:center;"><button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td></tr > ';
    $("#tblCDF").append(campo);
}

$("body").on("click", "#tblCDF .elimina", function () {
    id = $(this).parents("tr").find("td").eq(0).html();
    cde = $(this).parents("tr").find("input").val();
    var row = $(this).closest("tr");
    var customerId = row.find("span").html();


    if (confirm("Desea eliminar la seleccion")) {
        $(this).parents("tr").fadeOut("normal", function () {
            $.ajax({
                type: "POST",
                url: "/HistorialMedico/DeleteCDF",
                data: '{id: ' + customerId + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if ($("#tblCDF tr").length > 2) {
                        id.remove();
                    } else {
                        row.find(".Delete").hide();
                        row.find("span").html('&nbsp;');
                    }
                }
            });
        })
    }
});