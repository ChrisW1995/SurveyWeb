$(function () {
    $("#<%=datepicker.ClientID%>").datepicker({
        dateFormat: 'yy-mm-dd',
        showButtonPanel: true
    });
});
function CheckTopic() {
    if (document.getElementById("txtTopic").value == "") {
        alert('請輸入主題');
        document.getElementById("<%=txtTopic.ClientID%>").focus();
        return false;
    }
}