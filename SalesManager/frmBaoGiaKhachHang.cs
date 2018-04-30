using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class frmBaoGiaKhachHang : DevExpress.XtraEditors.XtraForm
    {
        UC_BaoGiaKhachHang frmBaoGiaKH;
        public frmBaoGiaKhachHang()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Báo Giá Khách Hàng";
            groupControl1.Controls.Clear();
            frmBaoGiaKH = new UC_BaoGiaKhachHang();
            frmBaoGiaKH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBaoGiaKH);//thêm user control vào panel

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Báo Giá Khách Hàng";
            groupControl1.Controls.Clear();
            frmBaoGiaKH = new UC_BaoGiaKhachHang();
            frmBaoGiaKH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBaoGiaKH);//thêm user control vào panel

        }
    }
}