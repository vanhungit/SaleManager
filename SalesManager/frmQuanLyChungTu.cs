using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.IO;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class frmQuanLyChungTu : DevExpress.XtraEditors.XtraForm
    {
        SYS_LOG _sys_log = new SYS_LOG();
        public frmQuanLyChungTu()
        {
            InitializeComponent();
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Quản Lý Chứng Từ");
            barManager1.SetPopupContextMenu(gridControl1, popupMenu1);
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            datetu.DateTime = DateTime.Now;
            dateden.DateTime = DateTime.Now;
            radioGroup1.SelectedIndex = 0;
            gridControl1.UseEmbeddedNavigator = true;
            gridControl1.DataSource = new TRANS_REFController().TRANS_REF_GetListAll_Type();
            WaitDialog.CloseWaitDialog();
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Tồn Kho";
            _sys_log.Reference = "";
            _sys_log.Module = "Tồn Kho";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
      
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                datetu.Properties.ReadOnly = true;
                dateden.Properties.ReadOnly = true;
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                datetu.Properties.ReadOnly = false;
                dateden.Properties.ReadOnly = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                gridControl1.DataSource = new TRANS_REFController().TRANS_REF_GetListAll_Type();
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                gridControl1.DataSource = new TRANS_REFController().TRANS_REF_GetList_ByDate_Type(datetu.DateTime,dateden.DateTime);
            }
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

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Quản Lý Chứng Từ");
            gridControl1.DataSource = new TRANS_REFController().TRANS_REF_GetListAll_Type();
            WaitDialog.CloseWaitDialog();

        }

    }
}
