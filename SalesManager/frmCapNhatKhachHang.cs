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
    public partial class frmCapNhatKhachHang : Form
    {
        public frmCapNhatKhachHang()
        {
            InitializeComponent();
        }
        CUSTOMER_GROUP objcustomer_group = new CUSTOMER_GROUP();
        CUSTOMER objcustomer_form = new CUSTOMER();
        public void Load_Data(CUSTOMER objcustomer)
        {
            InitLookUp();
            InitLookLoai();
            objcustomer_form = objcustomer;
            txtMaKhach.Text = objcustomer.Customer_ID;
            //lookupkhuvuc.Text = (new CUSTOMER_GROUPController().LayTTCUSTOMER_ByID(objcustomer.Customer_Group_ID)).Customer_Group_Name;
            lookupkhuvuc.SelectedText = "Cần Thơ";
            txtTen.Text = objcustomer.CustomerName;
            txtDiaChi.Text = objcustomer.CustomerAddress;
            txtMST.Text = objcustomer.Tax;
            txtFax.Text = objcustomer.Fax;
            txtDienThoai.Text = objcustomer.Tel;
            txtMobile.Text = objcustomer.Mobile;
            txtEmail.Text = objcustomer.Email;
            txtwebsite.Text = objcustomer.Website;
            txtTaiKhoan.Text = objcustomer.BankAccount;
            txtNganHang.Text = objcustomer.BankName;
            calLimitNo.Text = objcustomer.CreditLimit.ToString();
            calchietkhau.Text = objcustomer.Discount.ToString();
            txtnguoilienhe.Text = objcustomer.Contact;
            txtyahoo.Text = objcustomer.NickYM;
            txtsky.Text = objcustomer.NickSky;
            chkquanli.Checked = objcustomer.Active;
            lookUpLoaiKhach.EditValue = (objcustomer.Customer_Type_ID);
            lookupkhuvuc.EditValue = objcustomer.Customer_Group_ID;

        }
        private void InitLookLoai()
        {
            // Specify the data source to display in the dropdown.
            lookUpLoaiKhach.Properties.DataSource = new CUSTOMER_GROUPController().LayDSLoaiKhachHang();
            // The field providing the editor's display text.
            lookUpLoaiKhach.Properties.DisplayMember = "Customer_Type_Name";
            // The field matching the edit value.
            lookUpLoaiKhach.Properties.ValueMember = "Customer_Type_ID";
            lookUpLoaiKhach.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLoaiKhach.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLoaiKhach.Properties.AutoSearchColumnIndex = 1;
            lookUpLoaiKhach.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

        }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objcustomer_group = new CUSTOMER_GROUPController().LayTTCUSTOMER_ByName(lookupkhuvuc.Text.Trim());
            objcustomer_form.Customer_ID = txtMaKhach.Text.Trim();
            objcustomer_form.OrderID = 0;
            objcustomer_form.CustomerName = txtTen.Text;
            objcustomer_form.Customer_Type_ID = lookUpLoaiKhach.GetColumnValue("Customer_Type_ID").ToString();
            objcustomer_form.Customer_Group_ID = objcustomer_group.Customer_Group_ID;
            objcustomer_form.CustomerAddress = txtDiaChi.Text.Trim();
            objcustomer_form.Tax = txtMST.Text;
            objcustomer_form.Fax = txtFax.Text;
            objcustomer_form.Tel = txtDienThoai.Text;
            objcustomer_form.Mobile = txtMobile.Text;
            objcustomer_form.Website = txtwebsite.Text;
            objcustomer_form.BankAccount = txtTaiKhoan.Text;
            objcustomer_form.BankName = txtNganHang.Text;
            objcustomer_form.CreditLimit = double.Parse(calLimitNo.Text);
            objcustomer_form.Discount = double.Parse(calchietkhau.Text);
            objcustomer_form.Contact = txtnguoilienhe.Text;
            objcustomer_form.NickYM = txtyahoo.Text;
            objcustomer_form.NickSky = txtsky.Text;
            objcustomer_form.Active = chkquanli.Checked;
            objcustomer_form.Barcode = txtMaKhach.Text;
            rs = new CUSTOMERController().CapNhatCUSTOMER(objcustomer_form, objcustomer_form.Customer_ID);
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

        private void lookupkhuvuc_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCapNhatKhachHang_Load(object sender, EventArgs e)
        {
            InitLookUp();

        }
    }
}
