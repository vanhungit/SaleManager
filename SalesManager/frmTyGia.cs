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
    public partial class frmTyGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTyGia()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new CURRENCYController().CURRENCY_GetList();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new CURRENCYController().CURRENCY_GetList();
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
            if (MessageBox.Show("Bạn Muốn Xóa Tỷ Giá Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    rs = new CURRENCYController().CURRENCY_Delete(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Tỷ giá không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Tỷ giá đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new CURRENCYController().CURRENCY_GetList();
                }
            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemTyGia frm = new frmThemTyGia();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                CURRENCY objcurrentcy = new CURRENCY();
                objcurrentcy = new CURRENCYController().CURRENCY_Get(id);
                frmCapNhatTyGia frm = new frmCapNhatTyGia();
                frm.Load_Data(objcurrentcy);
                frm.ShowDialog();
            }
        }
    }
}