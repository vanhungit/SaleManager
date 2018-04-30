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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Xml;
namespace SalesManager
{
    public partial class frmThemTyGia : Form
    {
        public frmThemTyGia()
        {
            InitializeComponent();
        }
        CURRENCY objcurent = new CURRENCY();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objcurent.Currency_ID = txtMaTyGia.Text.Trim();
            objcurent.CurrencyName = txtTenTG.Text.Trim();
            objcurent.Exchange = double.Parse(calQD.Text);
            objcurent.Active = checkactive.Checked;
            rs = new CURRENCYController().CURRENCY_Insert(objcurent);
            if (rs < 1)
            {
                MessageBox.Show("Tỷ giá đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Tỷ giá mới đã được lưu", "Thông báo");
            }
        }
    }
}
