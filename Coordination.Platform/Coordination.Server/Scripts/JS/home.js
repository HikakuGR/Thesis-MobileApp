$(document).ready(function () {
    updateMarkers();
});

function updateMarkers() {
    setTimeout(updateMarkers, 30000);
    //TODO
    //AJAX Call & updateMarkers
    $.ajax({
        type: "POST",
        url: "GetMarkers",
        data: param = "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onUpdateMarkersAjaxSuccess,
        error: onUpdateMarkersAjaxError
    });
}
function onUpdateMarkersAjaxSuccess(data,status) {
    //TODO
}
function onUpdateMarkersAjaxError(data, status) {
    //TODO
}