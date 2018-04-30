using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_INWARD_DETAILController
    {
        private List<STOCK_INWARD_DETAIL> MapSTOCK_INWARD_DETAIL(DataTable dt)
        {
            List<STOCK_INWARD_DETAIL> rs = new List<STOCK_INWARD_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK_INWARD_DETAIL obj = new STOCK_INWARD_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString().Trim());
                if (dt.Columns.Contains("Inward_ID"))
                    obj.Inward_ID = dt.Rows[i]["Inward_ID"].ToString();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType =int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("Vat"))
                    obj.Vat = int.Parse(dt.Rows[i]["Vat"].ToString());
                if (dt.Columns.Contains("VatAmount"))
                    obj.VatAmount = double.Parse(dt.Rows[i]["VatAmount"].ToString());
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
                if (dt.Columns.Contains("Limit"))
                    obj.Limit = DateTime.Parse(dt.Rows[i]["Limit"].ToString());
                if (dt.Columns.Contains("Width"))
                    obj.Width = double.Parse(dt.Rows[i]["Width"].ToString());
                if (dt.Columns.Contains("Height"))
                    obj.Height = double.Parse(dt.Rows[i]["Height"].ToString());
                if (dt.Columns.Contains("Orgin"))
                    obj.Orgin = dt.Rows[i]["Orgin"].ToString();
                if (dt.Columns.Contains("Size"))
                    obj.Size = dt.Rows[i]["Size"].ToString();
                if (dt.Columns.Contains("Color"))
                    obj.Color = dt.Rows[i]["Color"].ToString();
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
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_INWARD_DETAIL_Insert(STOCK_INWARD_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_DETAIL_Insert",
                    obj.ID,
                    obj.Inward_ID,
                    obj.Product_ID,
                    obj.ProductName,
                    obj.RefType,
                    obj.Stock_ID,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.Vat,
                    obj.VatAmount,
                    obj.CurrentQty,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.DiscountRate,
                    obj.Discount,
                    obj.Charge,
                    obj.Limit,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.Color,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.IME,
                    obj.Location,
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
        public int STOCK_INWARD_DETAIL_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_DETAIL_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">uniqueidentifier</param>
        /// <returns></returns>
        public STOCK_INWARD_DETAIL STOCK_INWARD_DETAIL_Get(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_Get", ID);
                return MapSTOCK_INWARD_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_INWARD_DETAIL> STOCK_INWARD_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetList");
                return MapSTOCK_INWARD_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetList_ByDate", FromDate, ToDate, MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_GetList_ByDate_BKCT(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetList_ByDate_BKCT", FromDate, ToDate);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_GetList_ByID(string InwardID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetList_ByID",InwardID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_NhapHang(string InwardID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_NhapHang", InwardID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_GetbyRefType(int InwardID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetbyRefType", InwardID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_GetListPurchaseID(string Purchase_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_GetListPurchaseID", Purchase_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_DETAIL_ReportDate(DateTime FromDate, DateTime ToDate, string StockID, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_DETAIL_ReportDate", FromDate, ToDate, StockID, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_INWARD_DETAIL_Update(STOCK_INWARD_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_DETAIL_Update",
                    obj.ID,
                    obj.Inward_ID,
                    obj.Product_ID,
                    obj.ProductName,
                    obj.RefType,
                    obj.Stock_ID,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.Vat,
                    obj.VatAmount,
                    obj.CurrentQty,
                    obj.Quantity,
                    obj.UnitPrice,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.DiscountRate,
                    obj.Discount,
                    obj.Charge,
                    obj.Limit,
                    obj.Width,
                    obj.Height,
                    obj.Orgin,
                    obj.Size,
                    obj.Color,
                    obj.Batch,
                    obj.Serial,
                    obj.ChassyNo,
                    obj.IME,
                    obj.Location,
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
    }
}
