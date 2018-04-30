using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Xml;
namespace SalesManager
{
    public partial class frmCapNhatNhanVien : Form
    {
        public frmCapNhatNhanVien()
        {
            InitializeComponent();
            InitLookUp_PhongBan();
            InitLookUp_NhanVien();
        }
        EMPLOYEE objemployee = new EMPLOYEE();
        public void Load_Data(EMPLOYEE objemployee)
        {
            this.objemployee = objemployee;
            txtMa.Text = objemployee.Employee_ID;
            txtTen.Text = objemployee.Employee_Name;
            chkquanli.Checked = objemployee.Active;
            txtchucvu.Text = objemployee.Position_ID;
            txtdiachi.Text = objemployee.Address;
            txtemail.Text = objemployee.Email;
            txtdienthoai.Text = objemployee.O_Tel;
            txtdidong.Text = objemployee.H_Tel;
            lookbophan.EditValue = objemployee.Department_ID;
            looknhanvien.EditValue = objemployee.Employee_ID;
        }
        private void InitLookUp_PhongBan()
        {
            // Specify the data source to display in the dropdown.
            lookbophan.Properties.DataSource = new DEPARTMENTController().LayDSDEPARTMENT_GROUP();
            // The field providing the editor's display text.
            lookbophan.Properties.DisplayMember = "Department_Name";
            // The field matching the edit value.
            lookbophan.Properties.ValueMember = "Department_ID";
            lookbophan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookbophan.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookbophan.Properties.AutoSearchColumnIndex = 1;
        }
        private void InitLookUp_NhanVien()
        {
            // Specify the data source to display in the dropdown.
            looknhanvien.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            // The field providing the editor's display text.
            looknhanvien.Properties.DisplayMember = "Employee_Name";
            // The field matching the edit value.
            looknhanvien.Properties.ValueMember = "Employee_ID";
            looknhanvien.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            looknhanvien.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            looknhanvien.Properties.AutoSearchColumnIndex = 1;
        }
        private void lookbophan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemPhongBan frm = new frmThemPhongBan();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_PhongBan();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objemployee.Employee_ID = txtMa.Text;
            objemployee.Employee_Name = txtTen.Text;
            objemployee.Active = chkquanli.Checked;
            objemployee.Position_ID = txtchucvu.Text;
            objemployee.Address = txtdiachi.Text;
            objemployee.Email = txtemail.Text;
            objemployee.O_Tel = txtdienthoai.Text;
            objemployee.H_Tel = txtdidong.Text;
            objemployee.Department_ID = lookbophan.GetColumnValue("Department_ID").ToString();
            objemployee.Manager_ID = looknhanvien.GetColumnValue("Employee_ID").ToString();
            rs = new EMPLOYEEController().CapNhatNhanVien(objemployee);
            if (rs < 1)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
