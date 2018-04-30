using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;

namespace SalesManager
{
    public partial class frmChiTietLichSuHangHoa : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietLichSuHangHoa(string MaHang, string TenHang)
        {
            InitializeComponent();
            bandedGridView1.Invalidate();
            bandedGridView1.IndicatorWidth = 40;
            lookKho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookKho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookKho.Properties.ValueMember = "Stock_ID";
            //lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookKho.Properties.AutoSearchColumnIndex = 1;

            lookloai.Properties.DataSource = new REFTYPEController().REFTYPE_GetList();
            lookloai.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookloai.Properties.ValueMember = "ID";
            //lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookloai.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = new PRODUCTController().PRODUCT_History(MaHang,TenHang);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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