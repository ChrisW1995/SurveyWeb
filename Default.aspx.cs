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
        if (!string.IsNullOrEmpty(txtSearchTopic.Text))
        {
            q = q.Where(c => c.TopicName.Contains(txtSearchTopic.Text)).ToList();
        }
        if (!string.IsNullOrEmpty(datepicker.Text) && !string.IsNullOrEmpty(datepicker2.Text))
        {
            q = q.Where(c => c.TopicTime >= DateTime.Parse(datepicker.Text) && c.TopicTime <= DateTime.Parse(datepicker2.Text)).ToList();
        }
        
        lv_TopicLst.DataSource = q;
        lv_TopicLst.DataBind();
    }

    protected void lv_TopicLst_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        GetData();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        foreach(ListViewItem row in lv_TopicLst.Items)
        {

        }
    }
}