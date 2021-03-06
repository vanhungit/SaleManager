﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Xml;
using SalesManager.Controller;
namespace SalesManager
{
    public partial class frmThemHangHoa_DichVu : Form
    {
        SYS_USER objuser = new SYS_USER();
        public frmThemHangHoa_DichVu()
        {
            InitializeComponent();
            gridLookUpEdit1View.Invalidate();
            gridLookUpEdit1View.IndicatorWidth = 35;
            gridLookUpNganh.Properties.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
            gridLookUpNganh.Properties.DisplayMember = "TEN_NGANH";
            gridLookUpNganh.Properties.ValueMember = "ID_NGANH";
            gridLookUpNganh.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpNganh.EditValue = gridLookUpNganh.Properties.GetKeyValue(0);// chọn phần tử thứ nhất
            ReadXml_User();
            InitLookUp_DonVi();
            InitLookUp_KhoHang();
            InitLookUp_PhanLoai();
            InitLookUp_NhaCC();
        }
        PRODUCT objproduct = new PRODUCT();
        string Pathname;
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
        private void InitLookUp_KhoHang()
        {
            // Specify the data source to display in the dropdown.
            lookkho.Properties.DataSource = new STOCKController().STOCK_GetList();
            // The field providing the editor's display text.
            lookkho.Properties.DisplayMember = "Stock_Name";
            // The field matching the edit value.
            lookkho.Properties.ValueMember = "Stock_ID";
            lookkho.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookkho.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookkho.Properties.AutoSearchColumnIndex = 1;
            lookkho.EditValue = new STOCKController().STOCK_Top1().Stock_ID;
        }
        private void InitLookUp_PhanLoai()
        {
            // Specify the data source to display in the dropdown.
            lookphanloai.Properties.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetByNganh(gridLookUpNganh.Properties.GetKeyValue(0).ToString());
            // The field providing the editor's display text.
            lookphanloai.Properties.DisplayMember = "ProductGroup_Name";
            // The field matching the edit value.
            lookphanloai.Properties.ValueMember = "ProductGroup_ID";
            lookphanloai.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookphanloai.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookphanloai.Properties.AutoSearchColumnIndex = 1;
            //lookphanloai.EditValue = new PRODUCT_GROUPController().PRODUCT_GROUP_Top1().ProductGroup_ID;
        }
        private void InitLookUp_DonVi()
        {
            // Specify the data source to display in the dropdown.
            lookdonvi.Properties.DataSource = new UNITController().UNIT_GetList();
            // The field providing the editor's display text.
            lookdonvi.Properties.DisplayMember = "Unit_Name";
            // The field matching the edit value.
            lookdonvi.Properties.ValueMember = "Unit_ID";
            lookdonvi.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookdonvi.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookdonvi.Properties.AutoSearchColumnIndex = 1;
            lookdonvi.EditValue = new UNITController().UNIT_Top1().Unit_ID;
        }
        private void InitLookUp_NhaCC()
        {
            // Specify the data source to display in the dropdown.
            looknhacungcap.Properties.DataSource = new PROVIDERController().PROVIDER_GetList();
            // The field providing the editor's display text.
            looknhacungcap.Properties.DisplayMember = "CustomerName";
            // The field matching the edit value.
            looknhacungcap.Properties.ValueMember = "Customer_ID";
            looknhacungcap.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            looknhacungcap.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            looknhacungcap.Properties.AutoSearchColumnIndex = 1;
            looknhacungcap.EditValue = new PROVIDERController().PROVIDER_Top1().Customer_ID;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            /*FileStream frm;
            frm = new FileStream(Pathname, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[frm.Length];
            frm.Read(picbyte, 0, System.Convert.ToInt32(frm.Length));
            frm.Close();
            objproduct.Photo = picbyte;
             */
           
            MemoryStream ms = new MemoryStream();
            try
            {
                pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] buff = ms.GetBuffer();
                objproduct.Photo = buff;
            }
            catch
            {
                byte[] buff = { 1 };
                objproduct.Photo = buff;
            }
            objproduct.Product_Type_ID = cboloaihang.SelectedIndex;
            objproduct.Provider_ID = lookkho.GetColumnValue("Stock_ID").ToString();
            objproduct.Product_Group_ID = lookphanloai.GetColumnValue("ProductGroup_ID").ToString();
            objproduct.Product_ID = txtMa.Text;
            objproduct.Barcode = txtbarcode.Text;
            objproduct.Product_Name = txtten.Text;
            objproduct.Unit = lookdonvi.GetColumnValue("Unit_ID").ToString();
            objproduct.Origin = txtxuatxu.Text;
            objproduct.MinStock = double.Parse(caltoithieu.Text);
            objproduct.Customer_ID = looknhacungcap.GetColumnValue("Customer_ID").ToString();
            objproduct.Org_Price = double.Parse(calcgiamua.Text);
            objproduct.Sale_Price = double.Parse(calcgiasi.Text);
            objproduct.Retail_Price = double.Parse(calcgiale.Text);
            objproduct.UnitRate = 1;
            objproduct.Customer_Name = looknhacungcap.Text;
            objproduct.ExchangeRate = 1;
            objproduct.Active = true;
            objproduct.UserID = objuser.UserID;
            objproduct.Currency_ID = "VND";
            rs = new PRODUCTController().PRODUCT_Insert_Photo(objproduct);
            if (rs < 1)
            {
                MessageBox.Show("Mặt Hàng đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Mặt Hàng mới đã được lưu", "Thông báo");
            }
            
        }
        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            FileDialog file_dialog = new OpenFileDialog();
            file_dialog.InitialDirectory = @"d:\";
            file_dialog.Filter = "File anh(*.jpg;*.bmp;*.gif;*.png)|*jpg;*bmp;*gif;*png";
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                Pathname = file_dialog.FileName;
                Bitmap anh = new Bitmap(Pathname);
                pictureEdit1.Image = (Image)anh;
            }
            file_dialog = null;
        }

        private void lookkho_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemKhoHang frm = new frmThemKhoHang();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_KhoHang();
            }
        }

        private void lookphanloai_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemNhomHang frm = new frmThemNhomHang();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_PhanLoai();
            }
        }

        private void lookdonvi_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemDonVi frm = new frmThemDonVi();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_DonVi();
            }
        }

        private void looknhacungcap_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemPhanPhoi frm = new frmThemPhanPhoi();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_NhaCC();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmChiTietLichSuHangHoa frm = new frmChiTietLichSuHangHoa(txtMa.Text, txtten.Text);
            frm.ShowDialog();

        }

        private void gridLookUpNganh_EditValueChanged(object sender, EventArgs e)
        {
            lookphanloai.Properties.DataSource = new PRODUCT_GROUPController().PRODUCT_GROUP_GetByNganh(gridLookUpNganh.Properties.GetKeyValue(gridLookUpEdit1View.FocusedRowHandle).ToString());
            lookphanloai.ItemIndex = 0;
        }

        private void gridLookUpEdit1View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
