$(function(){
    $("#btnSubmit").hide();
    $("#confirmpassword").hide();
});

$("#ConfirmPass").on("keyup",function () {
    var pass = $("#Password").val();
    var confirm = $("#ConfirmPass").val();
    if (pass == confirm) {
        
        $("#btnSubmit").show();
        $("#confirmpassword").hide();
    }
    else {
        $("#btnSubmit").hide();
        $("#confirmpassword").show(1000);
    }
});
$("#Password").on("keyup",function () {
    var pass = $("#Password").val();
    var confirm = $("#ConfirmPass").val();
    if (pass == confirm) {
        
        $("#btnSubmit").show();
        $("#confirmpassword").hide();
    }
    else {
        $("#btnSubmit").hide();
        $("#confirmpassword").show(1000);  
    }
});