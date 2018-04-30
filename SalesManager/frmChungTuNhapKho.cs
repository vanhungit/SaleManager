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
    public partial class frmChungTuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        UC_ChungTuMuaHang frmCTMH;
        public frmChungTuNhapKho()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Nhập Kho";
            groupControl1.Controls.Clear();
            frmCTMH = new UC_ChungTuMuaHang();
            frmCTMH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmCTMH);//thêm user control vào panel
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Nhập Kho";
            groupControl1.Controls.Clear();
            frmCTMH = new UC_ChungTuMuaHang();
            frmCTMH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmCTMH);//thêm user control vào panel
        }
    }
}