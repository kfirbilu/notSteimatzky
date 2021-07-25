function AddToCart(id) {
    $.ajax({
        url: '/ShoppingCarts/ShoppingCartSummary',
        data: "BookId=" + id,
        success: function (componentview) {
            $('#Cart').html(componentview);
        }
    });
}