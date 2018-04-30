using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesManager
{
    public partial class UC_BaoGiaKhachHang : UserControl
    {
        public UC_BaoGiaKhachHang()
        {
            InitializeComponent();
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
        }

        private void chkbarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbarcode.Checked == true)
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else
            {
                splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
                lookUpTenKH.Focus();
            }
        }

    }
}
