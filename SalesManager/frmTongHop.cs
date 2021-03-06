using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class frmTongHop : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmTongHop()
        {
            InitializeComponent();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Báo Cáo Kho";
            _sys_log.Reference = "";
            _sys_log.Module = "Báo Cáo Kho";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        UC_TheKho frmTheKho;
        UC_TonKhoTongHop frmTKTongHop;
        UC_BangTHHangHoa frmTHHangHoa;
        UC_SoChiTietHangHoa frmSoChiTietHangHoa;
        UC_SanPhamBanChay frmsanphambanchay;
        UC_SanPhamDTCao frmsanphamdtcaonhat;
        UC_SanPhamNhapNhieu frmsanphamnhapnhieu;
        UC_SanPhamDSNhapNhieu frmsanphamdsnhapnhieu;
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Thẻ Kho";
            groupControl1.Controls.Clear();
            frmTheKho = new UC_TheKho();
            frmTheKho.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTheKho);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Tồn Kho Tổng Hợp";
            groupControl1.Controls.Clear();
            frmTKTongHop = new UC_TonKhoTongHop();
            frmTKTongHop.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTKTongHop);//thêm user control vào panel
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Tổng Hợp Hàng Hóa";
            groupControl1.Controls.Clear();
            frmTHHangHoa = new UC_BangTHHangHoa(this);
            frmTHHangHoa.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHHangHoa);//thêm user control vào panel
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Sổ Chi Tiết Hàng Hóa";
            groupControl1.Controls.Clear();
            frmSoChiTietHangHoa = new UC_SoChiTietHangHoa();
            frmSoChiTietHangHoa.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmSoChiTietHangHoa);//thêm user control vào panel
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Sản Phẩm Bán Chạy";
            groupControl1.Controls.Clear();
            frmsanphambanchay = new UC_SanPhamBanChay();
            frmsanphambanchay.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmsanphambanchay);//thêm user control vào panel
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Sản Phẩm Doanh Thu Cao Nhất";
            groupControl1.Controls.Clear();
            frmsanphamdtcaonhat = new UC_SanPhamDTCao();
            frmsanphamdtcaonhat.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmsanphamdtcaonhat);//thêm user control vào panel
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Sản Phẩm Nhập Nhiều";
            groupControl1.Controls.Clear();
            frmsanphamnhapnhieu = new UC_SanPhamNhapNhieu();
            frmsanphamnhapnhieu.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmsanphamnhapnhieu);//thêm user control vào panel
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Sản Phẩm Nhập Nhiều";
            groupControl1.Controls.Clear();
            frmsanphamdsnhapnhieu = new UC_SanPhamDSNhapNhieu();
            frmsanphamdsnhapnhieu.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmsanphamdsnhapnhieu);//thêm user control vào panel
        }
    }
}