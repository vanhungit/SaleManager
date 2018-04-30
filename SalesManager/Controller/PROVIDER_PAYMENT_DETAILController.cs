using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PROVIDER_PAYMENT_DETAILController
    {
        private List<PROVIDER_PAYMENT_DETAIL> MapPROVIDER_PAYMENT_DETAIL(DataTable dt)
        {
            List<PROVIDER_PAYMENT_DETAIL> rs = new List<PROVIDER_PAYMENT_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PROVIDER_PAYMENT_DETAIL obj = new PROVIDER_PAYMENT_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid( dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("PaymentID"))
                    obj.PaymentID = new Guid( dt.Rows[i]["PaymentID"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = new Guid( dt.Rows[i]["RefOrgNo"].ToString());
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = dt.Rows[i]["CurrencyID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Debit"))
                    obj.Debit = double.Parse(dt.Rows[i]["Debit"].ToString());
                if (dt.Columns.Contains("Payment"))
                    obj.Payment = double.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("DiscountPercent"))
                    obj.DiscountPercent = double.Parse(dt.Rows[i]["DiscountPercent"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FDebit"))
                    obj.FDebit = double.Parse(dt.Rows[i]["FDebit"].ToString());
                if (dt.Columns.Contains("FPayment"))
                    obj.FPayment = double.Parse(dt.Rows[i]["FPayment"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int PROVIDER_PAYMENT_DETAIL_Insert(PROVIDER_PAYMENT_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_DETAIL_Insert",
                    obj.ID,
                    obj.PaymentID,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FAmount,
                    obj.FDebit,
                    obj.FPayment,
                    obj.FDiscount,
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
        public int PROVIDER_PAYMENT_DETAIL_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_DETAIL_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PROVIDER_PAYMENT_Delete2011(Guid ID, string RefOrgNo)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_Delete2011", ID, RefOrgNo);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public PROVIDER_PAYMENT_DETAIL PROVIDER_PAYMENT_DETAIL_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_DETAIL_Get", ID);
                return MapPROVIDER_PAYMENT_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROVIDER_PAYMENT_DETAIL PROVIDER_PAYMENT_DETAIL_GetbyPaymentID(Guid PaymentID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_DETAIL_GetbyRefID", PaymentID);
                return MapPROVIDER_PAYMENT_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PROVIDER_PAYMENT_DETAIL> PROVIDER_PAYMENT_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_DETAIL_GetList");
                return MapPROVIDER_PAYMENT_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROVIDER_PAYMENT_DETAIL_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_DETAIL_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public List<PROVIDER_PAYMENT_DETAIL> PROVIDER_PAYMENT_DETAIL_Search(PROVIDER_PAYMENT_DETAIL obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_DETAIL_Search",
                    obj.RefOrgNo ,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FAmount,
                    obj.FDebit,
                    obj.FPayment,
                    obj.FDiscount,
                    obj.Description
                    );
                return MapPROVIDER_PAYMENT_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROVIDER_PAYMENT_DETAIL_Update(PROVIDER_PAYMENT_DETAIL obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_DETAIL_Update",
                    ID,
                    obj.PaymentID,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FAmount,
                    obj.FDebit,
                    obj.FPayment,
                    obj.FDiscount,
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
        public int PROVIDER_PAYMENT_DETAIL_UpdateById(PROVIDER_PAYMENT_DETAIL obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_DETAIL_UpdateById",
                    ID,
                    obj.PaymentID,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FAmount,
                    obj.FDebit,
                    obj.FPayment,
                    obj.FDiscount,
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

    }
}
