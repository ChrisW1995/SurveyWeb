<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>

<link rel="stylesheet" href="../../jquery-ui.css">

  <link rel="stylesheet" href="/resources/demos/style.css">
<link rel="stylesheet" href="../../Css/GridviewCss.css" />
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<style type="text/css">
    .ui-button{ 
        font-size:13px;
        font-weight:500;
    }
</style>
<script>  
    
    $(function () {
       $("#<%=btnShowPopup.ClientID%>").click(function () {
           showPopup();
            return false;
        });
    });

    function showPopup() {
        var dialog;
        dialog = $("#dialog").dialog({
            height: 500,
            width: 1000,
            modal: true,
            draggable: false,
            buttons: {
                關閉: function () {
                    $(this).dialog("close");
                }
            }
        });
    }

</script>

<div class="css_tr">
    <div class="css_td_topic">
        <b>主題：</b>
        <asp:Label ID="lbTopic" runat="server" Text=""></asp:Label>
    </div>

    
</div>

<!--一、【課程內容滿意度】-->
<div class="css_tr">
    <div class="css_td_topic"><b>一、【課程內容滿意度】</b></div>
    <div class="css_td_topic" style="font-size: 15px;">
        全部修改
        <asp:DropDownList ID="ddl_All" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_All_SelectedIndexChanged"></asp:DropDownList>
    </div>
</div>
<div class="css_tr">
    <div class="css_td">1、課程內容之吸引人程度</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_A1" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td">2、課程內容之實用性</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_A2" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td">3、課程時數安排</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_A3" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td">4、課程內容符合期待</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_A4" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td" >5、您對於課程有無任何建議或其他意見</div>
</div>
<div class="css_tr">
    <div class="css_td">
        <asp:TextBox ID="txt_A5" runat="server" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>
    </div>   
</div>
<br />

<!--二、講師授課之滿意度-->
<div class="css_tr" style="top:30px;">
    <div class="css_td_topic"><b>二、【講師授課之滿意度】</b></div>           
</div>

<div class="css_tr">
    <div class="css_td">1、講師的授課態度</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_B1" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td">2、講師的口才表達有助於理解課程內容</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_B2" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td">3、講師具有足夠的專業知識</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_B3" runat="server"></asp:DropDownList></div>
</div>

<div class="css_tr">
    <div class="css_td">4、課程內容符合期待</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_B4" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td" >5、講師對課程進度的時間掌控</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_B5" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td" >6、您對於講師有無任何建議或其他意見</div>
</div>
<div class="css_tr">
     <div class="css_td">
        <asp:TextBox ID="txt_B6" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox></div>
</div>
<br />

<!--三、整體教學環境方面-->
<div class="css_tr" style="top:30px;">
    <div class="css_td_topic"><b>三、【整體教學環境方面】</b></div>           
</div>
<div class="css_tr">
    <div class="css_td" >1、現場報到與接待流程的安排</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_C1" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td" >2、教學設備與器材(投影機、麥克風等)</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_C2" runat="server"></asp:DropDownList></div>
</div>
<div class="css_tr">
    <div class="css_td" >3、教學環境及設施(場地、桌椅、燈光、清潔等)</div>
    <div class="css_td_ans">
        <asp:DropDownList ID="ddl_C3" runat="server"></asp:DropDownList></div>
</div>
<br />

<!--四、其他-->
<div class="css_tr" style="top:30px;">
    <div class="css_td_topic"><b>四、【其他】</b></div>           
</div>
<div class="css_tr">
    <div class="css_td" >1、您從哪些管道得知本次教育訓練呢?</div>
