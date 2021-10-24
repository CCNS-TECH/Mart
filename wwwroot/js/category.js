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
function deleteSubCate(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the subcategory item!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/subcate/l1/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your subcategory item has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your subcategory item has been error deleted.", "error");
                }
            })
        });
}
function deleteSubCateL1(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the subcategory L1 item!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/subcate/l2/delete/"+val,
                type: 'post',
                datatype: "json",
                success:function(data){
                    swal("Deleted!", "Your subcategory L1 item has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your subcategory L1 item has been error deleted.", "error");
                }
            })
        });
}
function getcategorybyid() {
    var subId = $("#SubCateL1_Id").val();
    $.ajax({
        url: "/sub/l1/cate/"+subId,
        type: 'get',
        datatype: "json",
        success:function(data){
            $("#Category_Id").val(data.Category.CateId);
            $("#Category_En").val(data.Category.Cate_En)
        },
        error:function (data) {
            swal("Error!", "Your find category by subcategory id has been not found.", "error");
        }
    })
}