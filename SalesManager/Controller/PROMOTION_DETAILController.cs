using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class PROMOTION_DETAILController
    {
        private List<PROMOTION_DETAIL> MapPROMOTION_DETAIL(DataTable dt)
        {
            List<PROMOTION_DETAIL> rs = new List<PROMOTION_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PROMOTION_DETAIL obj = new PROMOTION_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Promotion_ID"))
                    obj.Promotion_ID = (dt.Rows[i]["Promotion_ID"].ToString());
                if (dt.Columns.Contains("PRODUCT_ID"))
                    obj.PRODUCT_ID = dt.Rows[i]["PRODUCT_ID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("ProductGroup_ID"))
                    obj.ProductGroup_ID = dt.Rows[i]["ProductGroup_ID"].ToString();
                if (dt.Columns.Contains("DiscountPercent"))
                    obj.DiscountPercent = double.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                if (dt.Columns.Contains("FromAmount"))
                    obj.FromAmount = double.Parse(dt.Rows[i]["FromAmount"].ToString());
                if (dt.Columns.Contains("ToAmount"))
                    obj.ToAmount = double.Parse(dt.Rows[i]["ToAmount"].ToString());
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
        public int PROMOTION_DETAIL_Insert(PROMOTION_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROMOTION_DETAIL_Insert",
                    obj.ID
                   , obj.Promotion_ID
                   , obj.PRODUCT_ID
                   , obj.ProductName
                   , obj.ProductGroup_ID
                   , obj.DiscountPercent
                   , obj.FromAmount
                   , obj.ToAmount
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                   , obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROMOTION_DETAIL_Update(PROMOTION_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROMOTION_DETAIL_Update",
                    obj.ID
                   , obj.Promotion_ID
                   , obj.PRODUCT_ID
                   , obj.ProductName
                   , obj.ProductGroup_ID
                   , obj.DiscountPercent
                   , obj.FromAmount
                   , obj.ToAmount
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                   , obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PROMOTION_GetAllList()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROMOTION_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PROMOTION_DETAIL_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROMOTION_DETAIL_Get", ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
