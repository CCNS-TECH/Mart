function alertSuccess(){
    $.growl({
        icon: "data-icon",
        title: 'Success!!',
        message: 'You has been data sent successfully.',
        url: ''
    },{
        element: 'body',
        type: 'success',
        allow_dismiss: true,
        placement: {
            from: 'top',
            align: 'right'
        },
        offset: {
            x: 30,
            y: 30
        },
        spacing: 10,
        z_index: 999999,
        delay: 2500,
        timer: 1000,
        url_target: '_blank',
        mouse_over: false,
        animate: {
            enter: 'animated fadeInRight',
            exit: 'animated fadeOutRight'
        },
        icon_type: 'class',
        template: '<div data-growl="container" class="alert background-success" role="alert">' +
            '<button type="button" class="close" data-growl="dismiss">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            '</button>' +
            '<span data-growl="icon"></span>' +
            '<span data-growl="title"></span>' +
            '<span data-growl="message"></span>' +
            '<a href="#" data-growl="url"></a>' +
            '</div>'
    });
}
function alertError(){
    $.growl({
        icon: "data-icon",
        title: 'Error!!',
        message: 'You has been data sent is error.',
        url: ''
    },{
        element: 'body',
        type: 'error',
        allow_dismiss: true,
        placement: {
            from: 'top',
            align: 'right'
        },
        offset: {
            x: 30,
            y: 30
        },
        spacing: 10,
        z_index: 999999,
        delay: 2500,
        timer: 1000,
        url_target: '_blank',
        mouse_over: false,
        animate: {
            enter: 'animated fadeInRight',
            exit: 'animated fadeOutRight'
        },
        icon_type: 'class',
        template: '<div data-growl="container" class="alert background-danger" role="alert">' +
            '<button type="button" class="close" data-growl="dismiss">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            '</button>' +
            '<span data-growl="icon"></span>' +
            '<span data-growl="title"></span>' +
            '<span data-growl="message"></span>' +
            '<a href="#" data-growl="url"></a>' +
            '</div>'
    });
}
function alertError404NotFound(){
    $.growl({
        icon: "data-icon",
        title: 'Error!!',
        message: 'You has been data sent is NotFound.',
        url: ''
    },{
        element: 'body',
        type: 'error',
        allow_dismiss: true,
        placement: {
            from: 'top',
            align: 'right'
        },
        offset: {
            x: 30,
            y: 30
        },
        spacing: 10,
        z_index: 999999,
        delay: 2500,
        timer: 1000,
        url_target: '_blank',
        mouse_over: false,
        animate: {
            enter: 'animated fadeInRight',
            exit: 'animated fadeOutRight'
        },
        icon_type: 'class',
        template: '<div data-growl="container" class="alert background-warning" role="alert">' +
            '<button type="button" class="close" data-growl="dismiss">' +
            '<span aria-hidden="true">&times;</span>' +
            '<span class="sr-only">Close</span>' +
            '</button>' +
            '<span data-growl="icon"></span>' +
            '<span data-growl="title"></span>' +
            '<span data-growl="message"></span>' +
            '<a href="#" data-growl="url"></a>' +
            '</div>'
    });
}