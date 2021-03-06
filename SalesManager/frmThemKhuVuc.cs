using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
namespace SalesManager
{
    public partial class frmThemKhuVuc : DevExpress.XtraEditors.XtraForm
    {
        public frmThemKhuVuc()
        {
            InitializeComponent();
        }
        CUSTOMER_GROUP objNV = new CUSTOMER_GROUP();
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string SinhMaKhuVuc()
        {
            string MaKhuVuc, MaTam;
            MaKhuVuc = "";
            MaTam = "";
            objNV = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1();
            MaTam = objNV.Customer_Group_ID;
            if (MaTam != "")
            {
               
                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhuVuc = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhuVuc = "0" + MaKhuVuc;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhuVuc = "KV" + MaKhuVuc;
            }
            else
            {
                MaKhuVuc = "KV000001";
            }
            return MaKhuVuc;
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objNV.Customer_Group_ID = txtMaKV.Text;
            objNV.Customer_Group_Name = txtTenKV.Text;
            objNV.Description = txtGhiChu.Text;
            objNV.Active = checkactive.Checked;
            rs = new CUSTOMER_GROUPController().ThemCUSTOMER_GROUP(objNV);
            if (rs < 1)
            {
                MessageBox.Show("Khu vực đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Khu vực mới đã được lưu", "Thông báo");
                txtTenKV.Text = "";
                txtGhiChu.Text = "";
                txtMaKV.Text = SinhMaKhuVuc();
                txtMaKV.Focus();
                txtMaKV.SelectAll();
            }
        }

        private void frmThemKhuVuc_Load(object sender, EventArgs e)
        {
            txtMaKV.Text = SinhMaKhuVuc();
        }
    }
}