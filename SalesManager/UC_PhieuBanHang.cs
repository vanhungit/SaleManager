using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using SalesManager.Entity;
using System.Collections;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Base;
using SimpleDialog;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;

namespace SalesManager
{
    public partial class UC_PhieuBanHang : UserControl
    {
        private InputBoxResultType validationType = InputBoxResultType.Any;
        STOCK_OUTWARD objstock = new STOCK_OUTWARD();
        STOCK_OUTWARD_DETAIL objstockdetail = new STOCK_OUTWARD_DETAIL();
        DataTable dtable = new DataTable();
        string[] DanhSach = new string[100];
        frmBanHang main_form;
        int GlobalRowSelect = 0;
        const char ESC = (char)0x1B;
        const char GS = (char)0x1D;
        const char LF = (char)0x0A;
        double KhachTra = 0;
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        public UC_PhieuBanHang(frmBanHang _frm)
        {
            InitializeComponent();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            //InitLookUpMaKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            InitLookUpKhoHang();
            barSubItem1.Enabled = false;
            barButtonItem7.Enabled = false;
            barButtonItem8.Enabled = false;
            barButtonItem9.Enabled = false;
            barSubItem3.Enabled = false;
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            lookUpdieukhoan.EditValue = "TM";
            lookUpthanhtoan.EditValue = "TM";
            lookUpNVBH.EditValue = objuser.PartID;
            dateEdithan.DateTime = DateTime.Now;
            dateNgayBan.DateTime = DateTime.Now;
            dateNgayGiao.DateTime = DateTime.Now;
            txtPhieuBH.Text = CreatePhieuBanHang();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridLookUpEdit2View.Invalidate();
            gridLookUpEdit2View.IndicatorWidth = 35;

            main_form = _frm;
            //gridControl1.UseEmbeddedNavigator = true;
            gridControl1.ShowOnlyPredefinedDetails = true;
            #region MaHang
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;
           /* repositoryItemLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            //repositoryItemLookUpEdit1.Properties.DisplayMember = "Product_ID";
            // The field matching the edit value.
            repositoryItemLookUpEdit1.Properties.ValueMember = "Product_ID";
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;
            */
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_Name";
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            #endregion
            //gridControl1.DataSource = new INVENTORYController().sp_PRODUCT_GetByStore_Group();
            //DataTable dtable = new DataTable();
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Size");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Vat");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("DiscountRate");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Charge");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao

