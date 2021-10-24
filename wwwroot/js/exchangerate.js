function deleteExchange(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the exchange rate!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/exch/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your exchange rate has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your exchange rate has been error deleted.", "error");
                }
            })
        });
}
function setExchange(val) {
    swal({
            title: "Are you sure?",
            text: "You'll to set default the exchange rate!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, set it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/exch/set/" + val,
                type: 'post',
                datatype: "json",
                success: function (data) {
                    swal("Success!", "Your exchange rate has been set default.", "success");
                    window.setTimeout(function () { location.reload(); }, 1500);
                },
                complete: function () {
                    
                    window.location.href = "/account/logout";
                },
                error: function (data) {
                    swal("Error!", "Your exchange rate has been error set default.", "error");
                }
            });
        });
}