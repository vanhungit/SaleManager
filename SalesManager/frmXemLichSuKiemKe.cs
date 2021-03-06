using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors.Controls;
namespace SalesManager
{
    public partial class frmXemLichSuKiemKe : DevExpress.XtraEditors.XtraForm
    {
        public frmXemLichSuKiemKe(string PhieuKiemKe)
        {
            InitializeComponent();
            repositoryItemLookUpEdit1.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Unit_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit1.Properties.ValueMember = "Unit_ID";//tìm theo
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;

            repositoryItemLookUpEdit2.Properties.DataSource = new STOCKController().STOCK_GetList();
            repositoryItemLookUpEdit2.Properties.DisplayMember = "Stock_Name";//hiển thị
            // The field matching the edit value.
            repositoryItemLookUpEdit2.Properties.ValueMember = "Stock_ID";//tìm theo
            repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = new ADJUSTMENT_DETAILController().ADJUSTMENT_DETAIL_GetbyAdjustment_ID(PhieuKiemKe);
        }
    }
}