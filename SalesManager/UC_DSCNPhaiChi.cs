using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using QuanLiBanHang.Controller;
using QuanLiBanHang.Entity;
using System.Data.SqlClient;
using MicrosoftHelper;
namespace SalesManager
{
    public partial class UC_DSCNPhaiChi : UserControl
    {
        public UC_DSCNPhaiChi()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
            //gridControl1.DataSource = new STOCK_INWARDController().sp_DEBT_GetInfoForProvider();
            SqlDataAdapter AdapterStockInward = new SqlDataAdapter("SELECT	d.RefID AS ChungTu,p.Customer_ID, p.CustomerName, d.RefDate AS Ngay,	dbo.CallExpire(d.RefDate,GETDATE()) AS TuoiNo,	d.Amount AS SoTien, d.Payment AS DaTra,	d.Balance ConLai, d.[Description] AS DienDai FROM DEBT d INNER JOIN PROVIDER p ON d.CustomerID = p.Customer_ID	WHERE d.CustomerID IN (SELECT p.Customer_ID FROM PROVIDER p) AND d.Balance<>0 and DATEDIFF(day,'" + dateTu.DateTime + "' ,d.RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',d.RefDate)<=0 ORDER BY p.CustomerName", DataProvider.ConnectionString);
            SqlDataAdapter AdapterStockInwardDetail = new SqlDataAdapter("select e.ChungTu ,S.Product_ID,S.ProductName,S.Unit,S.Quantity,S.UnitPrice,S.Amount from (SELECT d.RefID AS ChungTu, p.CustomerName, d.RefDate AS Ngay FROM DEBT d INNER JOIN PROVIDER p ON d.CustomerID = p.Customer_ID	WHERE d.CustomerID IN (SELECT p.Customer_ID FROM PROVIDER p) and DATEDIFF(day,'" + dateTu.DateTime + "' ,d.RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',d.RefDate)<=0 AND d.Balance<>0 ) e, STOCK_INWARD_DETAIL S	where e.ChungTu = S.Inward_ID", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterStockInward.Fill(dataSet11, "STOCK_INWARD");
            AdapterStockInwardDetail.Fill(dataSet11, "STOCK_INWARD_DETAIL");
            DataColumn keyColumn = dataSet11.Tables["STOCK_INWARD"].Columns["ChungTu"];
            DataColumn foreignKeyColumn = dataSet11.Tables["STOCK_INWARD_DETAIL"].Columns["ChungTu"];
            dataSet11.Relations.Add("Test", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["STOCK_INWARD"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Test", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["STOCK_INWARD_DETAIL"]);
            gridView2.Columns["ChungTu"].VisibleIndex = -1;
            gridView2.Columns["ChungTu"].Caption = "Chứng Từ";
            gridView2.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView2.Columns["ProductName"].Caption = "Tên Hàng";
            gridView2.Columns["Unit"].Caption = "DVT";
            gridView2.Columns["Quantity"].Caption = "Số Lượng";
            gridView2.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView2.Columns["Amount"].Caption = "Thành Tiền";
            gridView2.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["Amount"].DisplayFormat.FormatString = "n0";
            gridView2.OptionsView.ShowFooter = true;
            gridView2.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Amount"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", gridView2.Columns["Amount"]);
        }

        private void cbochon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThoiGianController thoigian = new ThoiGianController();
            string format = "M/d/yyyy";
            switch (cbochon.Text)
            {
                case "Hôm nay":
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    dateTu.DateTime = DateTime.ParseExact(DateTime.Now.Month + "/" + thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year) + "/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact(DateTime.Now.Month + "/" + thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    //dateDen.DateTime = DateTime.ParseExact("01" + "/" + "01" + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Quý này":
                    dateTu.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 1":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 2":
                    dateTu.DateTime = DateTime.ParseExact("02/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 3":
                    dateTu.DateTime = DateTime.ParseExact("03/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 4":
                    dateTu.DateTime = DateTime.ParseExact("04/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 5":
                    dateTu.DateTime = DateTime.ParseExact("05/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 6":
                    dateTu.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    dateTu.DateTime = DateTime.ParseExact("07/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 8":
                    dateTu.DateTime = DateTime.ParseExact("08/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 9":
                    dateTu.DateTime = DateTime.ParseExact("09/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 10":
                    dateTu.DateTime = DateTime.ParseExact("10/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 11":
                    dateTu.DateTime = DateTime.ParseExact("11/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 12":
                    dateTu.DateTime = DateTime.ParseExact("12/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlDataAdapter AdapterStockInward = new SqlDataAdapter("SELECT	d.RefID AS ChungTu,p.Customer_ID, p.CustomerName, d.RefDate AS Ngay,	dbo.CallExpire(d.RefDate,GETDATE()) AS TuoiNo,	d.Amount AS SoTien, d.Payment AS DaTra,	d.Balance ConLai, d.[Description] AS DienDai FROM DEBT d INNER JOIN PROVIDER p ON d.CustomerID = p.Customer_ID	WHERE d.CustomerID IN (SELECT p.Customer_ID FROM PROVIDER p) AND d.Balance<>0 and DATEDIFF(day,'" + dateTu.DateTime + "' ,d.RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',d.RefDate)<=0 ORDER BY p.CustomerName", DataProvider.ConnectionString);
            SqlDataAdapter AdapterStockInwardDetail = new SqlDataAdapter("select e.ChungTu ,S.Product_ID,S.ProductName,S.Unit,S.Quantity,S.UnitPrice,S.Amount from (SELECT d.RefID AS ChungTu, p.CustomerName, d.RefDate AS Ngay FROM DEBT d INNER JOIN PROVIDER p ON d.CustomerID = p.Customer_ID	WHERE d.CustomerID IN (SELECT p.Customer_ID FROM PROVIDER p) and DATEDIFF(day,'" + dateTu.DateTime + "' ,d.RefDate)>=0 and DATEDIFF(day,'" + dateDen.DateTime + "',d.RefDate)<=0 AND d.Balance<>0 ) e, STOCK_INWARD_DETAIL S	where e.ChungTu = S.Inward_ID", DataProvider.ConnectionString);
            DataSet dataSet11 = new DataSet();
            AdapterStockInward.Fill(dataSet11, "STOCK_INWARD");
            AdapterStockInwardDetail.Fill(dataSet11, "STOCK_INWARD_DETAIL");
            DataColumn keyColumn = dataSet11.Tables["STOCK_INWARD"].Columns["ChungTu"];
            DataColumn foreignKeyColumn = dataSet11.Tables["STOCK_INWARD_DETAIL"].Columns["ChungTu"];
            dataSet11.Relations.Add("Test", keyColumn, foreignKeyColumn);
            gridControl1.DataSource = dataSet11.Tables["STOCK_INWARD"];
            gridControl1.ForceInitialize();
            gridControl1.LevelTree.Nodes.Add("Test", gridView2);
            gridView2.PopulateColumns(dataSet11.Tables["STOCK_INWARD_DETAIL"]);
            gridView2.Columns["ChungTu"].VisibleIndex = -1;
            gridView2.Columns["ChungTu"].VisibleIndex = -1;
            gridView2.Columns["ChungTu"].Caption = "Chứng Từ";
            gridView2.Columns["Product_ID"].Caption = "Mã Hàng";
            gridView2.Columns["ProductName"].Caption = "Tên Hàng";
            gridView2.Columns["Unit"].Caption = "DVT";
            gridView2.Columns["Quantity"].Caption = "Số Lượng";
            gridView2.Columns["UnitPrice"].Caption = "Đơn Giá";
            gridView2.Columns["Amount"].Caption = "Thành Tiền";
            gridView2.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns["Amount"].DisplayFormat.FormatString = "n0";
            gridView2.OptionsView.ShowFooter = true;
            gridView2.Columns["Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns["Amount"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView2.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount", gridView2.Columns["Amount"]);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                frmLapPhieuChi frm = new frmLapPhieuChi(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString(), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString(), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString(), DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));
                frm.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                frmLapPhieuChi frm = new frmLapPhieuChi(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString(), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString(), gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString(), DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString()), double.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString()));
                frm.ShowDialog();
            }
        }
    }
}
