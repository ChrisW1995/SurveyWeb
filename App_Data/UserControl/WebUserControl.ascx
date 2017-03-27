<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>

<link rel="stylesheet" href="../../jquery-ui.css">

  <link rel="stylesheet" href="/resources/demos/style.css">
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
        var dialog;

        dialog = $("#dialog").dialog({
            autoOpen: false,
            height: 400,
            width: 350,
            modal: true,          
            draggable: false,
            buttons: {               
                關閉: function () {
                    dialog.dialog("close");
                }
            }
            
        });


        $("#<%=btnShowPopup.ClientID%>").button().on("click", function () {
            dialog.dialog("open");
        });
    });



</script>

<!--一、【課程內容滿意度】-->
<div class="css_tr">
    <div class="css_td_topic"><b>一、【課程內容滿意度】</b></div>   
    <div class="css_td_topic" style="font-size:15px;">
         全部修改 <asp:DropDownList ID="ddl_All" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_All_SelectedIndexChanged"></asp:DropDownList></div>
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
             <asp:CheckBox ID="CheckBox8" runat="server" Text="其他" value="8"/><asp:TextBox ID="txt_Else" runat="server" ></asp:TextBox><br />
             <asp:CheckBox ID="CheckBox9" runat="server" Text="校園張貼海報" value="9"/>（地點：<asp:TextBox ID="txtPosLocation" runat="server" ></asp:TextBox>）
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
    <asp:Button ID="btnShowPopup" runat="server" Text="查看資料"  OnClientClick="return false" /></div>
</div>
<br />

<div id="dialog">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
        PageSize="2" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" ItemStyle-Width="80" />
            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
</div>