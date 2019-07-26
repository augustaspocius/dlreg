var urlas = location.protocol + "//" + location.host.toString();
var fontSize = 11;
var now = new Date();
var datevalue;
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
    if(datevalue!= null)
    {
      return sendRequest(urlas + "/api/monthregs/" + datevalue, "GET", args);
    }
    else{
      return sendRequest(urlas + "/api/monthregs", "GET", args);
    }
    
    // $.ajax({
    //     url: urlas + "/api/monthregs",
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
    return sendRequest(urlas + "/api/Monthregs", "POST", {
      values: JSON.stringify(values)
    });
  },
  update: function(key, values) {
    //key.dp3 = values;
    return $.ajax({
      url: urlas + "/api/Monthregs/" + key.toString(),
      contentType: "application/json",
      method: "PUT",
      data: JSON.stringify(values)
    });
    // return sendRequest2(urlas + "/api/Monthregs/", "PUT", {
    //   key: key,
    //   values: JSON.stringify(values)
    // });
  },
  remove: function(key) {
    return sendRequest(urlas + "/api/Monthregs/" + key.toString(), "DELETE", {
      key: key
    });
  }
});



// function UpdateHeight() {
//   $("#gridContainer")
//   .dxDataGrid("instance")
//   .option("height", $(window).height());
// }

var gridcontainer = $("#gridContainer")
.dxDataGrid({
  dataSource: monthreg,
  columnWidth: 50,
  showBorders: true,
  showRowLines: true,
  height: '100%',
    rowAlternationEnabled: false,
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
        dataField: "worker.workplace",
        caption: "Workplace",
        dataType: String,
        allowHeaderFiltering: true,
        fixed: true,
        width: 78,
        allowEditing: false,
        headerFilter: {
          visible: true,
          allowSearch: true
        },
        // allowAdding: false,
        // allowDeleting: false,
        
        // calculateCellValue: function(data) {
          //     return [
            //         data.worker.name, data.worker.lastname]
            //         .join(" ");
        // }
      },
      {
        dataField: "worker.fullname",
        caption: "Employee",
        dataType: String,
        allowHeaderFiltering: true,
        fixed: true,
        width: 110,
        allowEditing: false,
        headerFilter: {
          visible: true,
          allowSearch: true
        },
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
        allowHeaderFiltering: false,
        headerFilter: {
          visible: true,
          allowSearch: true
        },
        filterValues: [
          Number(getThisYear().toString() + getThisMonth().toString())
        ],
        filterType: "include",
        width: 59
      },
      { allowEditing: true, dataType: String, dataField: "dp1" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d1" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp2" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d2" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp3" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d3" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp4" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d4" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp5" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d5" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp6" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d6" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp7" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d7" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp8" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d8" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp9" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d9" , allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp10", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d10", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp11", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d11", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp12", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d12", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp13", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d13", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp14", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d14", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp15", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d15", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp16", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d16", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp17", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d17", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp18", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d18", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp19", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d19", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp20", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d20", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp21", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d21", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp22", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d22", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp23", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d23", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp24", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d24", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp25", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d25", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp26", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d26", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp27", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d27", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp28", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d28", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp29", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d29", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp30", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d30", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
      { allowEditing: true, dataType: String, dataField: "dp31", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^[^0-9]+$/, message: "Do not use digits."}, { type: "stringLength", max: 1, message: "Požymis turi būti 1 simbolio" }] },{ allowEditing: true, dataType: Number, dataField: "d31", allowHeaderFiltering: false, validationRules: [{type: "pattern", pattern: /^(\d+(?:[\.]\d{1})?)$/, message: "Only use this format: 0.0."}]},
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
              e.value == "P" ? "yellow" : "WhiteSmoke"
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
    customizeExportData: function (columns, rows) {
      rows.forEach(function (row) {
                var rowValues = row.values;
                rowValues[66] = parseFloat(rowValues[66]).toFixed(1);  //Roundina SUM
              })
            },
            export: {
              enabled: true,
              //allowExportSelectedData: true
            }
            
          })
.dxDataGrid("instance");

$("#datebox").dxDateBox({
              dateSerializationFormat: "",
              displayFormat: "yyyyMM",
              opened: false,
              maxZoomLevel: 'year', 
              minZoomLevel: 'century', 
              width: 100,
              allowHeaderFiltering: false,
              value: now,
              //valueUpdateAction: function(e){ alert(e.actionValue); },
              onValueChanged: function(e)
              {
                //alert(e.component._options.text);
                datevalue = e.component._options.text;
                gridcontainer.refresh();
              }
});
          
// window.onresize = function() {
//             UpdateHeight();
// };
          
// UpdateHeight();
          
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

$("#selectDate").dxSelectBox({
  dataSource: monthreg,
  value: monthreg.monthid,
  onValueChanged: function(data) {
    if (data.value == "All") dataGrid.clearFilter();
    else dataGrid.filter(["Date", "=", data.value]);
  }
});

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

  optiondp = gridcontainer.columnOption(dp, "caption", i.toString());
  optiondp = gridcontainer.columnOption(dp, "alignment", "left");
}

function sendRequest(url, method, data) {
  var d = $.Deferred();

  method = method || "GET";

  //logRequest(method, url, data);

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
