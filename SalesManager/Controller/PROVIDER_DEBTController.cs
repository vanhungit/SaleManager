using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PROVIDER_DEBTController
    {
        private List<PROVIDER_DEBT> MapPROVIDER_DEBT(DataTable dt)
        {
            List<PROVIDER_DEBT> rs = new List<PROVIDER_DEBT>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PROVIDER_DEBT obj = new PROVIDER_DEBT();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("RefOrgNo"))
                    obj.RefOrgNo = dt.Rows[i]["RefOrgNo"].ToString();
                if (dt.Columns.Contains("RefID"))
                    obj.RefID = dt.Rows[i]["RefID"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType =int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("RefStatus"))
                    obj.RefStatus = int.Parse(dt.Rows[i]["RefStatus"].ToString());
                if (dt.Columns.Contains("PaymentMethod"))
                    obj.PaymentMethod = dt.Rows[i]["PaymentMethod"].ToString();
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
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("Payment"))
                    obj.Payment = double.Parse(dt.Rows[i]["Payment"].ToString());
                if (dt.Columns.Contains("Balance"))
                    obj.Balance = double.Parse(dt.Rows[i]["Balance"].ToString());
                if (dt.Columns.Contains("FAmount"))
                    obj.FAmount = double.Parse(dt.Rows[i]["FAmount"].ToString());
                if (dt.Columns.Contains("FPayment"))
                    obj.FPayment = double.Parse(dt.Rows[i]["FPayment"].ToString());
                if (dt.Columns.Contains("FBalance"))
                    obj.FBalance = double.Parse(dt.Rows[i]["FBalance"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                if (dt.Columns.Contains("FDiscount"))
                    obj.FDiscount = double.Parse(dt.Rows[i]["FDiscount"].ToString());
                if (dt.Columns.Contains("IsChanged"))
                    obj.IsChanged = bool.Parse(dt.Rows[i]["IsChanged"].ToString());
                if (dt.Columns.Contains("IsPublic"))
                    obj.IsPublic = bool.Parse(dt.Rows[i]["IsPublic"].ToString());
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
        /// Thêm công nợ nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_Insert(PROVIDER_DEBT obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_Insert",
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
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.FPayment,
                    obj.FBalance,
                    obj.Discount,
                    obj.FDiscount,
                    obj.IsChanged,
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
        /// <summary>
        /// xóa công nợ khách hàng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// check tồn tại công nợ nhà cung cấp
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_Exist(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_Exist", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// check tồn tại công nợ nhà cung cấp
        /// </summary>
        /// <param name="RefID"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_ExistByID(string RefID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_ExistByID", RefID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Lấy thông tin công nợ nhà cung cấp theo mã nhà cung cấp
        /// </summary>
        /// <param name="Customer_ID"></param>
        /// <returns></returns>
        public PROVIDER_DEBT PROVIDER_DEBT_Get(string Customer_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_DEBT_Get", Customer_ID);
                return MapPROVIDER_DEBT(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách công nợ nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public List<PROVIDER_DEBT> PROVIDER_DEBT_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_DEBT_GetList");
                return MapPROVIDER_DEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách công nợ nhà cung cấp thông qua mã khu vực
        /// </summary>
        /// <param name="Customer_Group_ID"></param>
        /// <returns></returns>
        public DataTable PROVIDER_DEBT_GetListInit(string Customer_Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_DEBT_GetListInit", Customer_Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm công nợ nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<PROVIDER_DEBT> PROVIDER_DEBT_Search(PROVIDER_DEBT obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_Search", 
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
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.FPayment,
                    obj.FBalance,
                    obj.Discount,
                    obj.FDiscount,
                    obj.IsChanged,
                    obj.Description
                    );
                return MapPROVIDER_DEBT(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// cập nhật công nợ nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_Update(PROVIDER_DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_Update",
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
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.FPayment,
                    obj.FBalance,
                    obj.Discount,
                    obj.FDiscount,
                    obj.IsChanged,
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
        /// <summary>
        /// cập nhật công nợ nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int PROVIDER_DEBT_UpdateById(PROVIDER_DEBT obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_DEBT_UpdateById",
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
                    obj.Amount,
                    obj.Payment,
                    obj.Balance,
                    obj.FAmount,
                    obj.FPayment,
                    obj.FBalance,
                    obj.Discount,
                    obj.FDiscount,
                    obj.IsChanged,
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
