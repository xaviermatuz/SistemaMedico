function AppendRow(row, Id, ID_Atleta, Prueba, Resultado, Fecha_Y_Lugar, Evento) {
    //Bind ID.
    $(".ID", row).find("span").html(Id);
    var input = $(".ID", row).find("#idcde");
    input.val(Id);

    //Bind atleta.
    $(".atletaid", row).find("span").html(ID_Atleta);

    //Bind Prueba.
    $(".prueba", row).find("span").html(Prueba);
    $(".prueba", row).find("input").val(Prueba);

    //Bind Resultado.
    $(".resultado", row).find("span").html(Resultado);
    $(".resultado", row).find("input").val(Resultado);

    //Bind FYL.
    $(".fyl", row).find("span").html(Fecha_Y_Lugar);
    $(".fyl", row).find("input").val(Fecha_Y_Lugar);

    //Bind Evento.
    $(".evento", row).find("span").html(Evento);
    $(".evento", row).find("input").val(Evento);

    row.find(".Edit").show();
    row.find(".Delete").show();
    $("#tblNdE").append(row);
};

//Add event handler.
$("body").on("click", "#btnAddtblEv", function () {
    var txtfecha = $("#txtFechant");
    var txtNotas = $("#txtNotas");
    var txtf = $("#txtF");
    var txtatleta = $('#atleta').val();
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $.ajax({
        type: "POST",
        url: "/ExamenFisico/InsertarNdE",
        data: '{ Fecha: "' + txtfecha.val() + '", Notas: "' + txtNotas.val() + '", F: "' + txtf.val() + '", ID_Atleta: "' + txtatleta + '", Fecha_de_Registro: "' + fecha + '", Estado: "' + true + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var row = $("#tblNdE tr:last-child");
            if ($("#tblNdE tr:last-child span").eq(0).html() != "&nbsp;") {
                row = row.clone();
            }
            addrow5(r.ID, r.ID_Atleta, r.Fecha, r.Notas, r.F);
            txtfecha.val("");
            txtNotas.val("");
            txtf.val("");
        }
    });
});

function addrow5(id, idatleta, Fecha, Notas, F) {
    campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td><td style="display:none;"><span>' + idatleta + '</span></td><td style="text-align:center;"><span>' + Fecha + '</span><input type="text" style="display:none;" value="' + Fecha + '" /></td><td style="text-align:center;"><span>' + Notas + '</span><input type="text" style="display:none;" value="' + Notas + '"/></td><td style="text-align:center;"><span>' + F + '</span><input type="text" style="display:none;" value="' + F + '"/></td><td style="text-align:center;"><button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td></tr>';
    $("#tblNdE").append(campo);
}

$("body").on("click", "#tblNdE .elimina", function () {
    id = $(this).parents("tr").find("td").eq(0).html();
    cde = $(this).parents("tr").find("input").val();
    var row = $(this).closest("tr");
    var ID = row.find("span").html();


    if (confirm("Desea eliminar la seleccion")) {
        $(this).parents("tr").fadeOut("normal", function () {
            $.ajax({
                type: "POST",
                url: "/ExamenFisico/DeleteNdE",
                data: '{id: ' + ID + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if ($("#tblCDE tr").length > 2) {
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