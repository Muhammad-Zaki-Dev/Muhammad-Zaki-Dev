/*
 Template Name: Agroxa - Responsive Bootstrap 4 Admin Dashboard
 Author: Themesbrand
 File: C3 Chart init js
 */
var Orders = {};
var Suppliers = {};

function GetOrdersData() {
    $.ajax({
        type: 'GET',
        url: '/Admin/GetOrders',
        async: false,
        success: (res) => {
            debugger;
            Orders = res;
        },
        error: () => {
       
            toastr.error('Error');
        }
    });

}

function GetSuppliersData() {
    $.ajax({
        type: 'GET',
        url: '/Admin/GetSuppliers',
        async: false,
        success: (res) => {
            debugger;
            Suppliers = res;
        },
        error: () => {
           
            toastr.error('Error');
        }
    });

}

!function ($) {
    "use strict";

    var ChartC3 = function () { };
    GetOrdersData();
    GetSuppliersData();
    ChartC3.prototype.init = function () {
        //generating chart 
        //c3.generate({
        //    bindto: '#chart',
        //    data: {
        //        columns: [
        //            ['Pending', Orders[0].Jan, Orders[0].Feb, Orders[0].Mar, Orders[0].April, Orders[0].May, Orders[0].Jun, Orders[0].Jul, Orders[0].Aug, Orders[0].Sep, Orders[0].Oct, Orders[0].Nov, Orders[0].Dec],
        //            ['Approved', Orders[1].Jan, Orders[1].Feb, Orders[1].Mar, Orders[1].April, Orders[1].May, Orders[1].Jun, Orders[1].Jul, Orders[1].Aug, Orders[1].Sep, Orders[1].Oct, Orders[1].Nov, Orders[1].Dec],
        //            ['Shipped', Orders[2].Jan, Orders[2].Feb, Orders[2].Mar, Orders[2].April, Orders[2].May, Orders[2].Jun, Orders[2].Jul, Orders[2].Aug, Orders[2].Sep, Orders[2].Oct, Orders[2].Nov, Orders[2].Dec],
        //            ['Delivered', Orders[3].Jan, Orders[3].Feb, Orders[3].Mar, Orders[3].April, Orders[3].May, Orders[3].Jun, Orders[3].Jul, Orders[3].Aug, Orders[3].Sep, Orders[3].Oct, Orders[3].Nov, Orders[3].Dec]
        //        ],
        //        type: 'pie',
        //        colors: {
        //            Pending: '#f0f1f4',
        //            Approved: '#28a745',
        //            Shipped: '#f16c69',
        //            Delivered: '#20c997'
        //        }
        //    }
        //});

        //generating chart 
        c3.generate({
            bindto: '#SuppliersChart',
            data: {
                columns: [
                    ['Total Suppliers', Suppliers.TotalSuppliers],
                    ['Pending Suppliers', Suppliers.PendingSuppliers],
                    ['Approved Suppliers', Suppliers.ApprovedSuppliers],
                    ['In-Active Suppliers', Suppliers.DeActivatedSuppliers]
                ],
                type: 'donut',
                colors: {
                    Approved: '#28a745',
                    Pending: '#f16c69',
                    Total: '#20c997'
                }
            }
        });

        //combined chart
        c3.generate({
            bindto: '#combine-chart',
            data: {
                columns: [
                    ['SonyVaio', 30, 20, 50, 40, 60, 50],
                    ['iMacs', 200, 130, 90, 240, 130, 220],
                    ['Tablets', 300, 200, 160, 400, 250, 250],
                    ['iPhones', 200, 130, 90, 240, 130, 220],
                    ['Macbooks', 130, 120, 150, 140, 160, 150]
                ],
                types: {
                    SonyVaio: 'bar',
                    iMacs: 'bar',
                    Tablets: 'spline',
                    iPhones: 'line',
                    Macbooks: 'bar'
                },
                colors: {
                    SonyVaio: '#f0f1f4',
                    iMacs: '#f16c69',
                    Tablets: '#2f8ee0',
                    iPhones: '#fb4',
                    Macbooks: '#28bbe3'
                },
                groups: [
                    ['SonyVaio', 'iMacs']
                ]
            },
            axis: {
                x: {
                    type: 'categorized'
                }
            }
        });

        //roated chart
        c3.generate({
            bindto: '#roated-chart',
            data: {
                columns: [
                    ['Revenue', 30, 200, 100, 400, 150, 250],
                    ['Pageview', 50, 20, 10, 40, 15, 25]
                ],
                types: {
                    Revenue: 'bar'
                },
                colors: {
                    Revenue: '#f0f1f4',
                    Pageview: '#28bbe3'
                }
            },
            axis: {
                rotated: true,
                x: {
                    type: 'categorized'
                }
            }
        });

        //stacked chart
        c3.generate({
            bindto: '#chart-stacked',
            data: {
                columns: [
                    ['Revenue', 130, 120, 150, 140, 160, 150, 130, 120, 150, 140, 160, 150],
                    ['Pageview', 200, 130, 90, 240, 130, 220, 200, 130, 90, 240, 130, 220]
                ],
                types: {
                    Revenue: 'area-spline',
                    Pageview: 'area-spline'
                    // 'line', 'spline', 'step', 'area', 'area-step' are also available to stack
                },
                colors: {
                    Revenue: '#f0f1f4',
                    Pageview: '#28bbe3'
                }
            }
        });

        //Donut Chart
        //c3.generate({
        //    bindto: '#donut-chart',
        //    data: {
        //        columns: [
        //            ['Desktops', 78],
        //            ['Smart Phones', 55],
        //            ['Mobiles', 40],
        //            ['Tablets', 25]
        //        ],
        //        type: 'donut'
        //    },
        //    donut: {
        //        title: "Candidates",
        //        width: 30,
        //        label: {
        //            show: false
        //        }
        //    },
        //    color: {
        //        pattern: ['#f0f1f4', '#f16c69', '#28bbe3', '#2f8ee0']
        //    }
        //});

        //Pie Chart
        //c3.generate({
        //    bindto: '#pie-chart',
        //    data: {
        //        columns: [
        //            ['Desktops', 78],
        //            ['Smart Phones', 55],
        //            ['Mobiles', 40],
        //            ['Tablets', 25]
        //        ],
        //        type: 'pie'
        //    },
        //    color: {
        //        pattern: ['#f0f1f4', '#f16c69', '#28bbe3', '#2f8ee0']
        //    },
        //    pie: {
        //        label: {
        //            show: false
        //        }
        //    }
        //});

    },
        $.ChartC3 = new ChartC3, $.ChartC3.Constructor = ChartC3

}(window.jQuery),

    //initializing 
    function ($) {
        "use strict";
        $.ChartC3.init()
    }(window.jQuery);



