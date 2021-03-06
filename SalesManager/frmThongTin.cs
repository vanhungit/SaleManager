using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
namespace SalesManager
{
    public partial class frmThongTin : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTin()
        {
            InitializeComponent();
            barManager1.SetPopupContextMenu(pictureEdit1, popupMenu1);
        }
        SYS_COMPANY objsyscompany = new SYS_COMPANY();
        string Pathname;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            objsyscompany = new SYS_COMPANYController().SYS_COMPANY_Get("01");
            if (objsyscompany.Company_Id != "01")
            {
                int rs = -1;
                FileStream frm;
                frm = new FileStream(Pathname, FileMode.Open, FileAccess.Read);
                byte[] picbyte = new byte[frm.Length];
                frm.Read(picbyte, 0, System.Convert.ToInt32(frm.Length));
                frm.Close();
                objsyscompany.Company_Id = "01";
                objsyscompany.Company = txtTen.Text;
                objsyscompany.Address = txtDiaChi.Text;
                objsyscompany.Fax = txtFax.Text;
                objsyscompany.Email = txtEmail.Text;
                objsyscompany.Tel = txtDienthoai.Text;
                objsyscompany.Tax = txtMST.Text;
                objsyscompany.WebSite = txtWebsite.Text;
                objsyscompany.Licence = txtMST.Text;
                objsyscompany.Photo = picbyte;
                rs = new SYS_COMPANYController().SYS_COMPANY_Insert(objsyscompany);
                if (rs < 1)
                {
                    MessageBox.Show("Công ty đã tồn tại", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Công ty mới đã được lưu", "Thông báo");
                }
            }
            else
            {
                int rs = -1;
                if (Pathname != null)
                {
                    FileStream frm;
                    frm = new FileStream(Pathname, FileMode.Open, FileAccess.Read);
                    byte[] picbyte = new byte[frm.Length];
                    frm.Read(picbyte, 0, System.Convert.ToInt32(frm.Length));
                    frm.Close();
                    objsyscompany.Photo = picbyte;
                }
                objsyscompany.Company_Id = "01";
                objsyscompany.Company = txtTen.Text;
                objsyscompany.Address = txtDiaChi.Text;
                objsyscompany.Fax = txtFax.Text;
                objsyscompany.Email = txtEmail.Text;
                objsyscompany.Tel = txtDienthoai.Text;
                objsyscompany.Tax = txtMST.Text;
                objsyscompany.WebSite = txtWebsite.Text;
                objsyscompany.Licence = txtMST.Text;
                rs = new SYS_COMPANYController().SYS_COMPANY_Update(objsyscompany,objsyscompany.Company_Id);
                if (rs < 1)
                {
                    MessageBox.Show("Công ty đã tồn tại", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Công ty đã cập nhật", "Thông báo");
                }
            }
        }

        private void barLargeButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void frmThongTin_Load(object sender, EventArgs e)
        {
            objsyscompany = new SYS_COMPANYController().SYS_COMPANY_Get("01");
            if (objsyscompany.Company_Id == "01")
            {
                MemoryStream fs1 = new MemoryStream(objsyscompany.Photo, true);
                pictureEdit1.Image = Image.FromStream(fs1);
                pictureEdit1.Refresh();
                txtTen.Text = objsyscompany.Company;
                txtDiaChi.Text = objsyscompany.Address;
                txtDienthoai.Text = objsyscompany.Tel;
                txtEmail.Text = objsyscompany.Email;
                txtFax.Text = objsyscompany.Fax;
                txtMST.Text = objsyscompany.Tax;
                txtWebsite.Text = objsyscompany.WebSite;
                txtGP.Text = objsyscompany.Licence;
             }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}