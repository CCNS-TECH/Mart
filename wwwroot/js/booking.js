//$(".confirm-booking").on("click",function () {
//    swal({
//        title: "Booking Confirm!",
//        text: "Would you like to confirm booking room?",
//        type: "input",
//        showCancelButton: true,
//        closeOnConfirm: false,
//        inputPlaceholder: "Description",
//        confirmButtonClass: "btn-danger"
//    }, function (inputValue) {
//        if (inputValue === false) return false;
//        if (inputValue === "") {
//            swal.showInputError("You need to write description!");
//            return false
//        }else{
//            var parm=$("#sectionId").val();
            
//            $.ajax({
//                url: "/pos/section/confirm/booking",
//                type: "post",
//                datatype: "json",
//                data:{"id":parm,"message":inputValue},
//                success: function (data) {
//                    swal({
//                            title:"Confirm Successful!",
//                            text:"Your booking has been confirm!",
//                            type:"success"
//                        });
//                    window.setTimeout(function(){window.location.reload()}, 1500);
//                }
//            });
//        }
//    });
//});


$(".cancel-booking").on("click",function () {
    swal({
        title: "Booking Cancel!",
        text: "Would you like to cancel booking?",
        type: "input",
        showCancelButton: true,
        closeOnConfirm: false,
        confirmButtonClass: "btn-danger",
        inputPlaceholder: "Description"
    }, function (inputValue) {
        if (inputValue === false) return false;
        if (inputValue === "") {
            swal.showInputError("You need to write description!");
            return false
        }else{
            var parm = $(".sectionId").val();
            console.log("ID:" + parm);
            $.ajax({
                url: "/pos/section/cancel/booking",
                type: "post",
                datatype: "json",
                data:{"id":parm,"message":inputValue},
                success: function (data) {
                    swal({
                            title:"Cancel Successful!",
                            text:"Your booking has been cancelled!",
                            type:"success"
                        }
                    );
                    window.setTimeout(function(){window.location.reload()}, 1500);
                }
            });
        }
    });
});

$(document).ready(function () {
    document.querySelector('#booking').onclick = function () {

        swal({
                title:"Check In Successful!",
                text:"Checkin has been confirm!",
                type:"success"
            },
            function(){
                $('.md-close').trigger('click');
            }
        );
    };
    document.querySelector('#split').onclick = function () {

        swal({
                title:"Check In Successful!",
                text:"Checkin has been confirm!",
                type:"success"
            },
            function(){
                $('.md-close').trigger('click');
            }
        );
    };
    
    document.querySelector('#checkin').onclick = function () {
        swal({
                title:"Booking Successful!",
                text:"Your booking has been confirm!",
                type:"success"
            },
            function(){
                $('.md-close').trigger('click');
            }
        );
    };

    document.querySelector('#tranfer').onclick = function () {
        swal({
                title:"Booking Successful!",
                text:"Your booking has been confirm!",
                type:"success"
            },
            function(){
                $('.md-close').trigger('click');
            }
        );
    };
    
});

