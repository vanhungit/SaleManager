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
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;

namespace SalesManager
{
    public partial class frmEditMayIn : Form
    {
        PRINTERMAPPING objprintr = new PRINTERMAPPING();
        public frmEditMayIn(string Station,string printname)
        {
            InitializeComponent();
            InitLookUpKhoHang();
            txtStation.Text = Station;
            cboType.Text = printname;
            objprintr = new PRINTERMAPPINGController().Printer_Mapping_Getby(Station, printname);
            lookUpEditKho.EditValue = objprintr.Store_ID;
            txtLocalport.Text = objprintr.LocalPort;
            txtNetworkport.Text = objprintr.NetworkPort;
            txtPrinterName.Text = objprintr.Details;
            txtDisable.Checked = objprintr.Disabled;
            txtFeed.Text = objprintr.LineFeedsBeforeCut.ToString();
            chkColor.Checked = objprintr.Two_Color_Printing;
            chkcut.Checked = objprintr.CutReceipt;
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            objprintr.Station_ID = txtStation.Text;
            objprintr.Store_ID = lookUpEditKho.GetColumnValue("Stock_ID").ToString();
            objprintr.LocalPort = txtLocalport.Text;
            objprintr.NetworkPort = txtNetworkport.Text;
            objprintr.PrinterName = cboType.Text;
            objprintr.Details = txtPrinterName.Text;
            objprintr.Disabled = txtDisable.Checked;
            objprintr.CutReceipt = chkcut.Checked;
            objprintr.Two_Color_Printing = chkColor.Checked;
        }
    }
}
