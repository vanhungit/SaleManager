using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using SalesManager.Entity;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmChinhSuaThietBi : Form
    {
        Guid MobileID;
        Mobile_User objmobiuser = new Mobile_User();
        public frmChinhSuaThietBi(string ID)
        {
            InitializeComponent();
            gridLookUpEdit1.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit1.Properties.DisplayMember = "Employee_Name";
            gridLookUpEdit1.Properties.ValueMember = "Employee_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            MobileID = new Guid(ID);
            objmobiuser = new Mobile_UserController().Mobile_User_Get(MobileID);
            txtIP.Text = objmobiuser.IP_Address;
            txtMobileName.Text = objmobiuser.MobiName;
            txtSeriNum.Text = objmobiuser.SeriNumber;
            dtcreate.DateTime = objmobiuser.CreateDate;
            GhiChu.Text = objmobiuser.Decription;
            gridLookUpEdit1.EditValue = objmobiuser.Employee_ID;
            chkquanli.Checked = objmobiuser.Active;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objmobiuser.Employee_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Employee_ID");
            objmobiuser.IP_Address = txtIP.Text;
            objmobiuser.MobiName = txtMobileName.Text;
            objmobiuser.SeriNumber = txtSeriNum.Text;
            objmobiuser.CreateDate = dtcreate.DateTime;
            objmobiuser.Decription = GhiChu.Text;
            objmobiuser.Active = chkquanli.Checked;
            rs = new Mobile_UserController().Mobile_User_Update(objmobiuser);
            if (rs > -1)
            {
                MessageBox.Show("Thiết bị cập nhật thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thiết bị cập nhật thất bại", "Thông báo");

            }
        }
    }
}
