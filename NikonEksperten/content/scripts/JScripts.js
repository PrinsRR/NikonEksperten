// General scripts shared on both admin and main



function uploadslide(numID, katID) {
    var formData = new FormData($('#form'+ katID)[0]);

    $.ajax({
        url: '/Admin/CMS/EditSlide/' + katID, // to get the right path to controller from TableRoutes of Asp.Net MVC
        type: "POST",
        contentType: false,
        cache: false,
        processData: false,
        data: formData,
        success: function (data) {
            $("#" + numID).parent().parent().next().attr("src", "/Content/Images/SliderBilleder/" + data);
        },
        error: function (xhr, status, error) {
            alert("Der opstod en fejl under upload");
        }
    });
}
function removeeslide(numID, katID) {
    $.ajax({
        url: '/Admin/CMS/RemoveSlide/' + katID, // to get the right path to controller from TableRoutes of Asp.Net MVC
        type: "POST",
        contentType: false,
        cache: false,
        processData: false,
        katID: katID,
        success: function (katID) {
            $("#" + numID).parent().parent().parent().parent().html("");
        },
        error: function (xhr, status, error) {
            $("#" + numID).parent().parent().parent().parent().html("");
        }
    });
}

function addslidesubmit() {
    $("#formaddslide").submit();
}