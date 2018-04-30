using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;

namespace SalesManager
{
    public partial class UC_PhieuNhapHang : UserControl
    {
        STOCK_INWARD objstockinward = new STOCK_INWARD();
        STOCK_INWARD_DETAIL objstockinward_detail = new STOCK_INWARD_DETAIL();
        DataTable dtable = new DataTable();
        frmNhapHang main_form;
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        int GlobalRowSelect = 0;
        public UC_PhieuNhapHang()
        {
            InitializeComponent();
            InitLookUpKhoHang();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            barSubItem1.Enabled = false;
            barButtonItem8.Enabled = false;
            barButtonItem9.Enabled = false;
            barButtonItem10.Enabled = false;
            barSubItem3.Enabled = false;
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            lookUpdieukhoan.EditValue = "TM";
            lookUpthanhtoan.EditValue = "TM";
            lookUpNVBH.EditValue = "NV000001";
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            dateEdithan.DateTime = DateTime.Now;
            dateNgayNhap.DateTime = DateTime.Now;
            txtPhieuN.Text = CreatePhieuBanHang();
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            //repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Vat");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao

            gridControl1.DataSource = dtable;
            this.lookUpTenNPP.EditValueChanged += new System.EventHandler(this.lookUpTenNPP_EditValueChanged);
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;

        }
        public UC_PhieuNhapHang(frmNhapHang _nhap, string PhieuNhap)
        {
            InitializeComponent();
            InitLookUpKhoHang();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            txtPhieuN.Text = PhieuNhap;
            main_form = _nhap;
            objstockinward = new STOCK_INWARDController().STOCK_INWARD_Get(PhieuNhap);
            lookUpdieukhoan.EditValue = objstockinward.TermID;
            lookUpthanhtoan.EditValue = new CASH_METHODController().CASH_METHOD_Get(objstockinward.PaymentMethod).Code;
            txtMaNPP.EditValue = objstockinward.Customer_ID;
            lookUpNVBH.EditValue = objstockinward.Employee_ID;
            dateEdithan.DateTime = objstockinward.PaymentDate;
            dateNgayNhap.DateTime = objstockinward.DeliveryDate;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;

            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            //repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Vat");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao
            dtable = new STOCK_INWARD_DETAILController().STOCK_INWARD_DETAIL_GetList_ByID(PhieuNhap);
            gridControl1.DataSource = dtable;
            PROVIDER objprovider = new PROVIDER();
            objprovider = new PROVIDERController().PROVIDER_Get(objstockinward.Customer_ID);
            lookUpTenNPP.EditValue = objstockinward.Customer_ID;
            txtDiaChi.Text = objprovider.CustomerAddress;
            txtDienThoai.Text = objprovider.Tel;
            memoGhiChu.Text = objprovider.Description;
            this.lookUpTenNPP.EditValueChanged += new System.EventHandler(this.lookUpTenNPP_EditValueChanged);
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            //repositoryItemTextEdit1.Click += new EventHandler(repositoryItemLookUpEdit1_DoubleClick);
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
        private void InitLookUpTenKH()
        {
            // Specify the data source to display in the dropdown.
            lookUpTenNPP.Properties.DataSource = new PROVIDERController().PROVIDER_GetList();
            // The field providing the editor's display text.
            lookUpTenNPP.Properties.DisplayMember = "CustomerName";
            // The field matching the edit value.
            lookUpTenNPP.Properties.ValueMember = "Customer_ID";
            lookUpTenNPP.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
        }

        private void InitLookUp_NhanVien()
        {
            // Specify the data source to display in the dropdown.
            lookUpNVBH.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            // The field providing the editor's display text.
            lookUpNVBH.Properties.DisplayMember = "Employee_Name";
            // The field matching the edit value.
            lookUpNVBH.Properties.ValueMember = "Employee_ID";
            lookUpNVBH.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpNVBH.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpNVBH.Properties.AutoSearchColumnIndex = 1;
        }
        private void InitLookUp_dieukhoan()
        {
            // Specify the data source to display in the dropdown.
            lookUpdieukhoan.Properties.DataSource = new CASH_TERMController().CASH_TERM_GetList();
            // The field providing the editor's display text.
            lookUpdieukhoan.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpdieukhoan.Properties.ValueMember = "Code";
            lookUpdieukhoan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpdieukhoan.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpdieukhoan.Properties.AutoSearchColumnIndex = 1;
            lookUpdieukhoan.Invalidate();
        }
        private void InitLookUp_thanhtoan()
        {
            // Specify the data source to display in the dropdown.
            lookUpthanhtoan.Properties.DataSource = new CASH_METHODController().CASH_METHOD_GetList();
            // The field providing the editor's display text.
            lookUpthanhtoan.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpthanhtoan.Properties.ValueMember = "Code";
            lookUpthanhtoan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpthanhtoan.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpthanhtoan.Properties.AutoSearchColumnIndex = 1;
            lookUpthanhtoan.Invalidate();
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
        public int FindIndexGridView(string ProductID)
        {
            int trave = -1;
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString() == ProductID)
                    {
                        trave = i;
                        break;
                    }
                }
            }
            return trave;
        }
        public string CreatePhieuBanHang()
        {
            string PhieuNhapHang, Temp_BH, Number_PC;
            PhieuNhapHang = "BH_" + objuser.UserName + "_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            string _stockout_PC = new STOCK_INWARDController().SaleOrder_Search(objuser.UserName);
            Temp_BH = _stockout_PC;
            if (Temp_BH != "")
            {
                Number_PC = Temp_BH.Substring(Temp_BH.Length - 6, 6);
                Number_PC = (long.Parse(Number_PC.ToString()) + 1).ToString();
                PhieuNhapHang = Number_PC;
                for (int i = 0; i < 6 - Number_PC.Length; i++)
                {
                    PhieuNhapHang = "0" + PhieuNhapHang;
                }
                PhieuNhapHang = Temp_BH.Substring(0, Temp_BH.Length - 6) + PhieuNhapHang;
            }
            return PhieuNhapHang;
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
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], "1");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], double.Parse(repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Org_Price")));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], objproduct.VAT_ID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8], objproduct.Discount);

                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString()));
            }
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

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtPhieuN.Text = CreatePhieuBanHang();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            //InitLookUpMaKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            InitLookUpKhoHang();
            dtable.Rows.Clear();
        }

        private void lookUpTenNPP_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNPP.Text = lookUpTenNPP.Properties.GetKeyValue(gridLookUpEdit2View.FocusedRowHandle).ToString();
            PROVIDER objprovider = new PROVIDER();
            objprovider = new PROVIDERController().PROVIDER_Get(txtMaNPP.Text);
            txtDiaChi.Text = objprovider.CustomerAddress;
            txtDienThoai.Text = objprovider.Tel;
            memoGhiChu.Text = objprovider.Description;
            barSubItem1.Enabled = true;
            barSubItem1.Enabled = true;
            barButtonItem8.Enabled = true;
            barButtonItem9.Enabled = true;
            barButtonItem10.Enabled = true;
            barSubItem3.Enabled = true;
        }
        //private void lookUpMaNPP_EditValueChanged(object sender, EventArgs e)
        //{
        //    PROVIDER objprovider = new PROVIDER();
        //    objprovider = new PROVIDERController().PROVIDER_Get(lookUpMaNPP.Text);
        //    lookUpTenNPP.EditValue = lookUpMaNPP.Text;
        //    txtDiaChi.Text = objprovider.CustomerAddress;
        //    txtDienThoai.Text = objprovider.Tel;
        //    memoGhiChu.Text = objprovider.Description;
        //}
        

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int rsstock = 1;
            objstockinward.ID = txtPhieuN.Text;
            objstockinward.RefDate = DateTime.Now;
            objstockinward.RefType = 1;
            //if (lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
                objstockinward.RefStatus = 0;
            //else
            //    objstockinward.RefStatus = 1;
            objstockinward.PaymentMethod = new Guid(lookUpthanhtoan.GetColumnValue("ID").ToString());
            objstockinward.TermID = lookUpdieukhoan.GetColumnValue("Code").ToString();
            objstockinward.PaymentDate = dateNgayNhap.DateTime;
            objstockinward.DeliveryDate = dateEdithan.DateTime;
            objstockinward.Barcode = txtPhieuN.Text;
            objstockinward.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstockinward.Customer_ID = txtMaNPP.Text;
            objstockinward.CustomerName = lookUpTenNPP.Text;
            objstockinward.CustomerAddress = txtDiaChi.Text;
            objstockinward.Currency_ID = "VND";
            objstockinward.DiscountDate = DateTime.Now;
            objstockinward.User_ID = objuser.UserID;
            objstockinward.Reason = "Nhập Kho";
            objstockinward.Active = true;
            objstockinward.ExchangeRate = 1;
            objstockinward.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstockinward.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            STOCK_INWARDController test = new STOCK_INWARDController();
            objstockinward_detail.Inward_ID = txtPhieuN.Text;
            objstockinward_detail.RefType = 1;
            if (new STOCK_INWARDController().STOCK_INWARD_Exist(txtPhieuN.Text) == txtPhieuN.Text)
            {
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.STOCK_INWARD_Update(objstockinward, objstockinward.ID);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        if (gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString() != "")
                            objstockinward_detail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns["ID"]).ToString());
                        else
                            objstockinward_detail.ID = Guid.NewGuid();
                        objstockinward_detail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        objstockinward_detail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockinward_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockinward_detail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objstockinward_detail.UnitConvert = 1;
                        objstockinward_detail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockinward_detail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                        objstockinward_detail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Active = true;
                        //objstockinward_detail.Batch = "LOT21012014";
                        objstockinward_detail.Description = lookUpTenNPP.Text;
                        rsstockdetail = new STOCK_INWARD_DETAILController().STOCK_INWARD_DETAIL_Update(objstockinward_detail);
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
                    _sys_log.Description = "Cập Nhật Phiếu Nhập" + "-" + txtPhieuN.Text;
                    _sys_log.Reference = txtPhieuN.Text;
                    _sys_log.Module = "Phiếu Nhập";
                    _sys_log.Active = true;
                    SYS_LOGController insertlog = new SYS_LOGController();
                    insertlog.SYS_LOG_Insert(_sys_log);

                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            }
            else
            {
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.STOCK_INWARD_Insert(objstockinward);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstockinward_detail.ID = Guid.NewGuid();
                        objstockinward_detail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        objstockinward_detail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockinward_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockinward_detail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objstockinward_detail.UnitConvert = 1;
                        objstockinward_detail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockinward_detail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                        objstockinward_detail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockinward_detail.Active = true;
                        //objstockinward_detail.Batch = "LOT21112013";
                        objstockinward_detail.Description = lookUpTenNPP.Text;
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
                    _sys_log.Action_Name = "Thêm";
                    _sys_log.Description = "Thêm Phiếu Nhập" + "-" + txtPhieuN.Text;
                    _sys_log.Reference = txtPhieuN.Text;
                    _sys_log.Module = "Phiếu Nhập";
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
                txtPhieuN.Text = CreatePhieuBanHang();
                InitLookUp_dieukhoan();
                InitLookUp_thanhtoan();
                InitLookUpTenKH();
                //InitLookUpMaKH();
                InitLookUp_NhanVien();
                ReadXml_User();
                InitLookUpKhoHang();
                dtable.Rows.Clear();
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteSelectedRows();

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.SelectAll();
        }

        private void chkmavach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmavach.Checked == true)
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
                lookUpTenNPP.Focus();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (e.KeyCode == Keys.Enter)
            {
                objproduct = new PRODUCTController().PRODUCT_Getbybarcode(txtBarcode.Text.Trim());
                if (objproduct.Product_ID != "")
                {
                    gridLookUpEdit1.EditValue = objproduct.Product_ID;
                    calcdongia.Value = (decimal)objproduct.Org_Price;
                    calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                    txtBarcode.Text = "";
                    if (cbohanhdong.SelectedIndex == 0)
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        dtable.Rows.Add(rows);
                    }
                    else if (cbohanhdong.SelectedIndex == 1)
                    {
                        if (FindIndexGridView(objproduct.Product_ID) > -1)
                        {
                            for (int i = 0; i < gridView1.RowCount - 1; i++)
                            {
                                if (gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString() == objproduct.Product_ID)
                                {
                                    gridView1.SetRowCellValue(i, gridView1.Columns[4], (decimal)calcsoluong.Value);
                                    gridView1.SetRowCellValue(i, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString()));
                                    gridView1.RefreshData();

                                }
                            }
                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["ProductName"] = objproduct.Product_Name;
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            dtable.Rows.Add(rows);
                        }
                    }
                    else if (cbohanhdong.SelectedIndex == 2)
                    {
                        int i = FindIndexGridView(objproduct.Product_ID);
                        if (i > -1)
                        {
                            //XtraMessageBox.Show(FindIndexGridView(objproduct.Product_ID).ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns[4], decimal.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) + (decimal)calcsoluong.Value);
                            gridView1.SetRowCellValue(i, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString()));
                            gridView1.RefreshData();

                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["ProductName"] = objproduct.Product_Name;
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            dtable.Rows.Add(rows);
                        }
                    }
                    else if (cbohanhdong.SelectedIndex == 3)
                    {
                        if (FindIndexGridView(objproduct.Product_ID) > -1)
                        {
                            XtraMessageBox.Show("Hàng hóa bị trùng!", "Thông Báo");
                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["ProductName"] = objproduct.Product_Name;
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            dtable.Rows.Add(rows);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy sản phẩm", "Thông Báo");
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridLookUpEdit1.Text != "")
            {
                objproduct = new PRODUCTController().PRODUCT_Get(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
                gridLookUpEdit1.EditValue = objproduct.Product_ID;
                calcdongia.Value = (decimal)objproduct.Org_Price;
                calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                txtBarcode.Text = "";
                if (cbohanhdong.SelectedIndex == 0)
                {
                    DataRow rows = dtable.NewRow();
                    rows["Product_ID"] = objproduct.Product_ID;
                    rows["ProductName"] = objproduct.Product_Name;
                    rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                    rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                    rows["Quantity"] = calcsoluong.Value;
                    rows["UnitPrice"] = calcdongia.Value;
                    rows["Amount"] = calcthanhtien.Value;
                    rows["Discount"] = objproduct.Discount;
                    rows["Vat"] = objproduct.VAT_ID;
                    dtable.Rows.Add(rows);
                }
                else if (cbohanhdong.SelectedIndex == 1)
                {
                    if (FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")) > -1)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            if (gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString() == gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"))
                            {
                                gridView1.SetRowCellValue(i, gridView1.Columns[4], (decimal)calcsoluong.Value);
                                gridView1.SetRowCellValue(i, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString()));
                                gridView1.RefreshData();

                            }
                        }
                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        dtable.Rows.Add(rows);
                    }
                }
                else if (cbohanhdong.SelectedIndex == 2)
                {
                    int i = FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
                    if (i > -1)
                    {
                        //XtraMessageBox.Show(FindIndexGridView(objproduct.Product_ID).ToString());
                        gridView1.SetRowCellValue(FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")), gridView1.Columns[4], decimal.Parse(gridView1.GetRowCellValue(FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")), gridView1.Columns[4]).ToString()) + (decimal)calcsoluong.Value);
                        gridView1.SetRowCellValue(i, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString()));
                        gridView1.RefreshData();

                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        dtable.Rows.Add(rows);
                    }
                }
                else if (cbohanhdong.SelectedIndex == 3)
                {
                    if (FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")) > -1)
                    {
                        XtraMessageBox.Show("Hàng hóa bị trùng!", "Thông Báo");
                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMin(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        dtable.Rows.Add(rows);
                    }
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInPhieuNhapHang frm = new frmInPhieuNhapHang(txtPhieuN.Text);
            frm.Show();
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            objproduct = new PRODUCTController().PRODUCT_Get(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
            calcdongia.Value = (decimal)objproduct.Org_Price;
            calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
        }

        private void lookUpKhoNhap_EditValueChanged(object sender, EventArgs e)
        {
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoNhap.GetColumnValue("Stock_ID").ToString());

        }
    }
}
