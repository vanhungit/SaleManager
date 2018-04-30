using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class INVENTORYController
    {
        private List<INVENTORY> MapINVENTORY(DataTable dt)
        {
            List<INVENTORY> rs = new List<INVENTORY>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                INVENTORY obj = new INVENTORY();
                if (dt.Columns.Contains("ID"))
                    obj.ID = long.Parse(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("Limit"))
                    obj.Limit = DateTime.Parse(dt.Rows[i]["Limit"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("ChassyNo"))
                    obj.ChassyNo = dt.Rows[i]["ChassyNo"].ToString();
                if (dt.Columns.Contains("Color"))
                    obj.Color = dt.Rows[i]["Color"].ToString();
                if (dt.Columns.Contains("Location"))
                    obj.Location = dt.Rows[i]["Location"].ToString();
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Orgin"))
                    obj.Orgin = dt.Rows[i]["Orgin"].ToString();
                if (dt.Columns.Contains("Size"))
                    obj.Size = dt.Rows[i]["Size"].ToString();
                if (dt.Columns.Contains("Descritopn"))
                    obj.Descritopn = dt.Rows[i]["Descritopn"].ToString();
                rs.Add(obj);
            }
            return rs;
        }
        public int ThemINVENTORY(INVENTORY obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_Insert",
                    obj.ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefType,
                    obj.Stock_ID,
                    obj.Product_ID,
                    obj.Customer_ID,
                    obj.Currency_ID,
                    obj.Limit,
                    obj.Quantity,
                    obj.Amount,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.Color,
                    obj.Location,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.Descritopn
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int XoaINVENTORY(string INVENTORY_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_Delete", INVENTORY_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetAllStock(string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetAllStock", Product_ID, Product_Name);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_Get_ByDate(string StockID, string Product_Id, string Product_Name, DateTime DenNgay)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_Get_ByDate", StockID,  Product_Id,  Product_Name,  DenNgay);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_Get_ByDAY(string StockID, string Product_Id, string Product_Name, DateTime DenNgay)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_Get_ByDAY", StockID, Product_Id, Product_Name, DenNgay);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetFull(string StockID, string Product_Id, string Product_Name, int Zero)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetFull", StockID, Product_Id, Product_Name, Zero);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetList_Adjustment(string Product_ID, string ProductName, string Stock_ID, DateTime Date)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetList_Adjustment", Product_ID, ProductName, Stock_ID, Date);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetList_Init(string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetList_Init", Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public INVENTORY INVENTORY_GetQuantityStock(string Stock_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetQuantityStock", Stock_ID,Product_ID);
                return MapINVENTORY(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetStore_ExpireDay(string Stock_ID, string Product_ID, string Product_Name,int Zero)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetStore_ExpireDay", Stock_ID,  Product_ID,  Product_Name, Zero);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetStore_ExpireDay_Info(string Stock_ID, string Product_ID, string Product_Name, int Zero)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetStore_ExpireDay_Info", Stock_ID, Product_ID, Product_Name, Zero);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_GetStore_SumQuanlity(string Stock_ID, string Product_ID, string Product_Name, int Zero)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_GetStore_SumQuanlity", Stock_ID, Product_ID, Product_Name, Zero);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_ORDER(string Stock_ID, string Product_ID, string Product_Name, double Type)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_ORDER", Stock_ID, Product_ID, Product_Name, Type);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_Order_Warning(string Stock_ID, string Product_ID, string Product_Name, double Type)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_Order_Warning", Stock_ID, Product_ID, Product_Name, Type);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_Search_Stock(string Product_ID, string Product_Name, string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_Search_Stock", Product_ID, Product_Name, Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_SUMMARY(string Stock_ID, string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_SUMMARY",  Stock_ID,Product_ID, Product_Name);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_SUMMARY_BELOWER_REPORT(string Stock_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_SUMMARY_BELOWER_REPORT", Stock_ID, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_SUMMARY_DATE(DateTime FromDate,DateTime ToDate, string Stock_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_SUMMARY_DATE",FromDate,ToDate, Stock_ID, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_SUMMARY_OVER_REPORT(string Stock_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_SUMMARY_OVER_REPORT", Stock_ID, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_Summary_Revenue(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_Summary_Revenue", FromDate, ToDate);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVENTORY_SUMMARYREPORT(string Stock_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_SUMMARYREPORT", Stock_ID, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int INVENTORY_Update(INVENTORY obj,long ID )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVENTORY_Insert",
                    ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefType,
                    obj.Stock_ID,
                    obj.Product_ID,
                    obj.Customer_ID,
                    obj.Currency_ID,
                    obj.Limit,
                    obj.Quantity,
                    obj.Amount,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.Color,
                    obj.Location,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.Descritopn
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public DataTable INVENTORY_WARNING(DateTime FromDate,DateTime ToDate, string Stock_ID, string Product_ID, string Product_Name)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVENTORY_WARNING",FromDate,ToDate, Stock_ID, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_PRODUCT_GetByStore_Group()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_PRODUCT_GetByStore_Group");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
