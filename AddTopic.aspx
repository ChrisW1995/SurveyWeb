<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTopic.aspx.cs" Inherits="AddTopic" %>

<%@ Register Src="~/App_Data/UserControl/AddTopicControl.ascx" TagPrefix="uc1" TagName="AddTopicControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:AddTopicControl runat="server" ID="AddTopicControl" />
</asp:Content>

