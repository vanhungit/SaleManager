using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;

namespace QuanLiBanHang.Controller
{
    public class CASH_METHODController
    {
        private List<CASH_METHOD> MapCASH_METHOD(DataTable dt)
        {
            List<CASH_METHOD> rs = new List<CASH_METHOD>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CASH_METHOD obj = new CASH_METHOD();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Code"))
                    obj.Code = (dt.Rows[i]["Code"].ToString());
                if (dt.Columns.Contains("Name"))
                    obj.Name = (dt.Rows[i]["Name"].ToString());
                if (dt.Columns.Contains("NameEN"))
                    obj.NameEN = dt.Rows[i]["NameEN"].ToString();
                if (dt.Columns.Contains("TypeID"))
                    obj.TypeID = int.Parse(dt.Rows[i]["TypeID"].ToString());
                if (dt.Columns.Contains("IsPublic"))
                    obj.IsPublic = bool.Parse(dt.Rows[i]["IsPublic"].ToString());
                if (dt.Columns.Contains("CreatedBy"))
                    obj.CreatedBy = (dt.Rows[i]["CreatedBy"].ToString());
                if (dt.Columns.Contains("CreatedDate"))
                    obj.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = (dt.Rows[i]["ModifiedBy"].ToString());
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                if (dt.Columns.Contains("OwnerID"))
                    obj.OwnerID = (dt.Rows[i]["OwnerID"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int CASH_METHOD_Insert(CASH_METHOD obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CASH_METHOD_Insert",
                    obj.ID,
                    obj.Code,
                    obj.Name,
                    obj.NameEN,
                    obj.TypeID,
                    obj.IsPublic,
                    obj.CreatedBy,
                    obj.CreatedDate,
                    obj.ModifiedBy,
                    obj.ModifiedDate,
                    obj.OwnerID,
                    obj.Description,
                    obj.Sorted,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CASH_METHOD_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CASH_METHOD_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CASH_METHOD CASH_METHOD_Get(Guid ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CASH_METHOD_Get", ID);
                return MapCASH_METHOD(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
