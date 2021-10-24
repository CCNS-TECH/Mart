var table_defineUoM=$("#tbdefineuom tbody");

function deleteUoM(val){
    swal({
            title: "Are you sure?",
            text: "You'll to delete the uom item!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        },
        function(){
            $.ajax({
                url: "/uoms/DeleteUoM/",
                type: 'post',
                datatype: "json",
                data:{id:val},
                success:function(data){
                    swal("Deleted!", "Your uom item has been deleted.", "success");
                    window.setTimeout(function(){window.location.reload()}, 1500);
                },
                error:function (data) {
                    swal("Error!", "Your uom item has been error deleted.", "error");
                }
            })
        });
}
function deleteGUoM(val){
    swal({
        title: "Are you sure?",
        text: "You'll to delete the group uom item!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    },
    function(){
        $.ajax({
            url: "/uom/group/delete/"+val,
            type: 'post',
            datatype: "json",
            success:function(data){
                swal("Deleted!", "Your group uom item has been deleted.", "success");
                window.setTimeout(function(){window.location.reload()}, 1500);
            },
            error:function (data) {
                swal("Error!", "Your group uom item has been error deleted.", "error");
            }
        })
    });
}
function define_groupuom(val) {
    define_guomid = val;
    $("#group_define_uom").val(0);
    ListDefineUoM();
}
table_defineUoM.on("click", "#edit_defineuom", function () {
    var currow = $(this).closest("tr");
    var gdefineuomid = currow.find("td:eq(0)").text();
    var altqty = currow.find("td:eq(1)").text();
    var altuomname = currow.find("td:eq(2)").text();
    var baseqty = currow.find("td:eq(4)").text();
    var baseuonname = currow.find("td:eq(5)").text();
    var altuomid = currow.find("td:eq(6)").text();
    var baseuomid = currow.find("td:eq(7)").text();

    $("#group_define_uom").val(gdefineuomid);
    $("#altuom").val(altuomid).change();
    $("#altqty").val(altqty);
    $("#baseuom").val(baseuomid).change();
    $("#baseqty").val(baseqty);
});
function ListDefineUoM() {
    document.getElementById("baseuom").disabled = false;
    $.ajax({
        url: "/UoM/GetUoMDefine",
        type: "get",
        datatype: "json",
        data: { groupid: define_guomid },
        success: function (response) {
            var out = "";
            $.each(response, function (i, item) {
                if (i == 0) {
                    $("#baseuom").val(item.baseUoMId).change();
                    document.getElementById("baseuom").disabled = true;

                }
                out += "<tr><td hidden>" + item.gDUoMId
                    + "</td><td>" + item.altQty
                    + "</td><td>" + item.altUoMName
                    + "</td><td> = "
                    + "</td><td>" + item.baseQty
                    + "</td><td>" + item.baseUoMName
                    + "</td><td hidden>" + item.uoMId
                    + "</td><td hidden>" + item.baseUoMId

                    + "<td class='text-right'><a href='#'  id='edit_defineuom' class='btn-sm btn-primary'>Edit</a></td>"
                    + "</td></tr>";
            });
            $("#list_defineuom").html(out);
        }
    })
}
function click_DefineUoM() {
    var groupdefineuomid = $("#group_define_uom").val();
    var altuom = $("#altuom").val();
    var altuomname = $("#altuom option:selected").text();
    var altqty = $("#altqty").val();
    var baseuom = $("#baseuom").val();
    var baseuomname = $("#baseuom option:selected").text();
    var baseqty = $("#baseqty").val();

    var define = {
        GDUoMId: groupdefineuomid,
        GUoMId: define_guomid,
        AltUoMName: altuomname,
        UoMId: altuom,
        AltQty: altqty,
        BaseUoMId: baseuom,
        BaseUoMName: baseuomname,
        BaseQty: baseqty
    };
    $.ajax({
        url: "/UoM/InsertGDUoM",
        type: "post",
        datatype: "json",
        data: { defineUoM: define },
        success: function (response) {
            ListDefineUoM();
            $("#altqty").val("");
            $("#baseqty").val("");
            $("#group_define_uom").val(0);
        }
    });
}
