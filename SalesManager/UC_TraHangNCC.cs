using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using SalesManager.Controller;
using DevExpress.XtraEditors;
using SalesManager.Entity;

namespace SalesManager
{
    public partial class UC_TraHangNCC : UserControl
    {
        PURCHASE_RETURN objinbound = new PURCHASE_RETURN();
        PURCHASE_RETURN_DETAIL objinbound_detail = new PURCHASE_RETURN_DETAIL();
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        DataTable dtable = new DataTable();
        int GlobalRowSelect = 0;
        public UC_TraHangNCC()
        {
            InitializeComponent();
            InitLookUpKhoHang();
            InitLookUp_dieukhoan();
            InitLookUp_thanhtoan();
            InitLookUpTenKH();
            InitLookUp_NhanVien();
            ReadXml_User();
            lookUpdieukhoan.EditValue = "TM";
            lookUpthanhtoan.EditValue = "TM";
            lookUpNVBH.EditValue = "NV000001";
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            txtPhieuN.Text = CreateDonHangTraNCC();
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            dateEdithan.DateTime = DateTime.Now;
            dateNgayNhap.DateTime = DateTime.Now;
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
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
            repositoryItemLookUpEdit3.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit3.Properties.ValueMember = "Stock_ID";
            repositoryItemLookUpEdit3.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit3.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit3.Properties.AutoSearchColumnIndex = 1;
            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_ID";//tìm theo
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            //dtable.Columns.Add("Stock_Name");
            dtable.Columns.Add("Stock_ID");
            dtable.Columns.Add("Unit_ID");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("UnitPrice");
            dtable.Columns.Add("Vat");
            dtable.Columns.Add("Amount");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao
            dtable.Columns.Add("PO_ID");
            dtable.Columns.Add("PN_ID");
            gridControl1.DataSource = dtable;
            gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
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
        public string CreateDonHangTraNCC()
        {
            string PhieuNhapHang, Temp_BH, Number_PC;
            PhieuNhapHang = "TH_" + objuser.UserName + "_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            string _stockout_PC = new PURCHASE_RETURNController().PURCHASE_RETURN_Search(objuser.UserName);
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
        public void LoadFromPO(string PO_Number, string ProviderID, DataTable table)
        {
            lookUpTenNPP.EditValue = ProviderID;
            foreach (DataRow datarow in table.Rows)
            {
                DataRow dtrow = dtable.NewRow();
                dtrow[0] = datarow["Product_ID"].ToString().Trim();
                dtrow[1] = datarow["ProductName"].ToString().Trim();
                dtrow[2] = datarow["Stock_ID"].ToString().Trim();
                dtrow[3] = datarow["Unit_ID"].ToString().Trim();
                dtrow[4] = (datarow["Quantity"].ToString().Trim());
                dtrow[5] = (datarow["UnitPrice"].ToString().Trim());
                dtrow[6] = datarow["Vat"].ToString().Trim();
                dtrow[7] = (datarow["Amount"].ToString().Trim());
                dtrow[8] = datarow["Discount"].ToString().Trim();
                dtrow[9] = datarow["Description"].ToString().Trim();
                dtrow[10] = datarow["ID"].ToString().Trim();
                dtrow[11] = datarow["PO_ID"].ToString().Trim();
                dtrow[12] = "";
                dtable.Rows.Add(dtrow);
            }
            gridControl1.DataSource = dtable;

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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChonDonHangMua frm = new frmChonDonHangMua(this, "XKHT");
            frm.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]) != null)
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString() != "")
                {
                    PRODUCT objproduct = new PRODUCT();
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]) != null)
                    {
                        string test = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                        objproduct = new PRODUCTController().PRODUCT_Get(test.ToString());
                        if (objproduct.Product_Name.Trim() != gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString())
                        {
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], gridView2.GetRowCellDisplayText(GlobalRowSelect, "Product_Name"));
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], gridView2.GetRowCellDisplayText(GlobalRowSelect, "Stock_ID"));
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], new UNITController().UNIT_Get(objproduct.Unit).Unit_ID);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4], "1");
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5], double.Parse(gridView2.GetRowCellDisplayText(GlobalRowSelect, "Org_Price")));
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6], objproduct.VAT_ID);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8], objproduct.Discount);

                        }
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7], double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()) * double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString()));
                    }
                }
            }
        }

        private void lookUpTenNPP_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNPP.Text = lookUpTenNPP.Properties.GetKeyValue(gridLookUpEdit2View.FocusedRowHandle).ToString();
            PROVIDER objprovider = new PROVIDER();
            objprovider = new PROVIDERController().PROVIDER_Get(txtMaNPP.Text);
            txtDiaChi.Text = objprovider.CustomerAddress;
            txtDienThoai.Text = objprovider.Tel;
            memoGhiChu.Text = objprovider.Description;
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

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.SelectAll();

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = 1;
            objinbound.ID = txtPhieuN.Text;
            objinbound.RefDate = DateTime.Now;
            objinbound.RefType = 1;
            //if (lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objinbound.RefStatus = 0;
            //else
            //    objpurchaseorder.RefStatus = 1;
            objinbound.Status = 0;
            objinbound.PaymentMethod = new Guid(lookUpthanhtoan.GetColumnValue("ID").ToString());
            objinbound.TermID = lookUpdieukhoan.GetColumnValue("Code").ToString();
            objinbound.PaymentDate = dateNgayNhap.DateTime;
            objinbound.DeliveryDate = dateEdithan.DateTime;
            objinbound.Barcode = txtPhieuN.Text;
            objinbound.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objinbound.Customer_ID = txtMaNPP.Text;
            objinbound.CustomerName = lookUpTenNPP.Text;
            objinbound.CustomerAddress = txtDiaChi.Text;
            objinbound.Currency_ID = "VND";
            objinbound.DiscountDate = DateTime.Now;
            objinbound.User_ID = objuser.UserID;
            objinbound.Reason = "Đơn Hàng Trả";
            objinbound.Active = true;
            objinbound.ExchangeRate = 1;
            objinbound.Amount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            objinbound.FAmount = double.Parse(gridView1.Columns["Amount"].SummaryItem.SummaryValue.ToString());
            PURCHASE_RETURNController test = new PURCHASE_RETURNController();
            objinbound_detail.Return_ID = txtPhieuN.Text;
            objinbound_detail.RefType = 1;
            {
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.PURCHASE_RETURN_Insert(objinbound);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objinbound_detail.ID = Guid.NewGuid();
                        objinbound_detail.Stock_ID = repositoryItemLookUpEdit3.GetDataSourceValue(repositoryItemLookUpEdit3.Columns["Stock_ID"], repositoryItemLookUpEdit3.GetDataSourceRowIndex(repositoryItemLookUpEdit3.Columns["Stock_ID"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        //objinbound.Stock_ID = lookUpKhoNhap.GetColumnValue("Stock_ID").ToString();
                        objinbound_detail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objinbound_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objinbound_detail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_ID"], gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString())).ToString();
                        objinbound_detail.UnitConvert = 1;
                        objinbound_detail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objinbound_detail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objinbound_detail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                        objinbound_detail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                        objinbound_detail.QtyConvert = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                        objinbound_detail.RefPurchase_ID = gridView1.GetRowCellValue(i, gridView1.Columns["PO_ID"]).ToString();
                        objinbound_detail.RefInward_ID = "";
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["PN_ID"]).Equals(null))
                            objinbound_detail.RefInward_ID = "";
                        else
                            objinbound_detail.RefInward_ID = gridView1.GetRowCellValue(i, gridView1.Columns["PN_ID"]).ToString();
                        //objinbound_detail.Active = true;
                        //objpurchaseorder_detail.Batch = "LOT21112013";
                        objinbound_detail.Description = lookUpTenNPP.Text;
                        rsstockdetail = new PURCHASE_RETURN_DETAILController().PURCHASE_RETURN_DETAIL_Insert(objinbound_detail);
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
                    _sys_log.Description = "Thêm Đơn Hàng Trả" + "-" + txtPhieuN.Text;
                    _sys_log.Reference = txtPhieuN.Text;
                    _sys_log.Module = "Đơn Hàng Trả";
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
                txtPhieuN.Text = CreateDonHangTraNCC();
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

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChonPhieuNhap frm = new frmChonPhieuNhap(this);
            frm.ShowDialog();
        }

    }
}
