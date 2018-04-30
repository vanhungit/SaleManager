using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Entity;
using SalesManager.Controller;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;

namespace SalesManager
{
    public partial class frmThemMayIn : Form
    {
        PRINTERMAPPING objprintr = new PRINTERMAPPING();
        public frmThemMayIn()
        {
            InitializeComponent();
            InitLookUpKhoHang();
        }
        private void InitLookUpKhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpEditKho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookUpEditKho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookUpEditKho.Properties.ValueMember = "Stock_ID";
            lookUpEditKho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpEditKho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpEditKho.EditValue = "K000001";
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objprintr.Station_ID = lookUpEditKho.GetColumnValue("Stock_ID").ToString();
            objprintr.Store_ID = lookUpEditKho.GetColumnValue("Stock_ID").ToString();
            objprintr.LocalPort = txtLocalport.Text;
            objprintr.NetworkPort = txtNetworkport.Text;
            objprintr.PrinterName = cboType.Text;
            objprintr.Details = txtPrinterName.Text;
            objprintr.Disabled = txtDisable.Checked;
            objprintr.CutReceipt = chkcut.Checked;
            objprintr.Two_Color_Printing = chkColor.Checked;
            objprintr.LineFeedsBeforeCut = int.Parse(txtFeed.Text);
            rs = new PRINTERMAPPINGController().PRINTERMAPPING_Insert(objprintr);
            if (rs > -1)
            {
                XtraMessageBox.Show("Lưu Thành Công!", "Thông Báo");
            }
            else
                XtraMessageBox.Show("Lưu Thất Bại!", "Thông Báo");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lookUpEditKho_EditValueChanged(object sender, EventArgs e)
        {
            txtStation.Text = lookUpEditKho.GetColumnValue("Stock_ID").ToString();

        }
    }
}
