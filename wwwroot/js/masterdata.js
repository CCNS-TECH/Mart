$(function () {
    var pricelistStr=$("#PriceListId option:selected").text();
    var taxStr=$("#TaxId option:selected").text();
    var cateid = $("#CateId").val();
    
    
    $("#PriceListStr").val(pricelistStr);
    $("#TaxStr").val(taxStr);

    var groupid = $("#GUoMId").val();
    var groupStr = $("#GUoMId option:selected").text();
    $("#GUoMStr").val(groupStr);

    var subcateStr = $("#SubCateL0Id option:selected").text();
    $("#SubCateL0Str").val(subcateStr);
    
    Getuombygroups(groupid);
    
});

function getuombygroup(val1,val2) {
    var groupid = $("#GUoMId").val();
    var groupStr = $("#GUoMId option:selected").text();
    $("#GUoMStr").val(groupStr);
    Getuombygroups(groupid);
    
}
function Getuombygroups(groupid) {
    $.ajax({
        url: "/uom/define/"+groupid,
        type: "get",
        datatype: "json",
        success: function (data) {
            var out = "";
            $.each(data, function (i, uom) {
                console.log("Data::::" + JSON.stringify(uom));

                out += "<option value=" + uom.uoM_Id + ">" + uom.altUoMName + "</option>";
            });
            $("#SaleUoMId").html(out);
            $("#PchUoMId").html(out);
            $("#InvUoMIds").html(out);

            var saleUoMStr = $("#SaleUoMId option:selected").text();
            var pchUoMStr = $("#PchUoMId option:selected").text();
            var invUoMId = $("#InvUoMIds").val();
            var invUoMStr = $("#InvUoMIds option:selected").text();

            $("#SaleUoMStr").val(saleUoMStr);
            $("#PchUoMStr").val(pchUoMStr);
            
            $("#InvUoMId").val(invUoMId);
            $("#InvUoMStr").val(invUoMStr);
        }
    });
}
function onchange_category() {
    var cateid = $("#CateId").val();
    var cateStr = $("#CateId option:selected").text();
    $("#CateStr").val(cateStr);
    $.ajax({
        url: "/sub/l1/cate/id/"+cateid,
        type: "get",
        datatype: "json",
        success: function (data) {
            var out = "";
            $.each(data, function (i, sub) {
                
                out += "<option value=" + sub.subCateL1_Id + ">" + sub.subCateL1_En + "</option>";
            });
            $("#SubCateL0Id").html(out);
            var subStr = $("#SubCateL0Id option:selected").text();
            $("#SubCateL0Str").val(subStr);
        }
    });
}
function onchange_subcategory() {
    var subcateid = $("#SubCateL0Id").val();
    var subcateStr = $("#SubCateL0Id option:selected").text();
    $("#SubCateL0Str").val(subcateStr);
}


function onchange_pricelist() {
    var pricelistid = $("#PriceListId").val();
    var pricelistStr = $("#PriceListId option:selected").text();
    $("#PriceListStr").val(pricelistStr);
}
function onchange_tax() {
    var taxid = $("#TaxId").val();
    var taxStr = $("#TaxId option:selected").text();
    $("#TaxId").val(taxid);
    $("#TaxStr").val(taxStr);
}
function onchange_saleuom() {
    var saleUoMStr = $("#SaleUoMId option:selected").text();
    $("#SaleUoMStr").val(saleUoMStr);
    
}
function onchange_pchuom() {
    var pchUoMStr = $("#PchUoMId option:selected").text();
    $("#PchUoMStr").val(pchUoMStr);
}
function onchange_invuom() {
    var invUoMStr = $("#InvUoMId option:selected").text();
    $("#InvUoMStr").val(invUoMStr);
}
function checkQrCode() {
    $('[name="QrCode"]').each( function (){
        if($(this).prop('checked') == true){
            $("#QrCodeId").val(1);
        }else{
            $("#QrCodeId").val(0);
        }
    });
}