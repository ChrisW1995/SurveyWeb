﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPage.aspx.cs" Inherits="AddPage" MaintainScrollPositionOnPostback="false"%>

<%@ Register Src="~/App_Data/UserControl/WebUserControl.ascx" TagPrefix="uc1" TagName="WebUserControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <uc1:WebUserControl runat="server" ID="SurveyController" />
    </div>
    
        
</asp:Content>

