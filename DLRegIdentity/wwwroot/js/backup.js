var URL = location.protocol + "//" + location.host.toString();
var fontSize = 11;
var statuses = [
  "All",
  Number(getThisYear().toString() + getThisMonth().toString())
];

$("#gridContainer").css("font-size", fontSize + "px");
var monthreg = new DevExpress.data.CustomStore({
  key: "rowid",
  load: function(loadOptions) {
    var deferred = $.Deferred(),
      args = {};

    if (loadOptions.sort) {
      args.orderby = loadOptions.sort[0].selector;
      if (loadOptions.sort[0].desc) args.orderby += " desc";
    }

    //args.skip = loadOptions.skip || 0;
    //args.take = loadOptions.take || 12;
    return sendRequest(URL + "/api/monthregs", "GET", args);
    // $.ajax({
    //     url: URL + "/api/monthregs",
    //     dataType: "json",
    //     data: args,
    //     success: function(result) {
    //         deferred.resolve(result);
    //     },
    //     error: function() {
    //         deferred.reject("Data Loading Error");
    //     },
    //     timeout: 5000
    // });

    return deferred.promise();
  },
  insert: function(values) {
    return sendRequest(URL + "/api/Monthregs", "POST", {
      values: JSON.stringify(values)
    });
  },
  update: function(key, values) {
    //key.dp3 = values;
    return $.ajax({
      url: URL + "/api/Monthregs/" + key.toString(),
      contentType: "application/json",
      method: "PUT",
      data: JSON.stringify(values)
    });
    // return sendRequest2(URL + "/api/Monthregs/", "PUT", {
    //   key: key,
    //   values: JSON.stringify(values)
    // });
  },
  remove: function(key) {
    return sendRequest(URL + "/api/Monthregs/" + key.toString(), "DELETE", {
      key: key
    });
  }
});

function UpdateHeight() {
  $("#gridContainer")
    .dxDataGrid("instance")
    .option("height", $(window).height() - 20);
}

