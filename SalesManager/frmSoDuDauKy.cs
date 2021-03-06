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
    public partial class frmSoDuDauKy : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmSoDuDauKy()
        {
            InitializeComponent();
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Tổng Hợp Tồn Kho");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Nhập Kho Đầu Kỳ";
            groupControl1.Controls.Clear();
            frmTHtonkho = new UC_THTonKho();
            frmTHtonkho.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHtonkho);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Số Dư Đầu Kỳ";
            _sys_log.Module = "Số Dư Đầu Kỳ";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        UC_THTonKho frmTHtonkho;
        UC_BangKeTheoKy frmBangketheoky;
        UC_BangKeTheoHangHoa frmtheohanghoa;
        UC_CongNoDauKyKH frmcongnodaukykh;
        UC_CongNoDauKyNPP frmcongnodaukyncc;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Tổng Hợp Tồn Kho");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Nhập Kho Đầu Kỳ";
            groupControl1.Controls.Clear();
            frmTHtonkho = new UC_THTonKho();
            frmTHtonkho.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHtonkho);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }
        public void SuaChuaPhieuNhapDK(string _data)
        {
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmTHtonkho = new UC_THTonKho(this, _data);
            frmTHtonkho.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHtonkho);//thêm user control vào panel
            navBarGroup3.Visible = true;
        }
        public void TaoMoiPhieuNhapDK()
        {
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmTHtonkho = new UC_THTonKho();
            frmTHtonkho.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTHtonkho);//thêm user control vào panel
            navBarGroup3.Visible = true;
        }
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Tổng Hợp Tồn Kho");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Đầu Kỳ";
            groupControl1.Controls.Clear();
            frmBangketheoky = new UC_BangKeTheoKy(this);
            frmBangketheoky.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBangketheoky);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Tổng Hợp Tồn Kho");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Đầu Kỳ";
            groupControl1.Controls.Clear();
            frmtheohanghoa = new UC_BangKeTheoHangHoa(this);
            frmtheohanghoa.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmtheohanghoa);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.ShowDialog();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_KhachHang frm = new frm_KhachHang();
            frm.ShowDialog();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmNhaPhanPhoi frm = new frmNhaPhanPhoi();
            frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Công Nợ Khách Hàng");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Công Nợ Khách Hàng";
            groupControl1.Controls.Clear();
            frmcongnodaukykh = new UC_CongNoDauKyKH(this);
            frmcongnodaukykh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmcongnodaukykh);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Công Nợ Nhà Phân Phối");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Công Nợ Nhà Phân Phối";
            groupControl1.Controls.Clear();
            frmcongnodaukyncc = new UC_CongNoDauKyNPP(this);
            frmcongnodaukyncc.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmcongnodaukyncc);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }
    }
}