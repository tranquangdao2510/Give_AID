﻿var common = {
    init: function () {
        common.registerEvent
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Fund/ListFundName",
                    dataType: "json",
                    data: {
                        term: request.term
                    },
                    success: function (response) {
                        response(response.data);
                    }
                });
            },
               
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul);
            };
    } 
    
}

common.init()