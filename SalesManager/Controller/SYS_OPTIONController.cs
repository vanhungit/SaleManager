using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_OPTIONController
    {
        private List<SYS_OPTION> MapSYS_OPTION(DataTable dt)
        {
            List<SYS_OPTION> rs = new List<SYS_OPTION>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_OPTION obj = new SYS_OPTION();
                if (dt.Columns.Contains("Option_ID"))
                    obj.Option_ID = (dt.Rows[i]["Option_ID"].ToString());
                if (dt.Columns.Contains("OptionValue"))
                    obj.OptionValue = (dt.Rows[i]["OptionValue"].ToString());
                if (dt.Columns.Contains("ValueType"))
                    obj.ValueType = int.Parse(dt.Rows[i]["ValueType"].ToString());
                if (dt.Columns.Contains("System"))
                    obj.System = bool.Parse(dt.Rows[i]["System"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int SYS_OPTION_Insert(SYS_OPTION obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_OPTION_Insert",
                    obj.Option_ID,
                    obj.OptionValue,
                    obj.ValueType,
                    obj.Description
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int SYS_OPTION_Delete(string Option_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_OPTION_Delete", Option_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_OPTION SYS_OPTION_Get(string Option_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_OPTION_Get", Option_ID);
                return MapSYS_OPTION(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SYS_OPTION> SYS_OPTION_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_OPTION_GetList");
                return MapSYS_OPTION(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SYS_OPTION_Update(SYS_OPTION obj, string Option_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_LOG_Update",
                    Option_ID,
                    obj.OptionValue,
                    obj.ValueType,
                    obj.Description
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
