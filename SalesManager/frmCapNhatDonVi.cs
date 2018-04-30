using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;

namespace SalesManager
{
    public partial class frmCapNhatDonVi : Form
    {
        public frmCapNhatDonVi()
        {
            InitializeComponent();
        }
        UNIT objunit = new UNIT();
        public void Load_Data(UNIT objunit)
        {
            this.objunit = objunit;
            txtMa.Text = objunit.Unit_ID;
            txtTenKV.Text = objunit.Unit_Name;
            txtGhiChu.Text = objunit.Description;
            checkactive.Checked = objunit.Active;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objunit.Unit_ID = txtMa.Text;
            objunit.Unit_Name = txtTenKV.Text;
            objunit.Description = txtGhiChu.Text;
            objunit.Active = checkactive.Checked;
            rs = new UNITController().UNIT_Update(objunit,objunit.Unit_ID);
            if (rs < 1)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                Close();
            }
        }
    }
}
