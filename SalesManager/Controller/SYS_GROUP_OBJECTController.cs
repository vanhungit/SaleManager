using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
namespace QuanLiBanHang.Controller
{
    public class SYS_GROUP_OBJECTController
    {
        private List<SYS_GROUP_OBJECT> MapSYS_GROUP_OBJECT(DataTable dt)
        {
            List<SYS_GROUP_OBJECT> rs = new List<SYS_GROUP_OBJECT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_GROUP_OBJECT obj = new SYS_GROUP_OBJECT();
                if (dt.Columns.Contains("Object_ID"))
                    obj.Object_ID = dt.Rows[i]["Object_ID"].ToString();
                if (dt.Columns.Contains("Goup_ID"))
                    obj.Goup_ID = dt.Rows[i]["Goup_ID"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = dt.Rows[i]["Active"].ToString();


                rs.Add(obj);
            }
            return rs;
        }

    }
}
