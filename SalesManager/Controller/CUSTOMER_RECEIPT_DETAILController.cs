using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class CUSTOMER_RECEIPT_DETAILController
    {
        private List<CUSTOMER_RECEIPT_DETAIL> MapCUSTOMER_RECEIPT_DETAIL(DataTable dt)
        {
            List<CUSTOMER_RECEIPT_DETAIL> rs = new List<CUSTOMER_RECEIPT_DETAIL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CUSTOMER_RECEIPT_DETAIL obj = new CUSTOMER_RECEIPT_DETAIL();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid( dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("ReceiptID"))
                    obj.ReceiptID = new Guid( dt.Rows[i]["ReceiptID"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = new Guid(dt.Rows[i]["RefOrgNo"].ToString());
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
                if (dt.Columns.Contains("FDebit"))
                    obj.FDebit = double.Parse(dt.Rows[i]["FDebit"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = int.Parse(dt.Rows[i]["Sorted"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int ThemCUSTOMER_RECEIPT_DETAIL(CUSTOMER_RECEIPT_DETAIL obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_DETAIL_Insert",
                    obj.ID,
                    obj.ReceiptID,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FDebit,
                    obj.FAmount,
                    obj.FDiscount,
                    obj.Description,
                    obj.Sorted
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int XoaCUSTOMER_RECEIPT_DETAIL(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_DETAIL_Delete", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CUSTOMER_RECEIPT_DETAIL LayTenCUSTOMER_RECEIPT_DETAIL(string CUSTOMER_RECEIPT_DETAIL_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_DETAIL_Get", CUSTOMER_RECEIPT_DETAIL_ID);
                return MapCUSTOMER_RECEIPT_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CUSTOMER_RECEIPT_DETAIL CUSTOMER_RECEIPT_DETAIL_GetbyReceiptID(Guid obj_guidReceiptID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_DETAIL_GetbyReceiptID", obj_guidReceiptID);
                return MapCUSTOMER_RECEIPT_DETAIL(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CUSTOMER_RECEIPT_DETAIL> LayDSCUSTOMER_RECEIPT_DETAIL()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_DETAIL_GetList");
                return MapCUSTOMER_RECEIPT_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CheckCUSTOMER_RECEIPT_DETAIL(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_DETAIL_Exist", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CUSTOMER_RECEIPT_DETAIL> SearchDSCUSTOMER_RECEIPT_DETAIL(CUSTOMER_RECEIPT_DETAIL obj)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_DETAIL_Search",
                        obj.RefOrgNo ,
                        obj.ExchangeRate,
                        obj.Quantity,
                        obj.Amount,
                        obj.Debit,
                        obj.Payment,
                        obj.DiscountPercent,
                        obj.Discount,
                        obj.FDebit,
                        obj.FAmount,
                        obj.FDiscount,
                        obj.Description 
                    );
                return MapCUSTOMER_RECEIPT_DETAIL(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CapNhatCUSTOMER_RECEIPT_DETAIL(CUSTOMER_RECEIPT_DETAIL obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_DETAIL_Update", ID,
                    obj.ReceiptID ,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FDebit,
                    obj.FAmount,
                    obj.FDiscount,
                    obj.Description,
                    obj.Sorted 
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CapNhatCUSTOMER_RECEIPT_DETAILbyID(CUSTOMER_RECEIPT_DETAIL obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_DETAIL_UpdateById", ID,
                    obj.ReceiptID ,
                    obj.RefOrgNo,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.Quantity,
                    obj.Amount,
                    obj.Debit,
                    obj.Payment,
                    obj.DiscountPercent,
                    obj.Discount,
                    obj.FDebit,
                    obj.FAmount,
                    obj.FDiscount,
                    obj.Description
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
