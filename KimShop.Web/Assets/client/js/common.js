var common = {
    init: function () {
        common.registerEvents();
    },

    registerEvents: function () {

        $('.btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            common.addItem(productId);
        });

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
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<div>" + item.label + "</div>")
                .appendTo(ul);
        };
    },
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: { productId: productId },
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    alert('Thêm sản phẩm thành công.');
                }
            }
        });
    },
}

common.init();