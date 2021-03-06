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
    public partial class frmCaiDatMobility : DevExpress.XtraEditors.XtraForm
    {
        public frmCaiDatMobility()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Tìm Kiếm Máy Kiểm Kê";
            groupControl1.Controls.Clear();
            frm = new UC_TimKiem();
            frm.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frm);//thêm user control vào panel
        }
        UC_TimKiem frm;
        UC_ThietBiNguoiDung frmNguoiDung;
        UC_DuLieuOnLine frmdulieuonline;
        UC_InventoryMobile frminventory;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Tìm Kiếm Máy Kiểm Kê";
            groupControl1.Controls.Clear();
            frm = new UC_TimKiem();
            frm.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frm);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Thiết Bị && Người Dùng";
            groupControl1.Controls.Clear();
            frmNguoiDung = new UC_ThietBiNguoiDung();
            frmNguoiDung.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNguoiDung);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Dữ Liệu Online";
            groupControl1.Controls.Clear();
            frmdulieuonline = new UC_DuLieuOnLine();
            frmdulieuonline.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmdulieuonline);//thêm user control vào panel
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            groupControl1.ResetText();
            groupControl1.Text = "Data Inventory Online";
            groupControl1.Controls.Clear();
            frminventory = new UC_InventoryMobile();
            frminventory.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frminventory);//thêm user control vào panel
        }
        
    }
}