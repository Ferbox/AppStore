$('document').ready(function () {

    var all = new Array('#colorS', '#memberS', '#displayS', '#sizeS', '#cellS', '#barS');

    var charakForPhone = new Array('#color', '#member', '#display');
    var charakForTablet = new Array('#color', '#member', '#display', '#cell');
    var charakForMacBook = new Array('#color', '#member', '#display', '#bar');
    var charakForWatch = new Array('#color', '#size');
    var charakForMono = new Array('#color', '#member', '#display');

    var charakForPhoneS = new Array('#colorS', '#memberS', '#displayS');
    var charakForTabletS = new Array('#colorS', '#memberS', '#displayS', '#cellS');
    var charakForMacBookS = new Array('#colorS', '#memberS', '#displayS', '#barS');
    var charakForWatchS = new Array('#colorS', '#sizeS');
    var charakForMonoS = new Array('#colorS', '#memberS', '#displayS');

    function allOff() {
        for (var i = 0; i < all.length; i++) {
            $(all[i]).prop("disabled", true);
        }
        $('.option').css("display", "none")
    }
    $('#type').change(
        function () {
            if ($('#type').val() == "iPhone") {
                allOff();
                for (var i = 0; i < charakForPhone.length; i++) {
                    $(charakForPhone[i].toString()).css("display", "block");
                    $(charakForPhoneS[i].toString()).prop("disabled", false);
                }

            }
            if ($('#type').val() == "iPad") {
                allOff();
                for (var i = 0; i < charakForTablet.length; i++) {
                    $(charakForTablet[i].toString()).css("display", "block");
                    $(charakForTabletS[i].toString()).prop("disabled", false);
                }
            }
            if ($('#type').val() == "iMac") {
                allOff();
                for (var i = 0; i < charakForMono.length; i++) {
                    $(charakForMono[i].toString()).css("display", "block");
                    $(charakForMonoS[i].toString()).prop("disabled", false);
                }
            }
            if ($('#type').val() == "Accessories") {

            }
            if ($('#type').val() == "MacBook") {
                allOff();
                for (var i = 0; i < charakForMacBook.length; i++) {
                    $(charakForMacBook[i].toString()).css("display", "block");
                    $(charakForMacBookS[i].toString()).prop("disabled", false);
                }
            }
            if ($('#type').val() == "Watch") {
                allOff();
                for (var i = 0; i < charakForWatch.length; i++) {
                    $(charakForWatch[i].toString()).css("display", "block");
                    $(charakForWatchS[i].toString()).prop("disabled", false);
                }
            }
        });
    $('#form').submit(
        function () {
            var msg = $('#form').serialize();
            $.ajax({
                type: 'POST',
                url: '/Products/Create',
                data: msg,
                success: function (data) {
                    $('#results').html(data);
                },
                error: function (xhr, str) {
                    alert('Возникла ошибка: ' + xhr.responseCode);
                }
            }).done.location.href = "/Products/Index";

        });
});