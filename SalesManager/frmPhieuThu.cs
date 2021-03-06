using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;

namespace SalesManager
{
    public partial class frmPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmPhieuThu()
        {
            InitializeComponent();
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Tổng Hợp");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp";
            groupControl1.Controls.Clear();
            frmDSPC = new UC_DSPhieuThu();
            frmDSPC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDSPC);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Phiếu Thu";
            _sys_log.Module = "Thu Tiền";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        UC_DSPhieuThu frmDSPC;
        UC_DSCNPhaiThu frmDSCNPT;
        UC_ThongKeNoThu frmthongkeno;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Tổng Hợp");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp";
            groupControl1.Controls.Clear();
            frmDSPC = new UC_DSPhieuThu();
            frmDSPC.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDSPC);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Bảng Kê Tổng Hợp Chi Tiết");
            //WaitDialog.SetWaitDialogCaption("Bảng Kê Tổng Hợp");
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Chi Tiết";
            groupControl1.Controls.Clear();
            frmDSCNPT = new UC_DSCNPhaiThu();
            frmDSCNPT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmDSCNPT);//thêm user control vào panel
            WaitDialog.CloseWaitDialog();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp Công Nợ";
            groupControl1.Controls.Clear();
            frmthongkeno = new UC_ThongKeNoThu();
            frmthongkeno.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmthongkeno);//thêm user control vào panel
        }
    }
}