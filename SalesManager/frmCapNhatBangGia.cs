using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SalesManager.Entity;
using System.Xml;
using QuanLiBanHang.Controller;
using System.IO;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors.Controls;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class frmCapNhatBangGia : DevExpress.XtraEditors.XtraForm
    {
        UC_BangKeTongHopBangGia uc_tonghopbanggia;
        BANGGIA _banggia = new BANGGIA();
        SYS_USER objuser = new SYS_USER();
        public frmCapNhatBangGia(UC_BangKeTongHopBangGia frm, BANGGIA objbanggia)
        {
            InitializeComponent();
            uc_tonghopbanggia = frm;
            _banggia = objbanggia;
            txtMaBangGia.Text = objbanggia.ID;
            txtTenBangGia.Text = objbanggia.Name_ListPrice;
            dateNgayTao.DateTime = objbanggia.Refdate;
            lookUpLoaiGia.EditValue = objbanggia.RefType;
            dateBatDau.DateTime = objbanggia.StartDate;
            dateHetHan.DateTime = objbanggia.StopDate;
            chkDangDung.Checked = objbanggia.Active;
            InitLookUp_LoaiBang();
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new BANGGIA_DETAILController().BANGGIA_DETAIL_Get(objbanggia.ID);
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            _banggia.Name_ListPrice = txtTenBangGia.Text;
            _banggia.StartDate = dateBatDau.DateTime;
            _banggia.StopDate = dateHetHan.DateTime;
            _banggia.Active = chkDangDung.Checked;
            int rs = new BANGGIAController().CapNhatBANGGIA(_banggia, _banggia.ID);
            if (rs < 1)
            {
                MessageBox.Show("Bảng giá không được cập nhật", "Thông báo");
            }
            else
            {
                MessageBox.Show("Bảng giá đã được cập nhật", "Thông báo");
            }
            uc_tonghopbanggia.Refresh();
        }
    }
}