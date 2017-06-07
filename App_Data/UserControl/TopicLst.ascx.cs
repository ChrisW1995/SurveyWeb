using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TopicLst : System.Web.UI.UserControl
{
    Data data = new Data();
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        getTopic();
    }

    void getTopic()
    {
        dt = data.readData("SELECT * FROM Topic");
        ListView1.DataSource = dt;
        ListView1.DataBind();

    }
}