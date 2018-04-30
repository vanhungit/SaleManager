using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class frmPhanTichLoiNhuan : Form
    {
        UC_LoiNhuanHoaDon frmloinhuanhoadon;
        UC_LoiNhuanKhuVucKH frmloinhuantheokv;
        UC_LoiNhuanKhachHang frmloinhuankhachhang;
        UC_LoiNhuanTheoKhoHang frmloinhuankhohang;
        UC_LoiNhuanTheoNhomHang frmloinhuantheonhomhang;
        UC_LoiNhuanTheoMatHang frmloinhuantheomathang;
        SYS_LOG _sys_log = new SYS_LOG();
        public frmPhanTichLoiNhuan()
        {
            InitializeComponent();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Phân Tích Lợi Nhuận";
            _sys_log.Module = "Phân Tích Lợi Nhuận";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Hóa Đơn";
            groupControl1.Controls.Clear();
            frmloinhuanhoadon = new UC_LoiNhuanHoaDon();
            frmloinhuanhoadon.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuanhoadon);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Khu Vực Khách Hàng";
            groupControl1.Controls.Clear();
            frmloinhuantheokv = new UC_LoiNhuanKhuVucKH();
            frmloinhuantheokv.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuantheokv);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Khách Hàng";
            groupControl1.Controls.Clear();
            frmloinhuankhachhang = new UC_LoiNhuanKhachHang();
            frmloinhuankhachhang.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuankhachhang);//thêm user control vào panel
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Kho Hàng";
            groupControl1.Controls.Clear();
            frmloinhuankhohang = new UC_LoiNhuanTheoKhoHang();
            frmloinhuankhohang.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuankhohang);//thêm user control vào panel
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Nhóm Hàng";
            groupControl1.Controls.Clear();
            frmloinhuantheonhomhang = new UC_LoiNhuanTheoNhomHang();
            frmloinhuantheonhomhang.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuantheonhomhang);//thêm user control vào panel
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lợi Nhuận Theo Mặt Hàng";
            groupControl1.Controls.Clear();
            frmloinhuantheomathang = new UC_LoiNhuanTheoMatHang();
            frmloinhuantheomathang.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmloinhuantheomathang);//thêm user control vào panel
        }
    }
}
