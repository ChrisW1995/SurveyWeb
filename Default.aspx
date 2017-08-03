<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/App_Data/UserControl/TopicLst.ascx" TagPrefix="uc1" TagName="TopicLst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="build/jquery.datetimepicker.full.js"></script>
    <script>
        $(function () {
            $("#<%=datepicker.ClientID%>").datetimepicker({
        format: 'Y-m-d H:00'
    });
    $("#<%=datepicker2.ClientID%>").datetimepicker({
            format: 'Y-m-d H:00'
        });
        });
    </script>
    <link rel="stylesheet" type="text/css" href="./jquery.datetimepicker.css" />
    <link rel="stylesheet" href="../../jquery-ui.css">

    <div class="container">


        <div class="form-horizontal">
            <div class="form-group">
                <label for="txtSearchTopic" class="control-label  col-md-offset-1 col-md-2" style="text-align: right;">主題：</label>
                <div class="col-md-2">
                    <asp:TextBox ID="txtSearchTopic" runat="server" class="form-control" Wrap="False"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">

                <label for="datepicker" class="control-label  col-md-offset-1 col-md-2" style="text-align: right;">起始時間</label>
                <div class="col-md-2">
                    <asp:TextBox ID="datepicker" runat="server" class="form-control" Wrap="False"></asp:TextBox>
                </div>
                <div class="form-inline">
                    <label for="txtSearchTopic" class="control-label col-md-1" style="text-align: left;">結束時間</label>
                    <div class="col-md-2">
                        <asp:TextBox ID="datepicker2" runat="server" class="form-control" Wrap="False"></asp:TextBox>
                    </div>
                </div>

            </div>

            
        </div>
       <div class=" col-md-2  col-md-offset-5">
                <asp:Button class=" btn btn-primary btn-block center-block" ID="btnSearchTopic" runat="server" Text="搜尋" OnClick="btnSearchTopic_Click" />
            </div>
    </div>
     

    <%--  <div class="row form-inline">
        <div class="col-sm-offset-2 form-group col-md-3">
            <label for="txtSearchTopic">主題：</label>
            <asp:TextBox ID="txtSearchTopic" runat="server" class="form-control" Wrap="False"></asp:TextBox>
        </div>
        <asp:Button class=" btn btn-primary col-md-1" ID="btnSearchTopic" runat="server" Text="搜尋" OnClick="btnSearchTopic_Click" />
    </div>

    <div class="row form-inline">
        <div class="col-sm-offset-2 form-group col-md-3">
            <label for="txtSearchTopic">時間範圍：</label>
            <asp:TextBox ID="datepicker" runat="server" class="form-control" Wrap="False"></asp:TextBox>
        </div>
    </div>--%>


    <%--<div class="row form-inline">
        <div class="col-sm-offset-2 form-group col-md-3">
            <label for="txtStartTime"class ="col-md-2">時間範圍：</label>
            <asp:TextBox ID="datepicker" runat="server" class="form-control col-md-4" Wrap="False"></asp:TextBox>
        </div>
    </div>--%>

    <br />
    <div class="container">
        <div class="row">
            <asp:ListView ID="lv_TopicLst" runat="server" OnPagePropertiesChanging="lv_TopicLst_PagePropertiesChanging">
                <LayoutTemplate>
                    <table class="table table-striped">
                        <tr>
                           
                            <th width="80px;"></th>
                            <th>課程名稱</th>
                            <th>課程時間</th>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>

                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <asp:CheckBox ID="chkTopic" runat="server" />
                            <asp:Label ID="lbTopicID" runat="server" Text='<% #Eval("TopicID") %>' Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbTopicName" runat="server" Text='<% #Eval("TopicName") %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="lbTopicTime" runat="server" Text='<% #Eval("TopicTime") %>'></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

            <div class="container-fluid" >
                <div class="row" style="float: right;">
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lv_TopicLst" PageSize="15">
                        <Fields>
                            <asp:NextPreviousPagerField
                                ShowPreviousPageButton="true" ShowNextPageButton="False" ButtonCssClass="datapagerStyle" />
                            <asp:NumericPagerField ButtonCount="7" CurrentPageLabelCssClass="datapagerStyle" NumericButtonCssClass="datapagerStyle" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowPreviousPageButton="False" ButtonCssClass="datapagerStyle" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>

            <div class="container-fluid" style="margin-top:15px;">
                <div class="row" style="float: right;">
                    <div>
                        <asp:Button ID="btnExport" runat="server" Text="勾選匯出" class="btn btn-success" OnClick="btnExport_Click"/>
                        <asp:Button ID="btnExportAll" runat="server" Text="全部匯出" class="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

