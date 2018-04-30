using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_OUTWARD_DETAILController
    {
        private List<STOCK_OUTWARD_DETAIL> MapSTOCK_OUTWARD_DETAIL(DataTable dt)
        {
            List<STOCK_OUTWARD_DETAIL> rs = new List<STOCK_OUTWARD_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK_OUTWARD_DETAIL obj = new STOCK_OUTWARD_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Outward_ID"))
                    obj.Outward_ID = dt.Rows[i]["Outward_ID"].ToString();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("Vat"))
                    obj.Vat = int.Parse(dt.Rows[i]["Vat"].ToString());
                if (dt.Columns.Contains("VatAmount"))
                    obj.VatAmount = double.Parse(dt.Rows[i]["VatAmount"].ToString());
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert =double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("CurrentQty"))
                    obj.CurrentQty = double.Parse(dt.Rows[i]["CurrentQty"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("QtyConvert"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["QtyConvert"].ToString());
                if (dt.Columns.Contains("DiscountRate"))
                    obj.DiscountRate = double.Parse(dt.Rows[i]["DiscountRate"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("Charge"))
                    obj.Charge = double.Parse(dt.Rows[i]["Charge"].ToString());
                if (dt.Columns.Contains("Cost"))
                    obj.Cost = double.Parse(dt.Rows[i]["Cost"].ToString());
                if (dt.Columns.Contains("Profit"))
                    obj.Profit = double.Parse(dt.Rows[i]["Profit"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("ChassyNo"))
                    obj.ChassyNo = dt.Rows[i]["ChassyNo"].ToString();
                if (dt.Columns.Contains("IME"))
                    obj.IME = dt.Rows[i]["IME"].ToString();
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
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                //if (dt.Columns.Contains("Timestamp"))
                 //   obj.Timestamp = DateTime.Parse(dt.Rows[i]["Timestamp"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_OUTWARD_DETAIL_Insert(STOCK_OUTWARD_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DETAIL_Insert",
                    obj.ID,
                    obj.Outward_ID,
                    obj.Stock_ID,
                    obj.RefType,
                    obj.Product_ID,
                    obj.ProductName,
                    obj.Vat,
                    obj.VatAmount,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.CurrentQty,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.DiscountRate,
                    obj.Discount,
                    obj.Charge,
                    obj.Cost,
                    obj.Profit,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.IME,
                    obj.Location,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.StoreID,
                    obj.Description,
                    obj.Sorted,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_DETAIL_Insert_Packet(
                    string ID ,
                    string Outward_ID,
                    int RefType,
                    string Product_ID,
                    string ProductName,
                    DateTime Created,
                    string  Currency,
                    double Rate,
                    string Stock_ID,
                    int Vat,
                    double Quantity ,
                    double UnitPrice ,
                    double Amount ,
                    string Batch ,
                    string Unit ,
                    double UnitConvert ,
                    double Discount ,
                    double Charge ,
                    double Cost ,
                    double Profit ,
                    long StoreID ,    
                    bool Active ,
	                string Description 
        )
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DETAIL_Insert_Packet",
                    ID ,
                    Outward_ID,
                    RefType,
                    Product_ID,
                    ProductName,
                    Created,
                    Currency,
                    Rate,
                    Stock_ID,
                    Vat,
                    Quantity ,
                    UnitPrice ,
                    Amount ,
                    Batch ,
                    Unit ,
                    UnitConvert ,
                    Discount ,
                    Charge ,
                    Cost ,
                    Profit ,
                    StoreID ,    
                    Active ,
	                Description 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_ReportDate(DateTime FromDate, DateTime ToDate, string StockID, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_ReportDate", FromDate, ToDate, StockID, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_OUTWARD_DETAIL_Update(STOCK_OUTWARD_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DETAIL_Update",
                    obj.ID,
                    obj.Outward_ID,
                    obj.Stock_ID,
                    obj.RefType,
                    obj.Product_ID,
                    obj.ProductName,
                    obj.Vat,
                    obj.VatAmount,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.CurrentQty,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.DiscountRate,
                    obj.Discount,
                    obj.Charge,
                    obj.Cost,
                    obj.Profit,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.IME,
                    obj.Location,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.StoreID,
                    obj.Description,
                    obj.Sorted,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_DETAIL_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DETAIL_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_DETAIL_Outward_IDDelete(string Outward_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DETAIL_Outward_IDDelete", Outward_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public STOCK_OUTWARD_DETAIL STOCK_OUTWARD_DETAIL_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_Get", ID);
                return MapSTOCK_OUTWARD_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetForInvoice(string OutwardID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetForInvoice", OutwardID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_XuatHang(string OutwardID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_XuatHang", OutwardID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetList_ByDate", FromDate, ToDate,  MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetList_ByDate_Action(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetList_ByDate_Action", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetList_ByID(string Outward_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetList_ByID", Outward_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetListProductCustomer(DateTime FromDate, DateTime ToDate, string CustomerID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetListProductCustomer", FromDate, ToDate, CustomerID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_DETAIL_GetListSale(string SaleID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_DETAIL_GetListSale", SaleID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DELIVERY_ORDER_DETAIL_Getall()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DELIVERY_ORDER_DETAIL_Getall");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
