    function AppendRow(row, Id, ID_Atleta, Prueba, Resultado, Fecha_Y_Lugar, Evento) {
    //Bind ID.
    $(".cdeid", row).find("span").html(Id);

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

    //row.find(".Edit").show();
    //row.find(".Delete").show();
       // $("#tblCDE").append(row);
    };
 //Add event handler.
$("body").on("click", "#btnagregar", function () {
    var txtprueba = $("#txtpruebaac");
    var txtresultado = $("#txtresultadoac");
    var txtfyl = $("#txtfylac");
    var txtevento = $("#txteventoac");
    var txtatleta = $('#atleta').val();
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $.ajax({
    type: "POST",
        url: "/HistorialMedico/InsertarCDE",
        data: '{Prueba: "' + txtprueba.val() + '", Fecha_Y_Lugar: "' + txtfyl.val() + '", Resultado: "' + txtresultado.val() + '", Evento: "' + txtevento.val() + '", ID_Atleta: "' + txtatleta + '", Fecha_de_Registro: "' + fecha + '", Fecha_de_Actualizacion: "' + fecha +'", Estado: "' + true + '"}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (r) {
        var row = $("#tblCDE tr:last-child");
        if ($("#tblCDE tr:last-child span").eq(0).html() != "&nbsp;") {
    row = row.clone();
    }
    addrow3(r.ID, r.ID_Atleta, r.Prueba, r.Resultado, r.Fecha_Y_Lugar, r.Evento);
   // AppendRow(row,r.ID, r.ID_Atleta, r.Prueba, r.Resultado, r.Fecha_Y_Lugar, r.Evento);
    txtprueba.val("");
    txtresultado.val("");
    txtfyl.val("");
    txtevento.val("");
}
});
});    



    
 function addrow3(id, idatleta, prueba, resultado, fyl, evento) {
     campo = '<tr><td style="display:none;"> <span> ' + id + '</span> <input type="text" style="display:none;" value="' + id + '" id="idcde"  /></td><td style="display:none;"><span>' + idatleta + '</span></td><td style="text-align:center;"><span>' + prueba + '</span><input type="text" style="display:none;" value="' + prueba + '" /></td><td style="text-align:center;"><span>' + resultado + '</span><input type="text" style="display:none;" value="' + resultado + '"/></td><td style="text-align:center;"><span>' + fyl + '</span><input type="text" style="display:none;" value="' + fyl + '"/></td><td style="text-align:center;"><span>' + evento + '</span><input type="text" style="display:none;" value="' + evento + '" id="idcde"  /></td><td style="text-align:center;"><button class="btn bg-orange btn-circle waves-effect waves-circle waves-float edit" type="button"><i class="fa fa-edit fa-md"></i></button><a class="actualizar" style="display:none">Update</a><a class="cancel" href = "javascript:;" style = "display:none" > Cancel</a ><button class="btn btn-danger btn-circle waves-effect waves-circle waves-float elimina" type="button"><i class="fa fa-trash fa-md"></i></button></td></tr>';
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

//funcion editar
$("body").on("click", "#tblCDE .edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".actualizar").show();
    row.find(".cancel").show();
    row.find(".elimina").hide();
    $(this).hide();
}); 
//funcion actualizar
$("body").on("click", "#tblCDE .actualizar", function () {
    var row = $(this).closest("tr");
    var f = new Date();
    var fecha = f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear();
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    var ID = row.find("span").html();
    var mel = $(this).parents("tr").find("input").val();
        
    var cde = {};
    cde.ID =ID;
    cde.ID_Atleta = row.find(".atletaid").find("span").html();
    cde.Prueba = row.find(".prueba").find("span").html();
    cde.Resultado = row.find(".resultado").find("span").html();
    cde.Fecha_Y_Lugar = row.find(".fyl").find("span").html();
    cde.Evento = row.find(".evento").find("span").html();
    cde.Fecha_de_Actualizacion = fecha;

    console.log(mel);

    row.find(".edit").show();
    row.find(".elimina").show();
    row.find(".cancel").hide();
    $(this).hide();
    $.ajax({
        type: "POST",
        url: '/HistorialMedico/ActualizarCDE',
        data: '{CDE:' + JSON.stringify(cde) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.success) {
                alert(response.responseText);
            }
            else {
                console.log("tengo hambre");
            }
           
        }//function

    });
});

//evento cancelar
$("body").on("click", "#tblCDE .cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".edit").show();
    row.find(".elimina").show();
    row.find(".update").hide();
    $(this).hide();
});