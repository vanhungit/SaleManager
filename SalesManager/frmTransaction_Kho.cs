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
    public partial class frmTransaction_Kho : DevExpress.XtraEditors.XtraForm
    {
        UC_TransactionKhoTH frmTransationKhoTH;
        UC_TransactionKhoCT frmTransationKhoCT;
        public frmTransaction_Kho()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Giao Dịch Kho Theo Chi Tiết";
            groupControl1.Controls.Clear();
            frmTransationKhoCT = new UC_TransactionKhoCT();
            frmTransationKhoCT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTransationKhoCT);//thêm user control vào panel

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Giao Dịch Kho Theo Header";
            groupControl1.Controls.Clear();
            frmTransationKhoTH = new UC_TransactionKhoTH();
            frmTransationKhoTH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTransationKhoTH);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Giao Dịch Kho Theo Chi Tiết";
            groupControl1.Controls.Clear();
            frmTransationKhoCT = new UC_TransactionKhoCT();
            frmTransationKhoCT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTransationKhoCT);//thêm user control vào panel
        }
    }
}