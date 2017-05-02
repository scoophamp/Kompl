$(document).ready(function () {
    var pictureForms = $(".PictureForm");

    pictureForms.submit(function (e) {
        var form = $(this);
        e.preventDefault();


        setTimeout(function () {

        }, 1000);


        $.ajax({
            method: "POST",
            url: form.attr('action'),
            data: new FormData(form[0]),
            dataType: "html",
            beforeSend: function () {

            },
            success: function (data) {

                form[0].reset();
                $("#PhotoContainer").html(data);
            },
            complete: function () {
                setTimeout(hideSpinner, 1000);
            },
            processData: false,
            contentType: false
        });
    });
})