using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;

namespace SalesManager
{
    public partial class UC_ThietBiNguoiDung : UserControl
    {
        public UC_ThietBiNguoiDung()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            repositoryItemGridLookUpEdit1.DataSource = new EMPLOYEEController().LayDSNhanVien();
            repositoryItemGridLookUpEdit1.DisplayMember = "Employee_Name";
            repositoryItemGridLookUpEdit1.ValueMember = "Employee_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            gridControl1.DataSource = new Mobile_UserController().Mobile_User_GetList();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new Mobile_UserController().Mobile_User_GetList();

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
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                frmChinhSuaThietBi frm = new frmChinhSuaThietBi(id);
                frm.ShowDialog();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Thiết Bị Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                    rs = new Mobile_UserController().Mobile_User_Delete(new Guid(id));
                    if (rs < 1)
                    {
                        MessageBox.Show("Thiết bị không được xóa", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Thiết bị đã được xóa", "Thông báo");

                    }
                    gridControl1.DataSource = new Mobile_UserController().Mobile_User_GetList();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }
    }
}
