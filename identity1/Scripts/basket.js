$(document).ready(function () {
    $('.button').on('click', function () {
        var _id = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: "/Products/AddToBasket",
            data: { id: _id },
            success: function (data, textStatus, jqXHR) {
                if (data == 'True') {
                    alert('Добавлено');
                }
                else {
                    alert('Не добавлено');
                }
            }
        });


    });
});