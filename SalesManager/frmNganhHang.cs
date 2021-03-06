using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesManager.Controller;
using SalesManager.ImportExcel;
using SalesManager.Entity;

namespace SalesManager
{
    public partial class frmNganhHang : DevExpress.XtraEditors.XtraForm
    {
        public frmNganhHang()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
        }
        public void RefreshData()
        {
            gridControl1.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
        }
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNganhHang frm = new frmThemNganhHang(this);
            frm.ShowDialog();
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

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportNganhHang frm = new frmImportNganhHang(this);
            frm.ShowDialog();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();

        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                NGANH_HANG objnganh = new NGANH_HANG();
                objnganh = new NGANH_HANGController().PRODUCT_NGANHHANG_Get(id);
                frmCapNhatNganhHang frm = new frmCapNhatNganhHang(this, objnganh);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Ngành Hàng Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    rs = new NGANH_HANGController().XoaNGANHHANG(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Ngành hàng không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Ngành hàng đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");

            }
        }
    }
}