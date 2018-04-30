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
    public partial class frmThemPhanPhoi : Form
    {
        public frmThemPhanPhoi()
        {
            InitializeComponent();
            InitLookUp();
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
            lookupkhuvuc.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

        }
        public string SinhMaNPP()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objprovider = new PROVIDERController().PROVIDER_Top1();
            MaTam = objprovider.Customer_ID;
            if (MaTam != "")
            {
                
                long NumberKhuVuc = long.Parse(MaTam.Substring(3, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "NPP" + MaKhachHang;
            }
            else
            {
                //MessageBox.Show("ok");
                MaKhachHang = "NPP000001";
            }
            return MaKhachHang;
        }

        private void frmThemPhanPhoi_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaNPP();
            
        }

        private void lookkhuvuc_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
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
            objprovider.Tel = txtDienthoai.Text;
            objprovider.Mobile = txtMobile.Text;
            objprovider.Contact = txtnguoilienhe.Text;
            objprovider.Website = txtwebsite.Text;
            objprovider.BankAccount = txtTaiKhoan.Text;
            objprovider.BankName = txtNganhang.Text;
            objprovider.CreditLimit = calgioihanno.Text != "" ?  double.Parse(calgioihanno.Text) : 0;
            objprovider.Discount = calcchietkhau.Text != "" ? double.Parse(calcchietkhau.Text) : 0;
            objprovider.Position = txtchucvu.Text;
            objprovider.Active = chkquanli.Checked;
            rs = new PROVIDERController().PROVIDER_Insert(objprovider);
            if (rs < 1)
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Nhà cung cấp mới đã được lưu", "Thông báo");
            }
        }
    }
}
