using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesManager
{
    public partial class frmPhieuYeuCauKho : DevExpress.XtraEditors.XtraForm
    {
        UC_BangKeTongHopYeuCauKho frmYC;
        public frmPhieuYeuCauKho()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Yêu Cầu";
            groupControl1.Controls.Clear();
            frmYC = new UC_BangKeTongHopYeuCauKho();
            frmYC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmYC);//thêm user control vào panel

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Yêu Cầu";
            groupControl1.Controls.Clear();
            frmYC = new UC_BangKeTongHopYeuCauKho();
            frmYC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmYC);//thêm user control vào panel

        }
    }
}
