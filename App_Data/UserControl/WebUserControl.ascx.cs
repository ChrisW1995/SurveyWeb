using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class WebUserControl : System.Web.UI.UserControl
{
    Data data = new Data();
    DataTable dt;
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"].ToString();
        
        if (!IsPostBack)
        {
            GenerateChkValue();
            chkTopic();
            BindGrid();
            generalScore();
          
        } 
    }
    public void chkTopic()
    {
        DataTable dt = new DataTable();
       dt = data.readData(string.Format("SELECT * FROM Topic LEFT JOIN Content ON Topic.TopicID = Content.TopicID  WHERE Topic.TopicID = {0} ORDER BY TopicTime DESC", id));
        if(dt.Rows.Count==0)
        {
            Response.Write("<script>alert('Error');location.href='AddTopic.aspx';</script>");
            Response.End();
        }

        string strTime = string.Format("{0:yyyy-MM-dd HH:00}", dt.Rows[0][2]);
        lbTopic.Text = dt.Rows[0][1].ToString() + " "+strTime;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    string classtime = string.Format("{0:yyyy-MM-dd HH:00}", dr["TopicTime"]);
        //    string ddlText = string.Format("{0} {1}", dr["TopicName"].ToString(), classtime);
            
        //    ddlTopic.Items.Add(new ListItem(ddlText,dr["TopicID"].ToString()));
        //}
        
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
            string commandStr = "SELECT * FROM Content WHERE TopicID = "+id;
            using (SqlDataAdapter adapter = new SqlDataAdapter(commandStr, conn))
            {
                dt = NewDataTable();
                adapter.Fill(dt);
                Session["table"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
            }

        }
        Label1.Text = "共 " + dt.Rows.Count.ToString() + " 筆資料";
    }
    void generalScore()
    {
        foreach(Control ctrl in this.Controls)
        {
            if(ctrl is DropDownList)
            {
                for (int i = 5; i > 0; i--)
                {
                    ((DropDownList)ctrl).Width = 50;
                    ((DropDownList)ctrl).Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            
                          
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        DataTable dt = ((DataTable)Session["table"]);

        #region Add data to tablerow

        string chkStr = "", strElse="", strPosterLocation="";
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
                            strElse = txt_Else.Text;
                            break;
                        case "9":
                            strPosterLocation = txtPosLocation.Text;
                            break;
                    }
                }
            }
        }
        chkStr = chkStr.Length==0?"":chkStr.Substring(0, chkStr.Length - 1);
        #endregion 
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
        {
            conn.Open();
            string strCommand = "INSERT INTO Content VALUES(@TopicID, @A_1, @A_2, @A_3, @A_4, @A_5, @B_1, @B_2, @B_3, @B_4, @B_5, @B_6, @C_1, @C_2, @C_3, @D_1_TypeID, @D_2, @PosterLocation, @D1_Else)";

            using (SqlCommand cmd = new SqlCommand(strCommand, conn))
            {
                cmd.Parameters.AddWithValue("@TopicID", id);
                cmd.Parameters.AddWithValue("@A_1", ddl_A1.SelectedValue);
                cmd.Parameters.AddWithValue("@A_2", ddl_A2.SelectedValue);
                cmd.Parameters.AddWithValue("@A_3", ddl_A3.SelectedValue);
                cmd.Parameters.AddWithValue("@A_4", ddl_A4.SelectedValue);
                cmd.Parameters.AddWithValue("@A_5", txt_A5.Text);
                cmd.Parameters.AddWithValue("@B_1", ddl_B1.SelectedValue);
                cmd.Parameters.AddWithValue("@B_2", ddl_B2.SelectedValue);
                cmd.Parameters.AddWithValue("@B_3", ddl_B3.SelectedValue);
                cmd.Parameters.AddWithValue("@B_4", ddl_B4.SelectedValue);
                cmd.Parameters.AddWithValue("@B_5", ddl_B5.SelectedValue);
                cmd.Parameters.AddWithValue("@B_6", txt_B6.Text);
                cmd.Parameters.AddWithValue("@C_1", ddl_C1.SelectedValue);
                cmd.Parameters.AddWithValue("@C_2", ddl_C2.SelectedValue);
                cmd.Parameters.AddWithValue("@C_3", ddl_C3.SelectedValue);
                cmd.Parameters.AddWithValue("@D_1_TypeID", chkStr);
                cmd.Parameters.AddWithValue("@D_2", txt_D2.Text);
                cmd.Parameters.AddWithValue("@PosterLocation", strPosterLocation);
                cmd.Parameters.AddWithValue("@D1_Else", strElse);

                if(cmd.ExecuteNonQuery()==0)
                {
                    data.formatMsg("新增失敗！");
                }            
            }
        }

            
       
        Response.Redirect("~/AddPage.aspx?id="+id);

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

    protected void btnShowPopup_Click(object sender, EventArgs e)
    {
        
    }

    protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        dt = (DataTable)Session["table"];
        GridView1.DataSource = dt;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();",true);
    }

    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox8.Checked == true)      
            txt_Else.Enabled = true;        
        else
            txt_Else.Enabled = false;
    }

    protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox9.Checked == true)
            txtPosLocation.Enabled = true;
        else
            txtPosLocation.Enabled = false;
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        GridView1.Columns[0].Visible = false;
    }

    protected void btnDel_Click()
    {
        

    }



    protected void btnDel_Click(object sender, EventArgs e)
    {
       
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string _id = "", cmdStr = "";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
        {
            conn.Open();
            _id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lbID")).Text;
            cmdStr = "DELETE FROM Content WHERE id = " + _id;
            
            using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
            {
                cmd.ExecuteNonQuery();
            }

        }
        BindGrid();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);

    }
}