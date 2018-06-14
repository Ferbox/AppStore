$('document').ready(function () {
    setInterval(func, 1);


    function func() {


        if ($('#type').val() == "iPhone") {
            $('#color').css('display', 'block');
            $('#member').css('display', 'block');
            $('#display').css('display', 'block');
            $('#size').css('display', 'none');
            $('#cell').css('display', 'none');
            $('#bar').css('display', 'none');


            $('#colorL').css('display', 'none');
            $('#memberL').css('display', 'none');
            $('#displayL').css('display', 'none');
            $('#sizeL').css('display', 'block');
            $('#cellL').css('display', 'block');
            $('#barL').css('display', 'block');
        }
        if ($('#type').val() == "iPad") {

            $('#color').css('display', 'block');
            $('#member').css('display', 'block');
            $('#display').css('display', 'block');
            $('#size').css('display', 'none');
            $('#cell').css('display', 'block');
            $('#bar').css('display', 'none');

            $('#colorL').css('display', 'none');
            $('#memberL').css('display', 'none');
            $('#displayL').css('display', 'none');
            $('#sizeL').css('display', 'block');
            $('#cellL').css('display', 'none');
            $('#barL').css('display', 'block');
            //cell
        }
        if ($('#type').val() == "iMac") {
            $('#color').css('display', 'none');
            $('#member').css('display', 'none');
            $('#display').css('display', 'block');
            $('#size').css('display', 'none');
            $('#cell').css('display', 'none');
            $('#bar').css('display', 'none');

            $('#colorL').css('display', 'block');
            $('#memberL').css('display', 'block');
            $('#displayL').css('display', 'none');
            $('#sizeL').css('display', 'block');
            $('#cellL').css('display', 'block');
            $('#barL').css('display', 'block');
        }
        if ($('#type').val() == "Accessories") {

        }
        if ($('#type').val() == "MacBook") {
            $('#color').css('display', 'block');
            $('#member').css('display', 'block');
            $('#display').css('display', 'block');
            $('#size').css('display', 'none');
            $('#cell').css('display', 'none');
            $('#bar').css('display', 'block');

            $('#colorL').css('display', 'none');
            $('#memberL').css('display', 'none');
            $('#displayL').css('display', 'none');
            $('#sizeL').css('display', 'block');
            $('#cellL').css('display', 'block');
            $('#barL').css('display', 'none');
            //touch
        }
        if ($('#type').val() == "Watch") {
            $('#color').css('display', 'block');
            $('#member').css('display', 'none');
            $('#display').css('display', 'none');
            $('#size').css('display', 'block');
            $('#cell').css('display', 'block');
            $('#bar').css('display', 'none');

            $('#colorL').css('display', 'none');
            $('#memberL').css('display', 'block');
            $('#displayL').css('display', 'block');
            $('#sizeL').css('display', 'none');
            $('#cellL').css('display', 'none');
            $('#barL').css('display', 'block');
            //cell
        }
    }
});