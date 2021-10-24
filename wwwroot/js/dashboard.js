"use strict";
setInterval("tracking_dashboard();",60000);
function tracking_dashboard(){
    checkSection();
    getInvoice();
    bookedValue();
    checkedValue();
    orderValue();
    invoiceValue();
}
function bookedValue() {
    $.ajax({
        url: "/report/invoice/value",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            $("#invoiceValue").text(parseFloat(data).toFixed(2));
        },
        error:function () {
        }
    });
}
function checkedValue() {
    $.ajax({
        url: "/report/booked/value",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            $("#bookedValue").text(data);
        },
        error:function () {
        }
    });
}
function orderValue() {
    $.ajax({
        url: "/report/order/value",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            $("#orderValue").text(parseFloat(data).toFixed(2));
        },
        error:function () {
        }
    });
}
function invoiceValue() {
    $.ajax({
        url: "/report/checked/value",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            $("#checkedValue").text(data);
        },
        error:function () {
        }
    });
}
function checkSection(){
    $.ajax({
        url: "/section/all",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            /*Doughnut chart*/
            var ctx = document.getElementById("SectionSummary");
            var data = {
                labels: [
                    "Available", "Booked", "Busy", "Bill"
                ],
                datasets: [{
                    data: [data.countAvailable, data.countBooking, data.countBusy, data.countBill],
                    backgroundColor: [
                        "#1ABC9C",
                        "#FFE352",
                        "#677DFE",
                        "#FA5C34"
                    ],
                    borderWidth: [
                        "0px",
                        "0px",
                        "0px",
                        "0px"
                    ],
                    borderColor: [
                        "#1ABC9C",
                        "#FCC9BA",
                        "#B8EDF0",
                        "#B4C1D7"

                    ]
                }],

            };
            var myDoughnutChart = new Chart(ctx, {
                type: 'doughnut',
                data: data,
                options: {
                    showTooltips: true,
                    onAnimationComplete: function() {
                        this.showTooltip(this.segments, true);
                    },
                    showDatasetLabels : true,
                    cutoutPercentage: 41,
                    legend: {
                        display: true,
                        position:'bottom',
                        labels: {
                            boxWidth: 15,
                            boxHeight: 2,
                        },
                    },
                    title: {
                        display: true,
                    }
                }
            });
        },
        error:function () {
        }
    });
    Chart.plugins.register({
        afterDatasetsDraw: function(chartInstance, easing) {
            // To only draw at the end of animation, check for easing === 1
            var ctx = chartInstance.chart.ctx;
            chartInstance.data.datasets.forEach(function(dataset, i) {
                var meta = chartInstance.getDatasetMeta(i);
                if (!meta.hidden) {
                    meta.data.forEach(function(element, index) {
                        // Draw the text in black, with the specified font
                        ctx.fillStyle = 'white';
                        var fontSize = 14;
                        var fontStyle = 'normal';
                        var fontFamily = 'Helvetica Neue';
                        ctx.font = Chart.helpers.fontString(fontSize, fontStyle, fontFamily);
                        // Just naively convert to string for now
                        var dataString = dataset.data[index].toString();
                        // Make sure alignment settings are correct
                        ctx.textAlign = 'center';
                        ctx.textBaseline = 'middle';
                        var padding = 5;
                        var position = element.tooltipPosition();
                        ctx.fillText(dataString, position.x, position.y - (fontSize / 2) - padding);
                    });
                }
            });
        }
    });
}
function getInvoice(){
    $.ajax({
        url: "/report/inv",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            /*Pie chart*/
            var pieElem = document.getElementById("pieSaleSummary");
            var data4 = {
                labels: [
                    "Food ($)",
                    "Beverage ($)",
                    "Service ($)",
                    "Other Charge ($)",
                    "Section Amount ($)"
                ],
                datasets: [{
                    data: [data.food, data.beverage, data.service,data.otherCharge,data.sectionAmount],
                    backgroundColor: [
                        "#1ABC9C",
                        "#FFE352",
                        "#677DFE",
                        "#FA5C34",
                        "#105C34"
                    ],
                    hoverBackgroundColor: [
                        "#1ABC9C",
                        "#FFE352",
                        "#677DFE",
                        "#FA5C34",
                        "#105C34"
                    ]
                }]
            };
            var myPieChart = new Chart(pieElem, {
                type: 'pie',
                data: data4,
                options: {
                    legend: {
                        display: true,
                        position:'bottom',
                }
            }
            });
        },
        error:function () {
        }
    });
}
function getItemTopSale(){
    $.ajax({
        url: "/report/top/sale",
        type: "get",
        datatype: "json",
        async:false,
        success: function (data) {
            var datastr =[];
            var qtytopsale=[];
            $.each(data,function (i,val){
                datastr.push(val.itemStr);
                qtytopsale.push(val.quantity);
            });
            
            /*Bar chart*/
            var data1 = {
                labels: [datastr[0], datastr[1], datastr[2], datastr[3], datastr[4], datastr[5], datastr[6], datastr[7], datastr[8], datastr[9]],
                datasets: [{
                    label: "Top Sales",
                    backgroundColor: [
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)',
                        'rgba(95, 190, 170, 0.99)'
                    ],
                    hoverBackgroundColor: [
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)',
                        'rgba(26, 188, 156, 0.88)'
                    ],
                    data: [qtytopsale[0], qtytopsale[1], qtytopsale[2], qtytopsale[3], qtytopsale[4], qtytopsale[5], qtytopsale[6], qtytopsale[7], qtytopsale[8], qtytopsale[9]]
                }]
            };

            var bar = document.getElementById("barChart").getContext('2d');
            var myBarChart = new Chart(bar, {
                type: 'bar',
                data: data1,
                options: {
                    barValueSpacing: 20
                }
            });
        },
        error:function () {
        }
    });
}
$(document).ready(function(){
    checkSection();
    getInvoice();
    getItemTopSale();
});
function onChangeStaffValue() {
    var id = $("#staffSelection").val();
    getInvByUser(id)
}
function getInvByUser(id) {
    if(id == "0"){
        $("#UserProfile").text("0000-UserName");
        $('#profile').attr('src', "/images/profiles/user-200.png");
        $("#saleByStaff").find("tr td span#foodQty").text("0.00");
        $("#saleByStaff").find("tr td span#foodAmount").text("0.00");
        $("#saleByStaff").find("tr td span#beverageQty").text("0.00");
        $("#saleByStaff").find("tr td span#beverageAmount").text("0.00");
        $("#saleByStaff").find("tr td span#ServiceQty").text("0.00");
        $("#saleByStaff").find("tr td span#ServiceCharge").text("0.00");
        $("#saleByStaff").find("tr td span#OtherChargeQty").text("0.00");
        $("#saleByStaff").find("tr td span#OtherCharge").text("0.00");
        $("#saleByStaff").find("tr td span#SectionQty").text("0.00");
        $("#saleByStaff").find("tr td span#SectionAmount").text("0.00");
    }else{
        $.ajax({
            url: "/report/inv/user",
            type: "get",
            datatype: "json",
            data:{"id":id},
            contentType: false,
            processData: true,
            success: function (data) {
                $("#UserProfile").text(data.employee.emp_Code+"-"+data.employee.emp_Name);
                $('#profile').attr('src', "/images/profiles/" + data.employee.img);
                $("#saleByStaff").find("tr td span#foodQty").text(parseFloat(data.foodQty).toFixed(2));
                $("#saleByStaff").find("tr td span#foodAmount").text(parseFloat(data.food).toFixed(2));
                $("#saleByStaff").find("tr td span#beverageQty").text(parseFloat(data.beverageQty).toFixed(2));
                $("#saleByStaff").find("tr td span#beverageAmount").text(parseFloat(data.beverage).toFixed(2));
                $("#saleByStaff").find("tr td span#ServiceQty").text(parseFloat("1").toFixed(2));
                $("#saleByStaff").find("tr td span#ServiceCharge").text(parseFloat(data.service).toFixed(2));
                $("#saleByStaff").find("tr td span#OtherChargeQty").text(parseFloat("1").toFixed(2));
                $("#saleByStaff").find("tr td span#OtherCharge").text(parseFloat(data.otherCharge).toFixed(2));
                $("#saleByStaff").find("tr td span#SectionQty").text(parseFloat("1").toFixed(2));
                $("#saleByStaff").find("tr td span#SectionAmount").text(parseFloat(data.sectionAmount).toFixed(2));
            },
            error:function () {
            }
        });
    }
    
}