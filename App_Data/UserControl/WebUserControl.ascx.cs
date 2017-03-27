using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class WebUserControl : System.Web.UI.UserControl
{
    DataTable dt;
    string GroupID;
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable _dt = new DataTable();
        _dt.Columns.AddRange(new DataColumn[] {
            new DataColumn ("CustomerId"),
            new DataColumn ("Name")
        });
        _dt.Rows.Add("11","aaa");
        GridView1.DataSource = _dt;
        GridView1.DataBind();

        if (!IsPostBack)
        {
            //GenerateChkValue();
            dt = new DataTable();
            dt = NewDataTable();
            Session["table"] = dt;
            generalScore();
            GroupID = DateTime.Now.ToString("yyyyMMddHHmmss");               
        } 
    }
    
    protected DataTable NewDataTable()
    {
        DataTable _newdt = new DataTable();
        _newdt.Columns.AddRange(new DataColumn[] {
            new DataColumn ("TopicID"),     
            new DataColumn ("A_1"),
            new DataColumn ("A_2"),
            new DataColumn ("A_3"),
            new DataColumn ("A_4"),
            new DataColumn ("A_5"),
            new DataColumn ("B_1"),
            new DataColumn ("B_2"),
            new DataColumn ("B_3"),
            new DataColumn ("B_4"),
            new DataColumn ("B_5"),
            new DataColumn ("B_6"),
            new DataColumn ("C_1"),
            new DataColumn ("C_2"),
            new DataColumn ("C_3"),
            new DataColumn ("D_1_TypeID"),
            new DataColumn ("D_2"),
            new DataColumn ("PosterLocation"),
            new DataColumn ("D1_Else")           
        });
        return _newdt;
    }
    protected void BindGrid()
    {

        string conStr = ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(conStr))
        {
            string commandStr = "SELECT * FROM Content";
            using (SqlDataAdapter adapter = new SqlDataAdapter(commandStr, conn))
            {
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
    }
    void generalScore()
    {
        foreach(Control ctrl in this.Controls)
        {
            if(ctrl is DropDownList)
            {
                for(int i = 5; i>0; i--)
                {
                    ((DropDownList)ctrl).Width = 50;
                   ((DropDownList)ctrl).Items.Add(new ListItem(i.ToString(),i.ToString()));
                }
                
            }
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        DataTable dt = ((DataTable)Session["table"]);

        #region Add data to tablerow
        DataRow row = dt.NewRow();
        row["GroupID"] = GroupID;
        //row["Topic"] = txtTopic.Text;
        //row["ClassTime"] = string.Format(datepicker.Text, "yyyy-MM-dd HH:mm");
        row["A_1"] = ddl_A1.SelectedValue;
        row["A_2"] = ddl_A2.SelectedValue;
        row["A_3"] = ddl_A3.SelectedValue;
        row["A_4"] = ddl_A4.SelectedValue;
        row["A_5"] = txt_A5.Text;

        row["B_1"] = ddl_B1.SelectedValue;
        row["B_2"] = ddl_B2.SelectedValue;
        row["B_3"] = ddl_B3.SelectedValue;
        row["B_4"] = ddl_B4.SelectedValue;
        row["B_5"] = ddl_B5.SelectedValue;
        row["B_6"] = txt_B6.Text;

        row["C_1"] = ddl_C1.SelectedValue;
        row["C_2"] = ddl_C2.SelectedValue;
        row["C_3"] = ddl_C3.SelectedValue;

        string chkStr = "";
        foreach (Control ctrl in chk_Panel.Controls)
        {
            if (ctrl is CheckBox)
            {
                if (((CheckBox)ctrl).Checked == true)
                {
                    chkStr += ((CheckBox)ctrl).InputAttributes["value"] + ",";

                    switch (((CheckBox)ctrl).InputAttributes["value"])
                    {
                        case "8":
                            row["D1_Else"] = txt_Else.Text;
                            break;
                        case "9":
                            row["PosterLocation"] = txtPosLocation.Text;
                            break;
                    }
                }
            }
        }
        row["D_1_TypeID"] = chkStr.Substring(0, chkStr.Length - 1);
        #endregion 
        dt.Rows.Add(row);
        Session["table"] = dt;

    }

    protected void ddl_All_SelectedIndexChanged(object sender, EventArgs e)
    {

        foreach (Control ctrl in this.Controls)
        {
            if (ctrl is DropDownList)
            {
                ((DropDownList)ctrl).SelectedIndex = ddl_All.SelectedIndex;

            }

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    void GenerateChkValue()
    {
        foreach (Control ctrl in chk_Panel.Controls)
        {
            if (ctrl is CheckBox)
            {
                ((CheckBox)ctrl).InputAttributes["value"] = ((CheckBox)ctrl).ID.Substring(8);
            }
        }
    }
}