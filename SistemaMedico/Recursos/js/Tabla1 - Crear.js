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
        $("#tblCDE").append(row);
    };

    //Add event handler.
    $("body").on("click", "#btnAdd", function () {
    var txtprueba = $("#txtprueba");
    var txtresultado = $("#txtresultado");
    var txtfyl = $("#txtfyl");
    var txtevento = $("#txtevento");
    var txtatleta = $('#atleta').val();
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $.ajax({
    type: "POST",
    url: "/HistorialMedico/InsertarCDE",
    data: '{Prueba: "' + txtprueba.val() + '", Fecha_Y_Lugar: "' + txtfyl.val() + '", Resultado: "' + txtresultado.val() + '", Evento: "' + txtevento.val() + '", ID_Atleta: "' + txtatleta + '", Fecha_de_Registro: "' + fecha + '", Estado: "' + true + '"}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (r) {
        var row = $("#tblCDE tr:last-child");
        if ($("#tblCDE tr:last-child span").eq(0).html() != "&nbsp;") {
    row = row.clone();
    }
    addrow(r.ID, r.ID_Atleta, r.Prueba, r.Resultado, r.Fecha_Y_Lugar, r.Evento);
    txtprueba.val("");
    txtresultado.val("");
    txtfyl.val("");
    txtevento.val("");
}
});
});    
    
    function addrow(id, idatleta, prueba, resultado, fyl, evento) {
        campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td><td style="display:none;"><span>' + idatleta + '</span></td><td style="text-align:center;"><span>' + prueba + '</span><input type="text" style="display:none;" value="' + prueba + '" /></td><td style="text-align:center;"><span>' + resultado + '</span><input type="text" style="display:none;" value="' + resultado + '"/></td><td style="text-align:center;"><span>' + fyl + '</span><input type="text" style="display:none;" value="' + fyl + '"/></td><td style="text-align:center;"><span>' + evento + '</span><input type="text" style="display:none;" value="' + evento + '" id="idcde"  /></td><td style="text-align:center;"><button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td></tr>';
        $("#tblCDE").append(campo);
}    
    
$("body").on("click", "#tblCDE .elimina", function () {
            id = $(this).parents("tr").find("td").eq(0).html();
        cde = $(this).parents("tr").find("input").val();
        var row = $(this).closest("tr");
        var ID = row.find("span").html();


            if (confirm("Desea eliminar la seleccion")) {
            $(this).parents("tr").fadeOut("normal", function () {
                $.ajax({
                    type: "POST",
                    url: "/HistorialMedico/DeleteCDE",
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