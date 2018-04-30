using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using MicrosoftHelper;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class UC_THTonKho : UserControl
    {
        DataTable dtable = new DataTable();
        SYS_USER objuser = new SYS_USER();
        SYS_LOG _sys_log = new SYS_LOG();
        int GlobalRowSelect = 0;
        public UC_THTonKho()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            barSubItem1.Enabled = false;
            barButtonItem4.Enabled = false;
            barButtonItem5.Enabled = false;
            InitLookUpKhoHang();
            ReadXml_User();
            dateNgayTao.DateTime = DateTime.Now;
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_Name";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Quantity", typeof(double));
            dtable.Columns.Add("UnitPrice", typeof(double));
            dtable.Columns.Add("Amount", typeof(double));
            gridControl1.DataSource = dtable;
            txtPhieuDK.Text = CreatePhieuDK();
            repositoryItemLookUpEdit1.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit1.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);

        }
        public UC_THTonKho(frmSoDuDauKy _frm, string PhieuDK)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            barSubItem1.Enabled = false;
            barButtonItem4.Enabled = false;
            barButtonItem5.Enabled = false;
            InitLookUpKhoHang();
            ReadXml_User();
            dateNgayTao.DateTime = DateTime.Now;
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_Name";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Quantity", typeof(double));
            dtable.Columns.Add("UnitPrice", typeof(double));
            dtable.Columns.Add("Amount", typeof(double));
            dtable = new STOCK_INWARD_DETAILController().STOCK_INWARD_DETAIL_GetList_ByID(PhieuDK);
            gridControl1.DataSource = dtable;
            txtPhieuDK.Text = CreatePhieuDK();
            repositoryItemLookUpEdit1.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit1.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);

        }
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        private void InitLookUpKhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpKhoNhap.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpKhoNhap.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpKhoNhap.Properties.ValueMember = "Stock_ID";
            lookUpKhoNhap.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpKhoNhap.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpKhoNhap.EditValue = "K000001";
        }
        public string GetMaPhieu()
        {
            string Trave = "";
            SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
            SqlCommand sqlcmd = con.CreateCommand();
            sqlcmd.CommandText = "select max([RefID]) as ID from [TRANS_REF] where [RefID] like N'DK%'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            DataSet ds = new DataSet();
            //con.Open();
            da.Fill(ds, "TRANS_REF");
            //con.Close();
            DataTable dt_Table = ds.Tables["TRANS_REF"];
            foreach (DataRow datarow in dt_Table.Rows)
            {
                Trave = datarow["ID"].ToString();
            }
            return Trave;
        }
        public string CreatePhieuDK()
        {
            string PhieuBanHang, Temp_BH, Number_PC;
            PhieuBanHang = "DK" + "_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            Temp_BH = GetMaPhieu();
            if (Temp_BH != "")
            {
                Number_PC = Temp_BH.Substring(Temp_BH.Length - 6, 6);
                Number_PC = (long.Parse(Number_PC.ToString()) + 1).ToString();
                PhieuBanHang = Number_PC;
                for (int i = 0; i < 6 - Number_PC.Length; i++)
                {
                    PhieuBanHang = "0" + PhieuBanHang;
                }
                PhieuBanHang = Temp_BH.Substring(0, Temp_BH.Length - 6) + PhieuBanHang;
            }
            return PhieuBanHang;
        }
        public void repositoryItemGridLookUpEdit1View_click(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //XtraMessageBox.Show("ok");
            GlobalRowSelect = (e.RowHandle);
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]) != null)
            {
                string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                objproduct = new PRODUCTController().PRODUCT_Get(test.ToString());
                if (objproduct.Product_Name.Trim() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString())
                {

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Product_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Stock_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], new UNITController().UNIT_Get(objproduct.Unit).Unit_Name);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], 1);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], (objproduct.Org_Price));

                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString()));
            }
        }

        private void lookUpKhoNhap_EditValueChanged(object sender, EventArgs e)
        {
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = 1;
            STOCK_INWARD objstockinward = new STOCK_INWARD();
            STOCK_INWARD_DETAIL objstockinward_detail = new STOCK_INWARD_DETAIL();
            objstockinward.ID = txtPhieuDK.Text;
            objstockinward.RefDate = DateTime.Now;
            objstockinward.RefType = 0;
            //if (lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objstockinward.RefStatus = 0;
            //else
            //    objstockinward.RefStatus = 1;
            objstockinward.PaymentMethod = new Guid("11111111-1111-1111-1111-111111111111");
            objstockinward.TermID = "";
            objstockinward.PaymentDate = dateNgayTao.DateTime;
            objstockinward.DeliveryDate = dateNgayTao.DateTime;
            objstockinward.Barcode = txtPhieuDK.Text;
            objstockinward.Currency_ID = "VND";
            objstockinward.DiscountDate = DateTime.Now;
            objstockinward.User_ID = objuser.UserID;
            objstockinward.Reason = "Nhập Kho";
            objstockinward.Active = true;
            objstockinward.ExchangeRate = 1;
            objstockinward.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstockinward.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            STOCK_INWARDController test = new STOCK_INWARDController();
            objstockinward_detail.Inward_ID = txtPhieuDK.Text;
            objstockinward_detail.RefType = 1;
            if (new STOCK_INWARDController().STOCK_INWARD_Exist(txtPhieuDK.Text) != txtPhieuDK.Text)
            {
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.STOCK_INWARD_Insert(objstockinward);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstockinward_detail.ID = Guid.NewGuid();
                        objstockinward_detail.Stock_ID = lookUpKhoNhap.GetColumnValue("Stock_ID").ToString();
                        objstockinward_detail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockinward_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockinward_detail.Unit = repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns["Unit_ID"], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns["Unit_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objstockinward_detail.UnitConvert = 1;
                        objstockinward_detail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockinward_detail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockinward_detail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Active = true;
                        //objstockinward_detail.Batch = "LOT21012014";
                        objstockinward_detail.Description ="";
                        rsstockdetail = new STOCK_INWARD_DETAILController().STOCK_INWARD_DETAIL_Insert(objstockinward_detail);
                        if (rsstockdetail == -1)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                            break;
                        }
                    }
                    _sys_log.MChine = new MobilityNetwork().GetComputerName();
                    _sys_log.IP = new MobilityNetwork().GetIP();
                    _sys_log.UserID = objuser.UserID;
                    _sys_log.Created = DateTime.Now;
                    _sys_log.Action_Name = "Cập Nhật";
                    _sys_log.Description = "Cập Nhật Phiếu Nhập" + "-" + txtPhieuDK.Text;
                    _sys_log.Reference = txtPhieuDK.Text;
                    _sys_log.Module = "Nhập Kho Đầu Kỳ";
                    _sys_log.Active = true;
                    SYS_LOGController insertlog = new SYS_LOGController();
                    insertlog.SYS_LOG_Insert(_sys_log);

                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            }
            if (rsstock > -1)
            {
                XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void txtNguoiNhan_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNguoiNhan.Text != "")
            {
                barSubItem1.Enabled = true;
                barButtonItem4.Enabled = true;
                barButtonItem5.Enabled = true;
            }
            else
            {
                barSubItem1.Enabled = false;
                barButtonItem4.Enabled = false;
                barButtonItem5.Enabled = false;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
    }
}
