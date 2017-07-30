﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddTopicControl.ascx.cs" Inherits="AddTopicControl" %>


<script src="./jquery.js"></script>
<script src="build/jquery.datetimepicker.full.js"></script>
<link rel="stylesheet" href="../../Css/gridviewCss.css" type="text/css" />
<link rel="stylesheet" type="text/css" href="./jquery.datetimepicker.css"/>
<link rel="stylesheet" href="../../jquery-ui.css">
<script>
$(function () {
        $("#<%=datepicker.ClientID%>").datetimepicker({
            format: 'Y-m-d H:00'
        });
});
</script>
<script type="text/javascript">
    function checkTopic() {
        var txtTopic = document.getElementById('<%=txtTopic.ClientID%>').value;
        var txtdatetime = document.getElementById('<%=datepicker.ClientID%>').value;
        if (txtTopic.length == 0 || txtdatetime.length ==0) {           
            alert('請確定已輸入主題與正確之開課時間！');
            return false;           
        }
        else {
            return true;
        }
    }
</script>


<div class="css_tr">
    <div class="css_td"><b>主題：</b><asp:TextBox ID="txtTopic" runat="server"></asp:TextBox></div>   
    </div>
<div class="css_tr">
    <div class="css_td"><b>開課時間：</b><asp:TextBox ID="datepicker" runat="server"></asp:TextBox></div>   
    </div>
    <br />
    <div class="css_tr">
        <div class="css_td">
            <asp:GridView ID="datagrid" AutoGenerateColumns="False" CssClass="mydatagrid" RowStyle-CssClass="rows" AllowPaging="True" HeaderStyle-CssClass="header" PagerStyle-CssClass="pager" runat="server" PageSize="8" OnRowDeleting="datagrid_RowDeleting" OnRowCommand="datagrid_RowCommand" OnPageIndexChanging="datagrid_PageIndexChanging" OnRowCreated="datagrid_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="課程名稱">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Black" Text='<%# Bind("TopicName") %>' NavigateUrl='<%# string.Format("~/AddPage.aspx?id={0}", Eval("TopicID")) %>'></asp:HyperLink>
                            <asp:HiddenField ID="hf" runat="server" Value='<%# Bind("TopicID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="開課時間">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TopicTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" >
                    <ControlStyle CssClass="ui-button" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="header" />
                <PagerStyle CssClass="pager" />
                <RowStyle CssClass="rows" />
            </asp:GridView>
        </div>
    </div>

<div class="css_tr">
    <div class="css_td">
        <asp:Button class="ui-button" ID="btnAddTopic" runat="server" Text="新增主題" OnClientClick="if(!checkTopic())return false;" OnClick="btnAddTopic_Click" /></div>   
    </div>
   
