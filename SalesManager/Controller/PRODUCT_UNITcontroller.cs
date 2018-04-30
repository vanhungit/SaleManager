using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PRODUCT_UNITcontroller
    {
        private List<PRODUCT_UNIT> MapPRODUCT_UNIT(DataTable dt)
        {
            List<PRODUCT_UNIT> rs = new List<PRODUCT_UNIT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT_UNIT obj = new PRODUCT_UNIT();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = dt.Rows[i]["Product_ID"].ToString();
                if (dt.Columns.Contains("Unit_ID"))
                    obj.Unit_ID = dt.Rows[i]["Unit_ID"].ToString();
                if (dt.Columns.Contains("UnitConvert_ID"))
                    obj.UnitConvert_ID = dt.Rows[i]["UnitConvert_ID"].ToString();
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert = double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PRODUCT_UNIT_Insert(PRODUCT_UNIT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_UNIT_Insert",
                    obj.Product_ID,
                    obj.Unit_ID,
                    obj.UnitConvert_ID,
                    obj.UnitConvert,
                    obj.Sorted
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PRODUCT_UNIT_Delete(string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_UNIT_Delete", Product_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_UNIT_DeleteByProduct(string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_UNIT_DeleteByProduct", Product_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT_UNIT PRODUCT_UNIT_Get(string Product_ID, string Unit_ID, string UnitConvert_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_UNIT_Get", Product_ID, Unit_ID, UnitConvert_ID);
                return MapPRODUCT_UNIT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT_UNIT> PRODUCT_UNIT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_UNIT_GetList");
                return MapPRODUCT_UNIT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT_UNIT> PRODUCT_UNIT_Search(double UnitConvert)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_UNIT_Search", UnitConvert);
                return MapPRODUCT_UNIT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_UNIT_Update(PRODUCT_UNIT obj,string Product_ID,string Unit_ID,string UnitConvert_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_UNIT_Update",
                    Product_ID,
                    Unit_ID,
                    UnitConvert_ID,
                    obj.UnitConvert,
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
