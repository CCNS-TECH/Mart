function deletewhs(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the warehouse!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/whs/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your warehouse has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your warehouse has been error deleted.", "error");
                }
            })
        });
}
function setwhs(val) {
    swal({
            title: "Are you sure?",
            text: "You'll to set default the warehouse!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, set it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/whs/set/" + val,
                type: 'post',
                datatype: "json",
                success: function (data) {
                    swal("Success!", "Your warehouse has been set default.", "success");
                    window.setTimeout(function () { window.location.reload(); }, 1500);
                },
                complete: function () {

                    window.location.href = "/account/logout";
                },
                error: function (data) {
                    swal("Error!", "Your warehouse has been error set default.", "error");
                }
            });
        });
}