</div>
<div class="css_tr">
     <div class="css_td" style="display:table-row-group;">
       
         <asp:Panel ID="chk_Panel" runat="server" HorizontalAlign="Left">
             <asp:CheckBox ID="CheckBox1" runat="server" Text="文大Fun心學FB官方粉絲團" Value="1"/>
             <asp:CheckBox ID="CheckBox2" runat="server" Text="文大Fun心學Line官方帳號" value="2"/><br />
             <asp:CheckBox ID="CheckBox3" runat="server" Text="校園活動報名系統" value="3"/>
             <asp:CheckBox ID="CheckBox4" runat="server" Text="學校公告" value="4"/>
             <asp:CheckBox ID="CheckBox5" runat="server" Text="E-mail" value="5"/><br />
             <asp:CheckBox ID="CheckBox6" runat="server" Text="朋友介紹" value="6"/>
             <asp:CheckBox ID="CheckBox7" runat="server" Text="華夏報導" value="7"/>
             <asp:CheckBox ID="CheckBox8" runat="server" Text="其他" AutoPostBack="true" value="8" OnCheckedChanged="CheckBox8_CheckedChanged"/><asp:TextBox Enabled="false" ID="txt_Else" runat="server" ></asp:TextBox><br />
             <asp:CheckBox ID="CheckBox9" runat="server" Text="校園張貼海報" AutoPostBack="true" value="9" OnCheckedChanged="CheckBox9_CheckedChanged"/>（地點：<asp:TextBox Enabled="false" ID="txtPosLocation" runat="server" ></asp:TextBox>）
         </asp:Panel>
     </div>
</div>
    
<br />

<div class="css_tr">
    <div class="css_td">2、您希望資訊中心可以再開哪些關於能力相關的教育訓練呢?</div>
</div>
<div class="css_tr">
     <div class="css_td">
        <asp:TextBox ID="txt_D2" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox></div>
</div>

<div class="css_tr">
    <div class="css_td">
       <asp:Button class="ui-button ui-corner-all ui-widget" ID="btn_Add" runat="server" Text="新增"  OnClick="btn_Add_Click" />
    <asp:Button ID="btnShowPopup" runat="server" Text="查看資料" class="ui-button ui-corner-all ui-widget"  OnClick="btnShowPopup_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
</div>
<br />

<div id="dialog" title="查看資料" style="display:none;">
    <asp:GridView  ClientIDMode="Static" ID="GridView1" CssClass="mydatagrid" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging1" OnDataBound="GridView1_DataBound" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" PageSize="8" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtID" Text="" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="主題ID">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTopicID" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbTopicID" Text='<%# Eval("TopicID") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A_1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbA1" Text='<%# Eval("A_1") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A_2">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbA2" Text='<%# Eval("A_2") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A_3">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbA3" Text='<%# Eval("A_3") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A_4">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbA4" Text='<%# Eval("A_4") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="A_5">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbA5" Text='<%# Eval("A_5") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB1" Text='<%# Eval("B_1") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_2">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB2" Text='<%# Eval("B_2") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_3">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB3" Text='<%# Eval("B_3") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_4">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB4" Text='<%# Eval("B_4") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_5">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB5" Text='<%# Eval("B_5") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B_6">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbB6" Text='<%# Eval("B_6") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C_1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbC1" Text='<%# Eval("C_1") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C_2">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbC2" Text='<%# Eval("C_2") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="C_3">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbC3" Text='<%# Eval("C_3") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="如何得知">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbD_1_TypeID" Text='<%# Eval("D_1_TypeID") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="其他意見">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="D_2" Text='<%# Eval("D_2") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="海報地點">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbPosterLocation" Text='<%# Eval("PosterLocation") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="其他">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbD1_Else" Text='<%# Eval("D1_Else") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="70px" />
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle ForeColor="Black" Width="40px" />
            </asp:TemplateField>
            
        </Columns>
       
<HeaderStyle CssClass="header"></HeaderStyle>

        <PagerStyle CssClass="pager" />

<RowStyle CssClass="rows"></RowStyle>
       
    </asp:GridView>
    <hr style="height:0.5px; background-color:rgba(66, 65, 65, 0.67); display:block; margin-top:20px;""/>
</div>