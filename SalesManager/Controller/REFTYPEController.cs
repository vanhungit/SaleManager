using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;

namespace QuanLiBanHang.Controller
{
    public class REFTYPEController
    {
        private List<REFTYPE> MapREFTYPE(DataTable dt)
        {
            List<REFTYPE> rs = new List<REFTYPE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                REFTYPE obj = new REFTYPE();
                if (dt.Columns.Contains("ID"))
                    obj.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Name"))
                    obj.Name = dt.Rows[i]["Name"].ToString();
                if (dt.Columns.Contains("NameEN"))
                    obj.NameEN = dt.Rows[i]["RefDate"].ToString();
                if (dt.Columns.Contains("CategoryID"))
                    obj.CategoryID = int.Parse(dt.Rows[i]["CategoryID"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("IsSearch"))
                    obj.IsSearch = bool.Parse(dt.Rows[i]["IsSearch"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public DataTable REFTYPE_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "REFTYPE_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
