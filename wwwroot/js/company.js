function deletecompany(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the company!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/company/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your company has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your company has been error deleted.", "error");
                }
            })
        });
}
function setcompany(val) {
    swal({
            title: "Are you sure?",
            text: "You'll to set default the company!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, set it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/company/set/" + val,
                type: 'post',
                datatype: "json",
                success: function (data) {
                    swal("Success!", "Your company has been set default.", "success");
                    window.setTimeout(function () { location.reload(); }, 1500);
                },
                complete: function () {
                    window.location.href = "/account/logout";
                },
                error: function (data) {
                    swal("Error!", "Your company has been error set default.", "error");
                }
            });
        });
}