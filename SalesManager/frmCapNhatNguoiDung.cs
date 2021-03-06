using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Entity;
namespace SalesManager
{
    public partial class frmCapNhatNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        SYS_USER objuser = new SYS_USER();
        public frmCapNhatNguoiDung(string _Username)
        {
            InitializeComponent();
            gridLookUpEdit2.Properties.DataSource = new SYS_USERController().SYS_USER_GetEmpList();
            gridLookUpEdit2.Properties.DisplayMember = "Employee_Name";
            gridLookUpEdit2.Properties.ValueMember = "Employee_ID";
            gridLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit1.Properties.DataSource = new SYS_GROUPController().SYS_GROUP_GetList();
            gridLookUpEdit1.Properties.DisplayMember = "Group_Name";
            gridLookUpEdit1.Properties.ValueMember = "Group_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            objuser = new SYS_USERController().SYS_USER_Get_By_UserName(_Username);
            gridLookUpEdit2.EditValue = objuser.PartID;
            txtUserName.Text = _Username;
            txtPass.Text = objuser.Password;
            txtPassMask.Text = objuser.Password;
            gridLookUpEdit1.EditValue = objuser.Group_ID;
            txtDescription.Text = objuser.Description;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objuser.UserName = txtUserName.Text.Trim();
            objuser.Group_ID = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
            objuser.Description = gridLookUpEdit2.Text;
            objuser.PartID = gridLookUpEdit2View.GetRowCellValue(gridLookUpEdit2View.FocusedRowHandle, gridLookUpEdit2View.Columns[0]).ToString();
            objuser.Active = chkactive.Checked;
            objuser.Password = txtPass.Text.Trim();
            objuser.Description = txtDescription.Text;
            rs = new SYS_USERController().SYS_USER_Update(objuser, objuser.UserID);
            if (rs > -1)
            {
                MessageBox.Show("Cập Nhật Thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất bại", "Thông Báo");

            }
        }
    }
}