using DevComponents.DotNetBar;
using Ray.Framework.Config;
using Ray.Framework.Converter;
using Ray.Framework.CustomDotNetBar;
using Ray.Framework.Encrypt;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Huali.DS9208
{
    public partial class FrmBuildQRCode : Office2007Form
    {
        public FrmBuildQRCode()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        //private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");


        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
        }

        /// <summary>
        /// 生成,仅开放16-18库的QRCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX2_Click(object sender, EventArgs e)
        {
            string year = textBoxX1.Text;
            string tableIndex = textBoxX2.Text;

            ///2018-06-02 新增 对年份和表序号的检验,且库序号不能为99，99库测试专用
            if (int.Parse(year) >= 16 && int.Parse(year) <= 18 && int.Parse(tableIndex) >= 0 && int.Parse(tableIndex)< 99)
            {
                dt = QRCodeBuilder(year, tableIndex, true);
                this.dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["二维码"].Width = 240;
            }
            else
            {
                CustomDesktopAlert.H2("请输入有效的年份和表序号");
            }

        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            //string qrCode = "";
            //for (int j = 0; j < dataGridViewX1.Rows.Count; j++)
            //{
            //    qrCode = dataGridViewX1.Rows[j].Cells[1].Value.ToString();
            //    bcc.CreateQuickMark(pictureBox1, qrCode);
            //    Image img = pictureBox1.Image;
            //    img.Save("d:/temp/" + textBoxX2.Text + (j + 1).ToString().PadLeft(5,'0') + ".jpg");
            //}


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                //设置文件类型
                Filter = "Excel 97-2003工作簿（*.xls）|*.xls|所有文件(*.*)|*.*",
                FileName = "QRCode",//设置默认文件名
                RestoreDirectory = true,//保存对话框是否记忆上次打开的目录
                CheckPathExists = true//检查目录
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strSaveFileLocation = saveFileDialog.FileName;//文件路径
                DataTable2Excel.Data2Excel(dt, strSaveFileLocation);
            }
        }

        #endregion

        #region 私有过程
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year">两位数年份</param>
        /// <param name="startNo">起始编号</param>
        /// <param name="endNo">结束编号</param>
        private static void QRCodeBuilder(string year, int startNo, int endNo)
        {
            string tableIndex = GetTableIndexByQRCode(year.ToString() + startNo.ToString().PadLeft(7, '0'));
            if (startNo > 0 && endNo > 0)
            {
                for (int i = startNo; i < endNo; i++)
                {
                    string QRCode = year.ToString() + i.ToString().PadLeft(7, '0');
                }
            }
        }

        /// <summary>
        /// 由于数据量太大，系统采用分库处理
        /// 本过程通过二维码明文找到分库后表名的索引
        /// </summary>
        /// <param name="QRCode">二维码明文</param>
        /// <returns></returns>
        private static string GetTableIndexByQRCode(string QRCode)
        {
            string retVal = "";
            if (!string.IsNullOrEmpty(QRCode))
            {
                string QRYear = QRCode.Substring(0, 2);
                string QRTableIndex = QRCode.Substring(2, 2);
                retVal = "t_QRCode20" + QRYear + QRTableIndex;
            }
            return retVal;
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="year">两位数年份</param>
        /// <param name="tableIndex">表编号</param>
        /// <param name="enryptable">是否加密</param>
        private DataTable QRCodeBuilder(string year, string tableIndex, bool enryptable)
        {
            dt = new DataTable();
            if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(tableIndex))
            {
                DataColumn dtc0 = new DataColumn("序号", typeof(string));
                dt.Columns.Add(dtc0);
                DataColumn dtc1 = new DataColumn("二维码", typeof(string));
                dt.Columns.Add(dtc1);

                string QRCode = "";
                ///for (int i = 0; i < 100000; i++)
                for (int i = 0; i < 100000; i++)
                {
                    QRCode = year + tableIndex + i.ToString().PadLeft(5, '0');
                    if (enryptable)
                    {
                        QRCode = EncryptHelper.Encrypt(QRCode);
                    }

                    //添加数据到DataTable
                    DataRow dr = dt.NewRow();
                    dr["序号"] = (i + 1).ToString();
                    dr["二维码"] = QRCode;
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }

        #endregion
        
    }
}
