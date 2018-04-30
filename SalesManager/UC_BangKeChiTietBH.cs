using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using SalesManager.Controller;
using SalesManager.Entity;
using System.Net;
using System.Net.Sockets;
namespace SalesManager
{
    public partial class UC_BangKeChiTietBH : UserControl
    {
        frmBanHang main_form;
        SYS_LOG _sys_log = new SYS_LOG();
        public UC_BangKeChiTietBH(frmBanHang _nhap, string _Timechon,DateTime _DateTimeFrom, DateTime _DateTimeTo, DataTable _table)
        {

            InitializeComponent();
            cbochon.Text = _Timechon;
            dateDen.DateTime = _DateTimeFrom;
            dateTu.DateTime = _DateTimeTo;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = _table;
            main_form = _nhap;
        }
        #region Function Tra ve
        public string DateTimeChon()
        {
            return (cbochon.Text);
        }
        public DateTime DateTimeFrom()
        {
            return (dateTu.DateTime);
        }
        public DateTime DateTimeTo()
        {
            return (dateDen.DateTime);
        }
        public DataTable GridControlTable()
        {
            return ((DataTable)(gridControl1.DataSource)).Copy();
        }
        #endregion
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_GetList_ByDate_Action(dateTu.DateTime, dateDen.DateTime, 0, 2);
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
            if (gridControl1.DataSource != null)
                main_form.resetdataCT(cbochon.Text, dateTu.DateTime, dateDen.DateTime, ((DataTable)(gridControl1.DataSource)).Copy());
            else
                main_form.resetdata("hello");
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Phiếu Bán Hàng Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    if ((new DEBTController().DEBT_GetbyRefID(id).Amount >= new DEBTController().DEBT_GetbyRefID(id).Payment) && (new DEBTController().DEBT_GetbyRefID(id).Payment > 0))
                    {
                        MessageBox.Show("Không thể xóa phiếu mua hàng này.\n\n Phiếu này đã được thu tiền.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int rs = -1;
                        int rsdetail = -1;
                        rs = new STOCK_OUTWARDController().STOCK_OUTWARD_Delete(id);
                        DataTable TableStockdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_GetList_ByID(id);
                        //rsdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Delete(new Guid("391fd8bf-0f5f-452e-bdc5-a2303be1c3d2"));
                        foreach (DataRow datarow in TableStockdetail.Rows)
                        {
                            rsdetail = new STOCK_OUTWARD_DETAILController().STOCK_OUTWARD_DETAIL_Delete(new Guid(datarow["ID"].ToString()));
                        }
                        if ((rs > -1))
                        {
                            MessageBox.Show("Phiếu bán hàng đã được xóa", "Thông báo");
                            _sys_log.MChine = new MobilityNetwork().GetComputerName();
                            _sys_log.IP = new MobilityNetwork().GetIP();
                            _sys_log.UserID = "US000001";
                            _sys_log.Created = DateTime.Now;
                            _sys_log.Action_Name = "Xóa";
                            _sys_log.Description = "Xóa Bảng Kê Phiếu Xuất" + "-" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                            _sys_log.Reference = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                            _sys_log.Module = "Bảng Kê Phiếu Xuất";
                            _sys_log.Active = true;
                            SYS_LOGController insertlog = new SYS_LOGController();
                            insertlog.SYS_LOG_Insert(_sys_log);
                        }
                        else
                        {
                            MessageBox.Show("Phiếu bán hàng không được xóa", "Thông báo");

                        }
                    }
                }


            }
        }

    

       
    }
}
