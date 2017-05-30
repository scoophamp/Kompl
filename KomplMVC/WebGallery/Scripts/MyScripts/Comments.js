
$(document).ready(function (e) {
    setInterval(loadComments, 1);
});


function loadComments() {

    var commetnContainerPhoto = $(".js-CommetnContainerPhoto");
    var commetnContainerAlbum = $(".js-CommetnContainerAlbum");

    

    commetnContainerPhoto.each(function () {
        var container = $(this);
        var photoId = container.attr("data-photoId");
        var data = { id: photoId };
        $.ajax({
            dataType: "html",
            type: "GET",
            url: "/Photo/Comment",
            data: data,
            success: function (data) {
            container.html(data);

            }
        });

    });
    commetnContainerAlbum.each(function () {
        var container = $(this);
        var albumId = container.attr("data-AlbumId");
        var data = { id: albumId };
        $.ajax({
            dataType: "html",
            type: "GET",
            url: "/Album/Comment",
            data: data,
            success: function (data) {
                container.html(data);

            }
        });

    });
}