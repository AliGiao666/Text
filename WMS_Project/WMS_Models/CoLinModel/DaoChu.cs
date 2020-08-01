using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace WMS_Models.CoLinModel
{
    public class DaoChu
    { 
        
        public static byte[] ExportExcel(DataTable dt, string sWebRootFolder, string sFileName, string[] sColumnName, ref string msg)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    msg = "没有符合条件的数据！";
                    //  return false;
                }
                //转utf-8
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] buffer = utf8.GetBytes(sFileName);
                sFileName = utf8.GetString(buffer);
                //判断文件夹
                sWebRootFolder = Path.Combine(sWebRootFolder, "ExprotExcel");
                if (!Directory.Exists(sWebRootFolder))
                    Directory.CreateDirectory(sWebRootFolder);
                //删除大于7天的文件
                string[] files = Directory.GetFiles(sWebRootFolder, "*.xlsx", SearchOption.AllDirectories);
                foreach (string item in files)
                {

                    FileInfo f = new FileInfo(item);
                    DateTime now = DateTime.Now;
                    TimeSpan t = now - f.CreationTime;
                    int day = t.Days;
                    if (day > 7)
                    {
                        File.Delete(item);
                    }
                }
                //判断同名文件
                FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                if (file.Exists)
                {
                    //判断同名文件创建时间
                    file.Delete();
                    file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
                }
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    //添加worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sFileName.Split('.')[0]);
                    //添加表头
                    int column = 1;
                    if (sColumnName.Count() == dt.Columns.Count)
                    {
                        foreach (string cn in sColumnName)
                        {
                            worksheet.Cells[1, column].Value = cn.Trim();
                            worksheet.Cells[1, column].Style.Font.Bold = true;//字体为粗体
                            worksheet.Cells[1, column].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                            worksheet.Cells[1, column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;//设置样式类型
                            worksheet.Cells[1, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(159, 197, 232));//设置单元格背景色
                            column++;
                        }
                    }
                    else
                    {
                        foreach (DataColumn dc in dt.Columns)
                        {
                            worksheet.Cells[1, column].Value = dc.ColumnName;
                            worksheet.Cells[1, column].Style.Font.Bold = true;//字体为粗体
                            worksheet.Cells[1, column].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                            worksheet.Cells[1, column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;//设置样式类型
                            worksheet.Cells[1, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(159, 197, 232));//设置单元格背景色
                            column++;
                        }
                    }
                    //添加数据
                    int row = 2;
                    foreach (DataRow dr in dt.Rows)
                    {
                        int col = 1;
                        foreach (DataColumn dc in dt.Columns)
                        {
                            worksheet.Cells[row, col].Value = dr[col - 1].ToString();
                            col++;
                        }
                        row++;
                    }
                    //自动列宽
                    worksheet.Cells.AutoFitColumns();
                    //保存
                    package.Save();
                    return package.GetAsByteArray();
                }
            }
            catch (Exception ex)
            {
                msg = "生成Excel失败：" + ex.Message;
                return null;
            }
        }
    }
}
