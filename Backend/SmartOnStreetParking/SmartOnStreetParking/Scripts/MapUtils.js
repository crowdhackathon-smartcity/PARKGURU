/*
    coordType 1: polygon 2:line
*/
function initMap(coordString, coordType, mapContainer, ModelId, ModelName) {
    geocoder = new google.maps.Geocoder();
    var map = new google.maps.Map(mapContainer,
    {
        zoom: 2,
        center: { lat: 16.7639015, lng: 13.2240933 },
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        streetViewControl: false,
        mapTypeControl: true
    });

    if (coordString!=="" && coordType!==-1) {
        if (coordType === 1) {
            ConstructPolygon(JSON.parse(coordString), ModelId, '', ModelId, ModelName)
        }
        else if (coordType === 2) {
            ConstructPolyline(JSON.parse(coordString), ModelId, '', ModelId, ModelName);
        }
    }
    else {
        //codeAddress(document.getElementById('Address').value);
        //getSearchAddressData();
    }

    return map;


    function ConstructPolygon(coordRA, id, PolygonColor, zoneID, ZoneName) {
        var xx = 'p' + id;
        var color = getZoneColor();
        var xx1 = new google.maps.Polygon({
            paths: coordRA,
            strokeColor: color,
            strokeOpacity: 1,
            strokeWeight: 3,
            fillColor: color,
            fillOpacity: 0.4,
            indexID: id,
            zoneID: zoneID,
            ZoneName: ZoneName,
            editable: false
        })

        if (!google.maps.Polygon.prototype.getBounds) {

            google.maps.Polygon.prototype.getBounds = function () {
                var bounds = new google.maps.LatLngBounds()
                this.getPath().forEach(function (element, index) { bounds.extend(element) })
                return bounds
            }

        }

        var cnt = xx1.getBounds().getCenter();
        map.setCenter(cnt);
        xx1.setMap(map);
        map.fitBounds(xx1.getBounds());

        //addListenersOnPolygon(xx1);

        //deleteListenersOnPolygon(xx1);

        xx1.addListener('rightclick', function (xx1) {
            if (xx1.vertex != null && this.getPath().getLength() > 0) {
                this.getPath().removeAt(xx1.vertex);
            }
            else {
                ConfirmDeleteSelectedPolygon();
            }
        });

        gPolygon = xx1;
        //gPolygon = new Polygon(coordRA, map, new Pen(map), '#ff0000')


    }

    function ConstructPolyline(coordRA, id, PolygonColor, zoneID, ZoneName) {
        var color = getZoneColor();
        var xx = 'p' + id;
        var xx1 = new google.maps.Polyline({
            path: coordRA,
            strokeColor: color,
            strokeOpacity: 1,
            strokeWeight: 3,
            indexID: id,
            zoneID: zoneID,
            ZoneName: ZoneName,
            editable: false
        })

        var bounds = new google.maps.LatLngBounds();
        var points = xx1.getPath().getArray();
        for (var n = 0; n < points.length ; n++) {
            bounds.extend(points[n]);
        }
        bounds.getCenter();
        map.fitBounds(bounds);
        xx1.setMap(map);

        //addListenersOnPolygon(xx1);

        //deleteListenersOnPolygon(xx1);

        xx1.addListener('rightclick', function (xx1) {
            if (xx1.vertex != null && this.getPath().getLength() > 0) {
                this.getPath().removeAt(xx1.vertex);
            }
            else {
                ConfirmDeleteSelectedPolygon();
            }
        });

        gPolygon = xx1;
    }


    //initSearchPlaces('searchInput', map);
    //creator = new PolygonCreator(map);

}


function resetMap(m) {
    x = m.getZoom();
    c = m.getCenter();
    google.maps.event.trigger(m, 'resize');
    m.setZoom(x);
    m.setCenter(c);
};

function centerOnLocation(mapObject){
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function(position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

        
            mapObject.setCenter(pos);
        },
        function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    }
    else {
        // Browser doesn't support Geolocation
        //handleLocationError(false, infoWindow, map.getCenter());
    }
}

function initAutocomplete(id, map) {

    // Create the search box and link it to the UI element.
    var input = document.getElementById(id);
    var searchBox = new google.maps.places.SearchBox(input);
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Bias the SearchBox results towards current map's viewport.
    map.addListener('bounds_changed', function () {
        searchBox.setBounds(map.getBounds());
    });

    var markers = [];
    // Listen for the event fired when the user selects a prediction and retrieve
    // more details for that place.
    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) {
            return;
        }

        // Clear out the old markers.
        markers.forEach(function (marker) {
            marker.setMap(null);
        });
        markers = [];

        // For each place, get the icon, name and location.
        var bounds = new google.maps.LatLngBounds();
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }
            var icon = {
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25)
            };

            // Create a marker for each place.
            markers.push(new google.maps.Marker({
                map: map,
                icon: icon,
                title: place.name,
                position: place.geometry.location
            }));

            if (place.geometry.viewport) {
                // Only geocodes have viewport.
                bounds.union(place.geometry.viewport);
            } else {
                bounds.extend(place.geometry.location);
            }
        });
        map.fitBounds(bounds);
    });
}

