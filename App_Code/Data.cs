using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Data 的摘要描述
/// </summary>
public class Data
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WifiDataConnectionString"].ConnectionString);
    SqlCommand cmd;
    public Data()
    {

    }

    public DataTable readData(string command_txt)
    {
        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(command_txt,conn);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "table");
        conn.Close();

        return ds.Tables["table"];

    }
    public int insertData(string command_txt, Dictionary<string, string> dic_Parameter)
    {
        try
        {          
            cmd = new SqlCommand(command_txt, conn);
            conn.Open();
            foreach (KeyValuePair<string, string> item in dic_Parameter)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();

            return result;
        }
        catch(Exception e)
        {
            return -1;
        }

    }
    
   public string formatMsg( string msg)
    {
            return string.Format("<script> alert('{0}'); </script>",msg);
    }
}