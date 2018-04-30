using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace SalesManager
{
    public partial class UC_TimKiem : UserControl
    {
        public UC_TimKiem()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
        }
     
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MobilityNetwork test = new MobilityNetwork();
            gridControl1.DataSource = test.ViewDataTable();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemMobiUser frm = new frmThemMobiUser(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString(), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString());
            frm.ShowDialog();
        }

     
    }
}
