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
    public partial class frmChungTuXuatKho : DevExpress.XtraEditors.XtraForm
    {
        UC_ChungTuXuatKho frmCTXK;
        public frmChungTuXuatKho()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Xuất Kho";
            groupControl1.Controls.Clear();
            frmCTXK = new UC_ChungTuXuatKho();
            frmCTXK.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmCTXK);//thêm user control vào panel

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Xuất Kho";
            groupControl1.Controls.Clear();
            frmCTXK = new UC_ChungTuXuatKho();
            frmCTXK.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmCTXK);//thêm user control vào panel

        }
    }
}