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
    public partial class frmLenhSanXuat : DevExpress.XtraEditors.XtraForm
    {
        UC_LapLenhSanXuat frmLapLenh;
        UC_LenhSXCT frmLenhSXCT;
        public frmLenhSanXuat()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Lập Lệnh Sản Xuất";
            groupControl1.Controls.Clear();
            frmLapLenh = new UC_LapLenhSanXuat();
            frmLapLenh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLapLenh);//thêm user control vào panel
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lập Lệnh Sản Xuất";
            groupControl1.Controls.Clear();
            frmLapLenh = new UC_LapLenhSanXuat();
            frmLapLenh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLapLenh);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Sản Xuất Chi Tiết";
            groupControl1.Controls.Clear();
            frmLenhSXCT = new UC_LenhSXCT();
            frmLenhSXCT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLenhSXCT);//thêm user control vào panel
        }
    }
}