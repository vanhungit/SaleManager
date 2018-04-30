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
    public partial class frmCapNhatTyGia : Form
    {
        public frmCapNhatTyGia()
        {
            InitializeComponent();
        }
        CURRENCY objcurrentcy = new CURRENCY();
        public void Load_Data(CURRENCY objcurrentcy)
        {
            this.objcurrentcy = objcurrentcy;
            txtMaTyGia.Text  = objcurrentcy.Currency_ID;
            txtTenTG.Text = objcurrentcy.CurrencyName;
            calcEdit1.Text = objcurrentcy.Exchange.ToString();
            checkactive.Checked = objcurrentcy.Active;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objcurrentcy.Currency_ID = txtMaTyGia.Text;
            objcurrentcy.CurrencyName = txtTenTG.Text;
            objcurrentcy.Exchange = double.Parse(calcEdit1.Text.Trim());
            objcurrentcy.Active = checkactive.Checked;
            rs = new CURRENCYController().CURRENCY_Update(objcurrentcy,objcurrentcy.Currency_ID);
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
