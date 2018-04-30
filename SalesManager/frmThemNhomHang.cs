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
using SalesManager.Controller;
using DevExpress.XtraEditors.Controls;
namespace SalesManager
{
    public partial class frmThemNhomHang : Form
    {
        public frmThemNhomHang()
        {
            InitializeComponent();
            gridLookUpEdit1View.Invalidate();
            gridLookUpEdit1View.IndicatorWidth = 35;
            gridLookUpNganh.Properties.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
            gridLookUpNganh.Properties.DisplayMember = "TEN_NGANH";
            gridLookUpNganh.Properties.ValueMember = "ID_NGANH";
            gridLookUpNganh.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpNganh.EditValue = gridLookUpNganh.Properties.GetKeyValue(0);// chọn phần tử thứ nhất
        }
        PRODUCT_GROUP objproduct_group = new PRODUCT_GROUP();
        public string SinhMaNhomHang()
        {
            string MaKhachHang, MaTam;
            MaKhachHang = "";
            MaTam = "";
            objproduct_group = new PRODUCT_GROUPController().PRODUCT_GROUP_Top1();
            MaTam = objproduct_group.ProductGroup_ID;
            if (MaTam != "")
            {

                long NumberKhuVuc = long.Parse(MaTam.Substring(2, 6)) + 1;
                MaKhachHang = NumberKhuVuc.ToString();
                for (int i = NumberKhuVuc.ToString().Length; i < 6; i++)
                {
                    MaKhachHang = "0" + MaKhachHang;
                    //MessageBox.Show(MaKhuVuc);
                }
                MaKhachHang = "NH" + MaKhachHang;
            }
            else
            {
                MaKhachHang = "NH000001";
            }
            return MaKhachHang;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemNhomHang_Load(object sender, EventArgs e)
        {
            txtMa.Text = SinhMaNhomHang();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objproduct_group.ProductGroup_ID = txtMa.Text;
            objproduct_group.ID_NGANH = gridLookUpNganh.Properties.GetKeyValue(gridLookUpEdit1View.FocusedRowHandle).ToString();
            objproduct_group.ProductGroup_Name = txtTen.Text;
            objproduct_group.Description = txtGhiChu.Text;
            objproduct_group.Active = checkactive.Checked;
            rs = new PRODUCT_GROUPController().PRODUCT_GROUP_Insert(objproduct_group);
            if (rs < 1)
            {
                MessageBox.Show("Nhóm hàng đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Nhóm hàng mới đã được lưu", "Thông báo");
                txtGhiChu.Text = "";
                txtTen.Text = "";
                txtMa.Text = SinhMaNhomHang();
            }
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
