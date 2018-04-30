using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesManager.Entity;
using System.Data;
using MicrosoftHelper;

namespace SalesManager.Controller
{
    public class INBOUND_DELIVERYController
    {
        private List<INBOUND_DELIVERY> MapINBOUND_DELIVERY(DataTable dt)
        {
            List<INBOUND_DELIVERY> rs = new List<INBOUND_DELIVERY>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                INBOUND_DELIVERY obj = new INBOUND_DELIVERY();
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
                if (dt.Columns.Contains("Status"))
                    obj.Status = int.Parse(dt.Rows[i]["Status"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = new Guid(dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("TermID"))
                    obj.TermID = dt.Rows[i]["TermID"].ToString();
                if (dt.Columns.Contains("PaymentDate"))
                    obj.PaymentDate = DateTime.Parse(dt.Rows[i]["PaymentDate"].ToString());
                if (dt.Columns.Contains("DeliveryDate"))
                    obj.DeliveryDate = DateTime.Parse(dt.Rows[i]["DeliveryDate"].ToString());
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
                    obj.Payment = int.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Vat"))
                    obj.Vat = int.Parse(dt.Rows[i]["Vat"].ToString());
                if (dt.Columns.Contains("VatAmount"))
                    obj.VatAmount = double.Parse(dt.Rows[i]["VatAmount"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("DiscountDate"))
                    obj.DiscountDate = DateTime.Parse(dt.Rows[i]["DiscountDate"].ToString());
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
                    obj.Sorted = int.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                if (dt.Columns.Contains("CreatedBy"))
                    obj.CreatedBy = dt.Rows[i]["CreatedBy"].ToString();
                if (dt.Columns.Contains("CreatedDate"))
                    obj.CreatedDate = DateTime.Parse(dt.Rows[i]["CreatedDate"].ToString());
                if (dt.Columns.Contains("ModifiedBy"))
                    obj.ModifiedBy = dt.Rows[i]["ModifiedBy"].ToString();
                if (dt.Columns.Contains("ModifiedDate"))
                    obj.ModifiedDate = DateTime.Parse(dt.Rows[i]["ModifiedDate"].ToString());
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
        public int INBOUND_DELIVERY_Insert(INBOUND_DELIVERY obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "INBOUND_DELIVERY_Insert",
                    obj.ID
                   , obj.RefDate
                   , obj.Ref_OrgNo
                   , obj.RefType
                   , obj.RefStatus
                   , obj.Status
                   , obj.PaymentMethod
                   , obj.TermID
                   , obj.PaymentDate
                   , obj.DeliveryDate
                   , obj.Barcode
                   , obj.Department_ID
                   , obj.Employee_ID
                   , obj.Stock_ID
                   , obj.Branch_ID
                   , obj.Contract_ID
                   , obj.Customer_ID
                   , obj.CustomerName
                   , obj.CustomerAddress
                   , obj.Contact
                   , obj.Reason
                   , obj.Payment
                   , obj.Currency_ID
                   , obj.ExchangeRate
                   , obj.Vat
                   , obj.VatAmount
                   , obj.Amount
                   , obj.FAmount
                   , obj.DiscountDate
                   , obj.DiscountRate
                   , obj.Discount
                   , obj.OtherDiscount
                   , obj.Charge
                   , obj.IsClose
                   , obj.Description
                   , obj.Sorted
                   , obj.User_ID
                   , obj.CreatedDate
                   , obj.CreatedBy
                   , obj.ModifiedDate
                   , obj.ModifiedBy
                   , obj.Active
                   , obj.LastEditDate
                   , obj.CreationDate
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public string INBOUND_DELIVERY_Search(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "INBOUND_DELIVERY_Search", "%" + UserName + "%");
                return (dt.Rows[0]["ID"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ProductOrder_Search(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ProductOrder_Search", "%" + UserName + "%");
                return (dt.Rows[0]["HoaDon"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
