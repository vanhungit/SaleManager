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
    public partial class frmMaVach : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtable = new DataTable();
        SYS_LOG _sys_log = new SYS_LOG();
        public frmMaVach()
        {
            InitializeComponent();
            dtable.Columns.Add("Chon",typeof(bool));
            dtable.Columns.Add("CountNum");
            dtable.Columns.Add("Product_ID");
            dtable.Columns.Add("Product_Name");
            dtable.Columns.Add("Retail_Price");
            dtable.Columns.Add("Barcode");
            dtable.Columns.Add("Unit");
            repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpEdit1.Properties.DataSource = new UNITController().UNIT_GetList();
            repositoryItemLookUpEdit1.Properties.DisplayMember = "Unit_Name";
            // The field matching the edit value.
            repositoryItemLookUpEdit1.Properties.ValueMember = "Unit_ID";
            repositoryItemLookUpEdit1.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            repositoryItemLookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpEdit1.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource =  dtable;
            gridControl1.DataSource = new PRODUCTController().PrintBarcode();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem In Mã Vạch";
            _sys_log.Module = "Hiển Thị In Mã Vạch";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);

       }
        public void repositoryItemCheckEdit1_click(object sender, EventArgs e)
        {
            dtable = ((DataTable)(gridControl1.DataSource)).Copy();
            
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteSelectedRows();
            gridControl1.Refresh();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink1.ShowPreview();

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInMaVach frm = new frmInMaVach(((DataTable)(gridControl1.DataSource)).Copy());
            frm.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}