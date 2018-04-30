using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_INWARDController
    {
        private List<STOCK_INWARD> MapSTOCK_INWARD(DataTable dt)
        {
            List<STOCK_INWARD> rs = new List<STOCK_INWARD>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK_INWARD obj = new STOCK_INWARD();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("Ref_OrgNo"))
                    obj.Ref_OrgNo = dt.Rows[i]["Ref_OrgNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = new Guid(dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("TermID"))
                    obj.TermID = dt.Rows[i]["TermID"].ToString();
                if (dt.Columns.Contains("PaymentDate"))
                    obj.PaymentDate = DateTime.Parse(dt.Rows[i]["PaymentDate"].ToString());
                if (dt.Columns.Contains("DeliveryDate"))
                    obj.DeliveryDate =DateTime.Parse(dt.Rows[i]["DeliveryDate"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = dt.Rows[i]["Department_ID"].ToString();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("Stock_ID"))
                    obj.Stock_ID = dt.Rows[i]["Stock_ID"].ToString();
                if (dt.Columns.Contains("Branch_ID"))
                    obj.Branch_ID = dt.Rows[i]["Branch_ID"].ToString();
                if (dt.Columns.Contains("Contract_ID"))
                    obj.Contract_ID = dt.Rows[i]["Contract_ID"].ToString();
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("CustomerName"))
                    obj.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                if (dt.Columns.Contains("CustomerAddress"))
                    obj.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                if (dt.Columns.Contains("Contact"))
                    obj.Contact = dt.Rows[i]["Contact"].ToString();
                if (dt.Columns.Contains("Reason"))
                    obj.Reason = dt.Rows[i]["Reason"].ToString();
                if (dt.Columns.Contains("Payment"))
                    obj.Payment =int.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate =double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Vat"))
                    obj.Vat = int.Parse(dt.Rows[i]["Vat"].ToString());
                if (dt.Columns.Contains("VatAmount"))
                    obj.VatAmount =double.Parse(dt.Rows[i]["VatAmount"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount =double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount =double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("DiscountDate"))
                    obj.DiscountDate =DateTime.Parse(dt.Rows[i]["DiscountDate"].ToString());
                if (dt.Columns.Contains("DiscountRate"))
                    obj.DiscountRate = double.Parse(dt.Rows[i]["DiscountRate"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("OtherDiscount"))
                    obj.OtherDiscount = double.Parse(dt.Rows[i]["OtherDiscount"].ToString());
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted =int.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                //if (dt.Columns.Contains("Timestamp"))
                    //obj.Timestamp = DateTime.Parse(dt.Rows[i]["Timestamp"].ToString());
                if (dt.Columns.Contains("LastEditDate"))
                    obj.LastEditDate = DateTime.Parse(dt.Rows[i]["LastEditDate"].ToString());
                if (dt.Columns.Contains("CreationDate"))
                    obj.CreationDate = DateTime.Parse(dt.Rows[i]["CreationDate"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_INWARD_Insert(STOCK_INWARD obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_Insert",
                    obj.ID,
	                obj.RefDate,
	                obj.Ref_OrgNo,
	                obj.RefType,
	                obj.PaymentMethod,
	                obj.TermID,
		            obj.PaymentDate,
		            obj.DeliveryDate,
	                obj.Barcode,
	                obj.Department_ID,
	                obj.Employee_ID,
	                obj.Stock_ID,
	                obj.Branch_ID,
	                obj.Contract_ID,
	                obj.Customer_ID,
	                obj.CustomerName,
	                obj.CustomerAddress,
	                obj.Contact,
	                obj.Reason,
	                obj.Payment,
	                obj.Currency_ID,
	                obj.ExchangeRate,
	                obj.Vat,
	                obj.VatAmount,
	                obj.Amount,
	                obj.FAmount,
	                obj.DiscountDate, 
	                obj.DiscountRate, 
	                obj.Discount,
	                obj.OtherDiscount,
	                obj.Charge,
	                obj.IsClose,
	                obj.Description,
	                obj.Sorted,
	                obj.User_ID,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public STOCK_INWARD STOCK_INWARD_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_Get", ID);
                return MapSTOCK_INWARD(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_GetList_ByDate", FromDate,ToDate, MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable sp_DEBT_GetInfoForProvider()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "sp_DEBT_GetInfoForProvider");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_INWARD> STOCK_INWARD_GetPurchaseID(string Purchase_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_GetPurchaseID", Purchase_ID);
                return MapSTOCK_INWARD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string STOCK_INWARD_Exist(string ID)
        {
            DataTable dt = new DataTable();
            string test = "";
            try
            {
                 DataProvider.FillDataTable(DataProvider.ConnectionString,dt, "STOCK_INWARD_Exist", ID);
                 return MapSTOCK_INWARD(dt)[0].ID;
            }
            catch (Exception ex)
            {
                return test;
            }
        }
        public string SaleOrder_Search(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "SaleOrder_Search", "%" + UserName + "%");
                return (dt.Rows[0]["ID"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_INWARD_GetbyRefType(int ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_GetbyRefType", ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_INWARD> STOCK_INWARD_Search(STOCK_INWARD obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_INWARD_Search", 
                    obj.RefDate ,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.Barcode,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.Contact,
                    obj.Reason,
                    obj.Payment,
                    obj.ExchangeRate,
                    obj.Vat,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.Charge,
                    obj.IsClose,
                    obj.Description
                    );
                return MapSTOCK_INWARD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_INWARD_Update(STOCK_INWARD obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_Update",
                    ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.PaymentMethod,
                    obj.TermID,
                    obj.PaymentDate,
                    obj.DeliveryDate,
                    obj.Barcode,
                    obj.Department_ID,
                    obj.Employee_ID,
                    obj.Stock_ID,
                    obj.Branch_ID,
                    obj.Contract_ID,
                    obj.Customer_ID,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.Contact,
                    obj.Reason,
                    obj.Payment,
                    obj.Currency_ID,
                    obj.ExchangeRate,
                    obj.Vat,
                    obj.VatAmount,
                    obj.Amount,
                    obj.FAmount,
                    obj.DiscountDate,
                    obj.DiscountRate,
                    obj.Discount,
                    obj.OtherDiscount,
                    obj.Charge,
                    obj.IsClose,
                    obj.Description,
                    obj.Sorted,
                    obj.User_ID,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_INWARD_Update_RefStatus(string STOCK_INWARD_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_Update_RefStatus", STOCK_INWARD_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_INWARD_UpdateById(STOCK_INWARD obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_UpdateById",
                    ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.Barcode,
                    obj.Department_ID,
                    obj.Employee_ID,
                    obj.Stock_ID,
                    obj.Branch_ID,
                    obj.Contract_ID,
                    obj.Customer_ID,
                    obj.CustomerName,
                    obj.CustomerAddress,
                    obj.Contact,
                    obj.Reason,
                    obj.Payment,
                    obj.Currency_ID,
                    obj.ExchangeRate,
                    obj.Vat,
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.Charge,
                    obj.IsClose,
                    obj.Description,
                    obj.User_ID,
                    obj.Active 
                    );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_INWARD_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_INWARD_DeletePurchase(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_INWARD_DeletePurchase", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
    }
}
