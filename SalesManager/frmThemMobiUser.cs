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
using SalesManager.Entity;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmThemMobiUser : DevExpress.XtraEditors.XtraForm
    {
        public frmThemMobiUser(string  IP, string Name)
        {
            InitializeComponent();
            gridLookUpEdit1.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            gridLookUpEdit1.Properties.DisplayMember = "Employee_Name";
            gridLookUpEdit1.Properties.ValueMember = "Employee_ID";
            gridLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            txtIP.Text = IP;
            txtName.Text = Name;
            CreateDate.DateTime = DateTime.Now;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int trave = -1;
            Mobile_User objmobile = new Mobile_User();
            objmobile.ID = Guid.NewGuid();
            objmobile.IP_Address = txtIP.Text;
            objmobile.MobiName = txtName.Text;
            objmobile.Employee_ID = gridLookUpEdit1View.GetRowCellDisplayText(gridLookUpEdit1View.FocusedRowHandle, "Employee_ID");
            objmobile.OwnerID = "US000001";
            objmobile.Active = true;
            objmobile.CreateDate = CreateDate.DateTime;
            objmobile.Decription = memoEdit1.Text;
            objmobile.SeriNumber = textEdit3.Text;
            trave = new Mobile_UserController().Mobile_User_Insert(objmobile);
            if (trave > -1)
            {
                MessageBox.Show("Lưu Thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Lưu Thất bại", "Thông Báo");

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}