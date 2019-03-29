$(document).ready(function () {
    $('#DlDeport').on('change', function () {
        if (this.value != '') {
            CargarCategoria("#DdlCategoria", this.value);
        }
        console.log(this.value);
    });

});


function CargarCategoria(selectorcat, IdDeporte) {
    var url = document.getElementById("UrlGetCategoriaDeporte").href;
    url += "?IdDeporte=" + IdDeporte;

    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        url: url,
        context: document.body,
        data: {},
        success: function (result) {
            $(selectorcat).html('');
            var $dropdown = $(selectorcat);
            $dropdown.append($("<option />").val(-1).text("Javier Comelon"));
            $.each(result, function () {
                $dropdown.append($("<option />").val(this.ID).text(this.Categoria));
            });
        },
        error: function (xhr) {
            //debugger;
            console.warn(xhr.responseText);
        }
    });
}