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
    public partial class frmLapPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        PROVIDER_PAYMENT _provider_payment = new PROVIDER_PAYMENT();
        PROVIDER_PAYMENT_DETAIL _provider_payment_detail = new PROVIDER_PAYMENT_DETAIL();
        STOCK_INWARDController stockinward = new STOCK_INWARDController();
        public string MaKhachHang = "";
        public frmLapPhieuChi(string TenKhachHang, string MaKH, string ChungTu, DateTime NgayCT, double SoTien, double DaTra, double ConNo)
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
            txtSoPhieu.Text = CreatePhieuChi();
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
            lookUpChungTu.Properties.DataSource = new STOCK_INWARDController().STOCK_INWARD_GetList();
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
            lookUpTenKH.Properties.DataSource = new PROVIDERController().PROVIDER_GetList();
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
        public string CreatePhieuChi()
        {
            string PhieuChi, Temp_Chi, Number_PC;
            PhieuChi = "";//Trả về số phiếu thu
            Temp_Chi = "";//Số phiếu tạm
            Number_PC = "";// Number phiếu thu
            PROVIDER_PAYMENT _provider_PC = new PROVIDER_PAYMENTController().PROVIDER_PAYMENT_Top1RefID("NV000001");
            Temp_Chi = _provider_PC.RefID;
            if (Temp_Chi != "")
            {
                Number_PC = Temp_Chi.Substring(Temp_Chi.Length - 6, 6);
                Number_PC = (long.Parse(Number_PC.ToString()) + 1).ToString();
                PhieuChi = Number_PC;
                for (int i = 0; i < 6 - Number_PC.Length; i++)
                {
                    PhieuChi = "0" + PhieuChi;
                }
                PhieuChi = Temp_Chi.Substring(0, Temp_Chi.Length - 6) + PhieuChi;
            }
            return PhieuChi;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int rs_provider, rs_provider_detail;
            ////
            if (double.Parse(calcTienTra.Text.Trim()) > double.Parse(calcConNo.Text.Trim()))
            {
                calcTienTra.Text = calcConNo.Text;
            }
            _provider_payment.ID = Guid.NewGuid();
            _provider_payment.RefID = txtSoPhieu.Text.Trim();
            _provider_payment.RefDate = DateTime.Now;
            _provider_payment.RefType = 42;
            _provider_payment.RefStatus = 0;
            _provider_payment.RefOrgNo = lookUpChungTu.Text;
            _provider_payment.CurrencyID = "VND";
            _provider_payment.PaymentMethod = new STOCK_INWARDController().STOCK_INWARD_Get(lookUpChungTu.Text).PaymentMethod;
            _provider_payment.ExchangeRate = 1;
            _provider_payment.CustomerID = MaKhachHang;
            _provider_payment.CustomerName = lookUpTenKH.Text;
            _provider_payment.Amount = double.Parse(calcTienTra.Text);
            _provider_payment.CreatedBy = "admin";
            _provider_payment.ModifiedBy = "admin";
            _provider_payment.CreatedDate = DateTime.Now;
            _provider_payment.ModifiedDate = _provider_payment.CreatedDate;
            _provider_payment.OwnerID = "NV000001";
            _provider_payment.Description = memoEdit1.Text.Trim();
            _provider_payment.Active = true;
            PROVIDER_PAYMENTController _provider_payment_controller = new PROVIDER_PAYMENTController();
            /////
            _provider_payment_detail.PaymentID = _provider_payment.ID;
            _provider_payment_detail.ID = Guid.NewGuid();
            _provider_payment_detail.RefOrgNo = Guid.NewGuid();
            _provider_payment_detail.CurrencyID = _provider_payment.CurrencyID;
            _provider_payment_detail.ExchangeRate = 1;
            _provider_payment_detail.Quantity = 1;
            _provider_payment_detail.Amount = double.Parse(calcSoTien.Text);
            _provider_payment_detail.Debit = double.Parse(calcConNo.Text);
            _provider_payment_detail.Payment = double.Parse(calcTienTra.Text);
            _provider_payment_detail.Description = lookUpTenKH.Text;
            PROVIDER_PAYMENT_DETAILController _provider_payment_detail_controller = new PROVIDER_PAYMENT_DETAILController();
            //////
            DEBT _debt = new DEBT();
            DEBTController _debtcontroller = new DEBTController();
            //DEBTController _debtcontroller1 = new DEBTController();
            _debt = _debtcontroller.DEBT_GetbyRefID(lookUpChungTu.Text.Trim());
            _debt.Payment = _debt.Payment + double.Parse(calcTienTra.Text.Trim());
            _debt.Balance = _debt.Balance - double.Parse(calcTienTra.Text.Trim());
            _debt.FAmount = _debt.Balance;
            _provider_payment_detail.RefOrgNo = _debt.ID;
            _provider_payment.PaymentMethod = _debt.PaymentMethod;

            if (_debt.Payment == 0)
                _debt.IsChanged = true;
            if (txtSoPhieu.Text != "")
            {
                try
                {
                    rs_provider = _provider_payment_controller.PROVIDER_PAYMENT_Insert(_provider_payment);
                    rs_provider_detail = _provider_payment_detail_controller.PROVIDER_PAYMENT_DETAIL_Insert(_provider_payment_detail);
                    //rs_debt = new DEBTController().DEBT_UpdateByRefId(_debt, _debt.RefID);
                    if (/*(rs_debt >= 1) && */(rs_provider >= 1) && (rs_provider_detail >= 1))
                    {
                        stockinward.STOCK_INWARD_Update_RefStatus(lookUpChungTu.Text);
                        MessageBox.Show("Lưu Thành Công", "Cảnh Báo");

                    }
                    else
                    {
                        MessageBox.Show("Lưu Thất Bại", "Cảnh Báo");
                    }
                }
                catch
                {
                    MessageBox.Show("Lưu Thất Bại", "Cảnh Báo");
                }
            }
            else
                MessageBox.Show("Chưa nhập số phiếu", "Cảnh Báo");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}