using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class TRANS_DEBTController
    {
        private List<TRANS_DEBT> MapTRANS_DEBT(DataTable dt)
        {
            List<TRANS_DEBT> rs = new List<TRANS_DEBT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                TRANS_DEBT obj = new TRANS_DEBT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = (dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("BookID"))
                    obj.BookID = (dt.Rows[i]["BookID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = (dt.Rows[i]["RefID"].ToString());
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate =DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefDetailNo"))
                    obj.RefDetailNo = (dt.Rows[i]["RefDetailNo"].ToString());
                if (dt.Columns.Contains("RefNo"))
                    obj.RefNo = (dt.Rows[i]["RefNo"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = (dt.Rows[i]["RefOrgNo"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("CustomerID"))
                    obj.CustomerID = (dt.Rows[i]["CustomerID"].ToString());
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = (dt.Rows[i]["CurrencyID"].ToString());
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("IsDebt"))
                    obj.IsDebt =bool.Parse(dt.Rows[i]["IsDebt"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("Payment"))
                    obj.Payment = double.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("Balance"))
                    obj.Balance = double.Parse(dt.Rows[i]["Balance"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("FPayment"))
                    obj.FPayment = double.Parse(dt.Rows[i]["FPayment"].ToString());
                if (dt.Columns.Contains("FBalance"))
                    obj.FBalance = double.Parse(dt.Rows[i]["FBalance"].ToString());
                if (dt.Columns.Contains("Debit"))
                    obj.Debit = double.Parse(dt.Rows[i]["Debit"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted =long.Parse(dt.Rows[i]["Sorted"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int TRANS_DEBT_Insert(TRANS_DEBT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_DEBT_Insert",
                        obj.ID,
                        obj.BookID,
                        obj.RefID,
                        obj.RefDate,
                        obj.RefDetailNo,
                        obj.RefNo,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefStatus,
                        obj.CustomerID,
                        obj.CurrencyID,
                        obj.ExchangeRate,
                        obj.IsDebt,
                        obj.Amount,
                        obj.Discount,
                        obj.Payment,
                        obj.Balance,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.FPayment,
                        obj.FBalance,
                        obj.Debit,
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
        public int TRANS_DEBT_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_DEBT_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int TRANS_DEBT_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_DEBT_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public TRANS_DEBT TRANS_DEBT_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_DEBT_Get", ID);
                return MapTRANS_DEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRANS_DEBT> TRANS_DEBT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_DEBT_GetList");
                return MapTRANS_DEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TRANS_DEBT> TRANS_DEBT_Search(TRANS_DEBT obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "TRANS_DEBT_Search",
                    obj.RefDate ,
                    obj.RefDetailNo,
                    obj.RefNo,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.ExchangeRate,
                    obj.IsDebt,
                    obj.Amount,
                    obj.Discount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.FDiscount,
                    obj.FPayment,
                    obj.FBalance,
                    obj.Debit,
                    obj.Description
                    );
                return MapTRANS_DEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int TRANS_DEBT_Update(TRANS_DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_DEBT_Update",
                        ID,
                        obj.BookID,
                        obj.RefID,
                        obj.RefDate,
                        obj.RefDetailNo,
                        obj.RefNo,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefStatus,
                        obj.CustomerID,
                        obj.CurrencyID,
                        obj.ExchangeRate,
                        obj.IsDebt,
                        obj.Amount,
                        obj.Discount,
                        obj.Payment,
                        obj.Balance,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.FPayment,
                        obj.FBalance,
                        obj.Debit,
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
        public int TRANS_DEBT_UpdateById(TRANS_DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "TRANS_DEBT_UpdateById",
                        ID,
                        obj.BookID,
                        obj.RefID,
                        obj.RefDate,
                        obj.RefDetailNo,
                        obj.RefNo,
                        obj.RefOrgNo,
                        obj.RefType,
                        obj.RefStatus,
                        obj.CustomerID,
                        obj.CurrencyID,
                        obj.ExchangeRate,
                        obj.IsDebt,
                        obj.Amount,
                        obj.Discount,
                        obj.Payment,
                        obj.Balance,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.FPayment,
                        obj.FBalance,
                        obj.Debit,
                        obj.Description
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
