using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
namespace QuanLiBanHang.Controller
{
    public class CUSTOMER_TYPEController
    {
        private List<CUSTOMER_TYPE> MapCUSTOMER_TYPE(DataTable dt)
        {
            List<CUSTOMER_TYPE> rs = new List<CUSTOMER_TYPE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CUSTOMER_TYPE obj = new CUSTOMER_TYPE();
                if (dt.Columns.Contains("Customer_Type_ID"))
                    obj.Customer_Type_ID = dt.Rows[i]["Customer_Type_ID"].ToString();
                if (dt.Columns.Contains("Customer_Type_Name"))
                    obj.Customer_Type_Name = dt.Rows[i]["Customer_Type_Name"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
    }
}
