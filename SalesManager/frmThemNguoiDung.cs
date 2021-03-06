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
using DevExpress.XtraEditors.Controls;
namespace SalesManager
{
    public partial class frmThemNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmThemNguoiDung()
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

        }
        public string CreateUserID()
        {
            int Dem = int.Parse(new SYS_USERController().SYS_USER_maxUser().UserID.Substring(2,6)) +1;
            string UserID = "US000001";
            if (Dem > 1)
            {
                UserID = "";
                for (int i = 0; i < 6 - Dem.ToString().Length; i++)
                {
                    UserID = "0" + UserID;
                }
                UserID = "US" + UserID + Dem;
            }
            return UserID;
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SYS_USER objsysuser = new SYS_USER();
            int rs = -1;
            objsysuser.UserID = CreateUserID();
            objsysuser.UserName = txtUserName.Text.Trim();
            objsysuser.Group_ID = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
            objsysuser.Description = gridLookUpEdit2.Text;
            objsysuser.PartID = gridLookUpEdit2View.GetRowCellValue(gridLookUpEdit2View.FocusedRowHandle, gridLookUpEdit2View.Columns[0]).ToString();
            objsysuser.Active = chkactive.Checked;
            objsysuser.Password = txtPass.Text.Trim();
            rs = new SYS_USERController().SYS_USER_Insert(objsysuser);
            if (rs > -1)
            {
                MessageBox.Show("Lưu Thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }
    }
}