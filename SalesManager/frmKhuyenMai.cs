using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using SalesManager.Entity;
using DevExpress.XtraEditors.Controls;
using System.Xml;
using System.IO;

namespace SalesManager
{
    public partial class frmKhuyenMai : Form
    {
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        public frmKhuyenMai()
        {
            InitializeComponent();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new PROMOTION_DETAILController().PROMOTION_GetAllList();
            repositoryItemLookUpLoaiGia.Properties.DataSource = new BANGGIAController().LoaiBangGia();
            repositoryItemLookUpLoaiGia.Properties.DisplayMember = "TEN_LOAI";
            // The field matching the edit value.
            repositoryItemLookUpLoaiGia.Properties.ValueMember = "ID";
            repositoryItemLookUpLoaiGia.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            repositoryItemLookUpLoaiGia.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            repositoryItemLookUpLoaiGia.Properties.AutoSearchColumnIndex = 1;
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = objuser.UserID;
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Khuyến Mãi";
            _sys_log.Module = "Khuyến Mãi";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
        }
        public void RefreshLuoi()
        {
            gridControl1.DataSource = new PROMOTION_DETAILController().PROMOTION_GetAllList();

        }
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemKhuyenMai frm = new frmThemKhuyenMai(this);
            frm.ShowDialog();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new PROMOTION_DETAILController().PROMOTION_GetAllList();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                PROMOTION objpromotion = new PROMOTION();
                objpromotion = new PROMOTIONController().PROMOTION_Get(id);
                frmChinhSuaKhuyenMai frm = new frmChinhSuaKhuyenMai(this, objpromotion);
                frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                PROMOTION objpromotion = new PROMOTION();
                objpromotion = new PROMOTIONController().PROMOTION_Get(id);
                frmChinhSuaKhuyenMai frm = new frmChinhSuaKhuyenMai(this, objpromotion);
                frm.ShowDialog();
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

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Khuyến Mãi Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    PROMOTION objkhuyenmai = new PROMOTIONController().PROMOTION_Get(id);
                    if (objkhuyenmai.Active == true)
                    {
                        MessageBox.Show("Không Được Xóa Khuyến Mãi Đang Áp Dụng", "Thông báo");
                    }
                    else
                    {
                        rs = new PROMOTIONController().PROMOTION_Delete(id);
                        if (rs < 1)
                        {
                            MessageBox.Show("Khuyến mãi không được xóa", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Khuyến mãi đã được xóa", "Thông báo");
                        }
                        gridControl1.DataSource = new PROMOTION_DETAILController().PROMOTION_GetAllList();

                    }
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }
    }
}
