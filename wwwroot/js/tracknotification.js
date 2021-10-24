$(function () {
    notificationOrderPage();
});
setInterval("tracking_function();",15000);
function tracking_function(){
    notificationOrderPage();
}
function notificationOrderPage() {
    $.ajax({
        url: " /order/get/new",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            var out="";
            var status="";
            if(data !== 0){
                $.each(data,function (i,object) {
                    if(object.docStatus==="I"){
                        status='<i class="label label-primary btn-block text-center">Bill</i>';
                    }else{
                        status='<i class="label label-warning btn-block text-center">New Order</i>';
                    }
                    var date=object.docDate.split("T");
                    out +=
                        '<li style="padding: 0 10px;" class="item-list">'
                        + '<div class="d-flex flex-row" style="border-bottom: 1px #cccccc solid;">'
                        + '<div class="p-2 mr-auto">'
                        + '<p class="font-weight-bold item_name" style="margin: 0;max-width:110px;overflow-x: auto;"> #' +object.orderCode+'</p>'
                        + '<span class="font-weight-bold"><i class="icofont icofont-food-cart"></i> ' + object.sectionStr+'</span>'
                        + '<br/><span class="text-muted"><i class="icofont icofont-tasks-alt"></i> ' + date[0] + '</span>'
                        + '<br/><span>'+status+'</span>'
                        + '</div>'
                        + '<div class="p-2 align-self-center">'
                        + '<div class="pull-left">'
                        + '<p style="margin: 0; padding: 5px 10px 0"></p>'
                        + '</div>'
                        + '<div class="pull-right" style="align-items: center;">'
                        + '</div>'
                        + '</div>'
                        +'<div class="p-2 align-self-center">'
                        + '<i class="icofont icofont-money-bag"></i> <span class="font-weight-bold item_total text-danger" style="margin: 0">$'+ parseFloat(object.grandTotalUSD).toFixed(2)+'</span>'
                        + '</div>'
                        + '<div class="p-2 align-self-center">'
                        + '<a class="btn btn-default text-info pull-right" href="/pos/order/'+object.sectionId+'"  style="background: none;"><i class="icofont icofont-eye-alt"></i></a>'
                        + '</div>'
                        + '</div>'
                        + '</li>';
                });
                $(".totalnotification").text(data.length);
                $("#notification").html(out);
                $("#notification-list").html(out);

            }else{
                console.log("error get date order");
            }
        }
    });
}