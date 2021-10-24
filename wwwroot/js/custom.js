function deleteUser(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete this user profile!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/user/deleted/"+val,
                type: 'get',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your user profile has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your user profile has been error deleted.", "error");
                }
            })
        });
}
function deleteCate(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the category item!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/cate/delete/" + val,
                type: 'post',
                datatype: "json",
                success: function (data) {
                    swal("Deleted!", "Your cate item has been deleted.", "success");
                    window.setTimeout(function () { window.location.reload(); }, 1500);
                },
                error: function (data) {
                    swal("Error!", "Your cate item has been error deleted.", "error");
                }
            });
        });
}
function deleteSubCate(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the category item!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/cate/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your cate item has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your cate item has been error deleted.", "error");
                }
            })
        });
}