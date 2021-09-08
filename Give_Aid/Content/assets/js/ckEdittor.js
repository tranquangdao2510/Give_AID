$(document).ready(function () {
    CKEDITOR.replace("conTent");
    $('#selectImg').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#linkImg').val(url);
        };
        finder.popup();
    });
    CKEDITOR.replace("conTent1");

})