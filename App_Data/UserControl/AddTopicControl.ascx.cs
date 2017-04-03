using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddTopicControl : System.Web.UI.UserControl
{
    Data data = new Data();
    DataTable dt = new DataTable();
    SqlDataAdapter adpter = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            InitGrid();

    }

    public void InitGrid()
    {
        dt = data.readData("SELECT * FROM Topic ORDER BY TopicTime DESC");
        datagrid.DataSource = dt;
        datagrid.DataBind();

        Session["tb"] = dt;


    }
    public DataTable NewTable()
    {
        DataTable _dt = new DataTable();
        _dt.Columns.AddRange(new DataColumn[] {
            new DataColumn ("TopicID"),
            new DataColumn ("TopicName"),
            new DataColumn ("TopicTime")
        });
        return _dt;
    }

    protected void btnAddTopic_Click(object sender, EventArgs e)
    {
        if (txtTopic.Text == "" || datepicker.Text == "")
        {
            Response.Write("<script>alert('請確定已輸入主題與正確之開課時間！');</script>");
            return;
        }
        Dictionary<string, string> dic_Parameter = new Dictionary<string, string>();
        string commandtxt = "INSERT INTO Topic Values(@TopicName, @TopicTime)";
        dic_Parameter.Add("@TopicName", txtTopic.Text);
        dic_Parameter.Add("@TopicTime", datepicker.Text);
        int result = data.insertData(commandtxt, dic_Parameter);
        if (result == -1)
        {
            Response.Write(data.formatMsg("Error"));
            return;
        }
        else
        {
            Response.Write(data.formatMsg("新增主題成功"));
            txtTopic.Text = datepicker.Text = "";
            datagrid.DataBind();
            InitGrid();
        }
        Response.Redirect("~/AddTopic.aspx");


    }

    protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }



    protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.CommandText = "DELETE Topic WHERE TopicID = @ID";
                    cmd.Connection = conn;
                    int index = Convert.ToInt32(e.CommandArgument);
                    cmd.Parameters.AddWithValue("@ID", ((HiddenField)datagrid.Rows[index].FindControl("hf")).Value);
                    DataTable _dt = new DataTable();
                    if (cmd.ExecuteNonQuery() == -1)
                    {
                        Response.Write("<script>alert('error');</script>");
                        return;
                    }
                    else
                    {
                        Response.Write("<script>alert('刪除主題成功');</script>");
                        txtTopic.Text = datepicker.Text = "";
                        InitGrid();




                    }

                }
            }
        }
    }



    protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        datagrid.DataSource = (DataTable)Session["tb"];
        datagrid.PageIndex = e.NewPageIndex;
        datagrid.DataBind();
    }

 
    protected void datagrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        


    }
}

    