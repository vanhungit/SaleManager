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
    public partial class frmTongHopTonKho : Form
    {
        public frmTongHopTonKho()
        {
            InitializeComponent();
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Tổng Hợp Tồn Kho");
            advBandedGridView1.Invalidate();
            advBandedGridView1.IndicatorWidth = 40;
            datefrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
            InitLookUp_KhoHang();
            gridControl1.DataSource = new INVENTORY_DETAILController().INVENTORY_DETAIL_SUMMARY_THXNTON(datefrom.DateTime, dateTo.DateTime, "K000001");
            WaitDialog.CloseWaitDialog();

        }
        private void InitLookUp_KhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookkho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookkho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookkho.Properties.ValueMember = "Stock_ID";
            lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookkho.Properties.AutoSearchColumnIndex = 1;
            lookkho.EditValue = new STOCKController().STOCK_Top1().Stock_ID;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new INVENTORY_DETAILController().INVENTORY_DETAIL_SUMMARY_THXNTON(datefrom.DateTime, dateTo.DateTime, "K000002");
        }

        private void chon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThoiGianController thoigian = new ThoiGianController();
            switch (chon.Text)
            {
                case "Hôm nay":
                    datefrom.DateTime = DateTime.Now;
                    dateTo.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    datefrom.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    dateTo.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Quý này":
                    datefrom.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateTo.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    datefrom.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 1":
                    datefrom.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 2":
                    datefrom.DateTime = DateTime.Parse("02/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 3":
                    datefrom.DateTime = DateTime.Parse("03/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 4":
                    datefrom.DateTime = DateTime.Parse("04/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 5":
                    datefrom.DateTime = DateTime.Parse("05/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 6":
                    datefrom.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    datefrom.DateTime = DateTime.Parse("07/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 8":
                    datefrom.DateTime = DateTime.Parse("08/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 9":
                    datefrom.DateTime = DateTime.Parse("09/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 10":
                    datefrom.DateTime = DateTime.Parse("10/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 11":
                    datefrom.DateTime = DateTime.Parse("11/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 12":
                    datefrom.DateTime = DateTime.Parse("12/01/" + DateTime.Now.Year);
                    dateTo.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Quý 1":
                    datefrom.DateTime = thoigian.StartDayofQui(1, DateTime.Now.Year);
                    dateTo.DateTime = thoigian.EndDayofQui(1, DateTime.Now.Year);
                    break;
                case "Quý 2":
                    datefrom.DateTime = thoigian.StartDayofQui(2, DateTime.Now.Year);
                    dateTo.DateTime = thoigian.EndDayofQui(2, DateTime.Now.Year);
                    break;
                case "Quý 3":
                    datefrom.DateTime = thoigian.StartDayofQui(3, DateTime.Now.Year);
                    dateTo.DateTime = thoigian.EndDayofQui(3, DateTime.Now.Year);
                    break;
                case "Quý 4":
                    datefrom.DateTime = thoigian.StartDayofQui(4, DateTime.Now.Year);
                    dateTo.DateTime = thoigian.EndDayofQui(4, DateTime.Now.Year);
                    break;
                default:
                    datefrom.DateTime = DateTime.Now;
                    dateTo.DateTime = DateTime.Now;
                    break;
            }
        }

        private void advBandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ShowPreview();
        }
    }
}
