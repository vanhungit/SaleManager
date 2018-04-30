using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PRODUCT_BUILDController
    {
        private List<PRODUCT_BUILD> MapPRODUCT_BUILD(DataTable dt)
        {
            List<PRODUCT_BUILD> rs = new List<PRODUCT_BUILD>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT_BUILD obj = new PRODUCT_BUILD();
                if (dt.Columns.Contains("ProductID"))
                    obj.ProductID = dt.Rows[i]["ProductID"].ToString();
                if (dt.Columns.Contains("BuildID"))
                    obj.BuildID = dt.Rows[i]["BuildID"].ToString();
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Price"))
                    obj.Price = double.Parse(dt.Rows[i]["Price"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int PRODUCT_BUILD_Insert(PRODUCT_BUILD obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_BUILD_Insert",
                    obj.ProductID,
                    obj.BuildID,
                    obj.Quantity,
                    obj.Price,
                    obj.Amount
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PRODUCT_BUILD_Delete(string ProductID, string BuildID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_BUILD_Delete", ProductID, BuildID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_BUILD_Delete_Product(string BuildID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_BUILD_Delete_Product", BuildID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PRODUCT_BUILD PRODUCT_Get(string Product_ID, string BuildID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_Get", Product_ID, BuildID);
                return MapPRODUCT_BUILD(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT_BUILD> PRODUCT_BUILD_Get_Build(string BuildID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_Get_Build", BuildID);
                return MapPRODUCT_BUILD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_BUILD_Get_By_ID(string BuildID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_Get_By_ID", BuildID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_BUILD_Get_Tron(string BuildID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_Get_Tron", BuildID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_BUILD_GetFull(string BuildID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_GetFull", BuildID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PRODUCT_BUILD> PRODUCT_BUILD_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_GetList");
                return MapPRODUCT_BUILD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PRODUCT_BUILD_GetList_Product(string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_BUILD_GetList_Product", Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PRODUCT_BUILD_Update(PRODUCT_BUILD obj, string ProductID, string BuildID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PRODUCT_BUILD_Update",
                    ProductID,
                    BuildID,
                    obj.Quantity,
                    obj.Price,
                    obj.Amount
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
