var markers = new Array();

function createMarker(map, title, latitude, longitude,markerID) {
    // creating a marker
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map,
        title: title
        
    });
    marker["markerID"] = markerID;
    markers.push(marker);    
}
function initMap(map_ID, latitude, longitude) {
    map = new google.maps.Map(document.getElementById(map_ID), {
        zoom: 5,
        center: new google.maps.LatLng(latitude, longitude),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    infoWindow = new google.maps.InfoWindow();
    return map;
}
function updateMarker(map, newTitle, newLat, newLong, markerID) {
    //TODO
}
function removeMarker(map, markerID) {
    //TODO
}
