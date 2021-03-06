using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using SalesManager.ImportExcel;
using SalesManager.Controller;
using DevExpress.XtraEditors.Controls;

namespace SalesManager
{
    public partial class frmNhomHang : DevExpress.XtraEditors.XtraForm
    {
        public frmNhomHang()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
            repositoryItemLookUpNganh.Properties.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
            repositoryItemLookUpNganh.Properties.DisplayMember = "TEN_NGANH";
            repositoryItemLookUpNganh.Properties.ValueMember = "ID_NGANH";
            repositoryItemLookUpNganh.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNhomHang frm = new frmThemNhomHang();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                PRODUCT_GROUP objunit = new PRODUCT_GROUP();
                objunit = new PRODUCT_GROUPController().PRODUCT_GROUP_Get(id);
                frmCapNhatNhomHang frm = new frmCapNhatNhomHang();
                frm.Load_Data(objunit);
                frm.ShowDialog();
            }
        }
        public void RefreshData()
        {
            gridControl1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                PRODUCT_GROUP objunit = new PRODUCT_GROUP();
                objunit = new PRODUCT_GROUPController().PRODUCT_GROUP_Get(id);
                frmCapNhatNhomHang frm = new frmCapNhatNhomHang();
                frm.Load_Data(objunit);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Nhóm Hàng Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    rs = new PRODUCT_GROUPController().PRODUCT_GROUP_Delete(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Nhóm Hàng không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Nhóm Hàng đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportNhomhang frm = new frmImportNhomhang(this);
            frm.ShowDialog();
        }
    }
}