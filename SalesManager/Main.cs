using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Xml;
using System.IO;
using QuanLiBanHang.Entity;
using QuanLiBanHang.Controller;
using DevExpress.XtraEditors;

namespace SalesManager
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static DataTable DataKhuVuc_Save;
        static DataTable DataNhaPhanPhoi_Save;
        static DataTable DataNhaPhanPhoi_Save_look;
        SYS_LOG _sys_log = new SYS_LOG();
        public Main()
        {
            InitializeComponent();
            ReadXml();
            ReadXml_User();
            barStaticItem2.Caption = String.Format("{0:HH:mm:ss}", DateTime.Now);
            barStaticItem3.Caption = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            barStaticServer.Caption = System.Environment.MachineName;
            LoadForm(new frmWebsite());
        }
        public void LoadKhuVuc(DataTable _table)
        {
            DataKhuVuc_Save = _table;
        }
        public void LoadNhaPhanPhoi(DataTable _table_look, DataTable _table)
        {
            DataNhaPhanPhoi_Save = _table;
            DataNhaPhanPhoi_Save_look = _table_look;
        }
        #region ReadXML
        public void ReadXml()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("Config_Data.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("ConfigCSDL");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "1")
                {
                    barStaticServer.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    barStaticServer.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #endregion
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
                    barStaticItem1.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #region LoadForm function
        private void LoadForm(Form frmIsLoaded)
        {
            bool isLoaded = false;
            foreach (Form child in MdiChildren)
            {
                if (child.Text == frmIsLoaded.Text)
                {
                    isLoaded = true;
                    frmIsLoaded = child;
                    break;
                }
            }

            if (!isLoaded)
            {
                frmIsLoaded.MdiParent = this;
                frmIsLoaded.Show();
            }
            else
            {
                frmIsLoaded.Activate();
            }
        }
        #endregion
         
       
        private void barListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            bg_lookandfeel.LookAndFeel.SkinName = bar_lookandfeel.Strings[bar_lookandfeel.ItemIndex].ToString();
        }

        private void bar_khuvuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmKhuVuc(this,DataKhuVuc_Save));
        }

        private void bar_Thongtin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTin frm = new frmThongTin();
            frm.ShowDialog();
        }

        private void bar_Dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            Close();
            System.Diagnostics.Process.Start(@"D:\Database\SalesManager\SalesManager\bin\Debug\SalesManager.exe");

        }

        private void bar_Ketthuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Kết Thúc";
            _sys_log.Description = "Kết Thúc Hệ Thống";
            _sys_log.Module = "Hệ Thống";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            TimerStatus.Enabled = false;
            Close();
            //Application.Exit();
            //DialogResult ok;
            //ok = XtraMessageBox.Show("Bạn Có Muốn Thoát Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (ok == DialogResult.No)
            //{
            //    Close();
            //}
        }

        private void bar_khachang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Khách Hàng";
            _sys_log.Module = "Quản Lý Khách Hàng";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frm_KhachHang());
        }

        private void bar_nhaphanphoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Nhà Phân Phối";
            _sys_log.Module = "Quản Lý Nhà Phân Phối";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmNhaPhanPhoi(this,DataNhaPhanPhoi_Save_look,DataNhaPhanPhoi_Save));
        }

        private void bar_muahang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Tạo";
            _sys_log.Description = "Tạo Nhập Hàng";
            _sys_log.Module = "Nhập Hàng";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmNhapHang());
        }

        private void bar_kho_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Kho Hàng";
            _sys_log.Module = "Quản Lý Kho Hàng";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmKhoHang());
        }

        private void bar_donvi_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Đơn Vị";
            _sys_log.Module = "Quản Lý Đơn Vị";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmDonVi());
        }

        private void bar_nhomhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Nhóm Hàng";
            _sys_log.Module = "Quản Lý Nhóm Hàng";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmNhomHang());
        }

        private void bar_hanghoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Hàng Hóa";
            _sys_log.Module = "Quản Lý Hàng Hóa";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmHangHoa());
        }

        private void bar_tygia_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Tỷ Giá";
            _sys_log.Module = "Tỷ Giá";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmTyGia());
        }

        private void bar_bophan_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Bộ Phận";
            _sys_log.Module = "Quản Lý Bộ Phận";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmBoPhan());
        }

        private void bar_nhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Xem";
            _sys_log.Description = "Xem Quản Lý Nhân Viên";
            _sys_log.Module = "Quản Lý Nhân Viên";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmNhanVien());
        }

        private void bar_banhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Phiếu xuất hàng");
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Tạo";
            _sys_log.Description = "Tạo Bán Hàng";
            _sys_log.Module = "Bán Hàng";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmBanHang());
            WaitDialog.CloseWaitDialog();

        }

        private void bar_chuyenkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Tạo";
            _sys_log.Description = "Tạo Chuyển Kho";
            _sys_log.Module = "Chuyển Kho";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            LoadForm(new frmChuyenKho());
        }

        private void bar_tonkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmTonKho());
        }

        private void bar_tonghop_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmTongHop());
        }

        private void bar_tratien_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmPhieuChi());
        }

        private void bar_thutien_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmPhieuThu());
        }

        private void bar_quanlichungtu_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmQuanLyChungTu());

        }

        private void bar_tonghoptonkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmTHTonKho());

        }

        private void bar_baocao_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmBaoCaoBanHang());
        }

        private void bar_lichsuhanghoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmLichSuHangHoa());

        }

        private void bar_nhatki_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmNhatKyNguoiDung());
        }

        private void bar_vaitro_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmPhanQuyen());

        }

        private void bar_doimatkhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThayDoiMatKhau frm = new frmThayDoiMatKhau();
            frm.ShowDialog();
        }

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            barStaticItem2.Caption = String.Format("{0:HH:mm:ss}", DateTime.Now);

        }

      
        private void bar_saoluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            frmSaoLuu frm = new frmSaoLuu();
            frm.ShowDialog();
        }

        private void bar_hansudung_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmHanSuDung());
        }

        private void bar_nhapsodudauky_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmSoDuDauKy());
        }

        private void bbiAdjustment_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmKiemKe());
        }

        private void bbiMobilecomputer_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmCaiDatMobility());
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmNhapXuatHangHoa());
        }

        private void bbiRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhuchoi frm = new frmPhuchoi();
            frm.ShowDialog();
        }

        private void bbipromotion_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmKhuyenMai());
        }

        private void bbiPrintBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmMaVach());
        }

        private void bbiPrinter_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmCaiDatMayIn());

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmPhanTichLoiNhuan());

        }

        private void bar_exel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhapDuLieu frm = new frmNhapDuLieu();
            frm.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sys_log.MChine = new MobilityNetwork().GetComputerName();
            _sys_log.IP = new MobilityNetwork().GetIP();
            _sys_log.UserID = "US000001";
            _sys_log.Created = DateTime.Now;
            _sys_log.Action_Name = "Kết Thúc";
            _sys_log.Description = "Kết Thúc Hệ Thống";
            _sys_log.Module = "Hệ Thống";
            _sys_log.Active = true;
            SYS_LOGController insertlog = new SYS_LOGController();
            insertlog.SYS_LOG_Insert(_sys_log);
            TimerStatus.Enabled = false;
            DialogResult ok;
            ok = XtraMessageBox.Show("Bạn Có Muốn Thoát Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //System.Diagnostics.Process.Start(@"D:\Softs\TeamViewer_Setup.exe");
            //System.Diagnostics.Process.Start(@"D:\BarcodeKeyRecv.exe");
        }

        private void bbiUser_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiDongKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDongKy());
        }

        private void bbiListPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmBangGia());
        }

        private void bbiNganhHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmNganhHang());
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmGiaoHang());
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmDonMuaHang());
        }

        private void nbiCTMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmChungTuNhapKho());
        }

        private void nbiDonHangBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmDonHangBan());
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmChungTuXuatKho());
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmKhachTraHang());
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmTraHangNCC());
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmBaoGiaKhachHang());
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmPhieuYeuCauKho());
        }

        private void nbiLocation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmVitriKho());
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmLenhSanXuat());
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmLapRapThaoDo());
        }

        private void nbiTransaction_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadForm(new frmTransaction_Kho());
        }

    }
}