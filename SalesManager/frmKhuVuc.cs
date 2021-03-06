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
    public partial class frmKhuVuc : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmKhuVuc(Main frm, DataTable _table)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            gridControl1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();

        }
        CUSTOMER_GROUP objNV = new CUSTOMER_GROUP();        

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
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

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemKhuVuc frm = new frmThemKhuVuc();
            frm.ShowDialog();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Khu Vực Này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                    rs = new CUSTOMER_GROUPController().XoaCUSTOMER_GROUP(id);
                    if (rs < 1)
                    {
                        MessageBox.Show("Khu Vực không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Khu Vực đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
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
                CUSTOMER_GROUP objunit = new CUSTOMER_GROUP();
                objunit = new CUSTOMER_GROUPController().LayTTCUSTOMER_ByID(id);
                frmCapNhatKhuVuc frm = new frmCapNhatKhuVuc();
                frm.Load_Data(objunit);
                frm.ShowDialog();
            }
        }
    }
}