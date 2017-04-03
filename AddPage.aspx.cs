using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] == null)
        {
            //  data.formatMsg("Error!");
            // ScriptManager.RegisterStartupScript()            
            Response.Write("<script>alert('Error');location.href='AddTopic.aspx';</script>");
            Response.End();
        }
    }
}