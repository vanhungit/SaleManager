using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
namespace QuanLiBanHang.Controller
{
    public class PRODUCT_MODELController
    {
        private List<PRODUCT_MODEL> MapPRODUCT_UNIT(DataTable dt)
        {
            List<PRODUCT_MODEL> rs = new List<PRODUCT_MODEL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PRODUCT_MODEL obj = new PRODUCT_MODEL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("Code"))
                    obj.Code = dt.Rows[i]["Code"].ToString();
                if (dt.Columns.Contains("Name"))
                    obj.Name = dt.Rows[i]["Name"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
    }
}
