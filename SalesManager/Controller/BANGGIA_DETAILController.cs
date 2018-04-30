using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class BANGGIA_DETAILController
    {
        private List<BANGGIA_DETAIL> MapADJUSTMENT_DETAIL(DataTable dt)
        {
            List<BANGGIA_DETAIL> rs = new List<BANGGIA_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BANGGIA_DETAIL obj = new BANGGIA_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("ID_BANGGIA"))
                    obj.ID_BANGGIA = (dt.Rows[i]["ID_BANGGIA"].ToString());
                if (dt.Columns.Contains("PRODUCT_ID"))
                    obj.PRODUCT_ID = dt.Rows[i]["PRODUCT_ID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();

                if (dt.Columns.Contains("Org_Price"))
                    obj.Org_Price = double.Parse(dt.Rows[i]["Org_Price"].ToString());
                if (dt.Columns.Contains("Sale_Price"))
                    obj.Sale_Price = double.Parse(dt.Rows[i]["Sale_Price"].ToString());
                if (dt.Columns.Contains("Retail_Price"))
                    obj.Retail_Price = double.Parse(dt.Rows[i]["Retail_Price"].ToString());

                if (dt.Columns.Contains("Org_Price_New"))
                    obj.Org_Price_New = double.Parse(dt.Rows[i]["Org_Price_New"].ToString());
                if (dt.Columns.Contains("Sale_Price_New"))
                    obj.Sale_Price_New = double.Parse(dt.Rows[i]["Sale_Price_New"].ToString());
                if (dt.Columns.Contains("Retail_Price_New"))
                    obj.Retail_Price_New = double.Parse(dt.Rows[i]["Retail_Price_New"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                if (dt.Columns.Contains("CreateBy"))
                    obj.CreateBy = dt.Rows[i]["CreateBy"].ToString();
                if (dt.Columns.Contains("Createdate"))
                    obj.Createdate = DateTime.Parse(dt.Rows[i]["Createdate"].ToString());
                if (dt.Columns.Contains("ModifyBy"))
                    obj.ModifyBy = dt.Rows[i]["ModifyBy"].ToString();
                if (dt.Columns.Contains("ModifyDate"))
                    obj.ModifyDate = DateTime.Parse(dt.Rows[i]["ModifyDate"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int ThemBANGGIA_DETAIL(BANGGIA_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_DETAIL_Insert",
                    obj.ID
                   , obj.ID_BANGGIA
                   , obj.PRODUCT_ID
                   , obj.ProductName
                   , obj.Org_Price
                   , obj.Sale_Price
                   , obj.Retail_Price
                   , obj.Org_Price_New
                   , obj.Sale_Price_New
                   , obj.Retail_Price_New
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BANGGIA_DETAIL_GetList_ByDate(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_DETAIL_GetList_ByDate", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CapNhatBANGGIA_DETAIL(BANGGIA_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_DETAIL_Update",
                    obj.ID
                   , obj.ID_BANGGIA
                   , obj.PRODUCT_ID
                   , obj.ProductName
                   , obj.Org_Price
                   , obj.Sale_Price
                   , obj.Retail_Price
                   , obj.Org_Price_New
                   , obj.Sale_Price_New
                   , obj.Retail_Price_New
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDSBANGGIA_DETAIL()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_DETAIL_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BANGGIA_DETAIL_Get(string BangGia)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "BANGGIA_DETAIL_Get", BangGia);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int XoaBANGGIA_DETAIL(string ID_BANGGIA)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BANGGIA_DETAIL_Delete", ID_BANGGIA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
