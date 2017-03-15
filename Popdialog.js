$(function () {
    $("[id*=btnShowPopup]").click(function () {
        ShowPopup();
        return false;
    });
});
function ShowPopup() {
    $("#dialog").dialog({
        title: "GridView",
        width: 450,
        buttons: {
            Ok: function () {
                $(this).dialog('close');
            }
        },
        modal: true
    });
}