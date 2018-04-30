using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_INFOController
    {
        private List<SYS_INFO> MapSYS_INFO(DataTable dt)
        {
            List<SYS_INFO> rs = new List<SYS_INFO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_INFO obj = new SYS_INFO();
                if (dt.Columns.Contains("SysInfo_ID"))
                    obj.SysInfo_ID = dt.Rows[i]["SysInfo_ID"].ToString();
                if (dt.Columns.Contains("Application"))
                    obj.Application = dt.Rows[i]["Application"].ToString();
                if (dt.Columns.Contains("Version"))
                    obj.Version = dt.Rows[i]["Version"].ToString();
                if (dt.Columns.Contains("Type"))
                    obj.Type = int.Parse(dt.Rows[i]["Type"].ToString());
                if (dt.Columns.Contains("Created"))
                    obj.Created = DateTime.Parse(dt.Rows[i]["Created"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Interface"))
                    obj.Interface = int.Parse(dt.Rows[i]["Interface"].ToString());
                if (dt.Columns.Contains("Guid_ID"))
                    obj.Guid_ID = dt.Rows[i]["Guid_ID"].ToString();

                rs.Add(obj);

            }
            return rs;
        }
        public int SYS_INFO_Insert(SYS_INFO obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_INFO_Insert",
                    obj.SysInfo_ID,
                    obj.Application,
                    obj.Version,
                    obj.Type,
                    obj.Created,
                    obj.Description,
                    obj.Guid_ID
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int SYS_INFO_Delete(string SysInfo_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_INFO_Delete", SysInfo_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_INFO SYS_INFO_Get(string SysInfo_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_INFO_Get", SysInfo_ID);
                return MapSYS_INFO(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SYS_INFO> SYS_INFO_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_INFO_GetList");
                return MapSYS_INFO(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SYS_INFO_Update(SYS_INFO obj, string SysInfo_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_GROUP_Update",
                    SysInfo_ID,
                    obj.Application,
                    obj.Version,
                    obj.Type,
                    obj.Created,
                    obj.Description,
                    obj.Guid_ID
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
