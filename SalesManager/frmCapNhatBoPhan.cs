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
    public partial class frmCapNhatBoPhan : Form
    {
        public frmCapNhatBoPhan()
        {
            InitializeComponent();
        }
        DEPARTMENT objunit = new DEPARTMENT();
        public void Load_Data(DEPARTMENT objunit)
        {
            this.objunit = objunit;
            txtMa.Text = objunit.Department_ID;
            txtTenKV.Text = objunit.Department_Name;
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
            objunit.Department_ID = txtMa.Text;
            objunit.Department_Name = txtTenKV.Text;
            objunit.Description = txtGhiChu.Text;
            objunit.Active = checkactive.Checked;
            rs = new DEPARTMENTController().DEPARTMENT_Update(objunit, objunit.Department_ID);
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
