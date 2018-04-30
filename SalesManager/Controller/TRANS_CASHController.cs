using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class TRANS_CASHController
    {
        private List<TRANS_CASH> MapTRANS_CASH(DataTable dt)
        {
            List<TRANS_CASH> rs = new List<TRANS_CASH>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TRANS_CASH obj = new TRANS_CASH();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("BookID"))
                    obj.BookID = (dt.Rows[i]["BookID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = (dt.Rows[i]["RefID"].ToString());
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefNo"))
                    obj.RefNo = (dt.Rows[i]["RefNo"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = (dt.Rows[i]["RefOrgNo"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType =int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("CustomerID"))
                    obj.CustomerID = (dt.Rows[i]["CustomerID"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = (dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = (dt.Rows[i]["CurrencyID"].ToString());
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Balance"))
                    obj.Balance = double.Parse(dt.Rows[i]["Balance"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FBalance"))
                    obj.FBalance = double.Parse(dt.Rows[i]["FBalance"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int TRANS_CASH_Insert(TRANS_CASH obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_CASH_Insert",
                        obj.ID,
                        obj.BookID,
                        obj.RefID,
                        obj.RefDate,
                        obj.RefNo,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefStatus,
                        obj.CustomerID,
                        obj.PaymentMethod,
                        obj.CurrencyID,
                        obj.ExchangeRate,
                        obj.Amount,
                        obj.Balance,
                        obj.FAmount,
                        obj.FBalance,
                        obj.Description,
                        obj.Sorted
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_CASH_Delete()
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_CASH_Delete");
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_CASH_DeleteByCode()
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_CASH_DeleteByCode");
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public List<TRANS_CASH> TRANS_CASH_Get()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_CASH_Get");
                return MapTRANS_CASH(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRANS_CASH> TRANS_CASH_GetByCode()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_CASH_GetByCode");
                return MapTRANS_CASH(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
