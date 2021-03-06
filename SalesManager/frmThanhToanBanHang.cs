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
    public partial class frmThanhToanBanHang : DevExpress.XtraEditors.XtraForm
    {
        UC_PhieuBanHang frmphieubanhang;
        public frmThanhToanBanHang(UC_PhieuBanHang frm, double Tong)
        {
            InitializeComponent();
            calcEditThanhToan.Value = (decimal)Tong;
            calcEditKhachDua.Focus();
            frmphieubanhang = frm;
        }

        private void calcEdit2_EditValueChanged(object sender, EventArgs e)
        {
            calcEditConLai.Value = calcEditKhachDua.Value - calcEditThanhToan.Value;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (calcEditConLai.Value >= 0)
            {
                Close();
                frmphieubanhang.HamThanhToan((double)calcEditKhachDua.Value, (double)calcEditConLai.Value);
            }
            else
                MessageBox.Show("Khách Đưa Không Đủ Tiền!","Thông Báo");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}