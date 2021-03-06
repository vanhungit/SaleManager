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
    public partial class frm_KhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frm_KhachHang()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new CUSTOMERController().LayDSCUSTOMER();
        }
        public void RefreshData()
        {
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new CUSTOMERController().LayDSCUSTOMER();

        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
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

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new CUSTOMERController().LayDSCUSTOMER();

        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Khách Hàng Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                    rs = new CUSTOMERController().XoaCUSTOMER(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Khách hàng không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng đã được xóa", "Thông báo");

                    }
                    repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
                    gridControl1.DataSource = new CUSTOMERController().LayDSCUSTOMER();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");

            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemKhachHang frm = new frmThemKhachHang();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                CUSTOMER objcustomer = new CUSTOMER();
                objcustomer = new CUSTOMERController().LayTTCUSTOMER(id);
                frmCapNhatKhachHang frm = new frmCapNhatKhachHang();
                frm.Load_Data(objcustomer);
                frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.Columns[0].View.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                CUSTOMER objcustomer = new CUSTOMER();
                objcustomer = new CUSTOMERController().LayTTCUSTOMER(id);
                frmCapNhatKhachHang frm = new frmCapNhatKhachHang();
                frm.Load_Data(objcustomer);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportKhachHang frm = new frmImportKhachHang(this);
            frm.ShowDialog();
        }
    }
}