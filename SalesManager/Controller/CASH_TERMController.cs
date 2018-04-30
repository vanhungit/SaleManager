using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
using System.Data;

namespace QuanLiBanHang.Controller
{
    public class CASH_TERMController
    {
        private List<CASH_TERM> MapCASH_TERM(DataTable dt)
        {
            List<CASH_TERM> rs = new List<CASH_TERM>();
            for ( int i = 0; i < dt.Rows.Count; i++)
            {
                CASH_TERM obj = new CASH_TERM();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("Code"))
                    obj.Code = (dt.Rows[i]["ReceiptID"].ToString());
                if (dt.Columns.Contains("Name"))
                    obj.Name = (dt.Rows[i]["Name"].ToString());
                if (dt.Columns.Contains("NameEN"))
                    obj.NameEN = dt.Rows[i]["NameEN"].ToString();
                if (dt.Columns.Contains("TypeID"))
                    obj.TypeID = int.Parse(dt.Rows[i]["TypeID"].ToString());
                if (dt.Columns.Contains("DueTime"))
                    obj.DueTime = int.Parse(dt.Rows[i]["DueTime"].ToString());
                if (dt.Columns.Contains("DiscountTime"))
                    obj.DiscountTime = int.Parse(dt.Rows[i]["DiscountTime"].ToString());
                if (dt.Columns.Contains("DiscountPercent"))
                    obj.DiscountPercent = double.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                if (dt.Columns.Contains("DelayWithin"))
                    obj.DelayWithin = int.Parse(dt.Rows[i]["DelayWithin"].ToString());
                if (dt.Columns.Contains("DiscountPercent"))
                    obj.DiscountPercent = double.Parse(dt.Rows[i]["DiscountPercent"].ToString());
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
        public int CASH_TERM_Insert(CASH_TERM obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CASH_TERM_Insert",
                    obj.ID ,
                    obj.Code ,
                    obj.Name ,
                    obj.NameEN ,
                    obj.TypeID ,
                    obj.DueTime ,
                    obj.DiscountTime ,
                    obj.DiscountPercent ,
                    obj.DelayWithin ,
                    obj.IsPublic ,
                    obj.CreatedBy ,
                    obj.CreatedDate ,
                    obj.ModifiedBy ,
                    obj.ModifiedDate ,
                    obj.OwnerID ,
                    obj.Description ,
                    obj.Sorted ,
                    obj.Active 
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CASH_TERM_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CASH_TERM_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
