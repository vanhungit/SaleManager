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
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;

namespace SalesManager
{
    public partial class UC_PhieuChuyenKho : UserControl
    {
        STOCK_TRANSFER objstocktransfer = new STOCK_TRANSFER();
        STOCK_TRANSFER_DETAIL objstocktransferdetail = new STOCK_TRANSFER_DETAIL();
        DataTable dtable = new DataTable();
        frmBanHang main_form;
        int GlobalRowSelect = 0;
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        public UC_PhieuChuyenKho()
        {
            InitializeComponent();
            InitLookUpDen();
            InitLookUpKhoHang();
            InitLookUp_NhanVien();
            lookUpNVBH.EditValue = "NV000001"; 
            datechuyen.DateTime = DateTime.Now;
            ReadXml_User();
            txtPhieuChuyen.Text = CreatePhieuChuyenHang();
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            gridLookUpEdit1.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit1.Properties.DisplayMember = "Employee_Name";
            gridLookUpEdit1.Properties.ValueMember = "Employee_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            gridLookUpEdit2.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit2.Properties.DisplayMember = "Employee_ID";
            gridLookUpEdit2.Properties.ValueMember = "Employee_Name";
            gridLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            gridLookUpEdit3.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            gridLookUpEdit3.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit3.Properties.ValueMember = "Product_ID";
            gridLookUpEdit3.Properties.BestFitMode = BestFitMode.None;
            // Enable auto completion search mode.
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit3.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit5.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit5.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit5.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit5.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit5.Properties.AutoSearchColumnIndex = 1;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("Product_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Unit_Change");
            dtable.Columns.Add("Stock_NameFrom");
            dtable.Columns.Add("Stock_NameTo");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao
            gridControl1.DataSource = dtable;
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
        }
        public UC_PhieuChuyenKho(frmChuyenKho _nhap, string Phieuchuyen)
        {
            InitializeComponent();
            InitLookUpDen();
            InitLookUpKhoHang();
            InitLookUp_NhanVien();
            ReadXml_User();
            txtPhieuChuyen.Text = Phieuchuyen;
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            objstocktransfer = new STOCK_TRANSFERController().STOCK_TRANSFER_Get(Phieuchuyen.Trim());
            lookUpNVBH.EditValue = objstocktransfer.Sender_ID;
            datechuyen.DateTime = objstocktransfer.RefDate;
            gridLookUpEdit1.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit1.Properties.DisplayMember = "Employee_Name";
            gridLookUpEdit1.Properties.ValueMember = "Employee_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            gridLookUpEdit2.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit2.Properties.DisplayMember = "Employee_ID";
            gridLookUpEdit2.Properties.ValueMember = "Employee_Name";
            gridLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "Product_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit3.Properties.DataSource = new UNITController().UNIT_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Unit_Name";//tìm theo
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new STOCKController().STOCK_GetList();
            repositoryItemLookUpEdit4.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit5.Properties.DataSource = new STOCKController().STOCK_GetList();
            //repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit5.Properties.ValueMember = "Stock_Name";
            repositoryItemLookUpEdit5.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit5.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit5.Properties.AutoSearchColumnIndex = 1;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("Product_Name");
            dtable.Columns.Add("Unit_Name");
            dtable.Columns.Add("Unit_Change");
            dtable.Columns.Add("Stock_NameFrom");
            dtable.Columns.Add("Stock_NameTo");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao
            gridLookUpEdit1.EditValue = objstocktransfer.Receiver_ID;
            gridControl1.DataSource = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_GetList_ByTransferID_Modify(Phieuchuyen);
            repositoryItemGridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
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
        private void InitLookUpDen()
        {
            // Specify the data source to display in the dropdown.
            lookUpKhoDen.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpKhoDen.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpKhoDen.Properties.ValueMember = "Stock_ID";
            lookUpKhoDen.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpKhoDen.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpKhoDen.EditValue = "K000001";
        }
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
       
        public string CreatePhieuChuyenHang()
        {
            string PhieuChuyenHang, Temp_BH, Number_PC;
            PhieuChuyenHang = "CK_"+objuser.UserName +"_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            STOCK_TRANSFER _stockout_PC = new STOCK_TRANSFERController().Transfer_Search(objuser.UserName);
            Temp_BH = _stockout_PC.ID;
            if (Temp_BH != "")
            {
                Number_PC = Temp_BH.Substring(Temp_BH.Length - 6, 6);
                Number_PC = (long.Parse(Number_PC.ToString()) + 1).ToString();
                PhieuChuyenHang = Number_PC;
                for (int i = 0; i < 6 - Number_PC.Length; i++)
                {
                    PhieuChuyenHang = "0" + PhieuChuyenHang;
                }
                PhieuChuyenHang = Temp_BH.Substring(0, Temp_BH.Length - 6) + PhieuChuyenHang;
            }
            return PhieuChuyenHang;
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
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtPhieuChuyen.Text = CreatePhieuChuyenHang();

        }

        private void gridLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            gridLookUpEdit1.EditValue = gridLookUpEdit2.Text;

        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridLookUpEdit2.EditValue = gridLookUpEdit1.Text;
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
        public void repositoryItemGridLookUpEdit1View_click(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
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
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], new UNITController().UNIT_Get(objproduct.Unit).Unit_Name);
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Stock_Name"));
                    //gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Stock_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], lookUpKhoXuat.GetColumnValue("Stock_Name").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], lookUpKhoDen.GetColumnValue("Stock_Name").ToString());
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], "1");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7], double.Parse(repositoryItemGridLookUpEdit1View.GetRowCellDisplayText(GlobalRowSelect, "Org_Price")));
                }
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));

           }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = 1;
            int flag = 0;
            objstocktransfer.ID = txtPhieuChuyen.Text;
            objstocktransfer.RefDate = datechuyen.DateTime;
            objstocktransfer.RefType = 9;
            objstocktransfer.Sender_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstocktransfer.Receiver_ID = gridLookUpEdit2.Text;
            objstocktransfer.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstocktransfer.User_ID = objuser.UserID;
            objstocktransfer.IsReview = true;
            objstocktransfer.IsClose = false;
            objstocktransfer.FromStock_ID = "All";
            objstocktransfer.ToStock_ID = "All";
            objstocktransfer.Active = true;
            STOCK_TRANSFERController test = new STOCK_TRANSFERController();
            objstocktransferdetail.Transfer_ID = txtPhieuChuyen.Text;
            objstocktransferdetail.RefType = 9;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString() == gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString())
                {
                    XtraMessageBox.Show("Trùng kho đến và kho đi ở dòng số " + (i+1), "Thông Báo!");
                    flag = 1;
                    break;
                }
                else
                    flag = 0;
            }
            if (flag == 0)
            {
                if (new STOCK_TRANSFERController().STOCK_TRANSFER_Exist(txtPhieuChuyen.Text).ToString() == txtPhieuChuyen.Text)
                {
                    rsstock = test.STOCK_TRANSFER_Update(objstocktransfer, objstocktransfer.ID);
                    if (gridView1.RowCount > 0)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            int rsstockdetail = -1;
                            if (gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() != "")
                                objstocktransferdetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                            else
                                objstocktransferdetail.ID = Guid.NewGuid();
                            objstocktransferdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                            objstocktransferdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                            objstocktransferdetail.OutStock = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Stock_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString())).ToString();
                            objstocktransferdetail.InStock = repositoryItemLookUpEdit5.GetDataSourceValue(repositoryItemLookUpEdit5.Columns["Stock_ID"], repositoryItemLookUpEdit5.GetDataSourceRowIndex(repositoryItemLookUpEdit5.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString())).ToString();
                            objstocktransferdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                            objstocktransferdetail.Unit = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Unit_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                            objstocktransferdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                            objstocktransferdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                            objstocktransferdetail.UnitConvert = 1;
                            objstocktransferdetail.QtyConvert = 0;
                            objstocktransferdetail.StoreID = 0;
                            objstocktransferdetail.Description = gridLookUpEdit1.Text;
                            rsstockdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_Update(objstocktransferdetail);
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
                        _sys_log.Description = "Cập Nhật Phiếu Chuyển Kho" + "-" + txtPhieuChuyen.Text;
                        _sys_log.Reference = txtPhieuChuyen.Text;
                        _sys_log.Module = "Phiếu Chuyển Kho";
                        _sys_log.Active = true;
                        SYS_LOGController insertlog = new SYS_LOGController();
                        insertlog.SYS_LOG_Insert(_sys_log);
                    }
                    else
                        XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
                }
                else
                {
                    rsstock = test.STOCK_TRANSFER_Insert(objstocktransfer);
                    if (gridView1.RowCount > 0)
                    {
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            int rsstockdetail = -1;
                            objstocktransferdetail.ID = Guid.NewGuid();
                            objstocktransferdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                            objstocktransferdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                            objstocktransferdetail.OutStock = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Stock_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString())).ToString();
                            objstocktransferdetail.InStock = repositoryItemLookUpEdit5.GetDataSourceValue(repositoryItemLookUpEdit5.Columns["Stock_ID"], repositoryItemLookUpEdit5.GetDataSourceRowIndex(repositoryItemLookUpEdit5.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString())).ToString();
                            objstocktransferdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                            objstocktransferdetail.Unit = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Unit_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                            objstocktransferdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                            objstocktransferdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                            objstocktransferdetail.UnitConvert = 1;
                            objstocktransferdetail.QtyConvert = 0;
                            objstocktransferdetail.StoreID = 0;
                            objstocktransferdetail.Description = gridLookUpEdit1.Text;
                            rsstockdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_Insert(objstocktransferdetail);
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
                        _sys_log.Description = "Thêm Phiếu Chuyển Kho" + "-" + txtPhieuChuyen.Text;
                        _sys_log.Reference = txtPhieuChuyen.Text;
                        _sys_log.Module = "Phiếu Chuyển Kho";
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
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);

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
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteSelectedRows();

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = 1;
            objstocktransfer.ID = txtPhieuChuyen.Text;
            objstocktransfer.RefDate = datechuyen.DateTime;
            objstocktransfer.RefType = 9;
            objstocktransfer.Sender_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objstocktransfer.Receiver_ID = gridLookUpEdit2.Text;
            objstocktransfer.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objstocktransfer.User_ID = objuser.UserID;
            objstocktransfer.IsReview = true;
            objstocktransfer.IsClose = false;
            objstocktransfer.FromStock_ID = "All";
            objstocktransfer.ToStock_ID = "All";
            objstocktransfer.Active = true;
            STOCK_TRANSFERController test = new STOCK_TRANSFERController();
            objstocktransferdetail.Transfer_ID = txtPhieuChuyen.Text;
            objstocktransferdetail.RefType = 9;
            if (new STOCK_TRANSFERController().STOCK_TRANSFER_Exist(txtPhieuChuyen.Text).ToString() == txtPhieuChuyen.Text)
            {
                rsstock = test.STOCK_TRANSFER_Update(objstocktransfer, objstocktransfer.ID);
                if (gridView1.RowCount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        if (gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString() != "")
                            objstocktransferdetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString());
                        else
                            objstocktransferdetail.ID = Guid.NewGuid();
                        objstocktransferdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstocktransferdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstocktransferdetail.OutStock = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Stock_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString())).ToString();
                        objstocktransferdetail.InStock = repositoryItemLookUpEdit5.GetDataSourceValue(repositoryItemLookUpEdit5.Columns["Stock_ID"], repositoryItemLookUpEdit5.GetDataSourceRowIndex(repositoryItemLookUpEdit5.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString())).ToString();
                        objstocktransferdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstocktransferdetail.Unit = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Unit_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstocktransferdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                        objstocktransferdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstocktransferdetail.UnitConvert = 1;
                        objstocktransferdetail.QtyConvert = 0;
                        objstocktransferdetail.StoreID = 0;
                        objstocktransferdetail.Description = gridLookUpEdit1.Text;
                        rsstockdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_Update(objstocktransferdetail);
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
                rsstock = test.STOCK_TRANSFER_Insert(objstocktransfer);
                if (gridView1.RowCount > 0)
                {
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objstocktransferdetail.ID = Guid.NewGuid();
                        objstocktransferdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objstocktransferdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objstocktransferdetail.OutStock = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Stock_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString())).ToString();
                        objstocktransferdetail.InStock = repositoryItemLookUpEdit5.GetDataSourceValue(repositoryItemLookUpEdit5.Columns["Stock_ID"], repositoryItemLookUpEdit5.GetDataSourceRowIndex(repositoryItemLookUpEdit5.Columns["Stock_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString())).ToString();
                        objstocktransferdetail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                        objstocktransferdetail.Unit = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Unit_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Unit_Name"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString())).ToString();
                        objstocktransferdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                        objstocktransferdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString());
                        objstocktransferdetail.UnitConvert = 1;
                        objstocktransferdetail.QtyConvert = 0;
                        objstocktransferdetail.StoreID = 0;
                        objstocktransferdetail.Description = gridLookUpEdit1.Text;
                        rsstockdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_Insert(objstocktransferdetail);
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
            if (rsstock > -1)
            {
                XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
            }
            else
            {
                XtraMessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.SelectAll();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[11]).ToString();
            XtraMessageBox.Show(test);
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (e.KeyCode == Keys.Enter)
            {
                objproduct = new PRODUCTController().PRODUCT_Getbybarcode(txtBarcode.Text.Trim());
                if (objproduct.Product_ID != "")
                {
                    gridLookUpEdit3.EditValue = objproduct.Product_ID;
                    calcdongia.Value = (decimal)objproduct.Org_Price;
                    calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                    txtBarcode.Text = "";
                    if (cbohanhdong.SelectedIndex == 0)
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["Product_Name"] = objproduct.Product_Name;
                        rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                        rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                                    gridView1.SetRowCellValue(i, gridView1.Columns[6], (decimal)calcsoluong.Value);
                                    gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString()));
                                    gridView1.RefreshData();

                                }
                            }
                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["Product_Name"] = objproduct.Product_Name;
                            rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                            rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                            dtable.Rows.Add(rows);
                        }
                    }
                    else if (cbohanhdong.SelectedIndex == 2)
                    {
                        int i = FindIndexGridView(objproduct.Product_ID);
                        if (i > -1)
                        {
                            //XtraMessageBox.Show(FindIndexGridView(objproduct.Product_ID).ToString());
                            gridView1.SetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[6], decimal.Parse(gridView1.GetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[6]).ToString()) + (decimal)calcsoluong.Value);
                            gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString()));
                            gridView1.RefreshData();

                        }
                        else
                        {
                            DataRow rows = dtable.NewRow();
                            rows["Product_ID"] = objproduct.Product_ID;
                            rows["Product_Name"] = objproduct.Product_Name;
                            rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                            rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                            rows["Product_Name"] = objproduct.Product_Name;
                            rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                            rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                            rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                            rows["Quantity"] = calcsoluong.Value;
                            rows["UnitPrice"] = calcdongia.Value;
                            rows["Amount"] = calcthanhtien.Value;
                            rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                gridLookUpEdit2.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            if (gridLookUpEdit3.Text != "")
            {
                objproduct = new PRODUCTController().PRODUCT_Get(gridView2.GetFocusedRowCellDisplayText("Product_ID"));
                gridLookUpEdit3.EditValue = objproduct.Product_ID;
                calcdongia.Value = (decimal)objproduct.Org_Price;
                calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);
                txtBarcode.Text = "";
                if (cbohanhdong.SelectedIndex == 0)
                {
                    DataRow rows = dtable.NewRow();
                    rows["Product_ID"] = objproduct.Product_ID;
                    rows["Product_Name"] = objproduct.Product_Name;
                    rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                    rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                    rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                    rows["Quantity"] = calcsoluong.Value;
                    rows["UnitPrice"] = calcdongia.Value;
                    rows["Amount"] = calcthanhtien.Value;
                    rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                                gridView1.SetRowCellValue(i, gridView1.Columns[6], (decimal)calcsoluong.Value);
                                gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString()));
                                gridView1.RefreshData();

                            }
                        }
                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["Product_Name"] = objproduct.Product_Name;
                        rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                        rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        dtable.Rows.Add(rows);
                    }
                }
                else if (cbohanhdong.SelectedIndex == 2)
                {
                    int i = FindIndexGridView(objproduct.Product_ID);
                    if (i > -1)
                    {
                        //XtraMessageBox.Show(FindIndexGridView(objproduct.Product_ID).ToString());
                        gridView1.SetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[6], decimal.Parse(gridView1.GetRowCellValue(FindIndexGridView(objproduct.Product_ID), gridView1.Columns[6]).ToString()) + (decimal)calcsoluong.Value);
                        gridView1.SetRowCellValue(i, gridView1.Columns[8], double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString()) * double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString()));
                        gridView1.RefreshData();

                    }
                    else
                    {
                        DataRow rows = dtable.NewRow();
                        rows["Product_ID"] = objproduct.Product_ID;
                        rows["Product_Name"] = objproduct.Product_Name;
                        rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                        rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
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
                        rows["Product_Name"] = objproduct.Product_Name;
                        rows["Stock_NameFrom"] = lookUpKhoXuat.GetColumnValue("Stock_Name").ToString();
                        rows["Stock_NameTo"] = lookUpKhoDen.GetColumnValue("Stock_Name").ToString();
                        rows["Unit_Name"] = new UNITController().UNIT_Get(objproduct.Unit).Unit_Name;
                        rows["Quantity"] = calcsoluong.Value;
                        rows["UnitPrice"] = calcdongia.Value;
                        rows["Amount"] = calcthanhtien.Value;
                        rows["Discount"] = (decimal)(objproduct.Discount) * (calcthanhtien.Value);
                        dtable.Rows.Add(rows);
                    }
                }
            }
        }

        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            PRODUCT objproduct = new PRODUCT();
            objproduct = new PRODUCTController().PRODUCT_Get(gridView2.GetFocusedRowCellDisplayText("Product_ID"));
            calcdongia.Value = (decimal)objproduct.Retail_Price;
            calcthanhtien.Value = (calcdongia.Value) * (calcsoluong.Value);

        }

        private void lookUpKhoXuat_EditValueChanged(object sender, EventArgs e)
        {
            gridLookUpEdit3.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());
            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE_Stock(lookUpKhoXuat.GetColumnValue("Stock_ID").ToString());

        }
    }
}
