using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class PRODUCT_TYPEController
    {
        private List<PRODUCT_TYPE> MapDEBT(DataTable dt)
        {
            List<PRODUCT_TYPE> rs = new List<PRODUCT_TYPE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT_TYPE obj = new PRODUCT_TYPE();
                if (dt.Columns.Contains("Product_Type_ID"))
                    obj.Product_Type_ID = int.Parse(dt.Rows[i]["Product_Type_ID"].ToString());
                if (dt.Columns.Contains("Product_Name"))
                    obj.Product_Name = dt.Rows[i]["Product_Name"].ToString();
               

                rs.Add(obj);
            }
            return rs;
        }
        public DataTable PRODUCT_TYPE_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PRODUCT_TYPE_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
