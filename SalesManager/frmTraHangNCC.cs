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
    public partial class frmTraHangNCC : DevExpress.XtraEditors.XtraForm
    {
        UC_TraHangNCC frmTHNCC;
        public frmTraHangNCC()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Trả Hàng Nhà Cung Cấp";
            groupControl1.Controls.Clear();
            frmTHNCC = new UC_TraHangNCC();
            frmTHNCC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHNCC);//thêm user control vào panel

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Trả Hàng Nhà Cung Cấp";
            groupControl1.Controls.Clear();
            frmTHNCC = new UC_TraHangNCC();
            frmTHNCC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHNCC);//thêm user control vào panel

        }
    }
}