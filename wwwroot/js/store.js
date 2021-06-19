function loadMap() {
    const map = new Microsoft.Maps.Map(document.getElementById('map'), {
        credentials: 'ApuCycJr1Nj2E8XCyNgrPLfogKZjB7vguFf3VTXFjqgR9pcvU_8GWQLs5OReJuE6',
    });
    map.setView({
        mapTypeId: Microsoft.Maps.MapTypeId.road,
        center: new Microsoft.Maps.Location(32.100000, 34.788052),
        zoom: 10
    });

    $.ajax({
        type: 'GET',
        url: '/stores/All',
        async: true,
        success: function (stores) {
            stores.forEach(store => addLocationToMap(map, store));
        },
        error: function (response) {
            alert("Error on getting all locations");
            console.log(response);
        }
    });
}

const addLocationToMap = (map, store) => {
    const pushPin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(store.lat, store.lng), { color: 'blue' });
    pushPin.setOptions({ enableHoverStyle: true });
    pushPin.metadata = {
        id: store.storeId,
        title: store.storeName,
        description: store.description,
        address: store.address
    };

    map.entities.push(pushPin);

    const infoboxTemplate = '<div class="customInfobox" style="background-color:lightgray;":relative;"><div>{title}</div><br>{description}<br>{address}</div>  ';

    const infobox = new Microsoft.Maps.Infobox(pushPin.getLocation(), {
        visible: false
    });

    infobox.setMap(map);

    const showInfobox = e => {
        if (e.target.metadata) {
            infobox.setOptions({
                location: e.target.getLocation(),
                htmlContent: infoboxTemplate.replace('{title}', e.target.metadata.title).replace('{description}', e.target.metadata.description).replace('{address}', e.target.metadata.address),
                visible: true
            });
        }
    }
    const hideInfobox = e => {
        infobox.setOptions({ visible: false });
    }


    Microsoft.Maps.Events.addHandler(pushPin, 'mouseout', hideInfobox);
    Microsoft.Maps.Events.addHandler(pushPin, 'click', showInfobox);
};