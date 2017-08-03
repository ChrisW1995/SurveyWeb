using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _model;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using System.Data;
using System.Reflection;

/// <summary>
/// Excel 的摘要描述
/// </summary>
public class Excel
{
    //public Excel()
    //{

    //}
    SurveyModel context = new SurveyModel();
    DataTable dt;
    public XSSFWorkbook initailExcel()
    {
        //---initail excel
        XSSFWorkbook _workbook = new XSSFWorkbook();
        ISheet u_sheet = _workbook.CreateSheet("sheet1");
        //---font style and align
        XSSFCellStyle cs = (XSSFCellStyle)_workbook.CreateCellStyle();
        cs.Alignment = HorizontalAlignment.Center;
        XSSFFont font = (XSSFFont)_workbook.CreateFont();
        font.Boldweight = (short)FontBoldWeight.Bold;

        cs.SetFont(font);

        for (int i = 14; i <= 22; i++)
        {
            u_sheet.SetColumnWidth(i, 2500);

        }

        #region MergeRegion
        IRow u_row = u_sheet.CreateRow(0);
        u_row.CreateCell(0).SetCellValue("(一)【課程內容滿意度】");
        u_row.CreateCell(5).SetCellValue("(二)【講師授課之滿意度】");
        u_row.CreateCell(11).SetCellValue("(三)【整體教學環境方面】");
        u_row.CreateCell(14).SetCellValue("(四)【其他】");
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 4));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 5, 10));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 11, 13));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 14, 23));

        u_row.GetCell(0).CellStyle = u_row.GetCell(5).CellStyle =
        u_row.GetCell(11).CellStyle = u_row.GetCell(14).CellStyle = cs;
        #endregion

        return _workbook;
    }
    public MemoryStream export2Excel(int _TopicId)
    {
        
        //---initail excel
        XSSFWorkbook workbook = new XSSFWorkbook();
        ISheet u_sheet = workbook.CreateSheet("sheet1");
         //---font style and align
         XSSFCellStyle cs = (XSSFCellStyle)workbook.CreateCellStyle();
        cs.Alignment = HorizontalAlignment.Center;
        XSSFFont font = (XSSFFont)workbook.CreateFont();
        font.Boldweight = (short)FontBoldWeight.Bold;

        cs.SetFont(font);

        for (int i = 14; i <= 22; i++)
        {
            u_sheet.SetColumnWidth(i, 2500);
            
        }

        #region MergeRegion
        IRow u_row = u_sheet.CreateRow(0);
        u_row.CreateCell(0).SetCellValue("(一)【課程內容滿意度】");
        u_row.CreateCell(5).SetCellValue("(二)【講師授課之滿意度】");
        u_row.CreateCell(11).SetCellValue("(三)【整體教學環境方面】");
        u_row.CreateCell(14).SetCellValue("(四)【其他】");
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 4));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 5, 10));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 11, 13));
        u_sheet.AddMergedRegion(new CellRangeAddress(0, 0, 14, 23));

        u_row.GetCell(0).CellStyle = u_row.GetCell(5).CellStyle =
        u_row.GetCell(11).CellStyle = u_row.GetCell(14).CellStyle = cs;
        #endregion

       
        //class content
        var q_list = context.Content.Where(c => c.TopicID == _TopicId).ToList();

        dt = Entities2DataDable(q_list);

#region Set columns on the second row 
        IRow sec_row = u_sheet.CreateRow(1);
        for(int i = 2; i < dt.Columns.Count-4; i++)
        {
            sec_row.CreateCell(i-2).SetCellValue(dt.Columns[i].ColumnName);
            sec_row.GetCell(i - 2).CellStyle = cs;
        }

        var choose = from c in context.D1_Choose select c;

        int count = 14;
        foreach(var c in choose)
        {
            sec_row.CreateCell(count).SetCellValue(c.Description);
            sec_row.GetCell(count).CellStyle = cs;
            count++;
        }
        sec_row.CreateCell(23).SetCellValue(dt.Columns[17].ColumnName);
        sec_row.GetCell(23).CellStyle = cs;
#endregion

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            IRow row = u_sheet.CreateRow(i + 2);
            for(int j = 2; j <=15; j++)
            {
                row.CreateCell(j-2).SetCellValue(dt.Rows[i][j].ToString());
                
            }

            if (dt.Rows[i][16].ToString() != "")
            {
                string[] locations = (dt.Rows[i][16].ToString()).Split(',');

                foreach (string _location in locations)
                {
                    int locationID = int.Parse(_location);
                    switch (locationID)
                    {
                        case 8:
                            row.CreateCell(13 + locationID).SetCellValue(dt.Rows[i][19].ToString());
                            break;
                        case 9:
                            row.CreateCell(13 + locationID).SetCellValue(dt.Rows[i][18].ToString());
                            break;
                        default:
                            row.CreateCell(13 + locationID).SetCellValue("v");
                            break;
                    }
                }

            }

            row.CreateCell(23).SetCellValue(dt.Rows[i][17].ToString());

        }
        MemoryStream MS = new MemoryStream();
        workbook.Write(MS);

        return MS;
       

        
    } 

    public DataTable Entities2DataDable<Content>(List<Content> items)
    {
        DataTable dt = new DataTable(typeof(Content).Name);

        PropertyInfo[] entityProps = typeof(Content).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach(PropertyInfo prop in entityProps)
        {
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            dt.Columns.Add(prop.Name, type);
        }

        foreach(Content item in items)
        {
            var values = new object[entityProps.Length];
            for (int i = 0; i < entityProps.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = entityProps[i].GetValue(item, null);
            }
            dt.Rows.Add(values);
        }
        
        return dt;
    }
}