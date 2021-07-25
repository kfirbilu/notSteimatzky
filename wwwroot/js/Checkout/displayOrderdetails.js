function fetchdata() {

    var itemsShop = $('#itemsShop');
    var url = itemsShop.attr('action');
    var total = 0;
    $.ajax(
        {
            url: url,
            type: 'Get',
            dataType: 'json',
            success: function (result) {
                
                result.forEach(function (data) {
                    total += parseFloat(data.price);
                });

                $("#order-totalPrice").append(formatToCurrency(total));
                $("#order-tax").append(formatToCurrency(total * 0.17));
                $("#order-totalPriceAfterTax").append(formatToCurrency(total * 1.17));
            }
        });
}

const formatToCurrency = amount => {
    return "$" + amount.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, "$&,");
};

$(document).ready(function () {
    //setTimeout(fetchdata, 0);
    fetchdata();
});