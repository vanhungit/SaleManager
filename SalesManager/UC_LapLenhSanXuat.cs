using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using QuanLiBanHang.Entity;
using System.IO;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using SalesManager.Controller;
using SalesManager.Entity;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class UC_LapLenhSanXuat : UserControl
    {
        INBOUND_DELIVERY objinbound = new INBOUND_DELIVERY();
        INBOUND_DELIVERY_DETAIL objinbound_detail = new INBOUND_DELIVERY_DETAIL();
        DataTable dtable = new DataTable();
        frmLenhSanXuat main_form;
        int GlobalRowSelect = 0;
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        public UC_LapLenhSanXuat()
        {
            InitializeComponent();
            ReadXml_User();
            InitLookUp_NhanVien();
            InitLookUpKhoHang();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            dateNgayTao.DateTime = DateTime.Now;
            dateNgayHT.DateTime = DateTime.Now;
            lookUpTenNV.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            lookUpTenNV.Properties.DisplayMember = "Employee_Name";
            lookUpTenNV.Properties.ValueMember = "Employee_ID";
            lookUpTenNV.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit2View.Invalidate();
            gridLookUpEdit2View.IndicatorWidth = 35;
            txtLenhSX.Text = CreatePhieuBanHang();
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("ProductName");
            dtable.Columns.Add("Unit_ID");
            dtable.Columns.Add("Quantity");
            dtable.Columns.Add("Description");
            dtable.Columns.Add("ID");//them vao

            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;

            repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            //repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;

            repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_ID";
            repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = dtable;
            gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;

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
            lookUpNVBH.EditValue = objuser.PartID;
        }
        private void InitLookUpKhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpKho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpKho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpKho.Properties.ValueMember = "Stock_ID";
            lookUpKho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpKho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpKho.EditValue = "K000001";
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
        public string CreatePhieuBanHang()
        {
            string PhieuBanHang, Temp_BH, Number_PC;
            PhieuBanHang = "IB_" + objuser.UserName + "_000001";//Trả về số phiếu thu
            Temp_BH = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            string _stockout_PC = new INBOUND_DELIVERYController().INBOUND_DELIVERY_Search(objuser.UserName);
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
        private void gridLookUpEdit2View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }

        }

        private void lookUpTenNV_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = (lookUpTenNV.Properties.GetKeyValue(gridLookUpEdit2View.FocusedRowHandle).ToString());
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
                lookUpTenNV.Focus();
            }
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

                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1], gridView2.GetRowCellDisplayText(GlobalRowSelect, "Product_Name"));
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2], objproduct.Unit);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3], "1");

                }

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

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = 1;
            objinbound.ID = txtLenhSX.Text;
            objinbound.RefDate = DateTime.Now;
            objinbound.RefType = 1;
            //if (lookUpdieukhoan.GetColumnValue("Code").ToString() == "TM")
            objinbound.RefStatus = 0;
            //else
            //    objpurchaseorder.RefStatus = 1;
            objinbound.Status = 0;
            objinbound.PaymentMethod = new Guid("11111111-1111-1111-1111-111111111111");
            objinbound.TermID = "TM";
            objinbound.PaymentDate = DateTime.Now;
            objinbound.DeliveryDate = DateTime.Now;
            objinbound.Barcode = txtLenhSX.Text;
            objinbound.Employee_ID = lookUpNVBH.GetColumnValue("Employee_ID").ToString();
            objinbound.Customer_ID = "";
            objinbound.CustomerName = "";
            objinbound.CustomerAddress = txtDiaChi.Text;
            objinbound.Currency_ID = "VND";
            objinbound.DiscountDate = DateTime.Now;
            objinbound.User_ID = objuser.UserID;
            objinbound.Reason = "Lệnh Nhập Kho";
            objinbound.Active = true;
            objinbound.ExchangeRate = 1;
            objinbound.Amount = 0;
            objinbound.FAmount = 0;
            INBOUND_DELIVERYController test = new INBOUND_DELIVERYController();
            objinbound_detail.Inbound_ID = txtLenhSX.Text;
            objinbound_detail.RefType = 1;
            {
                if (gridView1.RowCount > 1)
                {
                    rsstock = test.INBOUND_DELIVERY_Insert(objinbound);
                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                    {
                        int rsstockdetail = -1;
                        objinbound_detail.ID = Guid.NewGuid();
                        objinbound_detail.Stock_ID = lookUpKho.GetColumnValue("Stock_ID").ToString();
                        //objinbound.Stock_ID = lookUpKhoNhap.GetColumnValue("Stock_ID").ToString();
                        objinbound_detail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                        objinbound_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                        objinbound_detail.Unit = repositoryItemLookUpEdit4.GetDataSourceValue(repositoryItemLookUpEdit4.Columns["Unit_ID"], repositoryItemLookUpEdit4.GetDataSourceRowIndex(repositoryItemLookUpEdit4.Columns["Unit_ID"], gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString())).ToString();
                        objinbound_detail.UnitConvert = 1;
                        objinbound_detail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
                        objinbound_detail.Quantity = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
                        objinbound_detail.UnitPrice = 0;
                        objinbound_detail.Amount = 0;
                        objinbound_detail.QtyConvert = 0;
                        objinbound_detail.PO_ID = "";
                        objinbound_detail.PO_Line = new Guid("00000000-0000-0000-0000-000000000000");
                        objinbound_detail.SO_ID = "";
                        objinbound_detail.SO_Line = new Guid("00000000-0000-0000-0000-000000000000");
                        objinbound_detail.Active = true;
                        //objpurchaseorder_detail.Batch = "LOT21112013";
                        objinbound_detail.Description = "";
                        rsstockdetail = new INBOUND_DELIVERY_DETAILController().INBOUND_DELIVERY_DETAIL_Insert(objinbound_detail);
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
                    _sys_log.Description = "Thêm Lệnh Nhập Kho" + "-" + txtLenhSX.Text;
                    _sys_log.Reference = txtLenhSX.Text;
                    _sys_log.Module = "Lệnh Nhập Kho";
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
                txtLenhSX.Text = CreatePhieuBanHang();
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
    }
}
