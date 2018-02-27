var common = {
    init: function () {
        common.registerEvents();
    },

    registerEvents: function () {
        //$("#txtKeyword").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/Product/GetListProductByName",
        //            dataType: "json",
        //            data: {
        //                keyword: request.term
        //            },
        //            success: function (resp) {
        //                response(resp.data);
        //            }
        //        });
        //    },
        //    minLength: 0,
        //    select: function (event, ui) {
        //        log("Selected: " + ui.item.value + " aka " + ui.item.id);
        //    }
        //}); 

        $("#txtKeyword").autocomplete({
            minLength: 0,
            source:  function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (resp) {
                        response(resp.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                //$("#project-id").val(ui.item.value);
                //$("#project-description").html(ui.item.desc);
                //$("#project-icon").attr("src", "images/" + ui.item.icon);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<div>" + item.label + "</div>")
                .appendTo(ul);
        };
    }
}

common.init();