<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTopic.aspx.cs" Inherits="AddTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="css_tr">
    <div class="css_td"><b>主題：</b><asp:TextBox ID="txtTopic" runat="server"></asp:TextBox></div>   
    </div>
<div class="css_tr">
    <div class="css_td"><b>開課時間：</b><asp:TextBox ID="datepicker" runat="server"></asp:TextBox></div>   
    </div>
    <br />
    <div class="css_tr">
        <div class="css_td">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TopicID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="TopicID" HeaderText="TopicID" InsertVisible="False" ReadOnly="True" SortExpression="TopicID" />
                    <asp:BoundField DataField="TopicName" HeaderText="TopicName" SortExpression="TopicName" />
                    <asp:BoundField DataField="TopicTime" HeaderText="TopicTime" SortExpression="TopicTime" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WifiDataConnectionString %>" SelectCommand="SELECT * FROM [Topic]"></asp:SqlDataSource>
</asp:Content>

