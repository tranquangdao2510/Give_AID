var donateController = {
    init: function () {
        donateController.registerEvent();
    },

    registerEvent: function () {
        $('.btn-activer').off('click').on('click', function (e) {
            e.preventDefault();
            var id = parseInt($(this).data('id'));
            var btn= $(this)
            $.ajax({
                url: "/Admins/Donate/ChangeStatus",
                data: { id: id },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Completed');
                    } else {
                        btn.text('Unfinished');
                    }
                }
            });
        })
    }
}

donateController.init();