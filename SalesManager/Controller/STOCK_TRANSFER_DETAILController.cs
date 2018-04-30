using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_TRANSFER_DETAILController
    {
        private List<STOCK_TRANSFER_DETAIL> MapSTOCK_TRANSFER_DETAIL(DataTable dt)
        {
            List<STOCK_TRANSFER_DETAIL> rs = new List<STOCK_TRANSFER_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                STOCK_TRANSFER_DETAIL obj = new STOCK_TRANSFER_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Transfer_ID"))
                    obj.Transfer_ID = dt.Rows[i]["Transfer_ID"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType =int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Product_Name"))
                    obj.Product_Name = dt.Rows[i]["Product_Name"].ToString();
                if (dt.Columns.Contains("OutStock"))
                    obj.OutStock = dt.Rows[i]["OutStock"].ToString();
                if (dt.Columns.Contains("OutStockName"))
                    obj.OutStockName = dt.Rows[i]["OutStockName"].ToString();
                if (dt.Columns.Contains("LocationOut"))
                    obj.LocationOut = dt.Rows[i]["LocationOut"].ToString();
                if (dt.Columns.Contains("InStock"))
                    obj.InStock = dt.Rows[i]["InStock"].ToString();
                if (dt.Columns.Contains("InStockName"))
                    obj.InStockName = dt.Rows[i]["InStockName"].ToString();
                if (dt.Columns.Contains("LocationIn"))
                    obj.LocationIn = dt.Rows[i]["LocationIn"].ToString();
                if (dt.Columns.Contains("Unit"))
                    obj.Unit = dt.Rows[i]["Unit"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert =double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("UnitPrice"))
                    obj.UnitPrice = double.Parse(dt.Rows[i]["UnitPrice"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("QtyConvert"))
                    obj.QtyConvert = double.Parse(dt.Rows[i]["QtyConvert"].ToString());
                if (dt.Columns.Contains("StoreID"))
                    obj.StoreID = long.Parse(dt.Rows[i]["StoreID"].ToString());
                if (dt.Columns.Contains("Batch"))
                    obj.Batch = dt.Rows[i]["Batch"].ToString();
                if (dt.Columns.Contains("Serial"))
                    obj.Serial = dt.Rows[i]["Serial"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_TRANSFER_DETAIL_Insert(STOCK_TRANSFER_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_DETAIL_Insert",
                    obj.ID,
                    obj.Transfer_ID,
                    obj.RefType,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.OutStock,
                    obj.LocationOut,
                    obj.InStock,
                    obj.LocationIn,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitPrice,
                    obj.Quantity,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.StoreID,
                    obj.Batch,
                    obj.Serial,
                    obj.Description,
                    obj.Sorted
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_TRANSFER_DETAIL_Insert_Test(STOCK_TRANSFER_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_DETAIL_Insert_Test",
                    obj.ID,
                    obj.Transfer_ID,
                    obj.RefType,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.OutStock,
                    obj.InStock,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitPrice,
                    obj.Quantity,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.StoreID,
                    obj.Batch,
                    obj.Serial,
                    obj.Description,
                    obj.Sorted
                );
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
        public int STOCK_TRANSFER_DETAIL_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_DETAIL_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public STOCK_TRANSFER_DETAIL STOCK_TRANSFER_DETAIL_Get(string Transfer_ID, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_Get", Transfer_ID, Product_ID);
                return MapSTOCK_TRANSFER_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_TRANSFER_DETAIL> STOCK_TRANSFER_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetList");
                return MapSTOCK_TRANSFER_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetList_ByDate", FromDate, ToDate, MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_GetList_ByDate_Action(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetList_ByDate_Action", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_GetList_ByTransferID(string Transfer_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetList_ByTransferID", Transfer_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_GetList_ByTransferID_Modify(string Transfer_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetList_ByTransferID_Modify", Transfer_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_GetListByDate_STOCK(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_GetListByDate_STOCK", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_DETAIL_ReportDate(DateTime FromDate, DateTime ToDate, string StockID, string ProductID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_DETAIL_ReportDate", FromDate, ToDate, StockID, ProductID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_TRANSFER_DETAIL_Update(STOCK_TRANSFER_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_DETAIL_Update",
                    obj.ID,
                    obj.Transfer_ID ,
                    obj.RefType,
                    obj.Product_ID,
                    obj.Product_Name,
                    obj.OutStock,
                    obj.LocationOut,
                    obj.InStock,
                    obj.LocationIn,
                    obj.Unit,
                    obj.UnitConvert,
                    obj.UnitPrice,
                    obj.Quantity,
                    obj.Amount,
                    obj.QtyConvert,
                    obj.StoreID,
                    obj.Batch,
                    obj.Serial,
                    obj.Description,
                    obj.Sorted 
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
