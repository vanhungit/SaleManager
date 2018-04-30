using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_LOGController
    {
        private List<SYS_LOG> MapSYS_LOG(DataTable dt)
        {
            List<SYS_LOG> rs = new List<SYS_LOG>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_LOG obj = new SYS_LOG();
                if (dt.Columns.Contains("SYS_ID"))
                    obj.SYS_ID = long.Parse(dt.Rows[i]["SYS_ID"].ToString());
                if (dt.Columns.Contains("MChine"))
                    obj.MChine = (dt.Rows[i]["MChine"].ToString());
                if (dt.Columns.Contains("IP"))
                    obj.IP = (dt.Rows[i]["IP"].ToString());
                if (dt.Columns.Contains("UserID"))
                    obj.UserID = (dt.Rows[i]["UserID"].ToString());
                if (dt.Columns.Contains("Created"))
                    obj.Created =DateTime.Parse(dt.Rows[i]["Created"].ToString());
                if (dt.Columns.Contains("Module"))
                    obj.Module = (dt.Rows[i]["Module"].ToString());
                if (dt.Columns.Contains("Action"))
                    obj.Action = int.Parse(dt.Rows[i]["Action"].ToString());
                if (dt.Columns.Contains("Action_Name"))
                    obj.Action_Name = (dt.Rows[i]["Action_Name"].ToString());
                if (dt.Columns.Contains("Reference"))
                    obj.Reference = (dt.Rows[i]["Reference"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active =bool.Parse(dt.Rows[i]["Active"].ToString());


                rs.Add(obj);
            }
            return rs;
        }
        public int SYS_LOG_Insert(SYS_LOG obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_LOG_Insert",
                    obj.MChine,
                    obj.IP,
                    obj.UserID,
                    obj.Created,
                    obj.Module,
                    obj.Action,
                    obj.Action_Name,
                    obj.Reference,
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
        public int SYS_LOG_Delete(long SYS_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_LOG_Delete", SYS_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_LOG SYS_LOG_Get(string SYS_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_LOG_Get", SYS_ID);
                return MapSYS_LOG(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SYS_LOG SYS_LOG_GetbyDate(DateTime Created)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_LOG_GetbyDate", Created);
                return MapSYS_LOG(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SYS_LOG> SYS_LOG_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_LOG_GetList");
                return MapSYS_LOG(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SYS_LOG_GetList_ByDate(DateTime From,DateTime To)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_LOG_GetList_ByDate",From,To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SYS_LOG_Update(SYS_LOG obj, string SYS_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_LOG_Update",
                    SYS_ID ,
                    obj.MChine ,
                    obj.IP ,
                    obj.UserID ,
                    obj.Created ,
                    obj.Module ,
                    obj.Action ,
                    obj.Action_Name ,
                    obj.Reference ,
                    obj.Description ,
                    obj.Active 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_LOG Max_SYS_LOG_ID()
        {
            
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Max_SYS_LOG_ID");
                return MapSYS_LOG(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
