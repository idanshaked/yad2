const getSearchedUsers = function (fields) {
    return new Promise(resolve => {
        $.ajax({
            type: "GET",
            url: "/Users/Search/",
            data: fields,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (users) {
                resolve(users)
            }
        });
    })
}