using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
namespace SalesManager
{
    public partial class frmCapNhatKhoHang : Form
    {
        public frmCapNhatKhoHang()
        {
            InitializeComponent();
            InitLookUp();
        }
        STOCK objstock = new STOCK();
        private void InitLookUp()
        {
            // Specify the data source to display in the dropdown.
            looknguoiquanli.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            // The field providing the editor's display text.
            looknguoiquanli.Properties.DisplayMember = "Employee_Name";
            // The field matching the edit value.
            looknguoiquanli.Properties.ValueMember = "Employee_ID";
            looknguoiquanli.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            looknguoiquanli.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            looknguoiquanli.Properties.AutoSearchColumnIndex = 1;
        }
        public void Load_Data(STOCK obj)
        {
            objstock = obj;
            txtMa.Text = obj.Stock_ID;
            txtkihieu.Text = obj.Mobi;
            txtten.Text = obj.Stock_Name;
            txtnguoilienhe.Text = obj.Contact;
            txtdiachi.Text = obj.Address;
            txtDienthoai.Text = obj.Telephone;
            txtFax.Text = obj.Fax;
            txtEmail.Text = obj.Email;
            txtdiengiai.Text = obj.Description;
            chkquanli.Checked = obj.Active;
            looknguoiquanli.EditValue = obj.Manager;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objstock.Stock_ID = txtMa.Text;
            objstock.Mobi = txtkihieu.Text;
            objstock.Manager = looknguoiquanli.GetColumnValue("Employee_ID").ToString();
            objstock.Stock_Name = txtten.Text;
            objstock.Contact = txtnguoilienhe.Text;
            objstock.Address = txtdiachi.Text;
            objstock.Telephone = txtDienthoai.Text;
            objstock.Fax = txtFax.Text;
            objstock.Email = txtEmail.Text;
            objstock.Description = txtdiengiai.Text;
            objstock.Active = chkquanli.Checked;
            rs = new STOCKController().STOCK_Update(objstock,objstock.Stock_ID);
            if (rs < 1)
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thành Công", "Thông báo");
                Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
