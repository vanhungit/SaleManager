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
using SalesManager.ImportExcel;

namespace SalesManager
{
    public partial class frmDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmDonVi()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new UNITController().UNIT_GetList();
        }
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemDonVi frm = new frmThemDonVi();
            frm.ShowDialog();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new UNITController().UNIT_GetList();

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

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Đơn Vị Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    rs = new UNITController().UNIT_Delete(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Đơn vị không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new UNITController().UNIT_GetList();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                UNIT objunit = new UNIT();
                objunit = new UNITController().UNIT_Get(id);
                frmCapNhatDonVi frm = new frmCapNhatDonVi();
                frm.Load_Data(objunit);
                frm.ShowDialog();
            }
        }
        public void RefreshData()
        {
            gridControl1.DataSource = new UNITController().UNIT_GetList();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                UNIT objunit = new UNIT();
                objunit = new UNITController().UNIT_Get(id);
                frmCapNhatDonVi frm = new frmCapNhatDonVi();
                frm.Load_Data(objunit);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportDonVi frm = new frmImportDonVi(this);
            frm.ShowDialog();
        }

      
    }
}