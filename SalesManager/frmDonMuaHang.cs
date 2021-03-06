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
    public partial class frmDonMuaHang : DevExpress.XtraEditors.XtraForm
    {
        UC_DonMuaHang frmDHM;
        UC_BangKeTongHopDHM frmBangKeTHDHM;
        public frmDonMuaHang()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Đơn Mua Hàng";
            groupControl1.Controls.Clear();
            frmDHM = new UC_DonMuaHang();
            frmDHM.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDHM);//thêm user control vào panel
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Đơn Mua Hàng";
            groupControl1.Controls.Clear();
            frmDHM = new UC_DonMuaHang();
            frmDHM.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDHM);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp ĐHM";
            groupControl1.Controls.Clear();
            frmBangKeTHDHM = new UC_BangKeTongHopDHM();
            frmBangKeTHDHM.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBangKeTHDHM);//thêm user control vào panel
        }
    }
}