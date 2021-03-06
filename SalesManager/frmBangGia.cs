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
    public partial class frmBangGia : DevExpress.XtraEditors.XtraForm
    {
        UC_BangKeTongHopBangGia frmUCBangGia;
        UC_BangKeChiTietBangGia frmUCChiTietBangGia;
        public frmBangGia()
        {
            InitializeComponent();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Giá Tổng Hợp";
            groupControl1.Controls.Clear();
            frmUCBangGia = new UC_BangKeTongHopBangGia();
            frmUCBangGia.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmUCBangGia);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Chi Tiết");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Giá Tổng Hợp";
            groupControl1.Controls.Clear();
            frmUCChiTietBangGia = new UC_BangKeChiTietBangGia();
            frmUCChiTietBangGia.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmUCChiTietBangGia);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }
    }
}