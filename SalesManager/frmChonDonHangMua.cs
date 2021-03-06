using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesManager.Controller;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;

namespace SalesManager
{
    public partial class frmChonDonHangMua : DevExpress.XtraEditors.XtraForm
    {
        UC_ChungTuMuaHang frmchungtu;
        UC_TraHangNCC frmtrahangncc;
        string TagApp = "";
        public frmChonDonHangMua(UC_ChungTuMuaHang frm, String _app)
        {
            InitializeComponent();
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            InitLookUpKhoHang();
            InitLookUp_NhanVien();
            InitLookUpBophan();
            frmchungtu = frm;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 30;
            repositoryItemGridLookUpEdit1.DataSource = new STOCKController().STOCK_GetList();
            repositoryItemGridLookUpEdit1.DisplayMember = "Stock_Name";
            repositoryItemGridLookUpEdit1.ValueMember = "Stock_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUpEdit2.DataSource = new UNITController().UNIT_GetList();
            repositoryItemGridLookUpEdit2.DisplayMember = "Unit_Name";
            repositoryItemGridLookUpEdit2.ValueMember = "Unit_ID";
            repositoryItemGridLookUpEdit2.BestFitMode = BestFitMode.BestFitResizePopup;
            TagApp = _app;
        }
        public frmChonDonHangMua(UC_TraHangNCC frm, String _app)
        {
            InitializeComponent();
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            InitLookUpKhoHang();
            InitLookUp_NhanVien();
            InitLookUpBophan();
            frmtrahangncc = frm;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 30;
            repositoryItemGridLookUpEdit1.DataSource = new STOCKController().STOCK_GetList();
            repositoryItemGridLookUpEdit1.DisplayMember = "Stock_Name";
            repositoryItemGridLookUpEdit1.ValueMember = "Stock_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUpEdit2.DataSource = new UNITController().UNIT_GetList();
            repositoryItemGridLookUpEdit2.DisplayMember = "Unit_Name";
            repositoryItemGridLookUpEdit2.ValueMember = "Unit_ID";
            repositoryItemGridLookUpEdit2.BestFitMode = BestFitMode.BestFitResizePopup;
            TagApp = _app;
        }
        private void InitLookUpBophan()
        {
            // Specify the data source to display in the dropdown.
            lookUpEditBoPhan.Properties.DataSource = new DEPARTMENTController().LayDSDEPARTMENT_GROUP();
            // The field providing the editor's display text.
            lookUpEditBoPhan.Properties.DisplayMember = "Department_Name";
            // The field matching the edit value.
            lookUpEditBoPhan.Properties.ValueMember = "Department_ID";
            lookUpEditBoPhan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpEditBoPhan.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpEditBoPhan.EditValue = "BP000001";
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
        private void InitLookUp_NhanVien()
        {
            // Specify the data source to display in the dropdown.
            lookUpEditNCC.Properties.DataSource = new PROVIDERController().PROVIDER_GetList();
            // The field providing the editor's display text.
            lookUpEditNCC.Properties.DisplayMember = "CustomerName";
            // The field matching the edit value.
            lookUpEditNCC.Properties.ValueMember = "Customer_ID";
            lookUpEditNCC.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpEditNCC.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpEditNCC.Properties.AutoSearchColumnIndex = 1;
        }
        private void cbochon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThoiGianController thoigian = new ThoiGianController();
            string format = "M/d/yyyy";
            switch (cbochon.Text)
            {
                case "Hôm nay":
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    dateTu.DateTime = DateTime.ParseExact(DateTime.Now.Month + "/" + thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year) + "/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact(DateTime.Now.Month + "/" + thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    //dateDen.DateTime = DateTime.ParseExact("01" + "/" + "01" + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Quý này":
                    dateTu.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 1":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 2":
                    dateTu.DateTime = DateTime.ParseExact("02/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 3":
                    dateTu.DateTime = DateTime.ParseExact("03/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 4":
                    dateTu.DateTime = DateTime.ParseExact("04/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 5":
                    dateTu.DateTime = DateTime.ParseExact("05/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 6":
                    dateTu.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    dateTu.DateTime = DateTime.ParseExact("07/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 8":
                    dateTu.DateTime = DateTime.ParseExact("08/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 9":
                    dateTu.DateTime = DateTime.ParseExact("09/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 10":
                    dateTu.DateTime = DateTime.ParseExact("10/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 11":
                    dateTu.DateTime = DateTime.ParseExact("11/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 12":
                    dateTu.DateTime = DateTime.ParseExact("12/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Quý 1":
                    dateTu.DateTime = thoigian.StartDayofQui(1, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(1, DateTime.Now.Year);
                    break;
                case "Quý 2":
                    dateTu.DateTime = thoigian.StartDayofQui(2, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(2, DateTime.Now.Year);
                    break;
                case "Quý 3":
                    dateTu.DateTime = thoigian.StartDayofQui(3, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(3, DateTime.Now.Year);
                    break;
                case "Quý 4":
                    dateTu.DateTime = thoigian.StartDayofQui(4, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(4, DateTime.Now.Year);
                    break;
                default:
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((lookUpEditNCC.Text != "Chọn")||(lookUpEditDH.Text !="Chọn"))
            {
                gridControl1.DataSource = new PURCHASE_ORDERController().PURCHASE_ORDER_GetByDate(dateTu.DateTime, dateDen.DateTime, lookUpEditNCC.GetColumnValue("Customer_ID").ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hoặc đơn hàng mua !","Thông Báo");
                //lookUpEditNCC.Focus();
                //lookUpEditNCC.ShowPopup();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataTable tabletemp = (DataTable)(gridControl1.DataSource);//Mapping gridControl to table.
                DataTable tblFiltered = tabletemp.AsEnumerable()
                                 .Where((r => r.Field<bool>("Chon") == true))
                                 .CopyToDataTable();// LinQ select data table.
                //DataTable tblFiltered = tabletemp.AsEnumerable()
                //                 .Where((r => r.Field<bool>("Chon") == true)).Where((o => o.Field<decimal>("Quantity") > 1))
                //                 .CopyToDataTable();// LinQ select data table.
                if (TagApp == "NKMH")
                {
                    frmchungtu.LoadFromPO("", lookUpEditNCC.GetColumnValue("Customer_ID").ToString(), tblFiltered);
                    Close();
                }
                else if (TagApp == "XKHT")
                {
                    //frmtrahangncc.l
                    frmtrahangncc.LoadFromPO("", lookUpEditNCC.GetColumnValue("Customer_ID").ToString(), tblFiltered);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhấn nút lấy dữ liệu !","Thông Báo");
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
    }
}