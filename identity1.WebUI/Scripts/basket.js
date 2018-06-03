$(document).ready(function () {
    $('.delete').on('click', function () {
        var _id = $(this).attr("id");
        $.ajax({
            type: "POST",
            url: "/Products/DeleteFromBasket",
            data: { id: _id }
        });


    });
});