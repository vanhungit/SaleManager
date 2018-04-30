using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class SYS_USERController
    {
        private List<SYS_USER> MapSYS_USER(DataTable dt)
        {
            List<SYS_USER> rs = new List<SYS_USER>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                SYS_USER obj = new SYS_USER();
                if (dt.Columns.Contains("UserID"))
                    obj.UserID = (dt.Rows[i]["UserID"].ToString());
                if (dt.Columns.Contains("UserName"))
                    obj.UserName = (dt.Rows[i]["UserName"].ToString());
                if (dt.Columns.Contains("Password"))
                    obj.Password = (dt.Rows[i]["Password"].ToString());
                if (dt.Columns.Contains("Group_ID"))
                    obj.Group_ID = (dt.Rows[i]["Group_ID"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("PartID"))
                    obj.PartID = (dt.Rows[i]["PartID"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int SYS_USER_Insert(SYS_USER obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_Insert",
                        obj.UserID,
                        obj.UserName,
                        obj.Password,
                        obj.Group_ID,
                        obj.Description,
                        obj.PartID,
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
        /// Sao Lưu cơ sở dữ liệu
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        public int BACKUP_DATABASE(string pathname)
        {
            try
            {
                DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "BACKUP_DATABASE", pathname);
                return 1;
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Up lại cơ sở dữ liệu
        /// </summary>
        /// <param name="pathname"></param>
        /// <returns></returns>
        public int RESTORE_DATABASE(string pathname)
        {
            try
            {
                DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "RESTORE_DATABASE", pathname);
                return 1;
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// xóa nhân viên
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int SYS_USER_Delete(string UserID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_Delete", UserID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Lấy thông tin nhân viên theo mã 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public SYS_USER SYS_USER_Get(string UserID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_Get", UserID);
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhân viên theo tên
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public SYS_USER SYS_USER_Get_By_UserName(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_Get_By_UserName", UserName);
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhân viên theo account
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public DataTable SYS_USER_getEmpByAccount(string Account)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_getEmpByAccount", Account);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhân viên cho account
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public SYS_USER SYS_USER_getEmpForAccount(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_getEmpForAccount", UserName);
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SYS_USER SYS_USER_maxUser()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_maxUser");
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public DataTable SYS_USER_GetEmpList()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_GetEmpList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo mã nhóm
        /// </summary>
        /// <param name="Group_ID"></param>
        /// <returns></returns>
        public DataTable SYS_USER_GetGroupID(string Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_GetGroupID", Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        public DataTable SYS_USER_GetList()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo mã nhóm
        /// </summary>
        /// <param name="Group_ID"></param>
        /// <returns></returns>
        public SYS_USER SYS_USER_GetList_By_Group(string Group_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_GetList_By_Group", Group_ID);
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhân viên theo username
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public SYS_USER SYS_USER_GetUserName(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SYS_USER_GetUserName", UserName);
                return MapSYS_USER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int SYS_USER_Update(SYS_USER obj, string UserID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_Update",
                        UserID,
                        obj.UserName,
                        obj.Password,
                        obj.Group_ID,
                        obj.Description,
                        obj.PartID,
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
        /// Cập nhật nhân viên no pass
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int SYS_USER_UpdateNoPass(SYS_USER obj, string UserID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "SYS_USER_UpdateNoPass",
                        UserID,
                        obj.UserName,
                        obj.Group_ID,
                        obj.Description,
                        obj.PartID,
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
