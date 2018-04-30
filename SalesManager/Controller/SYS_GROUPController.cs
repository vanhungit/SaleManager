using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_GROUPController
    {

        private List<SYS_GROUP> MapSYS_GROUP(DataTable dt)
            {
                List<SYS_GROUP> rs = new List<SYS_GROUP>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SYS_GROUP obj = new SYS_GROUP();
                    if (dt.Columns.Contains("Group_ID"))
                        obj.Group_ID = dt.Rows[i]["Group_ID"].ToString();
                    if (dt.Columns.Contains("Group_Name"))
                        obj.Group_Name = dt.Rows[i]["Group_Name"].ToString();
                    if (dt.Columns.Contains("Group_NameEn"))
                        obj.Group_NameEn = dt.Rows[i]["Group_NameEn"].ToString();
                    if (dt.Columns.Contains("Description"))
                        obj.Description = dt.Rows[i]["Description"].ToString();
                    if (dt.Columns.Contains("Active"))
                        obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                    rs.Add(obj);
                }
                return rs;
            }
        public int SYS_GROUP_Insert(SYS_GROUP obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_GROUP_Insert",
                    obj.Group_ID,
                    obj.Group_Name,
                    obj.Group_NameEn,
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
        public int SYS_GROUP_Delete(string Group_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_GROUP_Delete", Group_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_GROUP SYS_GROUP_Get(string Group_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_GROUP_Get", Group_ID);
                return MapSYS_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SYS_GROUP_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_GROUP_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SYS_GROUP_Update(SYS_GROUP obj, string Group_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_GROUP_Update",
                    Group_ID,
                    obj.Group_Name,
                    obj.Group_NameEn,
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
    }
}
