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
    public partial class frmVitriKho : DevExpress.XtraEditors.XtraForm
    {
        UC_DanhMucLocation frmLocation;
        public frmVitriKho()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Location";
            groupControl1.Controls.Clear();
            frmLocation = new UC_DanhMucLocation();
            frmLocation.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLocation);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Location";
            groupControl1.Controls.Clear();
            frmLocation = new UC_DanhMucLocation();
            frmLocation.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLocation);//thêm user control vào panel
        }
    }
}