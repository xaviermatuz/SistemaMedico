$(document).ready(function () {
    $('#DdlDepto').on('change', function () {
        console.log(this.value);
        CargarMunicipios("#Municipio", this.value);
    });

});


function CargarMunicipios(SelectorMunicipios, IdDepartamento) {
    var url = document.getElementById("UrlGetMunicipiosPorDpto").href;
    url += "?IdDpto=" + IdDepartamento;

    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        url: url,
        context: document.body,
        data: {},
        success: function (result) {
            $(SelectorMunicipios).html('');
            var $dropdown = $(SelectorMunicipios);
            $dropdown.append($("<option />").val(-1).text("Seleccione un municipio"));
            $.each(result, function () {
                $dropdown.append($("<option />").val(this.ID).text(this.Nombre));
            });
        },
        error: function (xhr) {
            //debugger;
            console.warn(xhr.responseText);
        }
    });
}

var idListaCategActuales = '#CategoriasSeleccionadas';

function AsociarCategoriaConAtleta() {
    var categoriaSeleccionadaId = $('#DdlCategoria option:selected').val();

    var url = document.getElementById("UrlAddCategoryToAthlete").href;
    url += '?IdCategoria=' + categoriaSeleccionadaId;

    //var categoriaSeleccionadaLabel = $('#DdlCategoria option:selected').text();

    $.ajax({
        type: "GET",
        traditional: true,
        async: false,
        cache: false,
        url: url,
        context: document.body,
        data: {},
        success: function (result) {
            $(idListaCategActuales).append(result);
            renameInputs(idListaCategActuales, 'li', 'categorias');
        },
        error: function (xhr) {
            //debugger;
            console.warn(xhr.responseText);
        }
    });
}

function removeCatg(item) {
    //console.log(item);
    $(item).parent().remove();
    renameInputs(idListaCategActuales, 'li', 'categorias');
}

function renameInputs(parentElementId, itemsSelector, modelName) {
    var items = $(parentElementId + ' ' + itemsSelector);
    items.each(function (index, element) {
        $('input:hidden', element).each(function (indexInput, elementInput) {
            elementInput.name = modelName + '[' + index + '].' + elementInput.id;
        });
    });
}