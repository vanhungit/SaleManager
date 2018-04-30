using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MicrosoftHelper;
using SalesManager.Controller;
using System.Data.SqlClient;
namespace SalesManager
{
    public partial class UC_BaoCaoBanHangNV : UserControl
    {
        public UC_BaoCaoBanHangNV()
        {
            InitializeComponent();
            cbochon.Text = "Hôm nay";
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridView2.Invalidate();
            gridView2.IndicatorWidth = 35;
            gridView3.Invalidate();
            gridView3.IndicatorWidth = 35;
            SqlDataAdapter AdapterMaster = new SqlDataAdapter("select e.User_ID,u.Description,f.MuaHang,e.BanHang from(select s.User_ID,sum(d.DetailDT) as BanHang from (select Outward_ID, Sum(Amount) as DetailDT from STOCK_OUTWARD_DETAIL group by Outward_ID) d , STOCK_OUTWARD s where d.Outward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by s.User_ID) e, SYS_USER u,(select s.User_ID,sum(d.DetailDT) as MuaHang from (select Inward_ID, Sum(Amount) as DetailDT from STOCK_INWARD_DETAIL group by Inward_ID) d , STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by s.User_ID) f where e.User_ID = u.UserID and f.User_ID = u.UserID", DataProvider.ConnectionString);
            SqlDataAdapter AdapterMuaHang = new SqlDataAdapter("select s.User_ID,s.ID,s.RefDate,Product_ID,ProductName,Unit,sd.Stock_ID,Quantity,UnitPrice,sd.Amount as MuaHang from STOCK_INWARD s, STOCK_INWARD_DETAIL sd where DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 and sd.Inward_ID = s.ID", DataProvider.ConnectionString);
            SqlDataAdapter AdapterBanHang = new SqlDataAdapter("select s.User_ID,s.ID,s.RefDate,Product_ID,ProductName,Unit,sd.Stock_ID,Quantity,UnitPrice,s.Amount,sd.DiscountRate,sd.Discount,sd.Amount as BanHang from STOCK_OUTWARD s, STOCK_OUTWARD_DETAIL sd where DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 and sd.Outward_ID = s.ID", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterMaster.Fill(dataSet11, "MASTER");
            AdapterMuaHang.Fill(dataSet11, "MUAHANG");
            AdapterBanHang.Fill(dataSet11, "BANHANG");
            DataColumn keyColumn = dataSet11.Tables["MASTER"].Columns["User_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["MUAHANG"].Columns["User_ID"];
            DataColumn foreignKeyColumn_1 = dataSet11.Tables["BANHANG"].Columns["User_ID"];
            dataSet11.Relations.Add("Doanh Thu Mua Hàng", keyColumn, foreignKeyColumn);
            dataSet11.Relations.Add("Doanh Thu Bán Hàng", keyColumn, foreignKeyColumn_1);
            gridControl1.DataSource = dataSet11.Tables["MASTER"];
            gridView1.Columns["MuaHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["MuaHang"].DisplayFormat.FormatString = "n0";
            gridView1.Columns["BanHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["BanHang"].DisplayFormat.FormatString = "n0";
            gridView1.Columns["MuaHang"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["MuaHang"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["BanHang"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["BanHang"].SummaryItem.DisplayFormat = "{0:n0}";
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Doanh Thu Mua Hàng", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["MUAHANG"]);
            gridView2.Columns["User_ID"].VisibleIndex = -1;
            gridControl1.LevelTree.Nodes.Add("Doanh Thu Bán Hàng", gridView3);
            gridView3.PopulateColumns(dataSet11.Tables["BANHANG"]);
            gridView3.Columns["User_ID"].VisibleIndex = -1;
            gridView2.Columns["ID"].Caption = "Chứng Từ";
            gridView2.Columns["RefDate"].Caption = "Ngày";
            gridView2.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView2.Columns["ProductName"].Caption = "Tên Hàng";
            gridView2.Columns["Unit"].Caption = "Đơn Vị";
            gridView2.Columns["Stock_ID"].Caption = "Kho Hàng";
            gridView2.Columns["Quantity"].Caption = "Số Lượng";
            gridView2.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView2.Columns["MuaHang"].Caption = "Thành Tiền";
            gridView2.Columns["MuaHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["MuaHang"].DisplayFormat.FormatString = "n0";
            gridView3.Columns["ID"].Caption = "Chứng Từ";
            gridView3.Columns["RefDate"].Caption = "Ngày";
            gridView3.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView3.Columns["ProductName"].Caption = "Tên Hàng";
            gridView3.Columns["Unit"].Caption = "Đơn Vị";
            gridView3.Columns["Stock_ID"].Caption = "Kho Hàng";
            gridView3.Columns["Quantity"].Caption = "Số Lượng";
            gridView3.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView3.Columns["Amount"].Caption = "Thành Tiền";
            gridView3.Columns["DiscountRate"].Caption = "Chiết Khấu(%)";
            gridView3.Columns["Discount"].Caption = "Chiết Khấu";
            gridView3.Columns["BanHang"].Caption = "Thành Toán";
            gridView3.Columns["BanHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView3.Columns["BanHang"].DisplayFormat.FormatString = "n0";


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
            SqlDataAdapter AdapterMaster = new SqlDataAdapter("select e.User_ID,u.Description,f.MuaHang,e.BanHang from(select s.User_ID,sum(d.DetailDT) as BanHang from (select Outward_ID, Sum(Amount) as DetailDT from STOCK_OUTWARD_DETAIL group by Outward_ID) d , STOCK_OUTWARD s where d.Outward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by s.User_ID) e, SYS_USER u,(select s.User_ID,sum(d.DetailDT) as MuaHang from (select Inward_ID, Sum(Amount) as DetailDT from STOCK_INWARD_DETAIL group by Inward_ID) d , STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by s.User_ID) f where e.User_ID = u.UserID and f.User_ID = u.UserID", DataProvider.ConnectionString);
            SqlDataAdapter AdapterMuaHang = new SqlDataAdapter("select s.User_ID,s.ID,s.RefDate,Product_ID,ProductName,Unit,sd.Stock_ID,Quantity,UnitPrice,sd.Amount as MuaHang from STOCK_INWARD s, STOCK_INWARD_DETAIL sd where DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 and sd.Inward_ID = s.ID", DataProvider.ConnectionString);
            SqlDataAdapter AdapterBanHang = new SqlDataAdapter("select s.User_ID,s.ID,s.RefDate,Product_ID,ProductName,Unit,sd.Stock_ID,Quantity,UnitPrice,s.Amount,sd.DiscountRate,sd.Discount,sd.Amount as BanHang from STOCK_OUTWARD s, STOCK_OUTWARD_DETAIL sd where DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 and sd.Outward_ID = s.ID", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterMaster.Fill(dataSet11, "MASTER");
            AdapterMuaHang.Fill(dataSet11, "MUAHANG");
            AdapterBanHang.Fill(dataSet11, "BANHANG");
            DataColumn keyColumn = dataSet11.Tables["MASTER"].Columns["User_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["MUAHANG"].Columns["User_ID"];
            DataColumn foreignKeyColumn_1 = dataSet11.Tables["BANHANG"].Columns["User_ID"];
            dataSet11.Relations.Add("Doanh Thu Mua Hàng", keyColumn, foreignKeyColumn);
            dataSet11.Relations.Add("Doanh Thu Bán Hàng", keyColumn, foreignKeyColumn_1);
            gridControl1.DataSource = dataSet11.Tables["MASTER"];
            gridView1.Columns["MuaHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["MuaHang"].DisplayFormat.FormatString = "n0";
            gridView1.Columns["BanHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["BanHang"].DisplayFormat.FormatString = "n0";
            gridView1.Columns["MuaHang"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["MuaHang"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["BanHang"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["BanHang"].SummaryItem.DisplayFormat = "{0:n0}";
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Doanh Thu Mua Hàng", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["MUAHANG"]);
            gridView2.Columns["User_ID"].VisibleIndex = -1;
            gridControl1.LevelTree.Nodes.Add("Doanh Thu Bán Hàng", gridView3);
            gridView3.PopulateColumns(dataSet11.Tables["BANHANG"]);
            gridView3.Columns["User_ID"].VisibleIndex = -1;
            gridView2.Columns["ID"].Caption = "Chứng Từ";
            gridView2.Columns["RefDate"].Caption = "Ngày";
            gridView2.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView2.Columns["ProductName"].Caption = "Tên Hàng";
            gridView2.Columns["Unit"].Caption = "Đơn Vị";
            gridView2.Columns["Stock_ID"].Caption = "Kho Hàng";
            gridView2.Columns["Quantity"].Caption = "Số Lượng";
            gridView2.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView2.Columns["MuaHang"].Caption = "Thành Tiền";
            gridView2.Columns["MuaHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["MuaHang"].DisplayFormat.FormatString = "n0";
            gridView3.Columns["ID"].Caption = "Chứng Từ";
            gridView3.Columns["RefDate"].Caption = "Ngày";
            gridView3.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView3.Columns["ProductName"].Caption = "Tên Hàng";
            gridView3.Columns["Unit"].Caption = "Đơn Vị";
            gridView3.Columns["Stock_ID"].Caption = "Kho Hàng";
            gridView3.Columns["Quantity"].Caption = "Số Lượng";
            gridView3.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView3.Columns["Amount"].Caption = "Thành Tiền";
            gridView3.Columns["DiscountRate"].Caption = "Chiết Khấu(%)";
            gridView3.Columns["Discount"].Caption = "Chiết Khấu";
            gridView3.Columns["BanHang"].Caption = "Thành Toán";
            gridView3.Columns["BanHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView3.Columns["BanHang"].DisplayFormat.FormatString = "n0";

 
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
    }
}
