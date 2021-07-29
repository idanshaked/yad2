const validateUser = (user) => {
    const { Password, Phone, Email } = user;
    const invalidFields = []
    if (!Password) {
        invalidFields.push("Password")
    }
    if (!Phone || !(/^05\d{8}/).test(Phone)) {
        invalidFields.push("phone")
    }
    if (!Email) {
        invalidFields.push("mail")
    }
    return invalidFields;
}

$('#details').click(function () {
    var url = $('#detailsModal').data('url');

    $.get(url, function (data) {
        $('#detailsContent').html(data);

        $('#detailsModal').modal('show');
    });
});

$('#createBtn').click(function () {
    var url = $('#createModal').data('url');

    $.get(url, function (data) {
        $('#createContent').html(data);

        $('#createModal').modal('show');
    });
});

$(".table").on('click', '.deleteBtn', function (event) {
    var url = $('#deleteModal').data('url');
    $.ajax({
        url: url,
        type: 'get',
        data: {
            id: event.target.dataset.user
        },
        success: function (data) {
            $('#deleteContent').html(data);

            $('#deleteModal').modal('show');
        }
    });
})

$(".table").on("click", ".Edit", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            if (!$(this).hasClass("username")) {
                $(this).find("input").show();
                $(this).find("span").hide();
            }
        }
    });
    row.find(".Update").show();
    row.find(".cancel").show();
    row.find(".deleteBtn").hide();
    $(this).hide();
});

$(".table").on("click", ".cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            if ($(this).hasClass('isAdmin')) {
                input = $(this).find('#editable')
                if (!span.find("#realValue")[0].checked) {
                    $(this).find("#editable").prop('checked', false)
                } else {
                    $(this).find("#editable").prop('checked', true)
                }
            } else {
                input.val(span.data('val'));
            }
            input.hide();
            span.show();
        }
    });
    row.find(".Edit").show();
    row.find(".deleteBtn").show();
    row.find(".Update").hide();
    $(this).hide();
});