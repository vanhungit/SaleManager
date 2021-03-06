using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors.Controls;
using QuanLiBanHang.Entity;

namespace SalesManager
{
    public partial class frmLapPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        CUSTOMER_RECEIPT _customer_receip = new CUSTOMER_RECEIPT();
        CUSTOMER_RECEIPT_DETAIL _customer_receip_detail = new CUSTOMER_RECEIPT_DETAIL();
        STOCK_OUTWARDController stockoutward = new STOCK_OUTWARDController();
        public string MaKhachHang = "";
        public frmLapPhieuThu(string TenKhachHang, string MaKH, string ChungTu, DateTime NgayCT, double SoTien,double DaTra, double ConNo)
        {
            InitializeComponent();
            InitLookUp();
            InitLookUp_NhanVien();
            InitLookUp_BanHang();
            lookUpTenKH.EditValue = TenKhachHang;
            lookUpChungTu.EditValue = ChungTu;
            dateCT.DateTime = NgayCT;
            dateSoPhieu.DateTime = DateTime.Now;
            calcSoTien.Text = SoTien.ToString();
            calcTienTra.Text = ConNo.ToString();
            calcConNo.Text = ConNo.ToString();
            MaKhachHang = MaKH;
            txtSoPhieu.Text = CreatePhieuThu();

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
            looknhanvien.EditValue = "NV000001";
        }
        private void InitLookUp_BanHang()
        {
            // Specify the data source to display in the dropdown.
            lookUpChungTu.Properties.DataSource = new STOCK_OUTWARDController().STOCK_OUTWARD_GetList();
            // The field providing the editor's display text.
            lookUpChungTu.Properties.DisplayMember = "Barcode";
            // The field matching the edit value.
            lookUpChungTu.Properties.ValueMember = "ID";
            lookUpChungTu.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpChungTu.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpChungTu.Properties.AutoSearchColumnIndex = 1;
        }
        private void InitLookUp()
        {
            // Specify the data source to display in the dropdown.
            lookUpTenKH.Properties.DataSource = new CUSTOMERController().LayDSCUSTOMER();
            // The field providing the editor's display text.
            lookUpTenKH.Properties.DisplayMember = "CustomerName";
            // The field matching the edit value.
            lookUpTenKH.Properties.ValueMember = "CustomerName";
            lookUpTenKH.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpTenKH.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpTenKH.Properties.AutoSearchColumnIndex = 1;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Tạo Số Phiếu Thu Tự Động
        /// </summary>
        /// <returns></returns>
        public string CreatePhieuThu()
        {
            string PhieuThu,Temp_PT,Number_PT;
            PhieuThu = "";//Trả về số phiếu thu
            Temp_PT = "";//Số phiếu tạm
            Number_PT = "";// Number phiếu thu
            CUSTOMER_RECEIPT _customer_PT = new CUSTOMER_RECEIPTController().CUSTOMER_Top1RefID("NV000001");
            Temp_PT = _customer_PT.RefID;
            if (Temp_PT != "")
            {
                Number_PT = Temp_PT.Substring(Temp_PT.Length - 6, 6);
                Number_PT = (long.Parse(Number_PT.ToString()) + 1).ToString();
                PhieuThu = Number_PT;
                for (int i = 0; i < 6 - Number_PT.Length; i++)
                {
                    PhieuThu = "0" + PhieuThu;
                }
                PhieuThu = Temp_PT.Substring(0, Temp_PT.Length - 6) + PhieuThu;
            }
            return PhieuThu;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs_receip, rs_receip_detail;
            ////
            if (double.Parse(calcTienTra.Text.Trim()) > double.Parse(calcConNo.Text.Trim()))
            {
                calcTienTra.Text = calcConNo.Text;
            }
            _customer_receip.ID = Guid.NewGuid();
            _customer_receip.RefID = txtSoPhieu.Text.Trim();
            _customer_receip.RefDate = DateTime.Now;
            _customer_receip.RefType = 41;
            _customer_receip.RefStatus = 0;
            _customer_receip.RefOrgNo = lookUpChungTu.Text;
            _customer_receip.CurrencyID = "VND";
            _customer_receip.PaymentMethod = new STOCK_OUTWARDController().STOCK_OUTWARD_Get(lookUpChungTu.Text).PaymentMethod;
            _customer_receip.ExchangeRate = 1;
            _customer_receip.CustomerID = MaKhachHang;
            _customer_receip.CustomerName = lookUpTenKH.Text;
            _customer_receip.Amount = double.Parse(calcTienTra.Text);
            _customer_receip.CreatedBy = "admin";
            _customer_receip.ModifiedBy = "admin";
            _customer_receip.CreatedDate = DateTime.Now;
            _customer_receip.ModifiedDate = _customer_receip.CreatedDate;
            _customer_receip.OwnerID = "NV000001";
            _customer_receip.Description = memoEdit1.Text.Trim();
            _customer_receip.Active = true;
            CUSTOMER_RECEIPTController _customer_receip_controller = new CUSTOMER_RECEIPTController();
            /////
            _customer_receip_detail.ReceiptID = _customer_receip.ID;
            _customer_receip_detail.ID = Guid.NewGuid();
            _customer_receip_detail.RefOrgNo = Guid.NewGuid();
            _customer_receip_detail.CurrencyID = _customer_receip.CurrencyID;
            _customer_receip_detail.ExchangeRate = 1;
            _customer_receip_detail.Quantity = 1;
            _customer_receip_detail.Amount = double.Parse(calcSoTien.Text);
            _customer_receip_detail.Debit = double.Parse(calcConNo.Text);
            _customer_receip_detail.Payment = double.Parse(calcTienTra.Text);
            _customer_receip_detail.Description = lookUpTenKH.Text;
            CUSTOMER_RECEIPT_DETAILController _customer_receip_detail_controller = new CUSTOMER_RECEIPT_DETAILController();
            //////
            DEBT _debt = new DEBT();
            DEBTController _debtcontroller = new DEBTController();
            DEBTController _debtcontroller1 = new DEBTController();
            _debt = _debtcontroller.DEBT_GetbyRefID(lookUpChungTu.Text.Trim());
            _debt.Payment = _debt.Payment + double.Parse(calcTienTra.Text.Trim());
            _debt.Balance = _debt.Balance - double.Parse(calcTienTra.Text.Trim());
            _debt.FAmount = _debt.Balance;
            if (_debt.Balance == 0)
                _debt.IsChanged = true;
            _customer_receip_detail.RefOrgNo = _debt.ID;
            _customer_receip.PaymentMethod = _debt.PaymentMethod;

            if (txtSoPhieu.Text != "")
            {
                try
                {
                    rs_receip = _customer_receip_controller.ThemCUSTOMER_RECEIPT(_customer_receip);
                    rs_receip_detail = _customer_receip_detail_controller.ThemCUSTOMER_RECEIPT_DETAIL(_customer_receip_detail);
                    //rs_debt = new DEBTController().DEBT_UpdateByRefId(_debt, _debt.RefID);
                    if (/*(rs_debt >= 1) && */(rs_receip >= 1) && (rs_receip_detail >= 1))
                    {
                        stockoutward.STOCK_OUTWARD_Update_RefStatus(lookUpChungTu.Text);
                        MessageBox.Show("Lưu Thành Công","Cảnh Báo");

                    }
                    else
                    {
                        MessageBox.Show("Lưu Thất Bại","Cảnh Báo");
                    }
                }
                catch
                {
                    MessageBox.Show("Lưu Thất Bại", "Cảnh Báo");
                }
            }
            else
                MessageBox.Show("Chưa nhập số phiếu","Cảnh Báo");

        }
    }
}