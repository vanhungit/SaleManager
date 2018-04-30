using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
namespace QuanLiBanHang.Controller
{
    public class INVENTORY_ACTIONController
    {
        private List<INVENTORY_ACTION> MapINVENTORY_ACTION(DataTable dt)
        {
            List<INVENTORY_ACTION> rs = new List<INVENTORY_ACTION>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                INVENTORY_ACTION obj = new INVENTORY_ACTION();
                if (dt.Columns.Contains("Action_ID"))
                    obj.Action_ID = int.Parse(dt.Rows[i]["Action_ID"].ToString());
                if (dt.Columns.Contains("Action_Name"))
                    obj.Action_Name = dt.Rows[i]["Action_Name"].ToString();
            }
            return rs;
        }
    }
}
