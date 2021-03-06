﻿using System;
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

namespace SalesManager
{
    public partial class UC_BangKeChiTietCK : UserControl
    {
        frmChuyenKho main_form;
        SYS_LOG _sys_log = new SYS_LOG();
        public UC_BangKeChiTietCK(frmChuyenKho _nhap, string _Timechon, DateTime _DateTimeFrom, DateTime _DateTimeTo, DataTable _table)
        {
            InitializeComponent();
            cbochon.Text = _Timechon;
            main_form = _nhap;
            dateTu.DateTime = _DateTimeFrom;
            dateDen.DateTime = _DateTimeTo;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            lookkhotu.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookkhotu.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookkhotu.Properties.ValueMember = "Stock_ID";
            //lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookkhotu.Properties.AutoSearchColumnIndex = 1;
            lookkhoden.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookkhoden.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookkhoden.Properties.ValueMember = "Stock_ID";
            //lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookkhoden.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = _table;

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
            gridControl1.DataSource = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_GetList_ByDate_Action(dateTu.DateTime, dateDen.DateTime, 0, 9);
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

        private void cbochon_SelectedValueChanged(object sender, EventArgs e)
        {
            ThoiGianController thoigian = new ThoiGianController();
            switch (cbochon.Text)
            {
                case "Hôm nay":
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    dateTu.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    dateDen.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Quý này":
                    dateTu.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    dateTu.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 1":
                    dateTu.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 2":
                    dateTu.DateTime = DateTime.Parse("02/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 3":
                    dateTu.DateTime = DateTime.Parse("03/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 4":
                    dateTu.DateTime = DateTime.Parse("04/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 5":
                    dateTu.DateTime = DateTime.Parse("05/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 6":
                    dateTu.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    dateTu.DateTime = DateTime.Parse("07/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 8":
                    dateTu.DateTime = DateTime.Parse("08/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 9":
                    dateTu.DateTime = DateTime.Parse("09/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 10":
                    dateTu.DateTime = DateTime.Parse("10/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 11":
                    dateTu.DateTime = DateTime.Parse("11/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 12":
                    dateTu.DateTime = DateTime.Parse("12/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridControl1.DataSource != null)
                main_form.resetdataCT(cbochon.Text, dateTu.DateTime, dateDen.DateTime, ((DataTable)(gridControl1.DataSource)).Copy());
            else
                main_form.resetdata("hello");
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Phiếu Chuyển Kho Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    int rs = -1;
                    int rsdetail = -1;
                    rs = new STOCK_TRANSFERController().STOCK_TRANSFER_Delete(id);
                    DataTable TableStockdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_GetList_ByTransferID(id);
                    foreach (DataRow datarow in TableStockdetail.Rows)
                    {
                        rsdetail = new STOCK_TRANSFER_DETAILController().STOCK_TRANSFER_DETAIL_Delete(new Guid(datarow["ID"].ToString()));
                    }
                    if ((rs > -1))
                    {
                        MessageBox.Show("Phiếu chuyển kho đã được xóa", "Thông báo");
                        _sys_log.MChine = new MobilityNetwork().GetComputerName();
                        _sys_log.IP = new MobilityNetwork().GetIP();
                        _sys_log.UserID = "US000001";
                        _sys_log.Created = DateTime.Now;
                        _sys_log.Action_Name = "Xóa";
                        _sys_log.Description = "Xóa Bảng Kê Phiếu Chuyển Kho" + "-" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                        _sys_log.Reference = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                        _sys_log.Module = "Bảng Kê Phiếu Chuyển Kho";
                        _sys_log.Active = true;
                        SYS_LOGController insertlog = new SYS_LOGController();
                        insertlog.SYS_LOG_Insert(_sys_log);
                    }
                    else
                    {
                        MessageBox.Show("Phiếu chuyển kho không được xóa", "Thông báo");

                    }
                }
            }

        }
    }
}
