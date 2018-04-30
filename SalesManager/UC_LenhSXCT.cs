using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class UC_LenhSXCT : UserControl
    {
        public UC_LenhSXCT()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
            lookkhotu.Properties.DataSource = new STOCKController().STOCK_GetList();
            lookkhotu.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookkhotu.Properties.ValueMember = "Stock_ID";
            lookkhotu.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookkhotu.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookkhotu.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = new INBOUND_DELIVERY_DETAILController().INBOUND_DELIVERY_DETAIL_Getlist();
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new INBOUND_DELIVERY_DETAILController().INBOUND_DELIVERY_DETAIL_Getlist();

        }
    }
}
