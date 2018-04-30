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
    public partial class frmDonHangBan : DevExpress.XtraEditors.XtraForm
    {
        UC_DonBanHang frmDBH;
        public frmDonHangBan()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Đơn Bán Hàng";
            groupControl1.Controls.Clear();
            frmDBH = new UC_DonBanHang();
            frmDBH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDBH);//thêm user control vào panel

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Đơn Bán Hàng";
            groupControl1.Controls.Clear();
            frmDBH = new UC_DonBanHang();
            frmDBH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDBH);//thêm user control vào panel

        }
    }
}