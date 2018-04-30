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
    public partial class frmCapNhatKhuVuc : Form
    {
        public frmCapNhatKhuVuc()
        {
            InitializeComponent();
        }
        CUSTOMER_GROUP objunit = new CUSTOMER_GROUP();
        public void Load_Data(CUSTOMER_GROUP objCUSTOMER_GROUP)
        {
            this.objunit = objCUSTOMER_GROUP;
            txtMa.Text = objCUSTOMER_GROUP.Customer_Group_ID;
            txtTenKV.Text = objCUSTOMER_GROUP.Customer_Group_Name;
            txtGhiChu.Text = objCUSTOMER_GROUP.Description;
            checkactive.Checked = objCUSTOMER_GROUP.Active;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objunit.Customer_Group_ID = txtMa.Text;
            objunit.Customer_Group_Name = txtTenKV.Text;
            objunit.Description = txtGhiChu.Text;
            objunit.Active = checkactive.Checked;
            rs = new CUSTOMER_GROUPController().CapNhatCUSTOMER_GROUP(objunit, objunit.Customer_Group_ID);
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
