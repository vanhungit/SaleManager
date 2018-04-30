using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Controller;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmChonPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        UC_TraHangNCC frmTrahangNCC;
        public frmChonPhieuNhap(UC_TraHangNCC frm)
        {
            InitializeComponent();
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            InitLookUpKhoHang();
            InitLookUp_NhanVien();
            InitLookUpBophan();
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
            frmTrahangNCC = frm;
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
        
    }
}
