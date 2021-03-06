using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
namespace SalesManager
{
    public partial class frmNhatKyNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmNhatKyNguoiDung()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            //_sys_log.SYS_ID = new SYS_LOGController().Max_SYS_LOG_ID() + 1;
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Nhật Ký Hệ Thống";
            _sys_log.Module = "Nhật Ký Hệ Thống";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            gridControl1.DataSource = new SYS_LOGController().SYS_LOG_GetList_ByDate(DateTime.Now, DateTime.Now);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new SYS_LOGController().SYS_LOG_GetList_ByDate(DateTime.Now, DateTime.Now);
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SYS_LOG _sys_log = new SYS_LOG();
            if (MessageBox.Show("Bạn Muốn Xóa Nhật Ký Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                    //MessageBox.Show(id);
                    rs = new SYS_LOGController().SYS_LOG_Delete(Convert.ToInt32(id));
                    if (rs < 1)
                    {
                        MessageBox.Show("Nhật ký không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Nhật ký đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new SYS_LOGController().SYS_LOG_GetList_ByDate(DateTime.Now, DateTime.Now);
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[-1]).ToString();
        }
    }
}