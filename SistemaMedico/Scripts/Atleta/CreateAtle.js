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

function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
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
            renameInputs(idListaCategActuales, 'li', 'Model.Atleta_Categoria');
        },
        error: function (xhr) {
            //debugger;
            console.warn(xhr.responseText);
        }
    });
}

function removeCatg(endpointUrl, element) {
    console.log('element', element);
    //var values = $('#id').val(); _> aqui casi lo tenias
    var elementId = $(element).siblings('#ID').val();
    if (elementId == 0) {
        //Si el elemento es nuevo (no está guardardo en la bd solo lo borras de la vista)
        //var i = id.parentNode.parentNode.idListaCategActuales;
        //document.getElementById('ID_Categoria').remove(); -> Aquiestas borrando siempre el primer elemento que encuentre con ese ID.
        $(element).parent('li').remove(); //->Aqu le estamos diciendo que dle elemento que le pasas como parmaetro, busque al Pdre de tipo 'li' y lo borre
        renameInputs(idListaCategActuales, 'li', 'Model.Atleta_Categoria');

    } else {
        $.ajax({
            type: 'POST',
            url: endpointUrl,
            success: function (response) {
                $(element).parent('li').remove();
                renameInputs(idListaCategActuales, 'li', 'Model.Atleta_Categoria');
            }
        });
    }
}


function renameInputs(parentElementId, itemsSelector, modelName) {
    var items = $(parentElementId + ' ' + itemsSelector);
    items.each(function (index, element) {
        $('input:hidden', element).each(function (indexInput, elementInput) {
            elementInput.name = modelName + '[' + index + '].' + elementInput.id;
        });
    });
}

