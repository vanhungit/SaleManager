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
    public partial class frmThemKhoHang : Form
    {
        public frmThemKhoHang()
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
        public string SinhMaKhachHang()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objstock = new STOCKController().STOCK_Top1();
            MaTam = objstock.Stock_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(1, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "K" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "K000001";
            }
            return MaKhachHang;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objstock.Stock_ID = txtMa.Text;
            objstock.Stock_Name = txtten.Text;
            objstock.Mobi = txtkihieu.Text;
            objstock.Contact = txtnguoilienhe.Text;
            objstock.Address = txtdiachi.Text;
            objstock.Telephone = txtDienthoai.Text;
            objstock.Fax = txtFax.Text;
            objstock.Email = txtEmail.Text;
            objstock.Description = txtdiengiai.Text;
            objstock.Manager = looknguoiquanli.Text.Trim();
            objstock.Manager = "NV000001";
            objstock.Active = chkquanli.Checked;
            rs = new STOCKController().STOCK_Insert(objstock);
            if (rs < 1)
            {
                MessageBox.Show("Kho hàng đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Kho hàng mới đã được lưu", "Thông báo");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemKhoHang_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaKhachHang();
        }
    }
}
