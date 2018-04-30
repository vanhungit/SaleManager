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
    public partial class frmKhachTraHang : DevExpress.XtraEditors.XtraForm
    {
        UC_KhachTraHang frmKTH;
        public frmKhachTraHang()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Khách Trả Hàng";
            groupControl1.Controls.Clear();
            frmKTH = new UC_KhachTraHang();
            frmKTH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmKTH);//thêm user control vào panel

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Khách Trả Hàng";
            groupControl1.Controls.Clear();
            frmKTH = new UC_KhachTraHang();
            frmKTH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmKTH);//thêm user control vào panel

        }
    }
}