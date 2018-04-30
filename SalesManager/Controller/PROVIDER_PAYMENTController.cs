using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PROVIDER_PAYMENTController
    {
        private List<PROVIDER_PAYMENT> MapPROVIDER_PAYMENT(DataTable dt)
        {
            List<PROVIDER_PAYMENT> rs = new List<PROVIDER_PAYMENT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PROVIDER_PAYMENT obj = new PROVIDER_PAYMENT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate =DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = dt.Rows[i]["RefOrgNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus =int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = new Guid( dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = dt.Rows[i]["CurrencyID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate =double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("BranchID"))
                    obj.BranchID = dt.Rows[i]["BranchID"].ToString();
                if (dt.Columns.Contains("ContractID"))
                    obj.ContractID = dt.Rows[i]["ContractID"].ToString();
                if (dt.Columns.Contains("CustomerID"))
                    obj.CustomerID = dt.Rows[i]["CustomerID"].ToString();
                if (dt.Columns.Contains("CustomerName"))
                    obj.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                if (dt.Columns.Contains("CustomerAddress"))
                    obj.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                if (dt.Columns.Contains("CustomerTax"))
                    obj.CustomerTax = dt.Rows[i]["CustomerTax"].ToString();
                if (dt.Columns.Contains("ContactName"))
                    obj.ContactName = dt.Rows[i]["ContactName"].ToString();
                if (dt.Columns.Contains("Amount"))
                    obj.Amount =double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount =double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("Reconciled"))
                    obj.Reconciled = bool.Parse(dt.Rows[i]["Reconciled"].ToString());
                if (dt.Columns.Contains("IsPublic"))
                    obj.IsPublic = bool.Parse(dt.Rows[i]["IsPublic"].ToString());
                if (dt.Columns.Contains("CreatedBy"))
                    obj.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                if (dt.Columns.Contains("CreatedDate"))
                    obj.CreatedDate =DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                if (dt.Columns.Contains("OwnerID"))
                    obj.OwnerID = dt.Rows[i]["OwnerID"].ToString();
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted =long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active =bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int PROVIDER_PAYMENT_Insert(PROVIDER_PAYMENT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_Insert",
                    obj.ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.Barcode,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.BranchID,
                    obj.ContractID,
                    obj.CustomerID,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.CustomerTax,
                    obj.ContactName,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.FDiscount,
                    obj.Reconciled,
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
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PROVIDER_PAYMENT_Delete(Guid ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_Delete", ID);
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
        public int PROVIDER_PAYMENT_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PROVIDER_PAYMENT_ExistByID(string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_ExistByID", RefID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public PROVIDER_PAYMENT PROVIDER_PAYMENT_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_Get", ID);
                return MapPROVIDER_PAYMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROVIDER_PAYMENT PROVIDER_PAYMENT_GetbyRefID(string RefID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_GetbyRefID", RefID);
                return MapPROVIDER_PAYMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROVIDER_PAYMENT PROVIDER_PAYMENT_Top1RefID(string OwnerID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_Top1RefID", OwnerID);
                return MapPROVIDER_PAYMENT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PROVIDER_PAYMENT> PROVIDER_PAYMENT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_GetList");
                return MapPROVIDER_PAYMENT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PROVIDER_PAYMENT> PROVIDER_PAYMENT_Search(PROVIDER_PAYMENT obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_PAYMENT_Search",
                    obj.RefDate ,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.Barcode,
                    obj.ExchangeRate,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.CustomerTax,
                    obj.ContactName,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.FDiscount,
                    obj.Reconciled,
                    obj.Description
                    );
                return MapPROVIDER_PAYMENT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PROVIDER_PAYMENT_Update(PROVIDER_PAYMENT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_Update",
                    ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.Barcode,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.BranchID,
                    obj.ContractID,
                    obj.CustomerID,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.CustomerTax,
                    obj.ContactName,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.FDiscount,
                    obj.Reconciled,
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
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int PROVIDER_PAYMENT_UpdateById(PROVIDER_PAYMENT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_PAYMENT_UpdateById",
                    ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.Barcode,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.BranchID,
                    obj.ContractID,
                    obj.CustomerID,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.CustomerTax,
                    obj.ContactName,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.FDiscount,
                    obj.Reconciled,
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
            catch
            {
                //throw ex;
                return -1;
            }
        }
    }
}
