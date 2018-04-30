using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class DEPARTMENTController
    {
        private List<DEPARTMENT> MapDEPARTMENT(DataTable dt)
        {
            List<DEPARTMENT> rs = new List<DEPARTMENT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DEPARTMENT obj = new DEPARTMENT();
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = dt.Rows[i]["Department_ID"].ToString();
                if (dt.Columns.Contains("Department_Name"))
                    obj.Department_Name = dt.Rows[i]["Department_Name"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Thêm phòng ban
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ThemDEPARTMENT(DEPARTMENT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEPARTMENT_Insert",
                    obj.Department_ID,
                    obj.Department_Name,
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
        /// Lấy thông tin phòng ban
        /// </summary>
        /// <param name="DEPARTMENT_ID"></param>
        /// <returns></returns>
        public DEPARTMENT LayTTDEPARTMENT_ByID(string DEPARTMENT_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEPARTMENT_Get", DEPARTMENT_ID);
                return MapDEPARTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin thông qua tên
        /// </summary>
        /// <param name="DEPARTMENT_ID"></param>
        /// <returns></returns>
        public DEPARTMENT DEPARTMENT_GetbyName(string DEPARTMENT_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEPARTMENT_GetbyName", DEPARTMENT_Name);
                return MapDEPARTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấu danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        public List<DEPARTMENT> LayDSDEPARTMENT_GROUP()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEPARTMENT_GetList");
                return MapDEPARTMENT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Xóa phòng ban
        /// </summary>
        /// <param name="DEPARTMENT_ID"></param>
        /// <returns></returns>
        public int XoaDEPARTMENT(string DEPARTMENT_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEPARTMENT_Delete", DEPARTMENT_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật phòng ban
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="DEPARTMENT_ID"></param>
        /// <returns></returns>
        public int DEPARTMENT_Update(DEPARTMENT obj, string DEPARTMENT_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEPARTMENT_Update",
                    DEPARTMENT_ID,
                    obj.Department_Name,
                    obj.Description,
                    obj.Active
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm kiếm phòng ban
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<DEPARTMENT> DEPARTMENT_Search(DEPARTMENT obj)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEPARTMENT_Search",
                        obj.Department_ID ,
                        obj.Department_Name 
                    );
                return MapDEPARTMENT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy Top 1 phòng ban
        /// </summary>
        /// <returns></returns>
        public DEPARTMENT DEPARTMENT_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEPARTMENT_Top1");
                return MapDEPARTMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
