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
namespace SalesManager
{
    public partial class frmThemDonVi : Form
    {
        public frmThemDonVi()
        {
            InitializeComponent();
        }
        UNIT objunit = new UNIT();
        public string SinhMaDonVi()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objunit = new UNITController().UNIT_Top1();
            MaTam = objunit.Unit_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "DV" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "DV000001";
            }
            return MaKhachHang;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objunit.Unit_ID = txtMa.Text;
            objunit.Unit_Name = txtTenKV.Text;
            objunit.Description = txtGhiChu.Text;
            objunit.Active = checkactive.Checked;
            rs = new UNITController().UNIT_Insert(objunit);
            if (rs < 1)
            {
                MessageBox.Show("Đơn vị đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Đơn vị mới đã được lưu", "Thông báo");
                txtGhiChu.Text = "";
                txtTenKV.Text = "";
                txtMa.Text = SinhMaDonVi();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemDonVi_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaDonVi();
        }
    }
}
