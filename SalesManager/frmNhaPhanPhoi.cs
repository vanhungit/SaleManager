using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using SalesManager.ImportExcel;
namespace SalesManager
{
    public partial class frmNhaPhanPhoi : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmNhaPhanPhoi()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new PROVIDERController().PROVIDER_GetList();
        }
        public frmNhaPhanPhoi(Main frm, DataTable _table_look, DataTable _table)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new PROVIDERController().PROVIDER_GetList();
        }
        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new PROVIDERController().PROVIDER_GetList();
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
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                PROVIDER objcustomer = new PROVIDER();
                objcustomer = new PROVIDERController().PROVIDER_Get(id);
                frmCapNhatNhaPhanPhoi frm = new frmCapNhatNhaPhanPhoi();
                frm.Load_Data(objcustomer);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Nhà Cung Cấp Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                    rs = new PROVIDERController().PROVIDER_Delete(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Nhà Cung cấp không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Nhà cung cấp đã được xóa", "Thông báo");

                    }
                    repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
                    gridControl1.DataSource = new PROVIDERController().PROVIDER_GetList();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");

            }
        }

        private void barLargeButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadNhaPhanPhoi(((DataTable)repositoryItemLookUpEdit1.DataSource).Copy(), null);
            Close();
        }

        private void barLargeButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemLookUpEdit1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            gridControl1.DataSource = new PROVIDERController().PROVIDER_GetList();
        }

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemPhanPhoi frm = new frmThemPhanPhoi();
            frm.ShowDialog();
        }

        private void barLargeButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                //MessageBox.Show(id);
                PROVIDER objcustomer = new PROVIDER();
                objcustomer = new PROVIDERController().PROVIDER_Get(id);
                frmCapNhatNhaPhanPhoi frm = new frmCapNhatNhaPhanPhoi();
                frm.Load_Data(objcustomer);
                frm.ShowDialog();
            }

        }

        private void barLargeButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmImportNhaCC frm = new frmImportNhaCC(this);
            frm.ShowDialog();
        }
    }
}
