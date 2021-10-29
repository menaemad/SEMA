var id;
$(".AddUser").click(function () {
    id = $(this).attr("id");
    $("input[name=EventId]").val($(this).attr("id"));
    $("#exampleModal").modal('show');
});

$("#UserEventForm").submit(function (e) {
    e.preventDefault();
    frm = $($(this)[0]).serialize();
    $.ajax({
        type: "Post",
        url: $($(this)[0]).attr('action'),
        data: frm,

    }).done(function (data) {
        if (data.success) {
            var val = $("#NomberOfUser_" + id).text();
            $("#NomberOfUser_" + id).text(parseInt(val) + 1);
        }
        toastr.info(data.message);
        $("#exampleModal").modal('hide');

    });


});