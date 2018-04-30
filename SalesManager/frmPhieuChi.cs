using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using SalesManager;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
namespace SalesManager
{
    public partial class frmPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmPhieuChi()
        {
            InitializeComponent();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Phiếu Chi";
            _sys_log.Module = "Trả Tiền";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        UC_DSPhieuChi frmphieuchi;
        UC_DSCNPhaiChi frmcnphieuchi;
        UC_ThongKeNoTra frmnotra;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Tổng Hợp");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp";
            groupControl1.Controls.Clear();
            frmphieuchi = new UC_DSPhieuChi();
            frmphieuchi.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmphieuchi);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Chi Tiết");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Chi Tiết";
            groupControl1.Controls.Clear();
            frmcnphieuchi = new UC_DSCNPhaiChi();
            frmcnphieuchi.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmcnphieuchi);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();

        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Nợ Trả");
            groupControl1.ResetText();
            groupControl1.Text = "Thống Kê Nợ Trả";
            groupControl1.Controls.Clear();
            frmnotra = new UC_ThongKeNoTra();
            frmnotra.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmnotra);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }
    }
}