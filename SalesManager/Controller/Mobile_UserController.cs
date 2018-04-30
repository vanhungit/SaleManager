using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    class Mobile_UserController
    {
        private List<Mobile_User> MapMobile_User(DataTable dt)
        {
            List<Mobile_User> rs = new List<Mobile_User>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mobile_User obj = new Mobile_User();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("IP_Address"))
                    obj.IP_Address = (dt.Rows[i]["IP_Address"].ToString());
                if (dt.Columns.Contains("MobiName"))
                    obj.MobiName = dt.Rows[i]["MobiName"].ToString();
                if (dt.Columns.Contains("SeriNumber"))
                    obj.SeriNumber = dt.Rows[i]["SeriNumber"].ToString();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("OwnerID"))
                    obj.OwnerID = dt.Rows[i]["OwnerID"].ToString();
                if (dt.Columns.Contains("CreateDate"))
                    obj.CreateDate = DateTime.Parse(dt.Rows[i]["CreateDate"].ToString());
                if (dt.Columns.Contains("Decription"))
                    obj.Decription = dt.Rows[i]["Decription"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);

            }
            return rs;
        }
        public Mobile_User Mobile_User_Get(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Mobile_User_Get", ID);
                return MapMobile_User(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mobile_User_Insert(Mobile_User obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Mobile_User_Insert",
                    obj.ID  ,
                    obj.IP_Address,
                    obj.MobiName,
                    obj.SeriNumber,
                    obj.Employee_ID,
                    obj.OwnerID,
                    obj.CreateDate,
                    obj.Decription,
                    obj.Sorted,
                    obj.Active);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int Mobile_User_Update(Mobile_User obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Mobile_User_Update",
                    obj.ID,
                    obj.IP_Address,
                    obj.MobiName,
                    obj.SeriNumber,
                    obj.Employee_ID,
                    obj.OwnerID,
                    obj.CreateDate,
                    obj.Decription,
                    obj.Sorted,
                    obj.Active);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int Mobile_User_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "Mobile_User_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Mobile_User_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Mobile_User_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
