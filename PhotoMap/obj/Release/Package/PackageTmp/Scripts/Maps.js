function Initialize() {

    google.maps.visualRefresh = true;
    var Sweden = new google.maps.LatLng(55.605, 13.0038);
    var mapOptions = {
        zoom: 12,
        center: { lat: 55.605, lng: 13.0038 },
        mapTypeId: google.maps.MapTypeId.ROADMAP,
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);


    var autocomplete = new google.maps.places.Autocomplete(document.getElementById("txtautocomplete"));
    //autocomplete.bindTo('bounds', map);
    var Latitude = document.getElementById("latitude");
    var Longitude = document.getElementById("longitude");
    google.maps.event.addListener(autocomplete, 'place_changed', function () {

        var place = autocomplete.getPlace();
        var location = "Address: " + place.formatted_address + "<br/>";
        location += "Latitude: " + place.geometry.location.lat() + "<br/>";
        location += "Longitude: " + place.geometry.location.lng();

        Latitude.value = place.geometry.location.lat();
        Longitude.value = place.geometry.location.lng();

        document.getElementById('lblresult').innerHTML = location;


        var marker;
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(Latitude.value, Longitude.value),
            map: map,
        });
        marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png');
        map.setZoom(15);
        map.setCenter(marker.getPosition());
    });
};