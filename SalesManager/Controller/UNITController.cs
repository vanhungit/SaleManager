using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class UNITController
    {
        
        private List<UNIT> MapUNIT(DataTable dt)
        {
            List<UNIT> rs = new List<UNIT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                UNIT obj = new UNIT();
                if (dt.Columns.Contains("Unit_ID"))
                    obj.Unit_ID = (dt.Rows[i]["Unit_ID"].ToString());
                if (dt.Columns.Contains("Unit_Name"))
                    obj.Unit_Name = (dt.Rows[i]["Unit_Name"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Thêm đơn vị
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UNIT_Insert(UNIT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNIT_Insert",
                        obj.Unit_ID,
                        obj.Unit_Name,
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
        /// <summary>
        /// Xóa đơn vị
        /// </summary>
        /// <param name="Unit_ID"></param>
        /// <returns></returns>
        public int UNIT_Delete(string Unit_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNIT_Delete", Unit_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Lấy đơn vị theo mã
        /// 
        /// </summary>
        /// <param name="Unit_ID"></param>
        /// <returns></returns>
        public UNIT UNIT_Get(string Unit_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNIT_Get", Unit_ID);
                return MapUNIT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UNIT UNIT_GetByName(string Unit_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNIT_GetByName", Unit_Name);
                return MapUNIT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UNIT UNIT_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNIT_Top1");
                return MapUNIT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public DataTable UNIT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "UNIT_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Unit_ID"></param>
        /// <returns></returns>
        public int UNIT_Update(UNIT obj, string Unit_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "UNIT_Update",
                        Unit_ID,
                        obj.Unit_Name,
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
