using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
using System.Data;
namespace QuanLiBanHang.Controller
{
    public class CUSTOMER_GROUPController
    {
        private List<CUSTOMER_GROUP> MapCUSTOMER_GROUP(DataTable dt)
        {
            List<CUSTOMER_GROUP> rs = new List<CUSTOMER_GROUP>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CUSTOMER_GROUP obj = new CUSTOMER_GROUP();
                if (dt.Columns.Contains("Customer_Group_ID"))
                    obj.Customer_Group_ID = dt.Rows[i]["Customer_Group_ID"].ToString();
                if (dt.Columns.Contains("Customer_Group_Name"))
                    obj.Customer_Group_Name = dt.Rows[i]["Customer_Group_Name"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Thêm nhóm khu vực
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ThemCUSTOMER_GROUP(CUSTOMER_GROUP obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_GROUP_Insert",
                    obj.Customer_Group_ID,
                    obj.Customer_Group_Name,
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
        /// Xóa nhóm khu vực
        /// </summary>
        /// <param name="Customer_Group_ID"></param>
        /// <returns></returns>
        public int XoaCUSTOMER_GROUP(string Customer_Group_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_GROUP_Delete", Customer_Group_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhóm khu vực theo mã nhóm
        /// </summary>
        /// <param name="Customer_Group_ID"></param>
        /// <returns></returns>
        public CUSTOMER_GROUP LayTTCUSTOMER_ByID(string Customer_Group_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_GROUP_Get", Customer_Group_ID);
                return MapCUSTOMER_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhóm thông tin thông qua tên nhóm
        /// </summary>
        /// <param name="Customer_Group_Name"></param>
        /// <returns></returns>
        public CUSTOMER_GROUP LayTTCUSTOMER_ByName(string Customer_Group_Name)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_GROUP_GetByName", Customer_Group_Name);
                return MapCUSTOMER_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật thông tin nhóm khu vực
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Customer_Group_ID"></param>
        /// <returns></returns>
        public int CapNhatCUSTOMER_GROUP(CUSTOMER_GROUP obj, string Customer_Group_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_GROUP_Update",
                    Customer_Group_ID,
                    obj.Customer_Group_Name,
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
        /// Lấy danh sách nhóm khu vực
        /// </summary>
        /// <returns></returns>
        ///  
        public DataTable LayDSCUSTOMER_GROUP()
        {
            DataTable dt = new DataTable();
            try
            { 
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_GROUP_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LayDSLoaiKhachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_TYPE_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy mã nhóm ở top 1
        /// </summary>
        /// <returns></returns>
        public CUSTOMER_GROUP CUSTOMER_GROUP_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_GROUP_Top1");
                return MapCUSTOMER_GROUP(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public List<CUSTOMER_GROUP> LayDSCUSTOMER_GROUP()
        {
            DataTable dt = new DataTable();
            try
            { 
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_GROUP_GetList");
                return MapCUSTOMER_GROUP(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         */
        
    }
}
