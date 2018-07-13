using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Ray.Framework.Converter
{
    public sealed class Convert2DataTable
    {
        #region toDataTable
        /// <summary>
        /// 将TXT文件转成DataTable
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public DataTable Text2DataTable(string FileName)
        {
            if (!System.IO.File.Exists(FileName))
            {
                return null;
            }
            DataTable dtData = new DataTable();
            string[] strRows = System.IO.File.ReadAllLines(FileName);
            for (int intRow = 0; intRow < strRows.Length; intRow++)
            {

                string[] strCols = strRows[intRow].Split(',');
                if (intRow == 0)
                {
                    for (int intCol = 0; intCol < strCols.Length; intCol++)
                    {
                        //创建列
                        dtData.Columns.Add(new DataColumn("F" + intCol.ToString()));
                    }
                }
                DataRow drNew = dtData.NewRow();
                for (int intCol = 0; intCol < strCols.Length; intCol++)
                {
                    strCols[intCol] = strCols[intCol].Replace("\"", "");

                    drNew["F" + intCol.ToString()] = strCols[intCol].Trim();
                }
                dtData.Rows.Add(drNew);
            }
            return dtData;
        }

        /// <summary>
        /// 将Excel文件转成DataTable
        /// </summary>
        /// <param name="excelFileName">Excel文件名</param>
        /// <param name="sheetName">工作簿名</param>
        /// <param name="columnNames"></param>
        /// <returns></returns>
        public DataTable Excel2DataTable(string excelFileName, string sheetName, string columnNames, string orderBy)
        {
            if (excelFileName.ToLower().EndsWith(".xls") || excelFileName.ToLower().EndsWith(".xlsx"))
            {
                string strConn = "";
                string sql = "";
                DataTable dt = (DataTable)null;
                OleDbDataAdapter myCommand = null;

                if (excelFileName.ToLower().EndsWith(".xlsx") || excelFileName.ToLower().EndsWith(".xls"))
                {
                    //Excel 2007
                    strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelFileName + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                }
                else
                {
                    //Excel 2003
                    strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFileName + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                }

                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string m_SheetName = string.IsNullOrEmpty(sheetName) ? "Sheet1" : sheetName;

                string m_ColumnNames = string.IsNullOrEmpty(columnNames) ? "*" : columnNames;

                string m_OrderBy = string.IsNullOrEmpty(orderBy) ? "" : "ORDER BY " + orderBy;

                sql = string.Format("select {1} from [{0}$]  {2}", m_SheetName, m_ColumnNames, m_OrderBy);
                myCommand = new OleDbDataAdapter(sql, strConn);
                dt = new DataTable();
                try
                {
                    myCommand.Fill(dt);
                }
                catch
                {
                }
                return dt;
            }
            else
            {
                return (DataTable)null;
            }
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public DataTable CSV2DataTable(string fileName)
        {
            DataTable retDT = new DataTable();
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        retDT.Columns.Add(dc);
                    }
                }
                else
                {
                    DataRow dr = retDT.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    retDT.Rows.Add(dr);
                }
            }
            sr.Close();
            fs.Close();
            return retDT;
        }
        #endregion
    }

    public sealed class DataTable2Excel
    {
        #region DataTable2Excel
        /// <summary>
        /// 将Dataable转成Excel文件
        /// 
        /// Demo:
        ///SaveFileDialog kk = new SaveFileDialog();
        ///kk.Title = "保存EXECL文件";
        ///kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
        ///kk.FilterIndex = 1;
        ///if (kk.ShowDialog() == DialogResult.OK)
        ///{
        ///    string FileName = kk.FileName;
        ///}
        /// 
        /// </summary>
        /// <param name="m_DataTable">要导出的数据表</param>
        /// <param name="m_ExcelFileName">导出的Excel文件名</param>
        public static void Data2Excel(DataTable m_DataTable, string m_ExcelFileName)
        {
            if (File.Exists(m_ExcelFileName))
                File.Delete(m_ExcelFileName);
            FileStream objFileStream;
            StreamWriter objStreamWriter;
            string strLine = "";
            objFileStream = new FileStream(m_ExcelFileName, FileMode.OpenOrCreate, FileAccess.Write);
            objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
            for (int i = 0; i < m_DataTable.Columns.Count; i++)
            {
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);
            }
            objStreamWriter.WriteLine(strLine);
            strLine = "";

            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {
                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {
                    if (m_DataTable.Rows[i].ItemArray[j] == null)
                        strLine = strLine + " " + Convert.ToChar(9);
                    else
                    {
                        string rowstr = "";
                        rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();
                        if (rowstr.IndexOf("\r\n") > 0)
                            rowstr = rowstr.Replace("\r\n", " ");
                        if (rowstr.IndexOf("\t") > 0)
                            rowstr = rowstr.Replace("\t", " ");
                        strLine = strLine + rowstr + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
            }
            objStreamWriter.Close();
            objFileStream.Close();
        }
        #endregion
    }
}
