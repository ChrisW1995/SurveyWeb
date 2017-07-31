using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _model;

public partial class _Default : System.Web.UI.Page
{
    private SurveyModel db = new SurveyModel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearchTopic_Click(object sender, EventArgs e)
    {
        GetData();
    }

    protected void GetData()
    {
        var q = db.Topic.ToList();
        lv_TopicLst.DataSource = q;
        lv_TopicLst.DataBind();
    }

    protected void lv_TopicLst_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        GetData();
    }
}