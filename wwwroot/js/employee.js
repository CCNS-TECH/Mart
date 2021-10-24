$(document).ready(function () {
    $("#notify-purchase").hide();
    var userform = $("#create-user-form").show();
    userform.steps({
        headerTag: "h3",
        bodyTag: "fieldset",
        transitionEffect: "slideLeft",
        onStepChanging: function(event, currentIndex, newIndex) {

            // Allways allow previous action even if the current form is not valid!
            if (currentIndex > newIndex) {
                return true;
            }
            // Forbid next action on "Warning" step if the user is to young
            if (newIndex === 3 && Number($("#age-2").val()) < 18) {
                return false;
            }
            // Needed in some cases if the user went back (clean up)
            if (currentIndex < newIndex) {
                // To remove error styles
                userform.find(".body:eq(" + newIndex + ") label.error").remove();
                userform.find(".body:eq(" + newIndex + ") .error").removeClass("error");
            }
            userform.validate().settings.ignore = ":disabled,:hidden";
            return userform.valid();
        },
        onStepChanged: function(event, currentIndex, priorIndex) {

            // Used to skip the "Warning" step if the user is old enough.
            if (currentIndex === 2 && Number($("#age-2").val()) >= 18) {
                userform.steps("next");
            }
            // Used to skip the "Warning" step if the user is old enough and wants to the previous step.
            if (currentIndex === 2 && priorIndex === 3) {
                userform.steps("previous");
            }
        },
        onFinishing: function(event, currentIndex) {

            userform.validate().settings.ignore = ":disabled";
            return userform.valid();
        },
        onFinished: function(event, currentIndex) {
            adduser();
            $('.content input[type="text"]').val('');
            $('.content input[type="email"]').val('');
            $('.content input[type="password"]').val('');
        }
    }).validate({
        errorPlacement: function errorPlacement(error, element) {

            element.before(error);
        },
        rules: {
            confirm: {
                equalTo: "#password-2"
            }
        }
    });
});
function adduser(){
    var emps={};
    var employee={};
    var userAccount={};

    var fileUpload = $('#files').get(0);
    var files = fileUpload.files;
    var formData = new FormData();
    for (var i = 0; i < files.length; i++) {
        formData.append( files[i].name,files[i]);
    }
    
    
    $.each($("#create-user-form").serializeArray(), function (i, field) {
        emps[field.name] = field.value;
    });
    var getValue = function (valueName) {
        return emps[valueName];
    };
    employee.Id=getValue("Id");
    employee.Emp_Code = getValue("Emp_Code");
    employee.Emp_Name = getValue("Emp_Name");
    employee.Gender = getValue("Gender");
    employee.DoB = getValue("DoB");
    employee.Phone1 = getValue("Phone1");
    employee.Phone2 = getValue("Phone2");
    employee.Dept_Id = getValue("Dept_Id");
    employee.Dept_Str = $("#Dept_Id option:selected").text();
    employee.Post_Id = getValue("Post_Id");
    employee.Post_Str = $("#Post_Id option:selected").text();
    employee.Shift_Id = getValue("Shift_Id");
    employee.Shift_Str = $("#Shift_Id option:selected").text();
    employee.No_Num = getValue("No_Num");
    employee.St_Num = getValue("St_Num");
    employee.Sangkat = getValue("Sangkat");
    employee.Khan = getValue("Khan");
    employee.City = getValue("City");
    employee.Province = getValue("Province");
    employee.Email = getValue("email");
    employee.Old_Img=getValue("Old_Img");
    
    
    employee.UserAccount=userAccount;
    
   if(formData != null){
       $.ajax({
           url: "/profile/upload",
           type: 'post',
           processData: false,
           contentType: false,
           data : formData,
           success: function(data) {
               employee.Img = data;
               $.ajax({
                   url: "/user/create",
                   type: 'post',
                   datatype: "json",
                   data : { "employee": employee},
                   success: function(response) {
                       alertSuccess();
                       window.setTimeout(function(){window.location.replace('/user/list')}, 1500);
                   },
                   error:function(response)
                   {
                       alertError();
                   }
               });
           },
           error:function(data)
           {
               
           }
       });
   }else{
       employee.Img = "user-200.png";
       $.ajax({
           url: "/user/create",
           type: 'post',
           datatype: "json",
           data : { "employee": employee},
           success: function(response) {
               alertSuccess();
               window.setTimeout(function () { window.location.replace('/user/list');}, 1500);
           },
           error:function(response)
           {
               alertError();
           }
       });
   }
}
function select_change_Dept(){
    var deptId = $("#Dept_Id").val();
    $.ajax({
        url: "/position/dept/" + deptId,
        type: "get",
        datatype: "json",
        success: function (data) {
            var out = "";
            $.each(data, function (i, item) {
                out += "<option value=" + item.id + ">" + item.position_En + "</option>";
            });
            $("#Post_Id").html(out);
        }
    });
}
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
function Change_Image(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        
        reader.onload = function (e) {
            $('#image_profile')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function deleteShift(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the shift!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/user/shift/delete/" + val,
                type: 'post',
                datatype: "json",
                success: function (data) {
                    swal("Deleted!", "Your shift has been deleted.", "success");
                    window.setTimeout(function () { window.location.reload() }, 1500);
                },
                error: function (data) {
                    swal("Error!", "Your shift has been error deleted.", "error");
                }
            });
        });
}

