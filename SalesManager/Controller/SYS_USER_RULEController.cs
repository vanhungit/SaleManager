using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_USER_RULEController
    {
        private List<SYS_USER_RULE> MapSYS_USER_RULE(DataTable dt)
        {
            List<SYS_USER_RULE> rs = new List<SYS_USER_RULE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_USER_RULE obj = new SYS_USER_RULE();
                if (dt.Columns.Contains("Goup_ID"))
                    obj.Goup_ID = (dt.Rows[i]["Goup_ID"].ToString());
                if (dt.Columns.Contains("Object_ID"))
                    obj.Object_ID = (dt.Rows[i]["Object_ID"].ToString());
                if (dt.Columns.Contains("Rule_ID"))
                    obj.Rule_ID = (dt.Rows[i]["Rule_ID"].ToString());
                if (dt.Columns.Contains("AllowAdd"))
                    obj.AllowAdd = bool.Parse(dt.Rows[i]["AllowAdd"].ToString());
                if (dt.Columns.Contains("AllowDelete"))
                    obj.AllowDelete = bool.Parse(dt.Rows[i]["AllowDelete"].ToString());
                if (dt.Columns.Contains("AllowEdit"))
                    obj.AllowEdit = bool.Parse(dt.Rows[i]["AllowEdit"].ToString());
                if (dt.Columns.Contains("AllowAccess"))
                    obj.AllowAccess = bool.Parse(dt.Rows[i]["AllowAccess"].ToString());
                if (dt.Columns.Contains("AllowPrint"))
                    obj.AllowPrint = bool.Parse(dt.Rows[i]["AllowPrint"].ToString());
                if (dt.Columns.Contains("AllowExport"))
                    obj.AllowExport = bool.Parse(dt.Rows[i]["AllowExport"].ToString());
                if (dt.Columns.Contains("AllowImport"))
                    obj.AllowImport = bool.Parse(dt.Rows[i]["AllowImport"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int SYS_USER_RULE_Insert(SYS_USER_RULE obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_RULE_Insert",
                        obj.Goup_ID,
                        obj.Object_ID,
                        obj.Rule_ID,
                        obj.AllowAdd,
                        obj.AllowDelete,
                        obj.AllowEdit,
                        obj.AllowAccess,
                        obj.AllowPrint,
                        obj.AllowExport,
                        obj.AllowImport,
                        obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int SYS_USER_RULE_Delete(string Goup_ID, string Object_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_RULE_Delete", Goup_ID, Object_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public SYS_USER_RULE SYS_USER_RULE_Get(string Goup_ID, string Object_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_RULE_Get",  Goup_ID,  Object_ID);
                return MapSYS_USER_RULE(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SYS_USER_RULE_Get_By_Level(string Goup_ID, string Parent_ID, int Level, string Language_Id)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_RULE_Get_By_Level", Goup_ID,  Parent_ID,  Level,  Language_Id);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SYS_USER_RULE_PhanQuyen(string Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_RULE_PhanQuyen", Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SYS_GetbyLevel(string Group_ID, string Parent, int level)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_GetbyLevel", Group_ID,Parent,level);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SYS_USER_RULE> SYS_USER_RULE_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_RULE_GetList");
                return MapSYS_USER_RULE(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SYS_USER_RULE_Update(SYS_USER_RULE obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_RULE_Update",
                        obj.Goup_ID,
                        obj.Object_ID,
                        obj.Rule_ID,
                        obj.AllowAdd,
                        obj.AllowDelete,
                        obj.AllowEdit,
                        obj.AllowAccess,
                        obj.AllowPrint,
                        obj.AllowExport,
                        obj.AllowImport,
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
