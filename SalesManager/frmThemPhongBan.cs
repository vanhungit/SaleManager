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
    public partial class frmThemPhongBan : Form
    {
        public frmThemPhongBan()
        {
            InitializeComponent();
        }
        DEPARTMENT objdepartment = new DEPARTMENT();
        public string SinhMaBoPhan()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objdepartment = new DEPARTMENTController().DEPARTMENT_Top1();
            MaTam = objdepartment.Department_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "BP" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "BP000001";
            }
            return MaKhachHang;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objdepartment.Department_ID = txtMa.Text;
            objdepartment.Department_Name = txtten.Text;
            objdepartment.Description = txtGhiChu.Text;
            objdepartment.Active = chkquanly.Checked;
            rs = new DEPARTMENTController().ThemDEPARTMENT(objdepartment);
            if (rs < 1)
            {
                MessageBox.Show("Bộ phận đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Bộ phận mới đã được lưu", "Thông báo");
                txtMa.Text = SinhMaBoPhan();
                txtten.Text = "";
                txtGhiChu.Text = "";
            }
        }

        private void frmThemPhongBan_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaBoPhan();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
