using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCKController
    {
        private List<STOCK> MapSTOCK(DataTable dt)
        {
            List<STOCK> rs = new List<STOCK>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK obj = new STOCK();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Stock_Name"))
                    obj.Stock_Name = dt.Rows[i]["Stock_Name"].ToString();
                if (dt.Columns.Contains("Contact"))
                    obj.Contact = dt.Rows[i]["Contact"].ToString();
                if (dt.Columns.Contains("Address"))
                    obj.Address = dt.Rows[i]["Address"].ToString();
                if (dt.Columns.Contains("Email"))
                    obj.Email = dt.Rows[i]["Email"].ToString();
                if (dt.Columns.Contains("Telephone"))
                    obj.Telephone = dt.Rows[i]["Telephone"].ToString();
                if (dt.Columns.Contains("Fax"))
                    obj.Fax = dt.Rows[i]["Fax"].ToString();
                if (dt.Columns.Contains("Mobi"))
                    obj.Mobi = dt.Rows[i]["Mobi"].ToString();
                if (dt.Columns.Contains("Manager"))
                    obj.Manager = dt.Rows[i]["Manager"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_Insert(STOCK obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_Insert",
                    obj.Stock_ID,
                    obj.Stock_Name,
                    obj.Contact,
                    obj.Address,
                    obj.Email,
                    obj.Telephone,
                    obj.Fax,
                    obj.Mobi,
                    obj.Manager,
                    obj.Description,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_Delete(string Stock_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_Delete", Stock_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public STOCK STOCK_Get(string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_Get", Stock_ID);
                return MapSTOCK(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public STOCK Stock_GetNameQuantityMax(string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Stock_GetNameQuantityMax", Product_ID);
                return MapSTOCK(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public STOCK Stock_GetNameQuantityMin(string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Stock_GetNameQuantityMin", Product_ID);
                return MapSTOCK(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public STOCK STOCK_GetByName(string Stock_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_GetByName", Stock_Name);
                return MapSTOCK(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable REPORT_DOANHTHU_BYDATE(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "REPORT_DOANHTHU_BYDATE", FromDate, ToDate);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable REPORT_DOANHTHUBH_BYDATE(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "REPORT_DOANHTHUBH_BYDATE", FromDate, ToDate);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable NhapXuat_GetList_ByDate(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "NhapXuat_GetList_ByDate",From,To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_Update(STOCK obj, string Stock_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_Update",
                    Stock_ID,
                    obj.Stock_Name,
                    obj.Contact,
                    obj.Address,
                    obj.Email,
                    obj.Telephone,
                    obj.Fax,
                    obj.Mobi,
                    obj.Manager,
                    obj.Description,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public STOCK STOCK_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_Top1");
                return MapSTOCK(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}