function PointCreator(map) {
    //create pen to draw on map
    this.map = map;
    this.pen = new Pen(this.map);
    var thisOjb = this;
    var marker = null;

    this.event = google.maps.event.addListener(thisOjb.map, 'click', function (event) {
        if (marker != null) {
            marker.setMap(null);
        }
            marker = new google.maps.Marker({
                position: event.latLng,
                map: map,
                title: ''
            });

                
    });

    this.showData = function () {
        var returnData = [];
        var dataObj = {};
        if (marker != null) {
            dataObj["lat"] = marker.getPosition().lat();
            dataObj["lng"] = marker.getPosition().lng();
            returnData.push(dataObj);
        }
        return returnData;
    }

    this.showColor = function () {
        return "";
    }

    this.set = function (coordinates) {
        if (marker != null) {
            marker.setMap(null);
        }
        marker = new google.maps.Marker({
            position: coordinates,
            map: map,
            title: ''
        });

    }

    //destroy the pen
    this.destroy = function () {
        if (marker != null) {
            marker.setMap(null);
        }
        google.maps.event.removeListener(this.event);
    }
}

function getImage(mapData, imageType, imageContainer, size) {
	var mapUrl = 'https://maps.googleapis.com/maps/api/staticmap?key=AIzaSyBW2DhYWHrIk87gfJZr0gnnYTm2GqcebtY&';
	var streetUrl = 'https://maps.googleapis.com/maps/api/streetview?key=AIzaSyBW2DhYWHrIk87gfJZr0gnnYTm2GqcebtY&';
    var imageUrl;
    var imageSize;

    if (size == null || size == "") {
        imageSize= "500x300";
    }
    else {
        imageSize = size;
    }

    
    if (imageType == 1) {
        imageUrl = mapUrl;

        if (typeof(mapData[0].lat)!='undefined')
            imageUrl = imageUrl + "size=" + imageSize + "&zoom=11&markers=color:red|" + mapData[0].lat + "," + mapData[0].lng;
        else
            imageUrl = imageUrl + "size=" + imageSize + "&zoom=11&markers=color:red|" + mapData[0].Latitude + "," + mapData[0].Longitude;

        $('#' + imageContainer).html('<img src="' + imageUrl + '" class="img-responsive">');
    }
    else if (imageType == 2) {
        imageUrl = streetUrl;
        if (typeof (mapData.lat) != 'undefined')
            imageUrl = imageUrl + "size=" + imageSize + "&location=" + mapData.lat + "," + mapData.lng + "&heading=" + mapData.heading + "&pitch=" + mapData.pitch;
        else
            imageUrl = imageUrl + "size=" + imageSize + "&location=" + mapData.Latitude + "," + mapData.Longitude + "&heading=" + mapData.heading + "&pitch=" + mapData.pitch;

        $('#' + imageContainer).html('<img src="' + imageUrl + '" class="img-responsive">');
    }
}

function clearImage(imageContainer) {
    $('#' + imageContainer).html('');
}
/*
#############################################################################################
StreetView
#############################################################################################
*/


function initStreetViewMap(cnt, mapContainer, streetData, navMap) {
    var cntMap;
    var myheading;
    var mypitch;

    if (streetData != null && streetData != "") {
        streetData = JSON.parse(streetData.replace(/&quot;/g, '"'));
        var jsonStrData = JSON.stringify(streetData);
        var jsonData = JSON.parse(jsonStrData);

        cntMap = { lat: jsonData.lat, lng: jsonData.lng };
        myheading = jsonData.heading;
        mypitch = jsonData.pitch;
    }

   // '{"lat":38.0758592071883,"lng":23.812580961797266,"pitch":-11.90627294467123,"zoom":1.4422223286050743,"heading":1.5550387387646651}'


    markerColor = 'http://maps.google.com/mapfiles/ms/icons/green-dot.png';

    var panorama = new google.maps.StreetViewPanorama(
      mapContainer, {
          position: cntMap,          
          pov: {
              heading: myheading,
              pitch: mypitch
          }
      });

   // navMap.setStreetView(panorama);
    if (navMap != null) {
        navMap.addListener('click', function (event) {
            markerColor = 'http://maps.google.com/mapfiles/ms/icons/red-dot.png';


            panorama.setPosition({lat: event.latLng.lat(), lng: event.latLng.lng()});
    //        sv.getPanorama({ location: event.latLng, radius: 50 }, processSVData);
        });
    }


    panorama.setVisible(true);
    return panorama;
}
