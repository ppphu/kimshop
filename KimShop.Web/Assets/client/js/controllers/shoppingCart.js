var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        
        $('#frmPayment').validate({
            rules: {
                name: 'required',
                address: 'required',
                phone: {
                    required:true,
                    number:true
                },
                email: {
                    required:true,
                    email: true
                },
                messages: {
                    name: 'Bạn phải nhập vào họ tên',
                    address: 'Bạn phải nhập vào địa chỉ',
                    phone: {
                        required: 'Số điện thoại được yêu cầu.',
                        number:'Số điện thoại phải là số.'
                    },
                    email: {
                        required: 'Bạn cần nhập vào email.',
                        email:'Định dạng email chưa đúng'
                    }
                }
            }
        });

        $('.btnDeleteItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.delteteItem(productId);
        });

        $('.txtQuantity').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var productid = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {
                var amount = quantity * price;
                $('#amount_' + productid).text(numeral(amount).format('0,0'));
            }
            else {
                $('#amount_' + productid).text(0);
            }
            $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));

            cart.updateAllCart();
        });

        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = '/';
        });

        $('#btnDeleteAllCart').off('click').on('click', function (e) {
            e.preventDefault();
            cart.delteteAllCart();
            $('#divCheckout').hide();
        });

        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#divCheckout').show();
        });
        $('#btnCreateOrder').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmPayment').valid();
            if (isValid) {
                cart.createOrder();
            }
        });
        $('#chkUserLoginInfo').off('click').on('click', function (e) {
            if ($(this).prop('checked')) {
                cart.getLoginUser();
            }
            else {
                $('#txtFullName').val('');
                $('#txtAddress').val('');
                $('#txtPhone').val('');
                $('#txtEmail').val('');
            }
        });
    },
    getLoginUser: function () {
        $.ajax({
            url: '/ShoppingCart/GetUser',
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    var user = res.data;
                    $('#txtFullName').val(user.FullName);
                    $('#txtAddress').val(user.Address);
                    $('#txtPhone').val(user.PhoneNumber);
                    $('#txtEmail').val(user.Email);
                }
            }
        });
    },
    getTotalOrder: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(this).data('price'));
        });
        return total;
    },
    createOrder: function () {
        var order = {
            CustomerName: $('#txtFullName').val(),
            CustomerAddress: $('#txtAddress').val(),
            CustomerMobile: $('#txtPhone').val(),
            CustomerEmail: $('#txtEmail').val(),
            CustomerMessage: $('#txtMessage').val(),
            PaymentMethod: 'Thanh toán tiền mặt',
            Status: false
        };
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            data: { orderViewModel: JSON.stringify(order) },
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    $('#divCheckout').hide();
                    cart.delteteAllCart();
                    setTimeout(function () {
                        $('#cartContent').html('Bạn đã đặt hàng thành công, chúng tôi sẽ liên hệ với bạn sớm nhất có thể!');
                    }, 2000);
                }
            }
        });
    },
    delteteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: { productId: productId },
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    cart.loadData();
                }
            }
        });
    },
    delteteAllCart: function () {
        $.ajax({
            url: '/ShoppingCart/DeleteAllCart',
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    cart.loadData();
                }
            }
        });
    },
    updateAllCart: function () {
        var cartList = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartList.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            });
        });
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: { cartData: JSON.stringify(cartList) },
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    cart.loadData();
                }
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAllCart',
            type: 'GET',
            dataType: 'JSON',
            success: function (res) {
                if (res.status) {
                    var html = '';
                    var data = res.data;
                    var template = $('#templateCart').html();

                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            PriceF: numeral(item.Product.Price).format('0,0'),
                            Price: item.Product.Price,
                            Quantity: item.Quantity,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0')
                        });
                    });

                    $('#cartBody').html(html);
                    if (html == '') {
                        $('#cartContent').html('Không có sản phẩm trong giỏ hàng.');
                    }
                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvent();
                }
            }
        });
    }
};

cart.init();