"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

connection.on("ReceiveMessage", function (user, message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    $.ajax({
        url: " /order/get/new",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            var out="";
            var i=0;
            if(data !== 0){
                $.each(data,function (i,object) {
                    var date=object.docDate.split("T");
                     out +=
                         '<li style="padding: 0 10px;" class="item-list">'
                         + '<div class="d-flex flex-row">'
                         + '<div class="p-2 mr-auto">'
                         + '<p class="font-weight-bold item_name" style="margin: 0;max-width:110px;overflow-x: auto;"> #' +object.orderCode+ '</p>'
                         + '<span class="font-weight-bold"><i class="icofont icofont-food-cart"></i>' + object.sectionStr + '</span>'
                         + '<br/><span class="text-muted">' + date[0] + '</span>'
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
                         + '<a class="btn btn-default text-info pull-right" style="background: none;"><i class="icofont icofont-eye-alt"></i></a>'
                         + '</div>'
                         + '</div>'
                         + '</li>';
                     i +=1;
                });
                $(".totalnotification").text(data.length);
                $("#notification").html(out);
                
            }else{
                console.log("error get date order");
            }
        }
    });
});

connection.on("UserConnected", function(connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});

connection.start().then(function(){
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendOrder").addEventListener("click", function (event) {
    var user = "";
    var message = "";
    /*var groupValue=document.getElementById("group").value;
    if (groupValue === "All") {*/
        connection.invoke("SendMessage", user, message).catch(function (err) {
          return console.error(err.toString());
        });
    /*} 
    else {
        connection.invoke("SendMessageToUser", groupValue, message).catch(function (err) {
            return console.error(err.toString());
        });
    }*/
    
    event.preventDefault();
});
