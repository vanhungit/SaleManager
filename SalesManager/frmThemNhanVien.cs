using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Xml;
namespace SalesManager
{
    public partial class frmThemNhanVien : Form
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
            InitLookUp_PhongBan();
            InitLookUp_NhanVien();
        }
        EMPLOYEE objemployee = new EMPLOYEE();
        public string SinhMaNhanVien()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objemployee = new EMPLOYEEController().Employee_Top1();
            MaTam = objemployee.Employee_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "NV" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "NV000001";
            }
            return MaKhachHang;
        }
        private void InitLookUp_PhongBan()
        {
            // Specify the data source to display in the dropdown.
            lookbophan.Properties.DataSource = new DEPARTMENTController().LayDSDEPARTMENT_GROUP();
            // The field providing the editor's display text.
            lookbophan.Properties.DisplayMember = "Department_Name";
            // The field matching the edit value.
            lookbophan.Properties.ValueMember = "Department_ID";
            lookbophan.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookbophan.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookbophan.Properties.AutoSearchColumnIndex = 1;
        }
        private void InitLookUp_NhanVien()
        {
            // Specify the data source to display in the dropdown.
            looknhanvien.Properties.DataSource = new EMPLOYEEController().LayDSNhanVien();
            // The field providing the editor's display text.
            looknhanvien.Properties.DisplayMember = "Employee_Name";
            // The field matching the edit value.
            looknhanvien.Properties.ValueMember = "Employee_ID";
            looknhanvien.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            looknhanvien.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            looknhanvien.Properties.AutoSearchColumnIndex = 1;
        }

        private void lookbophan_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "1")
            {
                frmThemPhongBan frm = new frmThemPhongBan();
                frm.ShowDialog();
            }
            else
            {
                InitLookUp_PhongBan();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objemployee.Employee_ID = txtMa.Text;
            objemployee.Employee_Name = txtTen.Text;
            objemployee.Active = chkquanli.Checked;
            objemployee.Position_ID = txtchucvu.Text;
            objemployee.Address = txtdiachi.Text;
            objemployee.Email = txtemail.Text;
            objemployee.O_Tel = txtdienthoai.Text;
            objemployee.H_Tel = txtdidong.Text;
            objemployee.Department_ID = new DEPARTMENTController().DEPARTMENT_GetbyName(lookbophan.Text.Trim()).Department_ID;
            objemployee.Manager_ID = new EMPLOYEEController().EMPLOYEE_GetbyName(looknhanvien.Text.Trim()).Employee_ID;
            rs = new EMPLOYEEController().ThemNhanVien(objemployee);
            if (rs < 1)
            {
                MessageBox.Show("Nhân viên đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Nhân viên mới đã được lưu", "Thông báo");
            }
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaNhanVien();
        }
    }
}
