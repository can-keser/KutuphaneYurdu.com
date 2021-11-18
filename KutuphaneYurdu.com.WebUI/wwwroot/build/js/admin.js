var deleteURL = "";
var deleteReturnURL = "";

$(".hoverPicture").mouseover(function () {
    $(".kResim").show();
    $(".kResim").attr("src", $(this).attr("picture"));
    $(".kResim").css("top", $(this).offset().top-80);
})

function deleteSlideRecord(id) {
    deleteURL = "/admin/slide/delete?_id=" + id;
    deleteReturnURL="/admin/slide/index"
    $("#deleteModal").modal('show');
}

function deleteCategoryRecord(id) {
    deleteURL = "/admin/category/delete?_id=" + id;
    deleteReturnURL = "/admin/category/index"
    $("#deleteModal").modal('show');
}

function deleteBrandRecord(id) {
    deleteURL = "/admin/yazar/delete?_id=" + id;
    deleteReturnURL = "/admin/yazar/index"
    $("#deleteModal").modal('show');
}

function deleteBookRecord(id) {
    deleteURL = "/admin/book/delete?_id=" + id;
    deleteReturnURL = "/admin/book/index"
    $("#deleteModal").modal('show');
}

function deleteRecord() {

    $.ajax({
        type: "GET",
        url: deleteURL,
        success: function (data) {
            if (data != "") {
                $("#deleteModal").modal('hide');
                setTimeout(function () { location.href = deleteReturnURL}, 500);
            }
            else alert("hata oluştu...");
        },
        error: function (error) { alert(error.responseText) }
    });
}