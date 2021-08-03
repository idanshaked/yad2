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

const handleCreate = () => {
    var url = $('#createModal').data('url');

    $.get(url, function (data) {
        $('#createContent').html(data);

        $('#createModal').modal('show');
    });
}

const handleDelete = () => {
    var url = $('#deleteModal').data('url');
    $.ajax({
        url: url,
        type: 'get',
        data: {
            id: event.target.dataset.store
        },
        success: function (data) {
            $('#deleteContent').html(data);

            $('#deleteModal').modal('show');
        }
    });
}

const handleEdit = (event) => {
    var row = event.target.closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    $(row).find(".Update").show();
    $(row).find(".cancel").show();
    $(row).find(".deleteBtn").hide();
    $(row).find(".Edit").hide();
};

const handleCancel = (event) => {
    var row = event.target.closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.data('val'));
            input.hide();
            span.show();
        }
    });
    $(row).find(".Edit").show();
    $(row).find(".deleteBtn").show();
    $(row).find(".Update").hide();
    $(row).find(".cancel").hide();
};

const validateStore = (store) => {
    const { storeName, address, Description } = store;
    const invalidFields = []
    if (!storeName) {
        invalidFields.push("storeName")
    }
    if (!address) {
        invalidFields.push("address")
    }
    if (!Description) {
        invalidFields.push("Description")
    }
    return invalidFields;
}