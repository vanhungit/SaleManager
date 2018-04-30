using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiBanHang.Entity;
using System.Data;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class CUSTOMER_RECEIPTController
    {
        private List<CUSTOMER_RECEIPT> MapCUSTOMER_RECEIPT(DataTable dt)
        {
            List<CUSTOMER_RECEIPT> rs = new List<CUSTOMER_RECEIPT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CUSTOMER_RECEIPT obj = new CUSTOMER_RECEIPT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid(dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = dt.Rows[i]["RefOrgNo"].ToString();
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = new Guid(dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = dt.Rows[i]["CurrencyID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
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
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("Reconciled"))
                    obj.Reconciled = bool.Parse(dt.Rows[i]["Reconciled"].ToString());
                if (dt.Columns.Contains("IsPublic"))
                    obj.IsPublic =bool.Parse(dt.Rows[i]["IsPublic"].ToString());
                if (dt.Columns.Contains("CreatedBy"))
                    obj.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                if (dt.Columns.Contains("CreatedDate"))
                    obj.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
                if (dt.Columns.Contains("OwnerID"))
                    obj.OwnerID = dt.Rows[i]["OwnerID"].ToString();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ThemCUSTOMER_RECEIPT(CUSTOMER_RECEIPT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Insert",
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CUSTOMER_RECEIPT_ID"></param>
        /// <returns></returns>
        public int XoaCUSTOMER_RECEIPT(Guid CUSTOMER_RECEIPT_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Delete", CUSTOMER_RECEIPT_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CUSTOMER_RECEIPT_Delete2011(Guid CUSTOMER_RECEIPT_ID, string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Delete2011", CUSTOMER_RECEIPT_ID, RefID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CUSTOMER_RECEIPT_ID"></param>
        /// <returns></returns>
        public CUSTOMER_RECEIPT LayTTCUSTOMER_RECEIPT(string CUSTOMER_RECEIPT_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_Get", CUSTOMER_RECEIPT_ID);
                return MapCUSTOMER_RECEIPT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CUSTOMER_RECEIPT CUSTOMER_Top1RefID(string OwnerID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_Top1RefID", OwnerID);
                return MapCUSTOMER_RECEIPT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CUSTOMER_RECEIPT CUSTOMER_RECEIPT_GetbyRefID(string RefID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_GetbyRefID", RefID);
                return MapCUSTOMER_RECEIPT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CUSTOMER_RECEIPT> LayDSCUSTOMER_RECEIPT()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_GetList");
                return MapCUSTOMER_RECEIPT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<CUSTOMER_RECEIPT> SearchDSCUSTOMER_DEBT(CUSTOMER_RECEIPT obj)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "CUSTOMER_RECEIPT_Search",
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
                return MapCUSTOMER_RECEIPT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int CheckCUSTOMER_RECEIPT(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Exist", ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RefID"></param>
        /// <returns></returns>
        public int CheckCUSTOMER_RECEIPT_ExistByID(string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_ExistByID", RefID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int CapNhatCUSTOMER_RECEIPT(CUSTOMER_RECEIPT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Update",
                    ID ,
                    obj.RefID ,
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int CapNhatCUSTOMER_RECEIPTByID(CUSTOMER_RECEIPT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "CUSTOMER_RECEIPT_Update",
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
                    obj.Description,
                    obj.Active
                     );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