var gridcontainer = $("#gridContainer")
  .dxDataGrid({
    dataSource: monthreg,
    columnWidth: 50,
    showBorders: true,
    showRowLines: true,
    rowAlternationEnabled: true,
    allowColumnResizing: true,
    headerFilter: {
      visible: true
      //allowSearch: true
    },
    //   filterValue: [["monthid", "today"]],
    //   filterBuilder: {
    //     customOperations: [{
    //         name: "today",
    //         caption: "Today's date",
    //         dataTypes: ["date"],
    //         icon: "check",
    //         hasValue: false,

    //     }]
    // },
    paging: {
      enabled: false
    },
    editing: {
      //refreshMode: "reshape",
      mode: "row",
      allowUpdating: true
      //useIcons: true

      //allowDeleting: true,
      //allowAdding: true
    },
    scrolling: {
      mode: "infinite"
    },
    // export: {
    //   enabled: true,
    //   fileName: "Monthreg"

    //   // customizeExcelCell: options => {
    //   //     if(options.gridCell.rowType === 'data') {
    //   //         if(options.gridCell.data.OrderDate < new Date(2014, 2, 3)) {
    //   //             options.font.color = '#AAAAAA';
    //   //         }
    //   //         if(options.gridCell.data.SaleAmount > 15000) {
    //   //             if(options.gridCell.column.dataField === 'Employee') {
    //   //                 options.font.bold = true;
    //   //             }
    //   //             if(options.gridCell.column.dataField === 'SaleAmount') {
    //   //                 options.backgroundColor = '#FFBB00';
    //   //                 options.font.color = '#000000';
    //   //             }
    //   //         }
    //   //     }
    //   // }
    // },

    columns: [
      {
        dataField: "worker.id",
        caption: "ID",
        dataType: Number,
        allowEditing: false,
        allowHeaderFiltering: false,
        //showColumnHeaders: true,
        fixed: true,
        width: 21
      },
      {
        dataField: "worker.fullname",
        caption: "Employee",
        dataType: String,
        allowHeaderFiltering: false,
        fixed: true,
        width: 120,
        allowEditing: false
        // allowAdding: false,
        // allowDeleting: false,

        // calculateCellValue: function(data) {
        //     return [
        //         data.worker.name, data.worker.lastname]
        //         .join(" ");
        // }
      },
      {
        dataField: "worker.workplace",
        caption: "Workplace",
        dataType: String,
        allowHeaderFiltering: false,
        fixed: true,
        width: 61,
        allowEditing: false
        // allowAdding: false,
        // allowDeleting: false,

        // calculateCellValue: function(data) {
        //     return [
        //         data.worker.name, data.worker.lastname]
        //         .join(" ");
        // }
      },
      {
        caption: "Month",
        dataType: Number,
        fixed: true,
        dataField: "monthid",
        visible: true,
        allowEditing: false,
        headerFilter: {
          visible: true,
          allowSearch: true
        },
        filterValues: [
          Number(getThisYear().toString() + getThisMonth().toString())
        ],
        filterType: "include",
        //dataType : "date",
        //format : "yyyy-MM",
        //displayFormat: 'monthAndYear',
        //maxZoomLevel: 'year',
        //minZoomLevel: 'century',

        // editorOptions: {
        //   format: ,
        //   displayFormat: 'monthAndYear',
        //   maxZoomLevel: 'year',
        //   minZoomLevel: 'century',
        // }

        // deserializeValue: function(value) {
        //   var year = value.toString().substring(0,4);
        //   var month = value.toString().substring(4);
        //   var date = new Date();
        //   date.setFullYear(year, Number(month)-1, 1);

        //   return date;
        // },

        width: 59
      },
      { allowEditing: true, dataType: String, dataField: "dp1"  },{ allowEditing: true, dataType: Number, dataField: "d1" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp2"  },{ allowEditing: true, dataType: Number, dataField: "d2" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp3"  },{ allowEditing: true, dataType: Number, dataField: "d3" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp4"  },{ allowEditing: true, dataType: Number, dataField: "d4" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp5"  },{ allowEditing: true, dataType: Number, dataField: "d5" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp6"  },{ allowEditing: true, dataType: Number, dataField: "d6" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp7"  },{ allowEditing: true, dataType: Number, dataField: "d7" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp8"  },{ allowEditing: true, dataType: Number, dataField: "d8" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp9"  },{ allowEditing: true, dataType: Number, dataField: "d9" , precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp10" },{ allowEditing: true, dataType: Number, dataField: "d10", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp11" },{ allowEditing: true, dataType: Number, dataField: "d11", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp12" },{ allowEditing: true, dataType: Number, dataField: "d12", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp13" },{ allowEditing: true, dataType: Number, dataField: "d13", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp14" },{ allowEditing: true, dataType: Number, dataField: "d14", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp15" },{ allowEditing: true, dataType: Number, dataField: "d15", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp16" },{ allowEditing: true, dataType: Number, dataField: "d16", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp17" },{ allowEditing: true, dataType: Number, dataField: "d17", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp18" },{ allowEditing: true, dataType: Number, dataField: "d18", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp19" },{ allowEditing: true, dataType: Number, dataField: "d19", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp20" },{ allowEditing: true, dataType: Number, dataField: "d20", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp21" },{ allowEditing: true, dataType: Number, dataField: "d21", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp22" },{ allowEditing: true, dataType: Number, dataField: "d22", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp23" },{ allowEditing: true, dataType: Number, dataField: "d23", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp24" },{ allowEditing: true, dataType: Number, dataField: "d24", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp25" },{ allowEditing: true, dataType: Number, dataField: "d25", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp26" },{ allowEditing: true, dataType: Number, dataField: "d26", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp27" },{ allowEditing: true, dataType: Number, dataField: "d27", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp28" },{ allowEditing: true, dataType: Number, dataField: "d28", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp29" },{ allowEditing: true, dataType: Number, dataField: "d29", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp30" },{ allowEditing: true, dataType: Number, dataField: "d30", precision:1 },
      { allowEditing: true, dataType: String, dataField: "dp31" },{ allowEditing: true, dataType: Number, dataField: "d31", precision:1 },
      {
        caption: "Sum.",
        dataType: Number,
        allowHeaderFiltering: false,
        width: 50,
        fixed: true,
        fixedPosition: "right",

        format: {
          type: "fixedPoint",
          precision: 1
        },
        calculateCellValue: function(data) {
          return (
            data.d1 +
            data.d2 +
            data.d3 +
            data.d4 +
            data.d5 +
            data.d6 +
            data.d7 +
            data.d8 +
            data.d9 +
            data.d10 +
            data.d11 +
            data.d12 +
            data.d13 +
            data.d14 +
            data.d15 +
            data.d16 +
            data.d17 +
            data.d18 +
            data.d19 +
            data.d20 +
            data.d20 +
            data.d21 +
            data.d22 +
            data.d23 +
            data.d24 +
            data.d25 +
            data.d26 +
            data.d27 +
            data.d28 +
            data.d29 +
            data.d30 +
            data.d31
          );
        }
      }
    ],
    onRowUpdating: function(options) {
      options.newData = $.extend({}, options.oldData, options.newData);
    },
    onCellPrepared: function(e) {
      if (e.rowType == "data") {
        //alert(e.values);
        var month = new Date(
          getYear(e.row.data.monthid),
          getMonth(e.row.data.monthid),
          0
        ).getDate();
        //alert(month);
        for (var i = 1; i <= month; i++) {
          //e.cellElement.css("background-color", "red");

          var dp = "dp" + i.toString();
          var d = "d" + i.toString();
          if (e.column.dataField === dp) {
            //
            e.cellElement.css(
              "background-color",
              e.value == "P" ? "yellow" : ""
            );
          }
        }
        for (var i = month + 1; i <= 31; i++) {
          var dp = "dp" + i.toString();
          var d = "d" + i.toString();
          if (e.column.dataField === dp) {
            e.cellElement.find("input").prop("readonly", true);
          }
          if (e.column.dataField === d) {
            e.cellElement.find("input").prop("readonly", true);
          }
        }
      }
    },
    onContentReady: function(e) {
      e.component.columnOption("command:edit", "visibleIndex", -1); // if you want fixedPosition: left, uncomment this code
      e.component.columnOption("command:edit", "width", 70);
    },
    onExported: function(e) {
      //alert("OnExportedsecond");
    },
    onExporting: function(e) {
      //alert("OnExportingfirst");
    },
    onFileSaving: function(e) {
      //alert(e.data);
    },
    export: {
        enabled: true,
        //allowExportSelectedData: true
    }

  })
  .dxDataGrid("instance");

window.onresize = function() {
  UpdateHeight();
};

UpdateHeight();

function getThisYear(date) {
  date = new Date().getFullYear();
  return date;
}
function getThisMonth(date) {
  date = new Date().getMonth();
  date += 1;
  return date.toString().length < 2 ? "0" + date : date;
}

function getThisDate(date) {
  date = new Date();
  return date;
}

function getYear(stringdate) {
  var year = new Date().getFullYear(stringdate.toString().substring(0, 4));
  return year;
}

function getMonth(stringdate) {
  var month = stringdate.toString().substring(4);
  return Number(month);
}

for (var i = 1; i <= 31; i++) {
  var dp = "dp" + i.toString();
  var d = "d" + i.toString();

  if (i / 10 < 1) {
    // čia pirmas dienas 1-9 sutrumpina jų width
    var optiondp = gridcontainer.columnOption(dp, "width", 19.5);
  } else {
    var optiondp = gridcontainer.columnOption(dp, "width", 19.5);
  }
  var optiond = gridcontainer.columnOption(d, "width", 29);

  optiond = gridcontainer.columnOption(d, "alignment", "left");

  optiond = gridcontainer.columnOption(d, "caption", " ");
  optiond = gridcontainer.columnOption(d, "format", {
    type: "fixedPoint",
    precision: 1
  });
  optiond = gridcontainer.columnOption(d, "allowHeaderFiltering", false);

  optiondp = gridcontainer.columnOption(dp, "caption", i.toString());
  optiondp = gridcontainer.columnOption(dp, "alignment", "left");
  optiondp = gridcontainer.columnOption(dp, "allowHeaderFiltering", false);
}

function sendRequest(url, method, data) {
  var d = $.Deferred();

  method = method || "GET";

  $.ajax(url, {
    method: method || "GET",
    data: data,
    dataType: "json",

    //cache: false,
    xhrFields: { withCredentials: false },
    success: function(result) {
      d.resolve(result);
    },
    error: function() {
      d.reject("Data Loading Error");
    },
    timeout: 5000
  })
    .done(function(result) {
      d.resolve(method === "GET" ? result.data : result);
    })
    .fail(function(xhr) {
      d.reject(xhr.responseJSON ? xhr.responseJSON.Message : xhr.statusText);
    });
  return d.promise();
}