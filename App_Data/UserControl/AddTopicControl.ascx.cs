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
    DataSet ds = new DataSet();
    SqlDataAdapter adpter = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            InitGrid();



    }

    public void InitGrid()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM Topic ORDER BY TopicTime DESC";
                cmd.Connection = conn;
                adpter.SelectCommand = cmd;      
                adpter.Fill(ds,"dataTable");
                datagrid.DataSource = ds.Tables["dataTable"];
                datagrid.DataBind();

                Session["tb"] = ds.Tables["dataTable"];
            }
        }
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
        if(txtTopic.Text=="" || datepicker.Text=="")
        {
            Response.Write("<script>alert('請確定已輸入主題與正確之開課時間！');</script>");
            return;
        }
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Topic Values(@TopicName, @TopicTime)";
                cmd.Parameters.AddWithValue("@TopicName", txtTopic.Text);
                cmd.Parameters.AddWithValue("@TopicTime", datepicker.Text);
                cmd.Connection = conn;
                if(cmd.ExecuteNonQuery()==-1)
                {
                    Response.Write("<script>alert('error');</script>");
                    return;
                }
                else
                {
                    Response.Write("<script>alert('新增主題成功');</script>");
                    txtTopic.Text = datepicker.Text = "";
                    datagrid.DataBind();
                    InitGrid();
                }
                
            }
        }
    }

    protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }



    protected void datagrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Delete")
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.CommandText = "DELETE Topic WHERE TopicID = @ID";
                    cmd.Connection = conn;
                    int index = Convert.ToInt32(e.CommandArgument);
                    cmd.Parameters.AddWithValue("@ID", ((HiddenField)datagrid.Rows[index].FindControl("HiddenField1")).Value);
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
}