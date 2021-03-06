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
    public partial class frmGiaoHang : DevExpress.XtraEditors.XtraForm
    {
        UC_BangKeTongHopGH frmNH;
        UC_BangKeChiTietGH frmgh;
        public frmGiaoHang()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Phiếu Giao Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_BangKeTongHopGH();
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            groupControl1.ResetText();
            groupControl1.Text = "Phiếu Giao Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_BangKeTongHopGH();
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Phiếu Giao Hàng";
            groupControl1.Controls.Clear();
            frmgh = new UC_BangKeChiTietGH();
            frmgh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmgh);//thêm user control vào panel
        }

      
    }
}