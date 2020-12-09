var cart={
    init: function () {
        
    },
    regEvent: function () {
        $('#addtocart').off('click').on('click', function () {
            var listProduct = $('.addtocart');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).val(),
                    product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: 'Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                datatype: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "http://localhost:14787/Home"; 
                    }
                }
            })
        });
    }
}