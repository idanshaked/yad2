const getSearchedEntities = function (url,fields) {
    return new Promise(resolve => {
        $.ajax({
            type: "GET",
            url: url,
            data: fields,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (users) {
                resolve(users)
            }
        });
    })
}