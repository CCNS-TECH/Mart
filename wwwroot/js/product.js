function deletePriceList(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the price-list!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/price-list/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your price-list has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your price-list has been error deleted.", "error");
                }
            })
        });
}
function setPriceList(val) {
    swal({
            title: "Are you sure?",
            text: "You'll to set default the price list!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, set it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/price-list/set/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your price-list has been set default.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your price-list has been error set default.", "error");
                }
            })
        });
}