using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MicrosoftHelper;
using SalesManager.Controller;

namespace SalesManager
{
    public partial class UC_BaoCaoMuaHangTheoNCC : UserControl
    {
        public UC_BaoCaoMuaHangTheoNCC()
        {
            InitializeComponent();
            cbochon.Text = "Hôm nay";
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridView2.Invalidate();
            gridView2.IndicatorWidth = 35;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
            SqlDataAdapter AdapterStockInward = new SqlDataAdapter("select Customer_ID,CustomerName,sum(d.DetailDT) as DoanhThu from (select Inward_ID,	Sum(Amount) as DetailDT from STOCK_INWARD_DETAIL group by Inward_ID) d , STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by Customer_ID,CustomerName", DataProvider.ConnectionString);
            SqlDataAdapter AdapterStockInwardDetail = new SqlDataAdapter("select Customer_ID,ID,RefDate,d.ThanhTien from (select Inward_ID,Sum(Amount) as ThanhTien from STOCK_INWARD_DETAIL group by Inward_ID) d, STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 ", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterStockInward.Fill(dataSet11, "STOCK_INWARD");
            AdapterStockInwardDetail.Fill(dataSet11, "STOCK_INWARD_DETAIL");
            DataColumn keyColumn = dataSet11.Tables["STOCK_INWARD"].Columns["Customer_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["STOCK_INWARD_DETAIL"].Columns["Customer_ID"];
            dataSet11.Relations.Add("Danh Sách Chứng Từ", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["STOCK_INWARD"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Danh Sách Chứng Từ", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["STOCK_INWARD_DETAIL"]);
            gridView2.Columns["Customer_ID"].VisibleIndex = -1;
            gridView2.Columns["ID"].Caption = "Chứng Từ";
            gridView2.Columns["RefDate"].Caption = "Ngày";
            gridView2.Columns["ThanhTien"].Caption = "Thành Tiền";
            gridView2.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["ThanhTien"].DisplayFormat.FormatString = "n0";
            gridView2.OptionsView.ShowFooter = true;
            gridView2.Columns["ThanhTien"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["ThanhTien"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", gridView2.Columns["ThanhTien"]);
        }

        private void cbochon_SelectedValueChanged(object sender, EventArgs e)
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
            SqlDataAdapter AdapterStockInward = new SqlDataAdapter("select Customer_ID,CustomerName,sum(d.DetailDT) as DoanhThu from (select Inward_ID,	Sum(Amount) as DetailDT from STOCK_INWARD_DETAIL group by Inward_ID) d , STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',RefDate)<=0 group by Customer_ID,CustomerName", DataProvider.ConnectionString);
            SqlDataAdapter AdapterStockInwardDetail = new SqlDataAdapter("select Customer_ID,ID,RefDate,d.ThanhTien from (select Inward_ID,Sum(Amount) as ThanhTien from STOCK_INWARD_DETAIL group by Inward_ID) d, STOCK_INWARD s where d.Inward_ID = s.ID and DATEDIFF(day,'" + dateTu.DateTime + "' ,RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "' ,RefDate)<=0 ", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterStockInward.Fill(dataSet11, "STOCK_INWARD");
            AdapterStockInwardDetail.Fill(dataSet11, "STOCK_INWARD_DETAIL");
            DataColumn keyColumn = dataSet11.Tables["STOCK_INWARD"].Columns["Customer_ID"];
            DataColumn foreignKeyColumn = dataSet11.Tables["STOCK_INWARD_DETAIL"].Columns["Customer_ID"];
            dataSet11.Relations.Add("Danh Sách Chứng Từ", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["STOCK_INWARD"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Danh Sách Chứng Từ", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["STOCK_INWARD_DETAIL"]);
            gridView2.Columns["Customer_ID"].VisibleIndex = -1;
            gridView2.Columns["ID"].Caption = "Chứng Từ";
            gridView2.Columns["RefDate"].Caption = "Ngày";
            gridView2.Columns["ThanhTien"].Caption = "Thành Tiền";
            gridView2.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["ThanhTien"].DisplayFormat.FormatString = "n0";
            gridView2.OptionsView.ShowFooter = true;
            gridView2.Columns["ThanhTien"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["ThanhTien"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", gridView2.Columns["ThanhTien"]);

        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
