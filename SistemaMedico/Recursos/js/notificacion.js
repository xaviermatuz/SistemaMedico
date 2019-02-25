// $(function () {
//     $('.jsdemo-notification-button button').on('click', function () {
//         var placementFrom = $(this).data('placement-from');
//         var placementAlign = $(this).data('placement-align');
//         var animateEnter = $(this).data('animate-enter');
//         var animateExit = $(this).data('animate-exit');
//         var colorName = $(this).data('color-name');

//         showNotification(colorName, null, placementFrom, placementAlign, animateEnter, animateExit);
//     });
// });

function MostrarNotificacion(tipo,titulo, mensaje,icono) {
    // if (colorName === null || colorName === '') { colorName = 'bg-black'; }
    // if (text === null || text === '') { text = 'Turning standard Bootstrap alerts'; }
    // if (animateEnter === null || animateEnter === '') { animateEnter = 'animated fadeInDown'; }
    // if (animateExit === null || animateExit === '') { animateExit = 'animated fadeOutUp'; }
    
    var allowDismiss = true;

    $.notify({
        // icon: '../images/check.png',
        icon:icono,
        title: titulo,
        message: mensaje
    }, {
            type: tipo,
            allow_dismiss: allowDismiss,
            
            delay: 1000,
            icon_type: 'image',
           
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<img data-notify="icon" class="img-circle pull-left">' +
                '<span data-notify="title">{1}</span>' +
                '<span data-notify="message">{2}</span>' +
                '</div>'
        });
}