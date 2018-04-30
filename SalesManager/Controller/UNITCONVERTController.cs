using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class UNITCONVERTController
    {
        private List<UNITCONVERT> MapUNITCONVERT(DataTable dt)
        {
            List<UNITCONVERT> rs = new List<UNITCONVERT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                UNITCONVERT obj = new UNITCONVERT();
                if (dt.Columns.Contains("Product_ID"))
                    obj.Product_ID = (dt.Rows[i]["Product_ID"].ToString());
                if (dt.Columns.Contains("Unit_ID"))
                    obj.Unit_ID = (dt.Rows[i]["Unit_ID"].ToString());
                if (dt.Columns.Contains("UnitConvert"))
                    obj.UnitConvert =double.Parse(dt.Rows[i]["UnitConvert"].ToString());
                if (dt.Columns.Contains("UnitChild_ID"))
                    obj.UnitChild_ID = (dt.Rows[i]["UnitChild_ID"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int UNITCONVERT_Insert(UNITCONVERT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNITCONVERT_Insert",
                        obj.Product_ID,
                        obj.Unit_ID,
                        obj.UnitConvert,
                        obj.UnitChild_ID
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int UNITCONVERT_Delete(string Product_ID, string Unit_ID, string UnitChild_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNITCONVERT_Delete", Product_ID,  Unit_ID,  UnitChild_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int UNITCONVERT_Delete_ByProduct(string Product_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNITCONVERT_Delete_ByProduct", Product_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public UNITCONVERT UNITCONVERT_Get(string Product_ID, string Unit_ID, string UnitChild_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNITCONVERT_Get", Product_ID, Unit_ID, UnitChild_ID);
                return MapUNITCONVERT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UNITCONVERT UNITCONVERT_Get_Convert(string Product_ID, string Unit_ID, string UnitChild_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNITCONVERT_Get_Convert", Product_ID, Unit_ID, UnitChild_ID);
                return MapUNITCONVERT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UNITCONVERT> UNITCONVERT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNITCONVERT_GetList");
                return MapUNITCONVERT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UNITCONVERT UNITCONVERT_GetList_PRODUCT(string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNITCONVERT_GetList_PRODUCT", Product_ID);
                return MapUNITCONVERT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UNITCONVERT_Update(string Product_ID, string Unit_ID, double UnitConvert, string UnitChild_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNITCONVERT_Update",Product_ID,  Unit_ID,  UnitConvert,  UnitChild_ID );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
    }
}
