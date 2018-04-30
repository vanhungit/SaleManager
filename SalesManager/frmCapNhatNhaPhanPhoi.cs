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
    public partial class frmCapNhatNhaPhanPhoi : Form
    {
        public frmCapNhatNhaPhanPhoi()
        {
            InitializeComponent();
        }
        CUSTOMER_GROUP objcustomer_group = new CUSTOMER_GROUP();
        PROVIDER objprovider = new PROVIDER();
        private void InitLookUp()
        {
            // Specify the data source to display in the dropdown.
            lookupkhuvuc.Properties.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
            // The field providing the editor's display text.
            lookupkhuvuc.Properties.DisplayMember = "Customer_Group_Name";
            // The field matching the edit value.
            lookupkhuvuc.Properties.ValueMember = "Customer_Group_ID";
            lookupkhuvuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookupkhuvuc.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookupkhuvuc.Properties.AutoSearchColumnIndex = 1;
        }
        public void Load_Data(PROVIDER objprovider)
        {
            InitLookUp();
            this.objprovider = objprovider;
            txtMa.Text = objprovider.Customer_ID;
            txtten.Text = objprovider.CustomerName;
            txtdiachi.Text = objprovider.CustomerAddress;
            txtMST.Text = objprovider.Tax;
            txtFax.Text = objprovider.Fax;
            txtDienthoai.Text = objprovider.Tel;
            txtMobile.Text = objprovider.Mobile;
            txtEmail.Text = objprovider.Email;
            txtwebsite.Text = objprovider.Website;
            txtTaiKhoan.Text = objprovider.BankAccount;
            txtNganhang.Text = objprovider.BankName;
            calgioihanno.Text =  objprovider.CreditLimit.ToString();
            calcchietkhau.Text = objprovider.Discount.ToString();
            txtchucvu.Text = objprovider.Position;
            chkquanli.Checked = objprovider.Active;
            txtnguoilienhe.Text = objprovider.Contact;
            lookupkhuvuc.EditValue = objprovider.Customer_Group_ID;

        }
        private void lookkhuvuc_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemKhuVuc frm = new frmThemKhuVuc();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objcustomer_group = new CUSTOMER_GROUPController().LayTTCUSTOMER_ByName(lookupkhuvuc.Text.Trim());
            objprovider.Customer_ID = txtMa.Text;
            objprovider.Barcode = txtMa.Text;
            objprovider.OrderID = 0;
            objprovider.CustomerName = txtten.Text;
            objprovider.Customer_Type_ID = "0";
            objprovider.Customer_Group_ID = objcustomer_group.Customer_Group_ID;
            objprovider.CustomerAddress = txtdiachi.Text;
            objprovider.Tax = txtMST.Text;
            objprovider.Fax = txtFax.Text;
            objprovider.Email = txtEmail.Text;
            objprovider.Tel = txtDienthoai.Text;
            objprovider.Mobile = txtMobile.Text;
            objprovider.Contact = txtnguoilienhe.Text;
            objprovider.Website = txtwebsite.Text;
            objprovider.BankAccount = txtTaiKhoan.Text;
            objprovider.BankName = txtNganhang.Text;
            objprovider.CreditLimit = double.Parse(calgioihanno.Text);
            objprovider.Discount = double.Parse(calcchietkhau.Text);
            objprovider.Position = txtchucvu.Text;
            objprovider.Active = chkquanli.Checked;
            rs = new PROVIDERController().PROVIDER_Update(objprovider,objprovider.Customer_ID);
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
