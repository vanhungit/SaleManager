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
    public partial class frmHangHoa : DevExpress.XtraEditors.XtraForm
    {
        public frmHangHoa()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            repositoryItemLookUpEdit1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
            gridControl1.DataSource = new PRODUCTController().PRODUCT_GetFull_Stock();

        }
        public void RefreshData()
        {
            repositoryItemLookUpEdit1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
            gridControl1.DataSource = new PRODUCTController().PRODUCT_GetFull_Stock();

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
            repositoryItemLookUpEdit1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
            gridControl1.DataSource = new PRODUCTController().PRODUCT_GetFull_Stock();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Mặt Hàng Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                    rs = new PRODUCTController().PRODUCT_Delete(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Hàng hóa không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Hàng hóa đã được xóa", "Thông báo");

                    }
                    repositoryItemLookUpEdit1.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetList();
                    gridControl1.DataSource = new PRODUCTController().PRODUCT_GetFull_Stock();
                }

            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemHangHoa_DichVu frm = new frmThemHangHoa_DichVu();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                PRODUCT objproduct = new PRODUCT();
                objproduct = new PRODUCTController().PRODUCT_Get(id);
                frmCapNhatHoangHoa_DichVu frm = new frmCapNhatHoangHoa_DichVu();
                frm.Load_Data(objproduct);
                frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                PRODUCT objproduct = new PRODUCT();
                objproduct = new PRODUCTController().PRODUCT_Get(id);
                frmCapNhatHoangHoa_DichVu frm = new frmCapNhatHoangHoa_DichVu();
                frm.Load_Data(objproduct);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportHangHoa frm = new frmImportHangHoa(this);
            frm.ShowDialog();
        }
    }
}