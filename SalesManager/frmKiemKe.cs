using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Entity;
using SalesManager.Controller;
namespace SalesManager
{
    public partial class frmKiemKe : DevExpress.XtraEditors.XtraForm
    {
        ADJUSTMENT objadjustment = new ADJUSTMENT();
        ADJUSTMENT_DETAIL objadjustdetail = new ADJUSTMENT_DETAIL();
        SYS_LOG _sys_log = new SYS_LOG();
        public frmKiemKe()
        {
            InitializeComponent();
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 30;
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            gridLookUpEdit1.Properties.DataSource = new STOCKController().STOCK_GetList();
            gridLookUpEdit1.Properties.DisplayMember = "Stock_Name";
            gridLookUpEdit1.Properties.ValueMember = "Stock_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpEdit1.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit1.Properties.ValueMember = "Unit_ID";//tìm theo
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;
            gridControl2.DataSource = new ADJUSTMENTController().LayDSADJUSTMENT();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Báo Cáo Kiểm Kê";
            _sys_log.Module = "Báo Cáo Kiểm Kê";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = new PRODUCTController().Mobi_PRODUCT_GetByStore_ByStockID(gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID"));
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

        private void cbochon_SelectedIndexChanged(object sender, EventArgs e)
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int rsstock = -1;
            objadjustment.ID = "KK" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            objadjustment.RefDate = DateTime.Now;
            objadjustment.Ref_OrgNo = objadjustment.ID;
            objadjustment.RefType = 5;
            objadjustment.Employee_ID = "US000001";
            objadjustment.Stock_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            objadjustment.Accept = true;
            objadjustment.IsClose = false;
            objadjustment.Description = "(Kiểm Kê)";
            objadjustment.User_ID = "US000001";
            objadjustment.Active = true;
            objadjustdetail.Adjustment_ID = objadjustment.ID;
            objadjustdetail.Stock_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            ADJUSTMENTController test = new ADJUSTMENTController();
            rsstock = test.ThemADJUSTMENT(objadjustment);
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount ; i++)
                {
                    int rsstockdetail = -1;
                    objadjustdetail.ID = Guid.NewGuid();
                    objadjustdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objadjustdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objadjustdetail.Unit = new PRODUCTController().PRODUCT_Get(gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString()).Unit;
                    objadjustdetail.UnitConvert = 1;
                    objadjustdetail.NewQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                    objadjustdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
                    objadjustdetail.QtyDiff = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                    objadjustdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                    objadjustdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                    rsstockdetail = new ADJUSTMENT_DETAILController().ThemADJUSTMENT_DETAIL(objadjustdetail);
                    if (rsstockdetail == -1)
                    {
                        MessageBox.Show("Lưu Thất Bại", "Thông Báo");
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            if (rsstock > -1)
            {
                MessageBox.Show("Lưu Thành công", "Thông Báo");
                gridControl2.DataSource = new ADJUSTMENTController().LayDSADJUSTMENT();
            }
            else
            {
                MessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount > 0)
            {
                int rs = -1;
                string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                frmXemLichSuKiemKe frm = new frmXemLichSuKiemKe(id);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = new ADJUSTMENTController().LayDSADJUSTMENT();

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Kiểm Kê Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView2.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                    rs = new ADJUSTMENTController().XoaADJUSTMENT(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Kiểm kê không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Kiểm kê đã được xóa", "Thông báo");

                    }
                    gridControl2.DataSource = new ADJUSTMENTController().LayDSADJUSTMENT();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rsstock = -1;
            objadjustment.ID = "KK" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            objadjustment.RefDate = DateTime.Now;
            objadjustment.Ref_OrgNo = objadjustment.ID;
            objadjustment.RefType = 5;
            objadjustment.Employee_ID = "US000001";
            objadjustment.Stock_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            objadjustment.Accept = true;
            objadjustment.IsClose = false;
            objadjustment.Description = "(Kiểm Kê)";
            objadjustment.User_ID = "US000001";
            objadjustment.Active = true;
            objadjustdetail.Adjustment_ID = objadjustment.ID;
            objadjustdetail.Stock_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Stock_ID");
            ADJUSTMENTController test = new ADJUSTMENTController();
            rsstock = test.ThemADJUSTMENT(objadjustment);
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i < gridView1.RowCount ; i++)
                {
                    int rsstockdetail = -1;
                    objadjustdetail.ID = Guid.NewGuid();
                    objadjustdetail.Product_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    objadjustdetail.Product_Name = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    objadjustdetail.Unit = new PRODUCTController().PRODUCT_Get(gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString()).Unit;
                    objadjustdetail.UnitConvert = 1;
                    objadjustdetail.NewQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
                    objadjustdetail.CurrentQty = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
                    objadjustdetail.QtyDiff = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString());
                    objadjustdetail.UnitPrice = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString());
                    objadjustdetail.Amount = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString());
                    rsstockdetail = new ADJUSTMENT_DETAILController().ThemADJUSTMENT_DETAIL(objadjustdetail);
                    if (rsstockdetail == -1)
                    {
                        MessageBox.Show("Lưu Thất Bại", "Thông Báo");
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
            if (rsstock > -1)
            {
                MessageBox.Show("Lưu Thành công", "Thông Báo");
                gridControl2.DataSource = new ADJUSTMENTController().LayDSADJUSTMENT();
            }
            else
            {
                MessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.RowCount > 0)
            {
                int rs = -1;
                string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                frmXemLichSuKiemKe frm = new frmXemLichSuKiemKe(id);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
        }

       
    }
}