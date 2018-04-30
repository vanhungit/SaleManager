using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_OUTWARDController
    {
        private List<STOCK_OUTWARD> MapSTOCK_OUTWARD(DataTable dt)
        {
            List<STOCK_OUTWARD> rs = new List<STOCK_OUTWARD>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK_OUTWARD obj = new STOCK_OUTWARD();
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
                    obj.Amount =double.Parse(dt.Rows[i]["Amount"].ToString());
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
                if (dt.Columns.Contains("Charge"))
                    obj.Charge = double.Parse(dt.Rows[i]["Charge"].ToString());
                if (dt.Columns.Contains("Cost"))
                    obj.Cost = double.Parse(dt.Rows[i]["Cost"].ToString());
                if (dt.Columns.Contains("Profit"))
                    obj.Profit = double.Parse(dt.Rows[i]["Profit"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());
                //if (dt.Columns.Contains("Timestamp"))
                    //obj.Timestamp = DateTime.Parse(dt.Rows[i]["Timestamp"].ToString());
                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_OUTWARD_Insert(STOCK_OUTWARD obj)//Lưu ý Current_ID không được null
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_Insert",
                    obj.ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.RefStatus,
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
                    obj.Cost,
                    obj.Profit,
                    obj.User_ID,
                    obj.IsClose,
                    obj.Sorted,
                    obj.Description,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public void STOCK_OUTWARD_Insert_Test(STOCK_OUTWARD obj)
        {
            try
            {
                 DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_Insert_Test",
                    obj.ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.RefStatus,
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
                    obj.Cost,
                    obj.Profit,
                    obj.User_ID,
                    obj.IsClose,
                    obj.Sorted,
                    obj.Description,
                    obj.Active
                );
            }
            catch(Exception ex)
            {
               throw ex;
                //return -1;
            }
        }
        public int STOCK_OUTWARD_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_DeleteSale(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_DeleteSale", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }

        public string STOCK_OUTWARD_Exist(string ID)
        {
            DataTable dt = new DataTable();
            string test = "";
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_Exist", ID);
                 return MapSTOCK_OUTWARD(dt)[0].ID;
            }
            catch (Exception ex)
            {
                return test;
            }
        }
        public STOCK_OUTWARD STOCK_OUTWARD_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_Get", ID);
                return MapSTOCK_OUTWARD(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string HoaDon_Search(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "HoaDon_Search", "%" + UserName + "%");
                return (dt.Rows[0]["HoaDon"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_OUTWARD_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_GetList_ByDate", FromDate, ToDate, MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyCustomerGroup(DateTime FromDate, DateTime ToDate, string Customer_Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyCustomerGroup", FromDate, ToDate, Customer_Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyCustomerID(DateTime FromDate, DateTime ToDate, string Customer_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyCustomerID", FromDate, ToDate, Customer_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyStockID(DateTime FromDate, DateTime ToDate, string Stock_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyStockID", FromDate, ToDate, Stock_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyProduct_Group(DateTime FromDate, DateTime ToDate, string Product_Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyProduct_Group", FromDate, ToDate, Product_Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DELIVERY_ORDER_GetList()
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DELIVERY_ORDER_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyProduct_ID(DateTime FromDate, DateTime ToDate, string Product_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyProduct_ID", FromDate, ToDate, Product_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Report_ProfitbyInvoice(string ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Report_ProfitbyInvoice", ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable STOCK_OUTWARD_GetList_ByDate_Action(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_GetList_ByDate_Action", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public STOCK_OUTWARD STOCK_OUTWARD_GetSaleID(string SaleID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_GetSaleID", SaleID);
                return MapSTOCK_OUTWARD(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_OUTWARD> STOCK_OUTWARD_Search(STOCK_OUTWARD obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_OUTWARD_Search",
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
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.Charge,
                    obj.Cost,
                    obj.Profit,
                    obj.IsClose,
                    obj.Description 
                    );
                return MapSTOCK_OUTWARD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_OUTWARD_Update(STOCK_OUTWARD obj,string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_Update",
                    ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.RefStatus,
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
                    obj.Cost,
                    obj.Profit,
                    obj.User_ID,
                    obj.IsClose,
                    obj.Sorted,
                    obj.Description,
                    obj.Active
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_Update_RefStatus(string STOCK_OUTWARD_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_Update_RefStatus", STOCK_OUTWARD_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int STOCK_OUTWARD_UpdateById(STOCK_OUTWARD obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_OUTWARD_UpdateById",
                    ID,
                    obj.RefDate ,
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
                    obj.Amount,
                    obj.FAmount,
                    obj.Discount,
                    obj.Charge,
                    obj.Cost,
                    obj.Profit,
                    obj.User_ID,
                    obj.IsClose,
                    obj.Description,
                    obj.Active 
                );
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public List<STOCK_OUTWARD> STOCK_GetSales()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_GetSales");
                return MapSTOCK_OUTWARD(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
