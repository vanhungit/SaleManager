using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace SalesManager
{
    public partial class frmNhapHang : DevExpress.XtraEditors.XtraForm
    {
        static string chuoi = "";
        #region Biến Cờ
        int FlagNhap = 0;
        int FlagTH = 0;
        int FlagCT = 0;
        #endregion
        #region Biến Time
        /// <summary>
        /// Bảng Kê Chi Tiết
        /// </summary>
        static string DateTimeChon_CT = "Hôm nay";
        static DateTime DatetimeFrom_CT = DateTime.Now;
        static DateTime DatetimeTo_CT = DateTime.Now;
        /// <summary>
        /// Bảng Kê Tổng Hợp
        /// </summary>
        static string DateTimeChon_TH = "Hôm nay";
        static DateTime DatetimeFrom_TH = DateTime.Now;
        static DateTime DatetimeTo_TH = DateTime.Now;
        #endregion
        #region Table3
        static DataTable Table_THNH = new DataTable();
        static DataTable Table_CTNH = new DataTable();
        #endregion
        UC_PhieuNhapHang frmNH;
        UC_BangKeTongHopNH frmTH;
        UC_BangKeChiTietNH frmCT;
        public frmNhapHang()
        {
            InitializeComponent();
            DateTimeChon_CT = "Hôm nay";
            DateTimeChon_TH = "Hôm nay";
            DatetimeFrom_CT = DateTime.Now;
            DatetimeTo_CT = DateTime.Now;
            DatetimeFrom_TH = DateTime.Now;
            DatetimeTo_TH = DateTime.Now;
            Table_THNH.Reset();
            Table_CTNH.Reset();
            if (FlagTH == 1)
            {
                Table_THNH = frmTH.GridControlTable();
                DateTimeChon_TH = frmTH.DateTimeChon();
                DatetimeTo_TH = frmTH.DateTimeFrom();
                DatetimeFrom_TH = frmTH.DateTimeTo();
            }
            if (FlagCT == 1)
            {
                Table_CTNH = frmCT.GridControlTable();
                DateTimeChon_CT = frmCT.DateTimeChon();
                DatetimeTo_CT = frmCT.DateTimeFrom();
                DatetimeFrom_CT = frmCT.DateTimeTo();
            }

            groupControl1.ResetText();
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_PhieuNhapHang();
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
            FlagNhap = 1;
        }
        public void resetdata(string _data)
        {
            groupControl1.ResetText();
            groupControl1.Controls.Clear();
            chuoi = _data;
        }
        public void resetdataTH(string _data, DateTime _DateTimeFrom, DateTime _DateTimeTo, DataTable _table)
        {
            groupControl1.ResetText();
            groupControl1.Controls.Clear();
            DateTimeChon_TH = _data;
            DatetimeFrom_TH = _DateTimeFrom;
            DatetimeTo_TH = _DateTimeTo;
            Table_THNH = _table;
        }
        public void resetdataCT(string _data, DateTime _DateTimeFrom, DateTime _DateTimeTo, DataTable _table)
        {
            groupControl1.ResetText();
            groupControl1.Controls.Clear();
            DateTimeChon_CT = _data;
            DatetimeFrom_CT = _DateTimeFrom;
            DatetimeTo_CT = _DateTimeTo;
            Table_CTNH = _table;
        }
        public void SuaChuaPhieuBanHang(string _data)
        {
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_PhieuNhapHang(this, _data);
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
            navBarGroup3.Visible = true;
        }
        public void ThemPhieuBanHang()
        {
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_PhieuNhapHang();
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
            navBarGroup3.Visible = true;
        }
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navBarGroup3.Visible = false;
            if (FlagCT == 1)
            {
                Table_CTNH = frmCT.GridControlTable();
                DateTimeChon_CT = frmCT.DateTimeChon();
                DatetimeTo_CT = frmCT.DateTimeFrom();
                DatetimeFrom_CT = frmCT.DateTimeTo();
            }
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Tổng Hợp";
            groupControl1.Controls.Clear();
            frmTH = new UC_BangKeTongHopNH(this, DateTimeChon_TH, DatetimeFrom_TH, DatetimeTo_TH, Table_THNH);
            frmTH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmTH);//thêm user control vào panel
            FlagTH = 1;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navBarGroup3.Visible = true;
            if (FlagTH == 1)
            {
                Table_THNH = frmTH.GridControlTable();
                DateTimeChon_TH = frmTH.DateTimeChon();
                DatetimeTo_TH = frmTH.DateTimeFrom();
                DatetimeFrom_TH = frmTH.DateTimeTo();
            }
            if (FlagCT == 1)
            {
                Table_CTNH = frmCT.GridControlTable();
                DateTimeChon_CT = frmCT.DateTimeChon();
                DatetimeTo_CT = frmCT.DateTimeFrom();
                DatetimeFrom_CT = frmCT.DateTimeTo();
            }
             
            groupControl1.ResetText();
            groupControl1.Text = "Phiếu Nhập Hàng";
            groupControl1.Controls.Clear();
            frmNH = new UC_PhieuNhapHang();
            frmNH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmNH);//thêm user control vào panel
            FlagNhap = 1;

        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (FlagTH == 1)
            {
                Table_THNH = frmTH.GridControlTable();
                DateTimeChon_TH = frmTH.DateTimeChon();
                DatetimeTo_TH = frmTH.DateTimeFrom();
                DatetimeFrom_TH = frmTH.DateTimeTo();
            }
            groupControl1.ResetText();
            groupControl1.Text = "Bảng Kê Chi Tiết";
            groupControl1.Controls.Clear();
            frmCT = new UC_BangKeChiTietNH(this, DateTimeChon_CT, DatetimeFrom_CT, DatetimeTo_CT, Table_CTNH);
            frmCT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmCT);//thêm user control vào panel
            FlagCT = 1;
            
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmThemHangHoa_DichVu frm = new frmThemHangHoa_DichVu();
            frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmThemKhachHang frm = new frmThemKhachHang();
            frm.ShowDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmThemKhoHang frm = new frmThemKhoHang();
            frm.ShowDialog();
        }

    }
}