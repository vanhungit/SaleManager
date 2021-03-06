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
namespace SalesManager
{
    public partial class frmLichSuHangHoa : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmLichSuHangHoa()
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
            gridControl1.DataSource = new PRODUCTController().PRODUCT_History_Modify();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Lịch Sử Hàng Hóa";
            _sys_log.Module = "Lịch Sử Hàng Hóa";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
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