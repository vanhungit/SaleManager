using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SalesManager.Entity;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class INVOICE_Controller
    {
        private List<INVOICE> MapINVOICE(DataTable dt)
        {
            List<INVOICE> rs = new List<INVOICE>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                INVOICE obj = new INVOICE();
                if (dt.Columns.Contains("ID"))
                    obj.ID = long.Parse(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefNo"))
                    obj.RefNo = dt.Rows[i]["RefNo"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("StockID"))
                    obj.StockID = dt.Rows[i]["StockID"].ToString();
                if (dt.Columns.Contains("PrintCount"))
                    obj.PrintCount = int.Parse(dt.Rows[i]["PrintCount"].ToString());
                if (dt.Columns.Contains("TongTien"))
                    obj.TongTien = double.Parse(dt.Rows[i]["TongTien"].ToString());
                if (dt.Columns.Contains("KhachTra"))
                    obj.KhachTra = double.Parse(dt.Rows[i]["KhachTra"].ToString());
                if (dt.Columns.Contains("ConLai"))
                    obj.ConLai = double.Parse(dt.Rows[i]["ConLai"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                if (dt.Columns.Contains("CreateBy"))
                    obj.CreateBy = dt.Rows[i]["CreateBy"].ToString();
                if (dt.Columns.Contains("Createdate"))
                    obj.Createdate = DateTime.Parse(dt.Rows[i]["Createdate"].ToString());
                if (dt.Columns.Contains("ModifyBy"))
                    obj.ModifyBy = dt.Rows[i]["ModifyBy"].ToString();
                if (dt.Columns.Contains("ModifyDate"))
                    obj.ModifyDate = DateTime.Parse(dt.Rows[i]["ModifyDate"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int INVOICE_Insert(INVOICE obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVOICE_Insert",
                    obj.ID
                   , obj.RefNo
                   , obj.RefDate
                   , obj.RefType
                   , obj.RefStatus
                   , obj.StockID
                   , obj.PrintCount
                   , obj.TongTien
                   , obj.KhachTra
                   , obj.ConLai
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int INVOICE_Update(INVOICE obj, long ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVOICE_Update",
                    ID,
                    obj.RefNo
                   , obj.RefDate
                   , obj.RefType
                   , obj.RefStatus
                   , obj.StockID
                   , obj.PrintCount
                   , obj.TongTien
                   , obj.KhachTra
                   , obj.ConLai
                   , obj.Active
                   , obj.CreateBy
                   , obj.Createdate
                   , obj.ModifyBy
                   , obj.ModifyDate
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public INVOICE INVOICE_Get(long ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVOICE_Get", ID);
                return MapINVOICE(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable INVOICE_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INVOICE_Getlist");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int INVOICE_Delete(long Currency_ID)
        {
            try
            {
                DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INVOICE_Delete", Currency_ID);
                return 1;
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
    }
}
