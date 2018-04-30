using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PRODUCT_GROUPController
    {
        private List<PRODUCT_GROUP> MapPRODUCT_GROUP(DataTable dt)
        {
            List<PRODUCT_GROUP> rs = new List<PRODUCT_GROUP>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT_GROUP obj = new PRODUCT_GROUP();
                if (dt.Columns.Contains("ProductGroup_ID"))
                    obj.ProductGroup_ID = dt.Rows[i]["ProductGroup_ID"].ToString();
                if (dt.Columns.Contains("ProductGroup_Name"))
                    obj.ProductGroup_Name = dt.Rows[i]["ProductGroup_Name"].ToString();
                if (dt.Columns.Contains("ID_NGANH"))
                    obj.ID_NGANH = dt.Rows[i]["ID_NGANH"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("IsMain"))
                    obj.IsMain = bool.Parse(dt.Rows[i]["IsMain"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PRODUCT_GROUP_Insert(PRODUCT_GROUP obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_GROUP_Insert",
                    obj.ProductGroup_ID,
                    obj.ID_NGANH,
                    obj.ProductGroup_Name,
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
        public int PRODUCT_GROUP_Update(PRODUCT_GROUP obj, string ProductGroup_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_GROUP_Update",
                    ProductGroup_ID,
                    obj.ID_NGANH,
                    obj.ProductGroup_Name,
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
        public int PRODUCT_GROUP_Delete(string ProductGroup_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_GROUP_Delete", ProductGroup_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT_GROUP PRODUCT_GROUP_Get(string ProductGroup_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GROUP_Get", ProductGroup_ID);
                return MapPRODUCT_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT_GROUP PRODUCT_GROUP_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GROUP_Top1");
                return MapPRODUCT_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT_GROUP PRODUCT_GROUP_GetByName(string ProductGroup_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GROUP_GetByName", ProductGroup_Name);
                return MapPRODUCT_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GROUP_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GROUP_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_GROUP_GetByNganh(string MaNganh)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_GROUP_GetByNganh", MaNganh);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
