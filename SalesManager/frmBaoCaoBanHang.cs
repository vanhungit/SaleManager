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
    public partial class frmBaoCaoBanHang : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmBaoCaoBanHang()
        {
            InitializeComponent();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Báo Cáo Doanh Thu";
            _sys_log.Module = "Báo Cáo Doanh Thu";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        UC_BaoCaoMuaHangTheoNgay frmBCDate;
        UC_BaoCaoMuaHangTheoNCC frmBCNPP;
        UC_BaoCaoBanHangTheoNgay frmBCBHDate;
        UC_BaoCaoBanHangTheoKH frmBCBHKH;
        UC_BaoCaoBanHangNV frmBCNV;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Báo Cáo Doanh Thu Mua Hàng Theo Ngày");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Báo Cáo Doanh Thu Mua Hàng Theo Ngày";
            groupControl1.Controls.Clear();
            frmBCDate = new UC_BaoCaoMuaHangTheoNgay();
            frmBCDate.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBCDate);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Báo Cáo Doanh Thu Mua Hàng Theo NPP");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Báo Cáo Doanh Thu Mua Hàng Theo NPP";
            groupControl1.Controls.Clear();
            frmBCNPP = new UC_BaoCaoMuaHangTheoNCC();
            frmBCNPP.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBCNPP);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Báo Cáo Doanh Thu Bán Hàng Theo Ngày");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Báo Cáo Doanh Thu Bán Hàng Theo Ngày";
            groupControl1.Controls.Clear();
            frmBCBHDate = new UC_BaoCaoBanHangTheoNgay();
            frmBCBHDate.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBCBHDate);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Báo Cáo Doanh Thu Bán Hàng Theo KH");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Báo Cáo Doanh Thu Bán Hàng Theo KH";
            groupControl1.Controls.Clear();
            frmBCBHKH = new UC_BaoCaoBanHangTheoKH();
            frmBCBHKH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBCBHKH);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Báo Cáo Doanh Thu Nhân Viên");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Báo Cáo Doanh Thu Nhân Viên";
            groupControl1.Controls.Clear();
            frmBCNV = new UC_BaoCaoBanHangNV();
            frmBCNV.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmBCNV);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }
    }
}