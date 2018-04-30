using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using SalesManager.Entity;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using System.Xml;
using System.IO;
using QuanLiBanHang.Entity;
using System.Runtime.InteropServices;
namespace SalesManager
{
    public partial class frmChinhSuaKhuyenMai : Form
    {
        PROMOTION_DETAIL objpromotiondetail = new PROMOTION_DETAIL();
        DataTable dtable = new DataTable();
        frmKhuyenMai frmkhuyenmai = new frmKhuyenMai();
        PROMOTION objkhuyenmai = new PROMOTION();
        SYS_USER objuser = new SYS_USER();
        public frmChinhSuaKhuyenMai(frmKhuyenMai _frm, PROMOTION makhuyenmai)
        {
            InitializeComponent();
            InitLookUp_LoaiBang();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateBatDau.DateTime = DateTime.Now;
            dateHetHan.DateTime = DateTime.Now;
            dtCreateDate.DateTime = DateTime.Now;
            objkhuyenmai = makhuyenmai;
            txtMaKM.Text = makhuyenmai.ID;
            txtTenKM.Text = makhuyenmai.Name_Promotion;
            objkhuyenmai = makhuyenmai;
            frmkhuyenmai = _frm;
            dtable.Columns.Add("ProductGroup_ID");
            dtable.Columns.Add("Discount");
            dtable.Columns.Add("DateFrom");
            dtable.Columns.Add("DateTo");
            gridControl1.DataSource = new PROMOTION_DETAILController().PROMOTION_DETAIL_Get(makhuyenmai.ID);
        }
        private void InitLookUp_LoaiBang()
        {
            // Specify the data source to display in the dropdown.
            lookUpLoaiGia.Properties.DataSource = new BANGGIAController().LoaiBangGia();
            // The field providing the editor's display text.
            lookUpLoaiGia.Properties.DisplayMember = "TEN_LOAI";
            // The field matching the edit value.
            lookUpLoaiGia.Properties.ValueMember = "ID";
            lookUpLoaiGia.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLoaiGia.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLoaiGia.Properties.AutoSearchColumnIndex = 1;
            lookUpLoaiGia.EditValue = "3";
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
    
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
      
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            Close();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objkhuyenmai.Name_Promotion = txtTenKM.Text;
            objkhuyenmai.StartDate = dateBatDau.DateTime;
            objkhuyenmai.StopDate = dateHetHan.DateTime;
            objkhuyenmai.RefType = int.Parse(lookUpLoaiGia.GetColumnValue("ID").ToString());
            rs = new PROMOTIONController().PROMOTION_Update(objkhuyenmai);
            //if (gridView1.RowCount > 0)
            //{
            //    for (int i = 0; i < gridView1.RowCount - 1; i++)
            //    {
            //        int rsstockdetail = -1;
            //        objpromotiondetail.ProductGroup_ID = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
            //        objpromotiondetail.Promotion_ID = txtMaKM.Text;
            //        objpromotiondetail.DiscountPercent = double.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString());
            //        //objpromotiondetail.DateFrom = DateTime.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString());
            //        //objpromotiondetail.DateTo = DateTime.Parse(gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString());
            //        if (gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString() != "")
            //        {
            //            objpromotiondetail.ID = new Guid(gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString());
            //            rsstockdetail = new PROMOTION_DETAILController().PROMOTION_DETAIL_Update(objpromotiondetail);
            //        }
            //        else
            //        {
            //            objpromotiondetail.ID = Guid.NewGuid();
            //            rsstockdetail = new PROMOTION_DETAILController().PROMOTION_DETAIL_Insert(objpromotiondetail);
            //        }
            //        if (rsstockdetail == -1)
            //        {
            //            MessageBox.Show("Lưu Thất Bại", "Thông Báo");
            //            break;
            //        }
            //    }
            //}
            if (rs > -1)
            {
                MessageBox.Show("Cập Nhật Thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất bại", "Thông Báo");

            }
        }

     

    }
}
