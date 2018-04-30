using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class DEBTController
    {
        private List<DEBT> MapDEBT(DataTable dt)
        {
            List<DEBT> rs = new List<DEBT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DEBT obj = new DEBT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = new Guid( dt.Rows[i]["ID"].ToString());
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                //if (dt.Columns.Contains("RefOrgNo"))
                    //obj.RefOrgNo = new Guid( dt.Rows[i]["RefOrgNo"].ToString());
                if (dt.Columns.Contains("RefType"))
                    obj.RefType =int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = new Guid( dt.Rows[i]["PaymentMethod"].ToString());
                if (dt.Columns.Contains("CustomerID"))
                    obj.CustomerID = dt.Rows[i]["CustomerID"].ToString();
                if (dt.Columns.Contains("ProductID"))
                    obj.ProductID = dt.Rows[i]["ProductID"].ToString();
                if (dt.Columns.Contains("ProductName"))
                    obj.ProductName = dt.Rows[i]["ProductName"].ToString();
                if (dt.Columns.Contains("CurrencyID"))
                    obj.CurrencyID = dt.Rows[i]["CurrencyID"].ToString();
                if (dt.Columns.Contains("ExchangeRate"))
                    obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("TermID"))
                    obj.TermID = dt.Rows[i]["TermID"].ToString();
                if (dt.Columns.Contains("DueDate"))
                    obj.DueDate = DateTime.Parse(dt.Rows[i]["DueDate"].ToString());
                if (dt.Columns.Contains("Quantity"))
                    obj.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                if (dt.Columns.Contains("ReQuantity"))
                    obj.ReQuantity = double.Parse(dt.Rows[i]["ReQuantity"].ToString());
                if (dt.Columns.Contains("Price"))
                    obj.Price = double.Parse(dt.Rows[i]["Price"].ToString());
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Payment"))
                    obj.Payment = double.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("Balance"))
                    obj.Balance = double.Parse(dt.Rows[i]["Balance"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("IsChanged"))
                    obj.IsChanged = bool.Parse(dt.Rows[i]["IsChanged"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = (dt.Rows[i]["Description"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int DEBT_Insert(DEBT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_Insert",
                    obj.ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.CustomerID,
                    obj.ProductID,
                    obj.ProductName,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.TermID,
                    obj.DueDate,
                    obj.Quantity,
                    obj.ReQuantity,
                    obj.Price,
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.IsChanged,
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
        public DEBT DEBT_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_Get", ID);
                return MapDEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DEBT DEBT_GETCredit(string CustomerID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GETCredit", CustomerID);
                return MapDEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DEBT_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public int DEBT_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        public DEBT DEBT_GETDebit(string CustomerID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GETDebit", CustomerID);
                return MapDEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DEBT DEBT_GetbyRefID(string RefID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GetbyRefID", RefID);
                return MapDEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DEBT> DEBT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GetList");
                return MapDEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DEBT_NotDebtNote(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_NotDebtNote", From,To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DEBT_GetbyRefType(int RefType, string  MaKhuVuc)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GetbyRefType", RefType, MaKhuVuc);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DEBT_GetbyRefTypeNCC(int RefType, string MaKhuVuc)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_GetbyRefTypeNCC", RefType, MaKhuVuc);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Debt_CongNoThu(DateTime FromDate, DateTime ToDate, string Customer_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Debt_CongNoThu", FromDate, ToDate, Customer_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Debt_CongNoTra(DateTime FromDate, DateTime ToDate, string Customer_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Debt_CongNoTra", FromDate, ToDate, Customer_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DEBT> DEBT_Search(DEBT obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "DEBT_Search",
                    obj.RefDate ,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.ProductName,
                    obj.ExchangeRate,
                    obj.DueDate,
                    obj.Quantity,
                    obj.ReQuantity,
                    obj.Price,
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.IsChanged,
                    obj.Description
                    );
                return MapDEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DEBT_Update(DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_Update",
                    new Guid(ID),
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.CustomerID,
                    obj.ProductID,
                    obj.ProductName,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.TermID,
                    obj.DueDate,
                    obj.Quantity,
                    obj.ReQuantity,
                    obj.Price,
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.IsChanged,
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
        public int DEBT_UpdateById(DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_UpdateById",
                    ID,
                    obj.RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.CustomerID,
                    obj.ProductID,
                    obj.ProductName,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.TermID,
                    obj.DueDate,
                    obj.Quantity,
                    obj.ReQuantity,
                    obj.Price,
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.IsChanged,
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
        public int DEBT_UpdateByRefId(DEBT obj, string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "DEBT_UpdateByRefId",
                    obj.ID,
                    RefID,
                    obj.RefDate,
                    obj.RefOrgNo,
                    obj.RefType,
                    obj.RefStatus,
                    obj.PaymentMethod,
                    obj.CustomerID,
                    obj.ProductID,
                    obj.ProductName,
                    obj.CurrencyID,
                    obj.ExchangeRate,
                    obj.TermID,
                    obj.DueDate,
                    obj.Quantity,
                    obj.ReQuantity,
                    obj.Price,
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.IsChanged,
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
        public DataTable GET_DEBTDETAIL(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "GET_DEBTDETAIL", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GET_DebtSummaryDetail(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "GET_DebtSummaryDetail", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GET_DEBTSummaryDetailsProv(DateTime From, DateTime To)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "GET_DEBTSummaryDetailsProv", From, To);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