            //gridControl1.DataSource = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_GetList();
            gridControl1.DataSource = dtable;
            //gridView1.Columns[1].ColumnEdit = repositoryItemLookUpEdit1;//Thêm cái này sẽ thêm 1 cột nữa đc lookupitem
            //repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(repositoryItemLookUpEdit1_EditValueChanged);
            //repositoryItemTextEdit1.Click += new EventHandler(repositoryItemLookUpEdit1_DoubleClick);
            //gridView1.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            //gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            //gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            //this.lookUpMaKH.EditValueChanged += new System.EventHandler(this.lookUpMaKH_EditValueChanged);
            this.lookUpTenKH.EditValueChanged += new System.EventHandler(this.lookUpTenKH_EditValueChanged);
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            gridView1.RefreshData();
        }
        public UC_PhieuBanHang(frmBanHang _nhap,string Phieuxuat)
        {
            InitializeComponent();
            InitLookUpKhoHang();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            //InitLookUpMaKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            objstock = new STOCK_OUTWARDController().STOCK_OUTWARD_Get(Phieuxuat);
            main_form = _nhap;
            txtPhieuBH.Text = Phieuxuat;
            lookUpdieukhoan.EditValue = objstock.TermID;
            lookUpthanhtoan.EditValue = new CASH_METHODController().CASH_METHOD_Get(objstock.PaymentMethod).Code;
            txtMaKH.Text  = objstock.Customer_ID;
            lookUpNVBH.EditValue = objstock.Employee_ID;
            dateEdithan.DateTime = objstock.DeliveryDate;
            dateNgayBan.DateTime = objstock.RefDate;
            dateNgayGiao.DateTime = objstock.PaymentDate;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridLookUpEdit2View.Invalidate();
            gridLookUpEdit2View.IndicatorWidth = 35;

            //gridControl1.UseEmbeddedNavigator = true;
            gridControl1.ShowOnlyPredefinedDetails = true;
            #region MaHang
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new STOCKController().STOCK_GetList();
            repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            #endregion
            //gridControl1.DataSource = new INVENTORYController().sp_PRODUCT_GetByStore_Group();
            //DataTable dtable = new DataTable();
            dtable.Columns.Add("Product_ID",typeof(string));
            dtable.Columns.Add("ProductName",typeof(string));
            dtable.Columns.Add("Stock_Name", typeof(string));
            dtable.Columns.Add("Unit_Name", typeof(string));
            dtable.Columns.Add("Size", typeof(long));
            dtable.Columns.Add("Quantity", typeof(double));
            dtable.Columns.Add("UnitPrice", typeof(double));
            dtable.Columns.Add("Vat", typeof(double));
            dtable.Columns.Add("Amount", typeof(double));
            dtable.Columns.Add("DiscountRate", typeof(double));
            dtable.Columns.Add("Discount", typeof(double));
            dtable.Columns.Add("Charge", typeof(double));
            dtable.Columns.Add("Description", typeof(string));
            dtable.Columns.Add("ID", typeof(string));//them vao
            dtable = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_GetList_ByID(Phieuxuat);
            //gridControl1.DataSource = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_GetList();
            gridControl1.DataSource = dtable;
            //gridView1.Columns[1].ColumnEdit = repositoryItemLookUpEdit1;//Thêm cái này sẽ thêm 1 cột nữa đc lookupitem
            //repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(repositoryItemLookUpEdit1_EditValueChanged);
            //repositoryItemTextEdit1.Click += new EventHandler(repositoryItemLookUpEdit1_DoubleClick);
            //gridView1.FocusRectStyle = DrawFocusRectStyle.CellFocus;
            //gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            //gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            CUSTOMER _customer = new CUSTOMER();
            _customer = new CUSTOMERController().LayTTCUSTOMER(objstock.Customer_ID);
            lookUpTenKH.EditValue = objstock.Customer_ID;
            txtDiaChi.Text = _customer.CustomerAddress;
            txtDienThoai.Text = _customer.Tel;
            memoGhiChu.Text = _customer.Description;
            //this.lookUpMaKH.EditValueChanged += new System.EventHandler(this.lookUpMaKH_EditValueChanged);
            this.lookUpTenKH.EditValueChanged += new System.EventHandler(this.lookUpTenKH_EditValueChanged);
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            gridView1.RefreshData();

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
        private void InitLookUpTenKH()
        {
            // Specify the data source to display in the dropdown.
            lookUpTenKH.Properties.DataSource = new CUSTOMERController().LayDSCUSTOMER();
            // The field providing the editor's display text.
            lookUpTenKH.Properties.DisplayMember = "CustomerName";
            // The field matching the edit value.
            lookUpTenKH.Properties.ValueMember = "Customer_ID";
            lookUpTenKH.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //lookUpTenKH.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            //lookUpTenKH.Properties.AutoSearchColumnIndex = 1;
        }
        //private void InitLookUpMaKH()
        //{
        //    // Specify the data source to display in the dropdown.
        //    gridLookUpMK.Properties.DataSource = new CUSTOMERController().LayDSCUSTOMER();
        //    // The field providing the editor's display text.
        //    gridLookUpMK.Properties.DisplayMember = "Customer_ID";
        //    // The field matching the edit value.
        //    gridLookUpMK.Properties.ValueMember = "Customer_ID";
        //    gridLookUpMK.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

        //    // Enable auto completion search mode.
        //    //gridLookUpMK.Properties.SearchMode = SearchMode.AutoComplete;
        //    //// Specify the column against which to perform the search.
        //    //gridLookUpMK.Properties.AutoSearchColumnIndex = 1;
        //}
        private void InitLookUpKhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpKhoXuat.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpKhoXuat.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpKhoXuat.Properties.ValueMember = "Stock_ID";
            lookUpKhoXuat.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpKhoXuat.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpKhoXuat.EditValue = "K000001";
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
        void AddRow(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            int currentRow;
            currentRow = view.FocusedRowHandle;
            if (currentRow < 0)
                currentRow = view.GetDataRowHandleByGroupRowHandle(currentRow);
            view.AddNewRow();

            if (view.SortInfo.GroupCount == 0) return;

            //Initialize group values
            foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in view.GroupedColumns)
            {
                object val = view.GetRowCellValue(currentRow, groupColumn);
                view.SetRowCellValue(view.FocusedRowHandle, groupColumn, val);
            }
            view.UpdateCurrentRow();
            view.ShowEditor();
        }
        /// <summary>
        /// Hàm khởi tạo Phiếu Bán Hàng
        /// </summary>
        /// <returns></returns>
        public string CreatePhieuBanHang()
        {
            string PhieuBanHang, Temp_BH, Number_PC;
            PhieuBanHang = "BH_" + objuser.UserName + "_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            string _stockout_PC = new STOCK_OUTWARDController().HoaDon_Search(objuser.UserName);
            Temp_BH = _stockout_PC;
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
        private void lookUpTenKH_EditValueChanged(object sender, EventArgs e)
        {
            CUSTOMER _customer = new CUSTOMER();
            _customer = new CUSTOMERController().LayTTCUSTOMER(lookUpTenKH.Properties.GetKeyValue(gridLookUpEdit2View.FocusedRowHandle).ToString());
            txtMaKH.Text = _customer.Customer_ID;
            txtDiaChi.Text = _customer.CustomerAddress;
            txtDienThoai.Text = _customer.Tel;
            memoGhiChu.Text = _customer.Description;
            barSubItem1.Enabled = true;
            barButtonItem7.Enabled = true;
            barButtonItem8.Enabled = true;
            barButtonItem9.Enabled = true;
            barSubItem3.Enabled = true;
        }
        

        private void lookUpMaKH_EditValueChanged(object sender, EventArgs e)
        {
            CUSTOMER _customer = new CUSTOMER();
            //_customer = new CUSTOMERController().LayTTCUSTOMER(gridLookUpMK("Customer_ID").ToString());
            //lookUpTenKH.EditValue = lookUpMaKH.GetColumnValue("Customer_ID").ToString();
            txtDiaChi.Text = _customer.CustomerAddress;
            txtDienThoai.Text = _customer.Tel;
            memoGhiChu.Text = _customer.Description;

        }
        
        public void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], "iii");
            string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0],test)));
            //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10], "111");
            //XtraMessageBox.Show(test);
        }
        public void repositoryItemLookUpEdit1_DoubleClick(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]) != null)
            {
                string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                objproduct = new PRODUCTController().PRODUCT_Get(test.ToString());
                if (repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString())
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[3], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], new UNITController().UNIT_Get(objproduct.Unit).Unit_Name);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], "1");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], "3");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[6], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString()));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7], objproduct.VAT_ID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9], objproduct.Discount);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10], objproduct.Discount);
                }
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString() == "1")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[4], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString()));
                }
                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString() == "2")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[5], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString()));
                }
                else
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[6], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString()));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));

            }
            //XtraMessageBox.Show(repositoryItemLookUpEdit1.GetDataSourceValue(repositoryItemLookUpEdit1.Columns[1], repositoryItemLookUpEdit1.GetDataSourceRowIndex(repositoryItemLookUpEdit1.Columns[0], test)).ToString());
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string Thu = new STOCK_OUTWARDController().STOCK_OUTWARD_Exist(txtPhieuBH.Text).ToString();
            if ((Thu != txtPhieuBH.Text) && (dtable.Rows.Count > 0))
            {
                MessageBox.Show("Luu Phieu nay roi moi tao phieu moi");
            }
            else
            {
                txtPhieuBH.Text = CreatePhieuBanHang();
                InitLookUp_dieukhoan();
                InitLookUp_thanhtoan();
                InitLookUpTenKH();
                //InitLookUpMaKH();
                InitLookUp_NhanVien();
                ReadXml_User();
                InitLookUpKhoHang();
                dtable.Rows.Clear();
                calctong.Value = 0;
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Stock
            int rsstock = -1;
            objstock.ID = txtPhieuBH.Text;
            objstock.RefDate = DateTime.Now;
            objstock.RefType = 2;
            //if(lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objstock.RefStatus = 0;
            //else
            //    objstock.RefStatus = 1;
            objstock.PaymentMethod = new Guid(lookUpthanhtoan.GetColumnValue("ID").ToString());
            objstock.TermID = lookUpdieukhoan.GetColumnValue("Code").ToString();
            objstock.PaymentDate = dateNgayGiao.DateTime;
            objstock.DeliveryDate = dateEdithan.DateTime;
            objstock.Barcode = txtPhieuBH.Text;
            objstock.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstock.Customer_ID = txtMaKH.Text;
            objstock.CustomerName = lookUpTenKH.Text;
            objstock.CustomerAddress = txtDiaChi.Text;
            objstock.Currency_ID = "VND";
            objstock.DiscountDate = DateTime.Now;
            objstock.User_ID = objuser.UserID;
            objstock.Active = true;
            objstock.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstock.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            STOCK_OUTWARDController test = new STOCK_OUTWARDController();
            #endregion
            objstockdetail.Outward_ID = txtPhieuBH.Text;
            objstockdetail.RefType = 2;
            string Thu = new STOCK_OUTWARDController().STOCK_OUTWARD_Exist(txtPhieuBH.Text).ToString();
            if (Thu == txtPhieuBH.Text)
            {
                rsstock = test.STOCK_OUTWARD_Update(objstock,objstock.ID);
                if (gridView1.RowCount > 1)
                {
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        if(gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString() != "")
                            objstockdetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString());
                        else
                            objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Update(objstockdetail);
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
                    _sys_log.Description = "Cập Nhật Phiếu Xuất" + "-" + txtPhieuBH.Text;
                    _sys_log.Reference = txtPhieuBH.Text;
                    _sys_log.Module = "Phiếu Xuất";
                    _sys_log.Active = true;
                    SYS_LOGController insertlog = new SYS_LOGController();
                    insertlog.SYS_LOG_Insert(_sys_log);
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            }
            else
            {
                #region Stock detail
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.STOCK_OUTWARD_Insert(objstock);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Insert(objstockdetail);
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
                    _sys_log.Description = "Thêm Phiếu Xuất" + "-" + txtPhieuBH.Text;
                    _sys_log.Reference = txtPhieuBH.Text;
                    _sys_log.Module = "Phiếu Xuất";
                    _sys_log.Active = true;
                    SYS_LOGController insertlog = new SYS_LOGController();
                    insertlog.SYS_LOG_Insert(_sys_log);
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
                #endregion
                
            }
            if (rsstock > -1)
            {
                XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
                if (chkin.Checked == true)
                {
                    PRINT_RAW objprint = new PRINT_RAW();
                    FontConvert objfont = new FontConvert();
                    string output = Convert.ToChar(27) + "@" + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Công Ty TNHH Công Nghệ Song Phát.") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("61 Lương Hữu Khánh, Q.1, TP. HCM") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Tel : 9255 330 Fax: 9255 329") + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + ("PHIEU TINH TIEN") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "@" + Convert.ToChar(27) + "t" + Convert.ToChar(30) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Số TT", 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("Sản Phẩm", 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Giá Trị", 8)) + Convert.ToChar(10);
                    if (gridView1.RowCount > 1)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai((i + 1).ToString(), 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString(), 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() + "đ", 8)) + Convert.ToChar(10);
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString(), 20)) + "x" + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString() + "đ", 19)) + Convert.ToChar(10);
                        }
                    }
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + objfont.UnicodeToTvcn3("= Tổng cộng:") + objfont.CanhPhai(calctong.Text + objfont.UnicodeToTvcn3("đ"), 12) + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(0) + objfont.UnicodeToTvcn3("Số Lượng Mặt Hàng:") + objfont.CanhPhai((gridView1.Columns["Quantity"].SummaryItem.SummaryValue).ToString(), 30) + Convert.ToChar(10);
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + ("TIEN MAT (VND)") + objfont.CanhPhai(KhachTra.ToString() + objfont.UnicodeToTvcn3("đ"), 34) + Convert.ToChar(10);
                    output = output + ("TIEN THOI LAI =====>") + objfont.CanhPhai(double.Parse(calctong.Text) - KhachTra + objfont.UnicodeToTvcn3("đ"), 28) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("T.Suất", 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("GB chưa có GTGT", 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Thuế GTGT", 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("1>" + calcdiscountp.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcdiscountamount.Text, 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("2>" + calcvat.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcvatamount.Text, 9)) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Th.ngân: " + objfont.convertToUnSign2(lookUpNVBH.GetColumnValue("Employee_Name").ToString()), 48)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Ticket: " + txtPhieuBH.Text, 24)) + " " + objfont.CanhPhai(String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), 23) + Convert.ToChar(10) + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Cảm ơn Quý Khách!") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Hẹn gặp lại!") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "!" + Convert.ToChar(9) + objfont.UnicodeToTvcn3("Website : www.shopmini.com.vn") + Convert.ToChar(10);

                    output = output + Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0) + Convert.ToChar(10);
                    objprint.SendStringToPrinter(new PRINTERMAPPINGController().Printer_Mapping_Get("Receipt").Details, output);
                }
                txtPhieuBH.Text = CreatePhieuBanHang();
                InitLookUp_dieukhoan();
                InitLookUp_thanhtoan();
                InitLookUpTenKH();
                //InitLookUpMaKH();
                InitLookUp_NhanVien();
                ReadXml_User();
                InitLookUpKhoHang();
                dtable.Rows.Clear();
                calctong.Value = 0;
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

       

        private void gridControl1_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]) != null)
            {
                string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                objproduct = new PRODUCTController().PRODUCT_Get(test.ToString());
                //if(repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(repositoryItemGridLookUpEdit1View.FocusedRowHandle,"Product_Name") != gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString())

                if (objproduct.Product_Name.Trim() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString())
                {

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Product_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Stock_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], new UNITController().UNIT_Get(objproduct.Unit).Unit_Name);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], "1");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], "3");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], double.Parse(repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Retail_Price")));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7], objproduct.VAT_ID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9], objproduct.Discount);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10], objproduct.Discount);
                   
                }
                
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString() == "1")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], objproduct.Org_Price);
                }
                else if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString() == "2")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], objproduct.Sale_Price);
                }
                else
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], objproduct.Retail_Price);
                 
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString())*double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[9]).ToString()));
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString()) - double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[10]).ToString()));
                calcdiscountamount.Value = (decimal)(calcdiscountp.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                calcvatamount.Value = (decimal)(calcvat.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                calctong.Value = decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString()) - (decimal)calcdiscountamount.Value + (decimal)calcvatamount.Value;
 
            }
             
        }
        public void repositoryItemGridLookUpEdit1View_click(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //XtraMessageBox.Show("ok");
            GlobalRowSelect = (e.RowHandle);
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
             */
            //XtraMessageBox.Show(repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString());
            //XtraMessageBox.Show(repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], test).ToString());
        
            /*
            for (int i = 0; i < gridView1.RowCount -1; i++)
            {
                XtraMessageBox.Show(gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString());
            }
             */
            if (dtable.Rows.Count > 0)
            {
                DialogResult KetQua = MessageBox.Show("Bạn có muốn thoát khi phiếu chưa lưu?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (KetQua == DialogResult.Yes)
                {
                    main_form.Close();
                }
            }
            else
                main_form.Close();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.ShowDialog();
        }
        public void HamThanhToan(double KhachDua, double ConLai)
        {
            #region Stock
            int rsstock = -1;
            objstock.ID = txtPhieuBH.Text;
            objstock.RefDate = DateTime.Now;
            objstock.RefType = 2;
            //if(lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objstock.RefStatus = 0;
            KhachTra = KhachDua;
            
            //else
            //    objstock.RefStatus = 1;
            objstock.PaymentMethod = new Guid(lookUpthanhtoan.GetColumnValue("ID").ToString());
            objstock.TermID = lookUpdieukhoan.GetColumnValue("Code").ToString();
            objstock.PaymentDate = dateNgayGiao.DateTime;
            objstock.DeliveryDate = dateEdithan.DateTime;
            objstock.Barcode = txtPhieuBH.Text;
            objstock.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstock.Customer_ID = txtMaKH.Text;
            objstock.CustomerName = lookUpTenKH.Text;
            objstock.CustomerAddress = txtDiaChi.Text;
            objstock.Currency_ID = "VND";
            objstock.DiscountDate = DateTime.Now;
            objstock.User_ID = objuser.UserID;
            objstock.Active = true;
            objstock.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstock.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            STOCK_OUTWARDController test = new STOCK_OUTWARDController();
            #endregion
            objstockdetail.Outward_ID = txtPhieuBH.Text;
            objstockdetail.RefType = 2;
            string Thu = new STOCK_OUTWARDController().STOCK_OUTWARD_Exist(txtPhieuBH.Text).ToString();
            if (Thu == txtPhieuBH.Text)
            {
                rsstock = test.STOCK_OUTWARD_Update(objstock, objstock.ID);
                if (gridView1.RowCount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        if (gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString() != "")
                            objstockdetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString());
                        else
                            objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Update(objstockdetail);
                        if (rsstockdetail == -1)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                            break;
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            }
            else
            {
                #region Stock detail
                if (gridView1.RowCount > 0)
                {
                    rsstock = test.STOCK_OUTWARD_Insert(objstock);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Insert(objstockdetail);
                        if (rsstockdetail == -1)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                            break;
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
                #endregion

            }
            if (rsstock > -1)
            {
                //XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
                INVOICE objinvoice = new INVOICE();
                objinvoice.RefNo = txtPhieuBH.Text;
                objinvoice.RefDate = dateNgayBan.DateTime;
                objinvoice.RefType = 1;
                objinvoice.RefStatus = 1;
                objinvoice.PrintCount = 1;
                objinvoice.StockID = lookUpKhoXuat.GetColumnValue("Stock_ID").ToString();
                objinvoice.TongTien = (double)(calctong.Value);
                objinvoice.KhachTra = KhachDua;
                objinvoice.ConLai = ConLai;
                objinvoice.CreateBy = objuser.UserID;
                objinvoice.Createdate = DateTime.Now;
                objinvoice.ModifyBy = objuser.UserID;
                objinvoice.ModifyDate = DateTime.Now;
                objinvoice.Active = true;
                int trave = (new INVOICE_Controller().INVOICE_Insert(objinvoice));
                if (chkin.Checked == true)
                {
                    PRINT_RAW objprint = new PRINT_RAW();
                    FontConvert objfont = new FontConvert();
                    string output = Convert.ToChar(27) + "@" + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("SIEU THI HOANG ANH MART") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("TTM4, tòa nhà Sunview Town Block B") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Tel : 9255 330 Fax: 9255 329") + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + ("PHIEU TINH TIEN") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "@" + Convert.ToChar(27) + "t" + Convert.ToChar(30) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Số TT", 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("Sản Phẩm", 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Giá Trị", 8)) + Convert.ToChar(10);
                    if (gridView1.RowCount > 1)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai((i + 1).ToString(), 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString(), 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() + "đ", 8)) + Convert.ToChar(10);
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString(), 20)) + "x" + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString() + "đ", 19)) + Convert.ToChar(10);
                        }
                    }
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + objfont.UnicodeToTvcn3("= Tổng cộng:") + objfont.CanhPhai(calctong.Text + objfont.UnicodeToTvcn3("đ"), 12) + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(0) + objfont.UnicodeToTvcn3("Số Lượng Mặt Hàng:") + objfont.CanhPhai((gridView1.Columns["Quantity"].SummaryItem.SummaryValue).ToString(), 30) + Convert.ToChar(10);
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + ("TIEN MAT (VND)") + objfont.CanhPhai(KhachTra.ToString() + objfont.UnicodeToTvcn3("đ"), 34) + Convert.ToChar(10);
                    output = output + ("TIEN THOI LAI =====>") + objfont.CanhPhai(double.Parse(calctong.Text) - KhachTra + objfont.UnicodeToTvcn3("đ"), 28) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("T.Suất", 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("GB chưa có GTGT", 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Thuế GTGT", 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("1>" + calcdiscountp.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcdiscountamount.Text, 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("2>" + calcvat.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcvatamount.Text, 9)) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Th.ngân: " + objfont.convertToUnSign2(lookUpNVBH.GetColumnValue("Employee_Name").ToString()), 48)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Ticket: " + txtPhieuBH.Text, 24)) + " " + objfont.CanhPhai(String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), 23) + Convert.ToChar(10) + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Cảm ơn Quý Khách!") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Hẹn gặp lại!") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "!" + Convert.ToChar(9) + objfont.UnicodeToTvcn3("Website : www.shopmini.com.vn") + Convert.ToChar(10);

                    output = output + Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0) + Convert.ToChar(10);
                    objprint.SendStringToPrinter("EPSON TM-T82 Receipt", output);
                }
                txtPhieuBH.Text = CreatePhieuBanHang();
                InitLookUp_dieukhoan();
                InitLookUp_thanhtoan();
                InitLookUpTenKH();
                //InitLookUpMaKH();
                InitLookUp_NhanVien();
                ReadXml_User();
                InitLookUpKhoHang();
                dtable.Rows.Clear();
                calctong.Value = 0;
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Stock
            int rsstock = -1;
            objstock.ID = txtPhieuBH.Text;
            objstock.RefDate = DateTime.Now;
            objstock.RefType = 2;
            //if(lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objstock.RefStatus = 0;
            //else
            //    objstock.RefStatus = 1;
            objstock.PaymentMethod = new Guid(lookUpthanhtoan.GetColumnValue("ID").ToString());
            objstock.TermID = lookUpdieukhoan.GetColumnValue("Code").ToString();
            objstock.PaymentDate = dateNgayGiao.DateTime;
            objstock.DeliveryDate = dateEdithan.DateTime;
            objstock.Barcode = txtPhieuBH.Text;
            objstock.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstock.Customer_ID = txtMaKH.Text;
            objstock.CustomerName = lookUpTenKH.Text;
            objstock.CustomerAddress = txtDiaChi.Text;
            objstock.Currency_ID = "VND";
            objstock.DiscountDate = DateTime.Now;
            objstock.User_ID = objuser.UserID;
            objstock.Active = true;
            objstock.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstock.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            STOCK_OUTWARDController test = new STOCK_OUTWARDController();
            #endregion
            objstockdetail.Outward_ID = txtPhieuBH.Text;
            objstockdetail.RefType = 2;
            string Thu = new STOCK_OUTWARDController().STOCK_OUTWARD_Exist(txtPhieuBH.Text).ToString();
            if (Thu == txtPhieuBH.Text)
            {
                rsstock = test.STOCK_OUTWARD_Update(objstock, objstock.ID);
                if (gridView1.RowCount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        if (gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString() != "")
                            objstockdetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString());
                        else
                            objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Update(objstockdetail);
                        if (rsstockdetail == -1)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                            break;
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            }
            else
            {
                #region Stock detail
                if (gridView1.RowCount > 0)
                {
                    rsstock = test.STOCK_OUTWARD_Insert(objstock);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstockdetail.ID = Guid.NewGuid();
                        objstockdetail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstockdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstockdetail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstockdetail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString())).ToString();
                        objstockdetail.UnitConvert = 1;
                        objstockdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstockdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstockdetail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objstockdetail.Charge = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        objstockdetail.Size = (gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objstockdetail.Active = true;
                        objstockdetail.Description = lookUpTenKH.Text;
                        rsstockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Insert(objstockdetail);
                        if (rsstockdetail == -1)
                        {
                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                            break;
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
                #endregion

            }
            if (rsstock > -1)
            {
                XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
                if (chkin.Checked == true)
                {
                    PRINT_RAW objprint = new PRINT_RAW();
                    FontConvert objfont = new FontConvert();
                    string output = Convert.ToChar(27) + "@" + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Công Ty TNHH Công Nghệ Song Phát.") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("61 Lương Hữu Khánh, Q.1, TP. HCM") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Tel : 9255 330 Fax: 9255 329") + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + ("PHIEU TINH TIEN") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "@" + Convert.ToChar(27) + "t" + Convert.ToChar(30) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Số TT", 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("Sản Phẩm", 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Giá Trị", 8)) + Convert.ToChar(10);
                    if (gridView1.RowCount > 1)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai((i + 1).ToString(), 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString(), 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() + "đ", 8)) + Convert.ToChar(10);
                            output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString(), 20)) + "x" + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString() + "đ", 19)) + Convert.ToChar(10);
                        }
                    }
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + objfont.UnicodeToTvcn3("= Tổng cộng:") + objfont.CanhPhai(calctong.Text + objfont.UnicodeToTvcn3("đ"), 12) + Convert.ToChar(10);
                    output = output + Convert.ToChar(29) + "!" + Convert.ToChar(0) + objfont.UnicodeToTvcn3("Số Lượng Mặt Hàng:") + objfont.CanhPhai((gridView1.Columns["Quantity"].SummaryItem.SummaryValue).ToString(), 30) + Convert.ToChar(10);
                    output = output + "================================================" + Convert.ToChar(10);
                    output = output + ("TIEN MAT (VND)") + objfont.CanhPhai(KhachTra.ToString() + objfont.UnicodeToTvcn3("đ"), 34) + Convert.ToChar(10);
                    output = output + ("TIEN THOI LAI =====>") + objfont.CanhPhai(double.Parse(calctong.Text) - KhachTra + objfont.UnicodeToTvcn3("đ"), 28) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("T.Suất", 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("GB chưa có GTGT", 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Thuế GTGT", 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("1>" + calcdiscountp.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcdiscountamount.Text, 9)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("2>" + calcvat.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcvatamount.Text, 9)) + Convert.ToChar(10);
                    output = output + "------------------------------------------------" + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Th.ngân: " + objfont.convertToUnSign2(lookUpNVBH.GetColumnValue("Employee_Name").ToString()), 48)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Ticket: " + txtPhieuBH.Text, 24)) + " " + objfont.CanhPhai(String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), 23) + Convert.ToChar(10) + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Cảm ơn Quý Khách!") + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3("Hẹn gặp lại!") + Convert.ToChar(10);
                    output = output + Convert.ToChar(27) + "!" + Convert.ToChar(9) + objfont.UnicodeToTvcn3("Website : www.shopmini.com.vn") + Convert.ToChar(10);

                    output = output + Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0) + Convert.ToChar(10);
                    objprint.SendStringToPrinter("EPSON TM-T82 Receipt", output);
                }
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void chkbarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbarcode.Checked == true)
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
                lookUpTenKH.Focus();
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
                    calcdongia.Value = (decimal)objproduct.Retail_Price;
                    calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                    txtBarcode.Text = "";
                    if (cbohanhdong.SelectedIndex == 0)
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Size"] = 3;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        rows["DiscountRate"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                                    gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()));
                                    gridView1.SetRowCellValue(i, gridView1.Columns[10], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString()));
                                    gridView1.SetRowCellValue(i, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) - double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString()));
                                    gridView1.RefreshData();

                                }
                            }
                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["ProductName"] = objproduct.Product_Name;
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Size"] = 3;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            rows["DiscountRate"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            dtable.Rows.Add(rows);
                        }
                    }
                    else if (cbohanhdong.SelectedIndex == 2)
                    {
                        int i = FindIndexGridView(objproduct.Product_ID);
                        if (i > -1)
                        {
                            //XtraMessageBox.Show(FindIndexGridView(objproduct.Product_ID).ToString());
                            gridView1.SetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[4], decimal.Parse(gridView1.GetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[4]).ToString()) + (decimal)calcsoluong.Value);
                            gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()));
                            gridView1.SetRowCellValue(i, gridView1.Columns[10], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString()));
                            gridView1.SetRowCellValue(i, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) - double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString()));
                            gridView1.RefreshData();
                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["ProductName"] = objproduct.Product_Name;
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Size"] = 3;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            rows["DiscountRate"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                            rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Size"] = 3;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            rows["DiscountRate"] = objproduct.Discount;
                            rows["Vat"] = objproduct.VAT_ID;
                            rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            dtable.Rows.Add(rows);
                        }
                    }
                    calcdiscountamount.Value = (decimal)(calcdiscountp.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                    calcvatamount.Value = (decimal)(calcvat.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                    calctong.Value = decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString()) - (decimal)calcdiscountamount.Value + (decimal)calcvatamount.Value;
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy sản phẩm", "Thông Báo");
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                }
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            objproduct = new PRODUCTController().PRODUCT_Get(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
            calcdongia.Value = (decimal)objproduct.Retail_Price;
            calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridLookUpEdit1.Text != "")
            {
                objproduct = new PRODUCTController().PRODUCT_Get(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
                calcdongia.Value = (decimal)objproduct.Retail_Price;
                calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                txtBarcode.Text = "";
                if (cbohanhdong.SelectedIndex == 0)
                {
                    DataRow rows = dtable.NewRow();
                    rows["Product_ID"] = objproduct.Product_ID;
                    rows["ProductName"] = objproduct.Product_Name;
                    rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                    rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                    rows["Size"] = 3;
                    rows["Quantity"] = calcsoluong.Value;
                    rows["UnitPrice"] = calcdongia.Value;
                    rows["Amount"] = calcthanhtien.Value;
                    rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                    rows["DiscountRate"] = objproduct.Discount;
                    rows["Vat"] = objproduct.VAT_ID;
                    rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                                gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns[10], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) - double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString()));
                                gridView1.RefreshData();

                            }
                        }
                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Size"] = 3;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        rows["DiscountRate"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        dtable.Rows.Add(rows);
                    }
                }
                else if (cbohanhdong.SelectedIndex == 2)
                {
                    int i = FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID"));
                    if (i > -1)
                    {
                        gridView1.SetRowCellValue(FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")), gridView1.Columns[4], decimal.Parse(gridView1.GetRowCellValue(FindIndexGridView(gridLookUpEdit1View.GetFocusedRowCellDisplayText("Product_ID")), gridView1.Columns[4]).ToString()) + (decimal)calcsoluong.Value);
                        gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()));
                        gridView1.SetRowCellValue(i, gridView1.Columns[10], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString()));
                        gridView1.SetRowCellValue(i, gridView1.Columns[11], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString()) - double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString()));
                        gridView1.RefreshData();

                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["ProductName"] = objproduct.Product_Name;
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Size"] = 3;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        rows["DiscountRate"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                        rows["Stock_Name"] = new STOCKController().Stock_GetNameQuantityMax(objproduct.Product_ID).Stock_Name;
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Size"] = 3;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        rows["DiscountRate"] = objproduct.Discount;
                        rows["Vat"] = objproduct.VAT_ID;
                        rows["Charge"] = calcthanhtien.Value - (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        dtable.Rows.Add(rows);
                    }
                }
                calcdiscountamount.Value = (decimal)(calcdiscountp.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                calcvatamount.Value = (decimal)(calcvat.Value) * decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString());
                calctong.Value = decimal.Parse((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString()) - (decimal)calcdiscountamount.Value + (decimal)calcvatamount.Value;
            }
  
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.SelectAll();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //PRINT_RAW objprint = new PRINT_RAW();
            //FontConvert objfont = new FontConvert();
            //string output = Convert.ToChar(27) + "@" + Convert.ToChar(10);
            //output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Công Ty TNHH Công Nghệ Song Phát.") + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3("61 Lương Hữu Khánh, Q.1, TP. HCM") + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3("Tel : 9255 330 Fax: 9255 329") + Convert.ToChar(10);
            //output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + ("PHIEU TINH TIEN") + Convert.ToChar(10);
            //output = output + Convert.ToChar(27) + "@" + Convert.ToChar(27) + "t" + Convert.ToChar(30) + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Số TT", 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("Sản Phẩm", 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Giá Trị", 8)) + Convert.ToChar(10);
            //if (gridView1.RowCount > 1)
            //{
            //    for (int i = 0; i < gridView1.RowCount - 1; i++)
            //    {
            //        output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai((i + 1).ToString(), 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString(), 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() + "đ", 8)) + Convert.ToChar(10);
            //        output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString(), 20)) + "x" + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString() + "đ", 19)) + Convert.ToChar(10);
            //    }
            //}
            //output = output + "================================================" + Convert.ToChar(10);
            //output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + objfont.UnicodeToTvcn3("= Tổng cộng:") + objfont.CanhPhai(calctong.Text + objfont.UnicodeToTvcn3("đ"), 12) + Convert.ToChar(10);
            //output = output + Convert.ToChar(29) + "!" + Convert.ToChar(0) + objfont.UnicodeToTvcn3("Số Lượng Mặt Hàng:") + objfont.CanhPhai((gridView1.Columns["Quantity"].SummaryItem.SummaryValue).ToString(), 30) + Convert.ToChar(10);
            //output = output + "================================================" + Convert.ToChar(10);
            //output = output + ("TIEN MAT (VND)") + objfont.CanhPhai(KhachTra.ToString() + objfont.UnicodeToTvcn3("đ"), 34) + Convert.ToChar(10);
            //output = output + ("TIEN THOI LAI =====>") + objfont.CanhPhai(double.Parse(calctong.Text) - KhachTra + objfont.UnicodeToTvcn3("đ"), 28) + Convert.ToChar(10);
            //output = output + "------------------------------------------------" + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("T.Suất", 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("GB chưa có GTGT", 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Thuế GTGT", 9)) + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("1>" + calcdiscountp.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcdiscountamount.Text, 9)) + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("2>" + calcvat.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcvatamount.Text, 9)) + Convert.ToChar(10);
            //output = output + "------------------------------------------------" + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Th.ngân: " + objfont.convertToUnSign2(lookUpNVBH.GetColumnValue("Employee_Name").ToString()), 48)) + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Ticket: " + txtPhieuBH.Text, 24)) + " " + objfont.CanhPhai(String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), 23) + Convert.ToChar(10) + Convert.ToChar(10);
            //output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Cảm ơn Quý Khách!") + Convert.ToChar(10);
            //output = output + objfont.UnicodeToTvcn3("Hẹn gặp lại!") + Convert.ToChar(10);
            //output = output + Convert.ToChar(27) + "!" + Convert.ToChar(9) + objfont.UnicodeToTvcn3("Website : www.shopmini.com.vn") + Convert.ToChar(10);

            //output = output + Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0) + Convert.ToChar(10);
            //objprint.SendStringToPrinter(new PRINTERMAPPINGController().Printer_Mapping_Get("EPSON TM-T82 Receipt").Details, output);
            //frmInPhieuXuatHang frm = new frmInPhieuXuatHang();
            //frm.Show();
            PRINT_RAW objprint = new PRINT_RAW();
            FontConvert objfont = new FontConvert();
            string output = Convert.ToChar(27) + "@" + Convert.ToChar(10);
            output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Công Ty TNHH Công Nghệ Song Phát.") + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3("61 Lương Hữu Khánh, Q.1, TP. HCM") + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3("Tel : 9255 330 Fax: 9255 329") + Convert.ToChar(10);
            output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + ("PHIEU TINH TIEN") + Convert.ToChar(10);
            output = output + Convert.ToChar(27) + "@" + Convert.ToChar(27) + "t" + Convert.ToChar(30) + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Số TT", 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("Sản Phẩm", 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Giá Trị", 8)) + Convert.ToChar(10);
            if (gridView1.RowCount > 1)
            {
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai((i + 1).ToString(), 5)) + objfont.UnicodeToTvcn3(objfont.CanhGiua(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString(), 35)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() + "đ", 8)) + Convert.ToChar(10);
                    output = output + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString(), 20)) + "x" + objfont.UnicodeToTvcn3(objfont.CanhPhai(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString() + "đ", 19)) + Convert.ToChar(10);
                }
            }
            output = output + "================================================" + Convert.ToChar(10);
            output = output + Convert.ToChar(29) + "!" + Convert.ToChar(17) + objfont.UnicodeToTvcn3("= Tổng cộng:") + objfont.CanhPhai(calctong.Text + objfont.UnicodeToTvcn3("đ"), 12) + Convert.ToChar(10);
            output = output + Convert.ToChar(29) + "!" + Convert.ToChar(0) + objfont.UnicodeToTvcn3("Số Lượng Mặt Hàng:") + objfont.CanhPhai((gridView1.Columns["Quantity"].SummaryItem.SummaryValue).ToString(), 30) + Convert.ToChar(10);
            output = output + "================================================" + Convert.ToChar(10);
            output = output + ("TIEN MAT (VND)") + objfont.CanhPhai(KhachTra.ToString() + objfont.UnicodeToTvcn3("đ"), 34) + Convert.ToChar(10);
            output = output + ("TIEN THOI LAI =====>") + objfont.CanhPhai(double.Parse(calctong.Text) - KhachTra + objfont.UnicodeToTvcn3("đ"), 28) + Convert.ToChar(10);
            output = output + "------------------------------------------------" + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("T.Suất", 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua("GB chưa có GTGT", 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai("Thuế GTGT", 9)) + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("1>" + calcdiscountp.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcdiscountamount.Text, 9)) + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("2>" + calcvat.Text, 6)) + objfont.UnicodeToTvcn3(objfont.CanhGiua((gridView1.Columns["Charge"].SummaryItem.SummaryValue).ToString(), 33)) + objfont.UnicodeToTvcn3(objfont.CanhPhai(calcvatamount.Text, 9)) + Convert.ToChar(10);
            output = output + "------------------------------------------------" + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Th.ngân: " + objfont.convertToUnSign2(lookUpNVBH.GetColumnValue("Employee_Name").ToString()), 48)) + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3(objfont.CanhTrai("Ticket: " + txtPhieuBH.Text, 24)) + " " + objfont.CanhPhai(String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), 23) + Convert.ToChar(10) + Convert.ToChar(10);
            output = output + Convert.ToChar(27) + "a" + Convert.ToChar(49) + Convert.ToChar(27) + "t" + Convert.ToChar(30) + objfont.UnicodeToTvcn3("Cảm ơn Quý Khách!") + Convert.ToChar(10);
            output = output + objfont.UnicodeToTvcn3("Hẹn gặp lại!") + Convert.ToChar(10);
            output = output + Convert.ToChar(27) + "!" + Convert.ToChar(9) + objfont.UnicodeToTvcn3("Website : www.shopmini.com.vn") + Convert.ToChar(10);

            output = output + Convert.ToChar(29) + "V" + Convert.ToChar(65) + Convert.ToChar(0) + Convert.ToChar(10);
            objprint.SendStringToPrinter("EPSON TM-T82 Receipt", output);
        }

        private void lookUpKhoXuat_EditValueChanged(object sender, EventArgs e)
        {
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());

        }

        private void bbItemRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpTenKH.Focus();
            lookUpTenKH.SelectAll();

        }

        private void gridLookUpEdit2View_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }

        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (calctong.Value > 0)
            {
                string Thu = new STOCK_OUTWARDController().STOCK_OUTWARD_Exist(txtPhieuBH.Text).ToString();
                if ((Thu != txtPhieuBH.Text) && (dtable.Rows.Count > 0))
                {
                    frmThanhToanBanHang frm = new frmThanhToanBanHang(this, (double)calctong.Value);
                    frm.ShowDialog();
                }
            }
            else
            {
                XtraMessageBox.Show("Tiền Thanh Toán Chưa Có, Vui Lòng Refresh", "Thông Báo");
            }

        }

        private void gridLookUpEdit2View_CustomDrawRowIndicator_1(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }

        }

    
        //private void gridLookUpMK_EditValueChanged(object sender, EventArgs e)
        //{
        //    CUSTOMER _customer = new CUSTOMER();
        //    _customer = new CUSTOMERController().LayTTCUSTOMER(gridLookUpMK.Properties.GetDisplayValue(gridLookUpEdit2View.FocusedRowHandle).ToString());
        //    lookUpTenKH.EditValue = _customer.Customer_ID;
        //    txtDiaChi.Text = _customer.CustomerAddress;
        //    txtDienThoai.Text = _customer.Tel;
        //    memoGhiChu.Text = _customer.Description;
        //}

    }
}
