using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanHang.Controller;
using SalesManager.Controller;
using QuanLiBanHang.Entity;
using System.Xml;
using System.IO;
namespace SalesManager
{
    public partial class UC_BangKeTheoHangHoa : UserControl
    {
        frmSoDuDauKy frmsodudauky;
        SYS_LOG _sys_log = new SYS_LOG();
        SYS_USER objuser = new SYS_USER();
        public UC_BangKeTheoHangHoa(frmSoDuDauKy _frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
            gridControl1.DataSource = new KYKHOController().sp_HangHoaDauKy(dateTu.DateTime, dateDen.DateTime);
            frmsodudauky = _frm;
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
        private void cbochon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThoiGianController thoigian = new ThoiGianController();
            switch (cbochon.Text)
            {
                case "Hôm nay":
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    dateTu.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    dateDen.DateTime = DateTime.Parse(DateTime.Now.Month + "/" + thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Quý này":
                    dateTu.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    dateTu.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 1":
                    dateTu.DateTime = DateTime.Parse("01/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 2":
                    dateTu.DateTime = DateTime.Parse("02/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 3":
                    dateTu.DateTime = DateTime.Parse("03/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 4":
                    dateTu.DateTime = DateTime.Parse("04/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 5":
                    dateTu.DateTime = DateTime.Parse("05/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 6":
                    dateTu.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    dateTu.DateTime = DateTime.Parse("07/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 8":
                    dateTu.DateTime = DateTime.Parse("08/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 9":
                    dateTu.DateTime = DateTime.Parse("09/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 10":
                    dateTu.DateTime = DateTime.Parse("10/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 11":
                    dateTu.DateTime = DateTime.Parse("11/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 12":
                    dateTu.DateTime = DateTime.Parse("12/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Quý 1":
                    dateTu.DateTime = thoigian.StartDayofQui(1, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(1, DateTime.Now.Year);
                    break;
                case "Quý 2":
                    dateTu.DateTime = thoigian.StartDayofQui(2, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(2, DateTime.Now.Year);
                    break;
                case "Quý 3":
                    dateTu.DateTime = thoigian.StartDayofQui(3, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(3, DateTime.Now.Year);
                    break;
                case "Quý 4":
                    dateTu.DateTime = thoigian.StartDayofQui(4, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(4, DateTime.Now.Year);
                    break;
                default:
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new KYKHOController().sp_HangHoaDauKy(dateTu.DateTime, dateDen.DateTime);

        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmsodudauky.TaoMoiPhieuNhapDK();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                _sys_log.MChine = new MobilityNetwork().GetComputerName();
                _sys_log.IP = new MobilityNetwork().GetIP();
                _sys_log.UserID = objuser.UserID;
                _sys_log.Created = DateTime.Now;
                _sys_log.Action_Name = "Cập Nhật";
                _sys_log.Description = "Cập Nhật Bảng Kê Phiếu Nhập ĐK" + "-" + ID;
                _sys_log.Reference = ID;
                _sys_log.Module = "Bảng Kê Phiếu Nhập ĐK";
                _sys_log.Active = true;
                SYS_LOGController insertlog = new SYS_LOGController();
                insertlog.SYS_LOG_Insert(_sys_log);
                frmsodudauky.SuaChuaPhieuNhapDK(ID);
            }
        }
    }
}
