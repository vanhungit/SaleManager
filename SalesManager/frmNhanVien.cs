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

namespace SalesManager
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new EMPLOYEEController().LayDSNhanVien();

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

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new EMPLOYEEController().LayDSNhanVien();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Nhân Viên Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    rs = new EMPLOYEEController().XoaNhanVien(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Nhân viên không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new EMPLOYEEController().LayDSNhanVien();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }

        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();

        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                EMPLOYEE objemployee = new EMPLOYEE();
                objemployee = new EMPLOYEEController().LayTenNhanVien(id);
                frmCapNhatNhanVien frm = new frmCapNhatNhanVien();
                frm.Load_Data(objemployee);
                frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                EMPLOYEE objemployee = new EMPLOYEE();
                objemployee = new EMPLOYEEController().LayTenNhanVien(id);
                frmCapNhatNhanVien frm = new frmCapNhatNhanVien();
                frm.Load_Data(objemployee);
                frm.ShowDialog();
            }
        }
    }
}