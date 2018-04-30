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
    public partial class UC_DonBanHang : UserControl
    {
        public UC_DonBanHang()
        {
            InitializeComponent();
            splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChonBaoGiaBan frm = new frmChonBaoGiaBan();
            frm.ShowDialog();
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
