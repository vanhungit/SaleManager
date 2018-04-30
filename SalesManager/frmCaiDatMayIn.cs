using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmCaiDatMayIn : Form
    {
        public frmCaiDatMayIn()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;

        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmCaiDatMayIn_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = new PRINTERMAPPINGController().Printer_Mapping_GetList();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemMayIn frm = new frmThemMayIn();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditMayIn frm = new frmEditMayIn(gridView1.GetFocusedRowCellDisplayText("Store_ID"), gridView1.GetFocusedRowCellDisplayText("PrinterName"));
            frm.ShowDialog();
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
    }
}
