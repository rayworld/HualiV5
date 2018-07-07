using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using HualiHan.Models;
using Ray.Framework.Converter;
using System;
using System.Data;
using System.Windows.Forms;

namespace HualiHan
{
    public partial class frmEDI_SEOutStock : Office2007Form
    {
        public frmEDI_SEOutStock()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private static TemplateType template = TemplateType.Unknow;
        
        #region �¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //Check Data
            if (template == TemplateType.����)
            {
                if (CheckData_RL(dt))
                {
                    //ImportData
                    ImportData_RL(dt, "������");
                }
            }
            else if (template == TemplateType.�Ǵ�)
            {
                if (CheckData_XC(dt))
                {
                    //ImportData
                    ImportData_XC(dt, "������");
                }
            }
            else 
            {
                DesktopAlert.Show("����ʶ���Excelģ���ļ���");
            }
        }

        /// <summary>
        /// ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\Users\\Ray\\Desktop";//ע������д·��ʱҪ��c:\\������c:\
            dialog.Filter = "Excel2007�ļ�|*.xlsx|Excel2003�ļ�|*.xls|�����ļ�|*.*";
            dialog.RestoreDirectory = true;
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                this.dataGridViewX1.DataSource = null;
                string fileName = dialog.FileName;
                template = swichTemplateType(fileName);
                Convert2DataTable c2d = new Convert2DataTable();
                //string sheetName = template == TemplateType.���� ? "�ŵ���Ϣ" : "������ϸ";
                string sheetName = template == TemplateType.���� ? "�ŵ���Ϣ" : "Sheet1";
                dt = c2d.Excel2DataTable(fileName, sheetName, null, null);
                this.dataGridViewX1.DataSource = dt;
                DesktopAlert.Show("<h2>" + "�ɹ���Excel�ļ��� " + "</h2>");
            }
        }

        #endregion
        
        #region ˽�й���

        /// <summary>
        /// ѡ��ģ������
        /// </summary>
        /// <param name="filename">Excel�ļ���</param>
        /// <returns></returns>
        private TemplateType swichTemplateType(string filename)
        {
            if (filename.Contains("��������") == true)
            {
                template = TemplateType.����;
            }
            else if (filename.Contains("���۶���") == true)
            {
                template = TemplateType.�Ǵ�;
            }
            else
            {
                template = TemplateType.Unknow;
            }
            return template;
        }

        /// <summary>
        /// ���˲�ͬ��������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="where">����</param>
        /// <returns></returns>
        private DataTable FilterData(DataTable dt, string where)
        {
            DataRow[] rows = dt.Select(where);
            DataTable tmpdt = dt.Clone();
            foreach (DataRow row in rows)  // ����ѯ�Ľ����ӵ�tempdt�У� 
            {
                tmpdt.Rows.Add(row.ItemArray);
            }
            return tmpdt;
        }

        /// <summary>
        /// �õ�Ψһ�ĵ����б�
        /// </summary>
        /// <param name="dt">���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private string getDistinctBillNo(DataTable dt, string billNoFieldName)
        {
            string tempBillNo = "";
            string billNo = "";
            string retVal = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                billNo = dt.Rows[i][billNoFieldName].ToString();
                if (billNo != tempBillNo)
                {
                    retVal += billNo + ";";
                    tempBillNo = billNo;
                }
            }

            //ȥ�����һ���ֺ�
            return retVal.Substring(0, retVal.Length - 1);
        }

        #region ����

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private bool ImportData_RL(DataTable dt, string billNoFieldName)
        {
            bool retVal = false;

            if (dt.Rows.Count > 0)
            {
                //�õ����ݺŵ��б�
                string distinctBillNo = getDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //�õ�һ�ŵ�����
                    DataTable tmpdt = FilterData(dt, "������ = '" + billNo + "'");

                    //ImportSaleBill
                    InsertSaleBill_RL(tmpdt);
                }
            }
            else
            {
                DesktopAlert.Show("û�п��õ����ݣ�");
            }

            return retVal;
        }

        /// <summary>
        /// �������ݺϷ���
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <returns></returns>
        private bool CheckData_RL(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //����Ʒ����
                HualiHan.DAL.t_ICItem dICItem = new DAL.t_ICItem();
                string rowNum = dr["���"].ToString();
                string productNumber = dr["������Ʒ���"].ToString();
                string productDegree = dr["���ӹ��"].ToString();
                int productId = dICItem.getItemIDByFNameFnumber(productNumber, productDegree);
                if (productId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�в�Ʒ��Ų���ʶ��");
                    retVal = false;
                }
                else
                {
                    dr["������Ʒ���"] = productId.ToString();
                }

                //����ŵ�ID
                string storeNumber = dr["�ͻ����"].ToString();
                int storeId = dICItem.getCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�пͻ���Ų���ʶ��");
                    //�ܵ��ż��
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.getCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        DesktopAlert.Show("��" + rowNum + "���ܵ��Ų���ʶ��");
                        return false;
                    }
                    else
                    {
                        dr["�ܵ����"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["�ܵ����"] = storeId.ToString();
                }

                //���ͻ�ID
                string customNumber = dr["�ŵ���"].ToString();
                int customId = dICItem.getCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�пͻ���Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["�ͻ����"] = customId.ToString();
                    dr["�ŵ���"] = dr["�ܵ����"];
                }
            }
            return retVal;
        }

        /// <summary>
        /// ��һ�Ŷ���������д�����ݿ�
        /// </summary>
        /// <param name="dt">һ�Ŷ���������</param>
        private bool InsertSaleBill_RL(DataTable dt)
        {
            HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
            int interId = dSale.GetMaxFInterID();
            string billNo = dSale.GetMaxFBillNo();
            string sourceBillNo = dt.Rows[0]["������"].ToString();
            //�Ѿ����뵽��������
            int custId = int.Parse(dt.Rows[0]["�ͻ����"].ToString());
            int storeId = int.Parse(dt.Rows[0]["�ŵ���"].ToString());
            string productName = dt.Rows[0]["������Ʒ����"].ToString();
            string explanation = string.Format("���Ʒ {0} 2+1+1", productName);
            HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15326);
            try
            {
                if (dSale.InsertBill(mSale) == true)
                {
                    //DesktopAlert.Show("д����ɹ���");

                    //д�ӱ�
                    int succ = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                        int itemId = int.Parse(dt.Rows[i]["������Ʒ���"].ToString());
                        int entryId = i + 1;                        
                        int stockId = 526;//CSW
                        int qty = int.Parse(dt.Rows[i]["��������"].ToString());
                        HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                        decimal price = dicitem.getSalePriceByFItemID(itemId);

                        HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, qty, qty, 0, 0,40311,40635, 255);

                        if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                        {
                            succ += 1;
                        }
                    }
                    if (succ == dt.Rows.Count)
                    {
                        DesktopAlert.Show("<h2>���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���</h2>");
                        return true;
                    }
                    else
                    {
                        DesktopAlert.Show(billNo + "д�ӱ�ʧ�ܣ�");
                        return false;
                    }
                }
                else
                {
                    DesktopAlert.Show("д�����ݱ�ʧ��");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion

        #region �Ǵ�

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private bool ImportData_XC(DataTable dt, string billNoFieldName)
        {
            bool retVal = true;

            if (dt.Rows.Count > 0)
            {
                //�õ����ݺŵ��б�
                string distinctBillNo = getDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //�õ�һ�ŵ�����
                    DataTable tmpdt = FilterData(dt, billNoFieldName + " = '" + billNo + "'");

                    //������������
                    InsertSaleBill_XC(tmpdt);

                    //������������
                    InsertFreeBill_XC(tmpdt);

                    //����5P����
                    Insert5PBill_XC(tmpdt);
                }
            }
            else
            {
                DesktopAlert.Show("û�п��õ����ݣ�");
                return false;
            }
            return retVal;
        }

        /// <summary>
        /// �Ǵ���Ʒ��������
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool InsertFreeBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " ��Ʒ > 0 and ��� not like '%5P%'");

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                string explanation = string.Format("������� {0}", productName);
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15322);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["��Ʒ"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40526, unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// �Ǵ�5Ƭװ��������
        /// </summary>
        /// <param name="dt">��������</param>
        private bool Insert5PBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " ��Ʒ > 0 AND ��� LIKE '%5P%' ");

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                string explanation = string.Format("�������׿Ч {0}", productName);
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40393, 15326);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["��Ʒ"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, 0, 0, 0, 0, 0, 0, 0, 40311, 40569,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// �Ǵ����۶�������
        /// </summary>
        /// <param name="dt"></param>
        private bool InsertSaleBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, "���� > 0");

            //DesktopAlert.Show(tmpdt.Rows.Count.ToString());

            if (tmpdt.Rows.Count > 0)
            {
                HualiHan.DAL.SEOutStock dSale = new DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                //string explanation = string.Format("���� {0}", productName);
                string explanation = string.Format("{0}", productName);    
                HualiHan.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20302, null, 15322);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //DesktopAlert.Show("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            HualiHan.DAL.SEOutStockEntry dSaleEnrty = new DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["����"].ToString());
                            //int cxType = int.Parse(tmpdt.Rows[i]["�������"].ToString());
                            HualiHan.DAL.t_ICItem dicitem = new DAL.t_ICItem();
                            decimal price = dicitem.getSalePriceByFItemID(itemId);
                            int unitid = dicitem.getUnitIDByitemID(itemId);

                            HualiHan.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40470,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            DesktopAlert.Show("<h2>���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���</h2>");
                            return true;
                        }
                        else
                        {
                            DesktopAlert.Show(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        DesktopAlert.Show("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                DesktopAlert.Show("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool CheckData_XC(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //����Ʒ����
                HualiHan.DAL.t_ICItem dICItem = new DAL.t_ICItem();
                string rowNum = dr["���"].ToString();
                string sku = dr["SKU"].ToString();
                int productId = dICItem.getItemIDBySKU(sku);
                if (productId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�в�Ʒ��Ų���ʶ��");
                    retVal = false;
                }
                else
                {
                    dr["SKU"] = productId.ToString();
                }

                //����ŵ�ID
                string storeNumber = dr["�ŵ����"].ToString();
                int storeId = dICItem.getCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "���ŵ���벻��ʶ��");
                    //�ܵ��ż��
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.getCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        DesktopAlert.Show("��" + rowNum + "���ܵ��Ų���ʶ��");
                        return false;
                    }
                    else
                    {
                        dr["�ŵ����"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["�ŵ����"] = storeId.ToString();
                }

                //���ͻ�ID
                string customNumber = dr["������λ����"].ToString();
                int customId = dICItem.getCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�пͻ���Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["������λ����"] = customId.ToString();                    
                }

                //�ֿ���
                string stockName = dr["�ֿ�"].ToString();
                int stockId = dICItem.getStockIDByFName(stockName);
                if (stockId == 0)
                {
                    DesktopAlert.Show("��" + rowNum + "�вֿ��Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["�ֿ�"] = stockId.ToString();
                }

                //�������
                string cuxiaoType = dr["�������"].ToString();
                HualiHan.DAL.SEOutStockEntry dEntry = new DAL.SEOutStockEntry();
                int cxType = dEntry.getInterIDByFName(cuxiaoType);
                dr["�������"] = cxType.ToString();
            }
            return retVal;
        }
        #endregion

        #region ���ɶ���

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="interId">�ڲ�ID</param>
        /// <param name="billNo">����</param>
        /// <param name="storeId">�ŵ�ID</param>
        /// <param name="explanation">˵��</param>
        /// <param name="sourceBillNo">EDIԭ����</param>
        /// <param name="customId">�ͻ����</param>
        /// <param name="areaPS">areaPS:20303</param>
        /// <param name="HeadSelfS0238">2048.2000</param>
        /// <param name="HeadSelfS0239">sp.so</param>
        /// <returns></returns>
        private HualiHan.Models.SEOutStock BuildSaleModel(int interId, string billNo, int storeId, string explanation, string sourceBillNo, int customId, int areaPS, int? HeadSelfS0238, int HeadSelfS0239)
        {
            //������ǰ����
            DateTime currDate = DateTime.Now.Date;

            HualiHan.Models.SEOutStock mSale = new SEOutStock();
            HualiHan.DAL.SEOutStock dSale = new HualiHan.DAL.SEOutStock();
            mSale.FInterID = interId;
            mSale.FBillNo = billNo;
            mSale.FTranType = 83;
            mSale.FSalType = 101;
            mSale.FCustID = customId;//�������г���
            mSale.FExplanation = explanation;
            mSale.FBrNo = "0";
            mSale.FDate = currDate;
            mSale.FStockID = null;
            mSale.FAdd = null;
            mSale.FNote = null;
            mSale.FEmpID = 39426;
            mSale.FCheckerID = null;
            mSale.FBillerID = 16454;
            mSale.FManagerID = 0;
            mSale.FClosed = 0;
            mSale.FInvoiceClosed = 0;
            mSale.FBClosed = 0;
            mSale.FDeptID = 271;
            mSale.FSettleID = 0;
            mSale.FTranStatus = 0;
            mSale.FExchangeRate = 1;
            mSale.FCurrencyID = 1;
            mSale.FStatus = 0;
            mSale.FCancellation = false;
            mSale.FMultiCheckLevel1 = null;
            mSale.FMultiCheckLevel2 = null;
            mSale.FMultiCheckLevel3 = null;
            mSale.FMultiCheckLevel4 = null;
            mSale.FMultiCheckLevel5 = null;
            mSale.FMultiCheckLevel6 = null;
            mSale.FMultiCheckDate1 = null;
            mSale.FMultiCheckDate2 = null;
            mSale.FMultiCheckDate3 = null;
            mSale.FMultiCheckDate4 = null;
            mSale.FMultiCheckDate5 = null;
            mSale.FMultiCheckDate6 = null;
            mSale.FCurCheckLevel = null;
            mSale.FRelateBrID = 0;
            mSale.FCheckDate = null;
            mSale.FFetchAdd = "";
            mSale.FSelTranType = 0;
            mSale.FChildren = 0;
            mSale.FBrID = null;
            ///mSale.FAreaPS = 20303;
            mSale.FAreaPS = areaPS;
            mSale.FPOOrdBillNo = null;
            mSale.FManageType = 0;
            mSale.FExchangeRateType = 1;
            mSale.FCustAddress = null;
            mSale.FPrintCount = 0;
            //2480
            ///mSale.FHeadSelfS0238 = 40394;
            mSale.FHeadSelfS0238 = HeadSelfS0238;
            //sp
            ///mSale.FHeadSelfS0239 = 15326;
            mSale.FHeadSelfS0239 = HeadSelfS0239;
            //?
            mSale.FHeadSelfS0240 = sourceBillNo;
            mSale.FHeadSelfS1241 = null;
            mSale.FHeadSelfS1242 = null;
            // �ŵ���
            mSale.FHeadSelfS0241 = storeId;
            mSale.FHeadSelfS0244 = "";
            mSale.FHeadSelfS1244 = null;
            mSale.FHeadSelfS1243 = null;
            mSale.FHeadSelfS0245 = currDate;
            mSale.FHeadSelfS1245 = null;
            mSale.FHeadSelfS0247 = "";
            mSale.FHeadSelfS1246 = null;

            return mSale;
        }

        /// <summary>
        /// ������ϸ�����
        /// </summary>
        /// <param name="finterid">�ڲ�ID</param>
        /// <param name="fentryid">���</param>
        /// <param name="fitemid">��ƷID</param>
        /// <param name="fstockid">�ֿ�ID</param>
        /// <param name="AuxCommitQty"></param>
        /// <param name="AuxStockBillQty"></param>
        /// <param name="AuxStockQty"></param>
        /// <param name="CommitQty"></param>
        /// <param name="price"></param>
        /// <param name="qty"></param>
        /// <param name="StockBillQty"></param>
        /// <param name="StockQty"></param>
        /// <param name="EntrySelfS0252"></param>
        /// <param name="EntrySelfS0253"></param>
        /// <returns></returns>
        private HualiHan.Models.SEOutStockEntry BuildSaleEntryModel(int finterid, int fentryid, int fitemid, int fstockid, decimal qty, decimal price, decimal CommitQty, decimal AuxCommitQty, decimal StockQty, decimal AuxStockQty, decimal AuxStockBillQty, decimal StockBillQty, int EntrySelfS0252, int EntrySelfS0253,int UnitID)
        {
            /// ��������
            decimal currQty = qty;
            /// �����۸�
            decimal currPrice = price;
            /// ������ǰʱ��
            DateTime currDate = DateTime.Now.Date;

            HualiHan.Models.SEOutStockEntry mSaleEntry = new SEOutStockEntry();
            mSaleEntry.FInterID = finterid;
            mSaleEntry.FEntryID = fentryid;
            mSaleEntry.FItemID = fitemid;
            mSaleEntry.FStockID = fstockid;
            mSaleEntry.FBrNo = "0";
            mSaleEntry.FQty = currQty;
            mSaleEntry.FCommitQty = CommitQty;
            mSaleEntry.FPrice = currPrice;
            mSaleEntry.FAmount = currQty * currPrice;
            mSaleEntry.FOrderInterID = "0";
            mSaleEntry.FDate = null;
            mSaleEntry.FNote = "";
            mSaleEntry.FInvoiceQty = 0;
            mSaleEntry.FBCommitQty = 0;
            mSaleEntry.FUnitID = UnitID;
            mSaleEntry.FAuxBCommitQty = 0;
            mSaleEntry.FAuxCommitQty = AuxCommitQty;
            mSaleEntry.FAuxInvoiceQty = 0;
            mSaleEntry.FAuxPrice = currPrice;
            mSaleEntry.FAuxQty = currQty;
            mSaleEntry.FSourceEntryID = 0;
            mSaleEntry.FMapNumber = "";
            mSaleEntry.FMapName = "";
            mSaleEntry.FAuxPropID = 0;
            mSaleEntry.FBatchNo = "";
            mSaleEntry.FCheckDate = null;
            mSaleEntry.FExplanation = "";
            mSaleEntry.FFetchAdd = "";
            mSaleEntry.FFetchDate = currDate;
            mSaleEntry.FMultiCheckDate1 = null;
            mSaleEntry.FMultiCheckDate2 = null;
            mSaleEntry.FMultiCheckDate3 = null;
            mSaleEntry.FMultiCheckDate4 = null;
            mSaleEntry.FMultiCheckDate5 = null;
            mSaleEntry.FMultiCheckDate6 = null;
            mSaleEntry.FSecCoefficient = 0;
            mSaleEntry.FSecQty = 0;
            mSaleEntry.FSecCommitQty = 0;
            mSaleEntry.FSourceTranType = 0;
            mSaleEntry.FSourceInterId = 0;
            mSaleEntry.FSourceBillNo = "";
            mSaleEntry.FContractInterID = 0;
            mSaleEntry.FContractEntryID = 0;
            mSaleEntry.FContractBillNo = "";
            mSaleEntry.FOrderEntryID = 0;
            mSaleEntry.FOrderBillNo = "";
            mSaleEntry.FBackQty = 0;
            mSaleEntry.FAuxBackQty = 0;
            mSaleEntry.FSecBackQty = 0;
            mSaleEntry.FStdAmount = currPrice * currQty;
            mSaleEntry.FPlanMode = 14036;
            mSaleEntry.FMTONo = "";
            mSaleEntry.FStockQty = StockQty;
            mSaleEntry.FAuxStockQty = AuxStockQty;
            mSaleEntry.FSecStockQty = 0;
            mSaleEntry.FSecInvoiceQty = 0;
            mSaleEntry.FDiffQtyClosed = 0;
            mSaleEntry.FAuxStockBillQty = AuxStockBillQty;
            mSaleEntry.FStockBillQty = StockBillQty;
            mSaleEntry.FEntrySelfS0251 = null;
            //mSaleEntry.FEntrySelfS0252 = 40311;
            mSaleEntry.FEntrySelfS0252 = EntrySelfS0252;
            //mSaleEntry.FEntrySelfS0253 = 40635;
            mSaleEntry.FEntrySelfS0253 = EntrySelfS0253;
            mSaleEntry.FEntrySelfS1234 = null;
            mSaleEntry.FEntrySelfS1235 = null;
            //mSaleEntry.FEntrySelfS0254 = "�ӿ���Ƭ";
            mSaleEntry.FEntrySelfS0254 = "";
            mSaleEntry.FEntrySelfS1236 = null;

            return mSaleEntry;
        }
        #endregion

        #endregion

    }

    public enum TemplateType 
    {
        ����,
        �Ǵ�,
        Unknow,
    }
}