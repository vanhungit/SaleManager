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
    public partial class frmCapNhatNhomHang : Form
    {
        public frmCapNhatNhomHang()
        {
            InitializeComponent();
            gridLookUpEdit1View.Invalidate();
            gridLookUpEdit1View.IndicatorWidth = 35;
            gridLookUpNganh.Properties.DataSource = new NGANH_HANGController().LayDSNGANH_HANG();
            gridLookUpNganh.Properties.DisplayMember = "TEN_NGANH";
            gridLookUpNganh.Properties.ValueMember = "ID_NGANH";
            gridLookUpNganh.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            
        }
        PRODUCT_GROUP objproductgroup = new PRODUCT_GROUP();
        public void Load_Data(PRODUCT_GROUP objproductgroup)
        {
            this.objproductgroup = objproductgroup;
            txtMa.Text = objproductgroup.ProductGroup_ID;
            txtTen.Text = objproductgroup.ProductGroup_Name;
            txtGhiChu.Text = objproductgroup.Description;
            checkactive.Checked = objproductgroup.Active;
            gridLookUpNganh.EditValue = objproductgroup.ID_NGANH;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs = -1;
            objproductgroup.ProductGroup_ID = txtMa.Text;
            objproductgroup.ID_NGANH = gridLookUpNganh.Properties.GetKeyValue(gridLookUpEdit1View.FocusedRowHandle).ToString();
            objproductgroup.ProductGroup_Name = txtTen.Text;
            objproductgroup.Description = txtGhiChu.Text;
            objproductgroup.Active = checkactive.Checked;
            rs = new PRODUCT_GROUPController().PRODUCT_GROUP_Update(objproductgroup, objproductgroup.ProductGroup_ID);
            if (rs < 1)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
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
