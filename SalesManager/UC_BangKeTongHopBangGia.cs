using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Entity;
using SalesManager.Controller;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class UC_BangKeTongHopBangGia : UserControl
    {
        public UC_BangKeTongHopBangGia()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
            gridControl1.DataSource = new BANGGIAController().BANGGIA_GetList_ByDate(dateTu.DateTime,dateDen.DateTime);
            repositoryItemLookUpLoaiGia.Properties.DataSource = new BANGGIAController().LoaiBangGia();
            repositoryItemLookUpLoaiGia.Properties.DisplayMember = "TEN_LOAI";
            // The field matching the edit value.
            repositoryItemLookUpLoaiGia.Properties.ValueMember = "ID";
            repositoryItemLookUpLoaiGia.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpLoaiGia.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpLoaiGia.Properties.AutoSearchColumnIndex = 1;
        }
        public void Refresh()
        {
            gridControl1.DataSource = new BANGGIAController().BANGGIA_GetList_ByDate(dateTu.DateTime, dateDen.DateTime);
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemBangGia frm = new frmThemBangGia(this);
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new BANGGIAController().BANGGIA_GetList_ByDate(dateTu.DateTime, dateDen.DateTime);
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
            if (MessageBox.Show("Bạn Muốn Xóa Bảng Giá Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    BANGGIA objgia = new BANGGIAController().LayTenBANGGIA(id);
                    if (objgia.Active == true)
                    {
                        MessageBox.Show("Không Được Xóa Bảng Giá Đang Áp Dụng", "Thông báo");
                    }
                    else
                    {
                        rs = new BANGGIAController().XoaBANGGIA(id);
                        if (rs < 1)
                        {
                            MessageBox.Show("Bảng giá không được xóa", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Bảng giá đã được xóa", "Thông báo");
                        }
                        gridControl1.DataSource = new BANGGIAController().BANGGIA_GetList_ByDate(dateTu.DateTime, dateDen.DateTime);

                    }
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Set Bảng Giá Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    BANGGIA objgia = new BANGGIAController().LayTenBANGGIA(id);
                    rs = new BANGGIAController().SetBangGia(id, objgia.RefType);
                    if (rs < 1)
                    {
                        MessageBox.Show("Bảng giá không được Set", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Bảng giá đã được Set", "Thông báo");
                    }
                    gridControl1.DataSource = new BANGGIAController().BANGGIA_GetList_ByDate(dateTu.DateTime, dateDen.DateTime);

                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                //main_form.SuaChuaPhieuBanHang(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                BANGGIA objgia = new BANGGIAController().LayTenBANGGIA(id);
                frmCapNhatBangGia frm = new frmCapNhatBangGia(this, objgia);
                frm.ShowDialog();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                //main_form.SuaChuaPhieuBanHang(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                BANGGIA objgia = new BANGGIAController().LayTenBANGGIA(id);
                frmCapNhatBangGia frm = new frmCapNhatBangGia(this, objgia);
                frm.ShowDialog();
            }
        }
    }
}
