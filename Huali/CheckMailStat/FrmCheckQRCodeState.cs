using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using LumiSoft.Net.Mail;
using LumiSoft.Net.MIME;
using LumiSoft.Net.POP3.Client;
using Ray.Framework.DBUtility;
using Ray.Framework.Encrypt;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Huali.CheckMailStat
{
    public partial class FrmCheckQRCodeState : Office2007Form
    {
        public FrmCheckQRCodeState()
        {
            InitializeComponent();
        }
        
        private static string serverName = "pop.sina.com";
        private static int pop3Port = 110;
        private static string loginName = "hualiapi";
        private static string password = "A123456";
        private static string sql = "";
        private static bool retVal = true;
        DataTable dt = new DataTable();
        POP3_Client pop3 = new POP3_Client();
        POP3_ClientMessage message = (POP3_ClientMessage)null;
        ListViewItem lviMail = new ListViewItem();
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");

        private void Form3_Load(object sender, EventArgs e)
        {
            //连接邮件服务器
            ConnectMailServer(serverName, pop3Port, loginName, password);

            //显示邮件列表
            GetMailList();

            if (listView1.Items.Count > 0)
            {
                Utils.H2(listView1.Items.Count.ToString());
                foreach (ListViewItem mail in listView1.Items)
                {
                    //得到当前的邮件
                    lviMail = mail;

                    //得到邮件所有的附件
                    GetMailAttachments(lviMail);
                }
            }

            this.Close();
        }

        #region 私有过程

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        private void GetMailAttachments(ListViewItem lvimail)
        {
            if (retVal == true)
            {
                try
                {
                    message = (POP3_ClientMessage)lvimail.Tag;
                    Mail_Message mime = Mail_Message.ParseFromByte(message.MessageToByte());

                    foreach (MIME_Entity entity in mime.Attachments)
                    {
                        if (entity.ContentDisposition != null && entity.ContentDisposition.Param_FileName != null)
                        {
                            //保存附件中的CSV文件
                            SaveCSV(entity, entity.ContentDisposition.Param_FileName);
                        }
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    retVal = false;
                }
            }
        }

        /// <summary>
        /// 连接邮件服务器
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="port"></param>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        private void ConnectMailServer(string serverName, int port, string loginName, string password)
        {
            try
            {
                pop3.Connect(serverName, pop3Port, false);
                pop3.Login(loginName, password);
            }
            catch (Exception x)
            {
                MessageBox.Show(this, "POP3 server returned: " + x.Message + " !", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pop3.Dispose();
                retVal = false;
            }
        }

        /// <summary>
        /// 得到邮件列表
        /// </summary>
        private void GetMailList()
        {
            if (retVal == true)
            {
                try
                {
                    foreach (POP3_ClientMessage msg in pop3.Messages)
                    {
                        Mail_Message mime = Mail_Message.ParseFromByte(msg.HeaderToByte());

                        ListViewItem item = new ListViewItem();
                        if (mime.From != null)
                        {
                            item.Text = mime.From.ToString();
                        }
                        else
                        {
                            item.Text = "<none>";
                        }
                        if (string.IsNullOrEmpty(mime.Subject))
                        {
                            item.SubItems.Add("<none>");
                        }
                        else
                        {
                            item.SubItems.Add(mime.Subject);
                        }
                        item.SubItems.Add(mime.Date.ToString());
                        item.SubItems.Add(((decimal)(msg.Size / (decimal)1000)).ToString("f2") + " kb");
                        item.SubItems.Add(msg.UID);
                        item.Tag = msg;
                        this.listView1.Items.Add(item);
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    retVal = false;
                }
            }
        }

        /// <summary>
        /// 将CSV文件保存到本地
        /// </summary>
        /// <param name="entity">附件对象</param>
        /// <param name="fileName">保存的文件名</param>
        private void SaveCSV(MIME_Entity entity, String fileName)
        {
            if (retVal == true)
            {
                try
                {
                    // C:\\CSVS 目录必须存在
                    fileName = "c:\\csvs\\" + fileName;
                    fileName = fileName.Replace(".csv", " " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv");
                    File.WriteAllBytes(fileName, ((MIME_b_SinglepartBase)entity.Body).Data);
                    //读取文件的数据

                    dt = new DataTable();
                    dt = OpenCSV(fileName);
                    //写入数据库，生成日志
                    if(Insert2DB(dt) > 0)
                    {
                        //删除邮件
                        DeleteMail();
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    retVal = false;
                }
            }
        }

        /// <summary>
        /// 将数据表保存到数据库，并生成日志
        /// </summary>
        /// <param name="dt">数据表名</param>
        private int Insert2DB(DataTable dt)
        {
            if (retVal == true)
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        int recCount = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CheckDataModel model = new CheckDataModel
                            {
                                ///对应关系修改
                                StoreId = dt.Rows[i]["storeid"].ToString(),
                                CustomId = dt.Rows[i]["cusid"].ToString(),
                                QRCode = dt.Rows[i]["qrcode"].ToString()
                            };
                            model.QRCodeMing = EncryptHelper.Decrypt(model.QRCode);
                            model.CheckState = dt.Rows[i]["status"].ToString() == "未核销" ? "" : "C";
                            model.Memo = dt.Rows[i]["rem"].ToString();

                            string tableName = string.IsNullOrEmpty(model.QRCodeMing) ? "" : model.QRCodeMing.Substring(0, 4);

                            if (tableName == "")
                            {
                                sql = string.Format("INSERT INTO [dbo].[CheckLog]([FStoreId], [FCustomId], [FQRCode], [FQRCodeMing], [FStatus], [FRem], [FCheckResult]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", model.StoreId, model.CustomId, model.QRCode, model.QRCodeMing, model.CheckState, model.Memo, "失败：二维码未识别");
                                SqlHelper.ExecuteNonQuery(conn, sql);
                            }
                            else if (Exist(model.QRCodeMing) == false)
                            {
                                sql = string.Format("INSERT INTO [dbo].[CheckLog]([FStoreId], [FCustomId], [FQRCode], [FQRCodeMing], [FStatus], [FRem], [FCheckResult]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", model.StoreId, model.CustomId, model.QRCode, model.QRCodeMing, model.CheckState, model.Memo, "成功：二维码不存在");
                                SqlHelper.ExecuteNonQuery(conn, sql);

                                ///2018-06-01 产品核销如果二维码不存在，将二维码添加到QRCode表，并更新icstock表
                                ///2018-06-01 写QRCode表
                                sql = string.Format("INSERT INTO [dbo].[t_QRCode{0}] ([FQRCode], [FEntryID], [FState]) VALUES ('{1}','{2}','{3}')", tableName, model.QRCodeMing, "HOut0000000001",model.CheckState);
                                SqlHelper.ExecuteNonQuery(conn, sql);

                                //2018-06-01 更新ICStock表信息
                                sql = string.Format("update [dbo].[icstock] set [FActQty]= [FActQty] + 1 where [单据编号]= 'HOut000000' and [FEntryID] = 1");
                                SqlHelper.ExecuteNonQuery(conn, sql);

                            }
                            else
                            {
                                sql = string.Format("update [dbo].[t_QRCode{0}] set [FState] = '{1}' Where FQRCode = '{2}'", tableName, model.CheckState, model.QRCodeMing);
                                int res = SqlHelper.ExecuteNonQuery(conn, sql);
                                if (res > 0)
                                {
                                    sql = string.Format("INSERT INTO [dbo].[CheckLog]([FStoreId], [FCustomId], [FQRCode], [FQRCodeMing], [FStatus], [FRem], [FCheckResult]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", model.StoreId, model.CustomId, model.QRCode, model.QRCodeMing, model.CheckState, model.Memo, "成功");
                                    SqlHelper.ExecuteNonQuery(conn, sql);
                                    recCount++;
                                }
                            }
                        }

                        Utils.H2("共成功导入 " + recCount.ToString() + " 条记录！");
                        return recCount;

                    }
                    else
                    {
                         return 0;
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    retVal = false;
                    return 0;
                }
            }
            else 
            {
                return 0;
            }
        } 

        /// <summary>
        /// 判断唯一码是否存在
        /// </summary>
        /// <param name="qrcodeming">唯一码明码</param>
        /// <returns></returns>
        private bool Exist(string qrcodeming)
        {
            string tableName = qrcodeming.Substring(0, 4);
            string sql = string.Format("SELECT COUNT(*) FROM t_QRCode{0} WHERE FQRCode = {1}", tableName, qrcodeming);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            return obj != null && int.Parse(obj.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 将CSV文件转换成数据表
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public DataTable OpenCSV(string fileName)
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

        private void DeleteMail()
        {
            using (POP3_Client c = new POP3_Client())
            {
                c.Connect(serverName, pop3Port, false);
                c.Login(loginName, password);

                if (c.Messages.Count > 0)
                {
                    foreach (POP3_ClientMessage mail in c.Messages)
                    {
                        try
                        {
                            if (lviMail.SubItems[4].Text == mail.UID)
                            {
                                Utils.H2(mail.UID);
                                mail.MarkForDeletion();
                                lviMail.Remove();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            //LogTextHelper.Error(ex);
                        }
                    }
                }
            }
        }
        #endregion

        #region model

        public class CheckDataModel
        {
            public string QRCode { get; set; }

            public string QRCodeMing { get; set; }

            public string CustomId { get; set; }

            public string StoreId { get; set; }

            public string ProductId { get; set; }

            public string CheckState { get; set; }

            public string Memo { get; set; }
        }

        #endregion


    }
}