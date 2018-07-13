﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ray.Framework.DBUtility;
using System.Data.SqlClient;
using Ray.Framework.Encrypt;

namespace Huali
{
    public partial class FrmStatistics : Office2007Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        string sql = "";
        string Procedure_Name = "CreateOrUpdateQrcodeCounter";
        string Connection_Name = "SQLConnectionString";

        /// <summary>
        /// 查询QRCode的计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            //统计计数
            //SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(Connection_Name), CommandType.StoredProcedure, Procedure_Name, null);


            string startDate = dateTimeInput1.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dateTimeInput2.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            if (startDate != "0001-01-01" && endDate != "0001-01-01")
            {
                int startCounter = 0;
                int endCounter = 0;

                //用“小于”是指最接近的前一天的下班计数
                sql = string.Format("SELECT TOP 1 [fCounter] FROM [dbo].[t_Counter] WHERE [fDate] < '{0}' ORDER BY [fDate] DESC ", startDate);
                object objStartCounter = SqlHelper.GetSingle(sql);
                startCounter = objStartCounter != null ? int.Parse(objStartCounter.ToString()) : 0;
                if (startCounter == 0)
                {
                    DesktopAlert.Show("<h2>请输入有效的开始时间！</h2>");
                }

                sql = string.Format("SELECT TOP 1 [fCounter] FROM [dbo].[t_Counter] WHERE [fDate] <= '{0}' ORDER BY [fDate] DESC ", endDate);
                object objEndCounter = SqlHelper.GetSingle(sql);
                endCounter = objEndCounter != null ? int.Parse(objEndCounter.ToString()) : 0;
                if (endCounter == 0)
                {
                    DesktopAlert.Show("<h2>请输入有效的结束时间！</h2>");
                }

                int QRCodeCount = endCounter - startCounter;
                Utils.H2(string.Format("<h2>开始个数:" + startCounter + "<br/>结束个数:" + endCounter + "<br/>共查询到 {0} 条记录</h2>", QRCodeCount.ToString()));

            }
            else
            {
                DesktopAlert.Show("<h2>请输入有效的开始时间和结束时间！</h2>");
            }
        }

        /// <summary>
        /// 执行存储过程，插入计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX2_Click(object sender, EventArgs e)
        {
            try
            {
                //注意使用库的版本，连接字符串是否加密
                string conn = EncryptHelper.Decrypt(SqlHelper.GetConnectionString(Connection_Name));
                SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, Procedure_Name, null);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                DesktopAlert.Show("<h2>统计计数完成！</h2>");
            }
        }
    }
}