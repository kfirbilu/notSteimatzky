$(function () {
    $("#searchBook").autocomplete({
        source: "/Books/SearchAutoComplete",
        minLength: 1,
        select: function (event, ui) {
            location.href = '/Books/ViewBook?bookid=' + ui.item.id;
        }
    });
});