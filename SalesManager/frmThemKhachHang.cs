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
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
            InitLookUp();
            InitLookLoai();
        }
        CUSTOMER_GROUP objcustomer_group = new CUSTOMER_GROUP();
        CUSTOMER objcustomer = new CUSTOMER();
        private void InitLookUp()
        {
            // Specify the data source to display in the dropdown.
            lookupkhuvuc.Properties.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP() ;
            // The field providing the editor's display text.
            lookupkhuvuc.Properties.DisplayMember = "Customer_Group_Name";
            // The field matching the edit value.
            lookupkhuvuc.Properties.ValueMember = "Customer_Group_ID";
            lookupkhuvuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookupkhuvuc.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookupkhuvuc.Properties.AutoSearchColumnIndex = 1;
            lookupkhuvuc.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

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
            lookUpLoaiKhach.EditValue = "KHVL";

        }
        public string SinhMaKhachHang()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objcustomer = new CUSTOMERController().CUSTOMER_Top1();
            MaTam = objcustomer.Customer_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "KH" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "KH000001";
            }
            return MaKhachHang;
        }
        private void lookUpEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
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
            objcustomer.Customer_ID = txtMaKhach.Text.Trim();
            objcustomer.Barcode = txtMaKhach.Text.Trim();
            objcustomer.OrderID = 0;
            objcustomer.CustomerName = txtTen.Text;
            objcustomer.Customer_Type_ID = lookUpLoaiKhach.GetColumnValue("Customer_Type_ID").ToString();
            objcustomer.Customer_Group_ID = objcustomer_group.Customer_Group_ID;
            objcustomer.CustomerAddress = txtDiaChi.Text.Trim();
            objcustomer.Tax = txtMST.Text;
            objcustomer.Fax = txtFax.Text;
            objcustomer.Tel = txtDienThoai.Text;
            objcustomer.Mobile = txtMobile.Text;
            objcustomer.Website = txtwebsite.Text;
            objcustomer.BankAccount = txtTaiKhoan.Text;
            objcustomer.BankName = txtNganHang.Text;
            objcustomer.CreditLimit = double.Parse(calLimitNo.Text);
            objcustomer.Discount = double.Parse(calchietkhau.Text);
            objcustomer.Contact = txtnguoilienhe.Text;
            objcustomer.NickYM = txtyahoo.Text;
            objcustomer.NickSky = txtsky.Text;
            objcustomer.Active = chkquanli.Checked;
            rs = new CUSTOMERController().ThemCUSTOMER(objcustomer);
            if (rs < 1)
            {
                MessageBox.Show("Khách hàng đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Khách hàng mới đã được lưu", "Thông báo");
                txtMaKhach.Text = SinhMaKhachHang();
                lookupkhuvuc.SelectedText = "";
                txtTen.Text = "";
                txtDiaChi.Text = "";
                txtMST.Text = "";
                txtFax.Text = "";
                txtDienThoai.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtTaiKhoan.Text = "";
                txtNganHang.Text = "";
                calLimitNo.Text = "";
                calchietkhau.Text = "";
                txtnguoilienhe.Text = "";
                txtyahoo.Text = "";
                txtsky.Text = "";
                chkquanli.Checked = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhach.Text = SinhMaKhachHang();
        }

    }
}
