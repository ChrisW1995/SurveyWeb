using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _model;
using System.IO;

public partial class _Default : System.Web.UI.Page
{

    List<string> Lst_topicID;
    private SurveyModel db = new SurveyModel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearchTopic_Click(object sender, EventArgs e)
    {
        var q = GetData();
        lv_TopicLst.DataSource = q;
        lv_TopicLst.DataBind();
    }

    protected List<Topic> GetData()
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
        else if (!string.IsNullOrEmpty(datepicker.Text) && string.IsNullOrEmpty(datepicker2.Text))
        {
            q = q.Where(c => c.TopicTime >= DateTime.Parse(datepicker.Text) && c.TopicTime <= DateTime.Now).ToList();
        }
        else if (string.IsNullOrEmpty(datepicker.Text) && !string.IsNullOrEmpty(datepicker2.Text))
        {
            q = q.Where(c => c.TopicTime >= DateTime.Parse("2000/1/1") && c.TopicTime <= DateTime.Parse(datepicker2.Text)).ToList();
        }
        return q;
        
    }

    protected void lv_TopicLst_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        var q=GetData();
        lv_TopicLst.DataSource = q;
        lv_TopicLst.DataBind();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Lst_topicID = new List<string>();
        foreach (ListViewItem row in lv_TopicLst.Items)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkTopic");
            if (cb.Checked == true)
            {
                Label lbTopicId = (Label)row.FindControl("lbTopicID");
                Lst_topicID.Add(lbTopicId.Text);
            }
        }
        exportMain();


    }

    protected void btnExportAll_Click(object sender, EventArgs e)
    {
        Lst_topicID = new List<string>();
        var q = GetData();
        if(q == null)
        {
            Response.Write("<script>alert('Error');</script>");
            return;
        }
        
        foreach(var _id in q)
        {
            Lst_topicID.Add(_id.TopicID.ToString());
        }
        exportMain();
    }

    protected void exportMain()
    {
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        Excel excel = new Excel();
        MemoryStream MS = excel.export2Excel(Lst_topicID);
        string fileName = "ExcelData";

        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".xlsx");
        Response.BinaryWrite(MS.ToArray());

        MS.Close();
        MS.Dispose();

        Lst_topicID = null;
        Response.Flush();
        Response.End();
    }
}