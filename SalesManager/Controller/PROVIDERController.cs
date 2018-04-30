using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class PROVIDERController
    {
        private List<PROVIDER> MapPROVIDER(DataTable dt)
        {
            List<PROVIDER> rs = new List<PROVIDER>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                PROVIDER obj = new PROVIDER();
                if (dt.Columns.Contains("Customer_ID"))
                    obj.Customer_ID = dt.Rows[i]["Customer_ID"].ToString();
                if (dt.Columns.Contains("OrderID"))
                    obj.OrderID = long.Parse(dt.Rows[i]["OrderID"].ToString());
                if (dt.Columns.Contains("CustomerName"))
                    obj.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                if (dt.Columns.Contains("Customer_Type_ID"))
                    obj.Customer_Type_ID = dt.Rows[i]["Customer_Type_ID"].ToString();
                if (dt.Columns.Contains("Customer_Group_ID"))
                    obj.Customer_Group_ID = dt.Rows[i]["Customer_Group_ID"].ToString();
                if (dt.Columns.Contains("CustomerAddress"))
                    obj.CustomerAddress = dt.Rows[i]["CustomerAddress"].ToString();
                if (dt.Columns.Contains("Birthday"))
                    obj.Birthday = dt.Rows[i]["Birthday"].ToString();
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("Tax"))
                    obj.Tax = dt.Rows[i]["Tax"].ToString();
                if (dt.Columns.Contains("Tel"))
                    obj.Tel = dt.Rows[i]["Tel"].ToString();
                if (dt.Columns.Contains("Fax"))
                    obj.Fax = dt.Rows[i]["Fax"].ToString();
                if (dt.Columns.Contains("Email"))
                    obj.Email = dt.Rows[i]["Email"].ToString();
                if (dt.Columns.Contains("Mobile"))
                    obj.Mobile = dt.Rows[i]["Mobile"].ToString();
                if (dt.Columns.Contains("Website"))
                    obj.Website = dt.Rows[i]["Website"].ToString();
                if (dt.Columns.Contains("Contact"))
                    obj.Contact = dt.Rows[i]["Contact"].ToString();
                if (dt.Columns.Contains("Position"))
                    obj.Position = dt.Rows[i]["Position"].ToString();
                if (dt.Columns.Contains("NickYM"))
                    obj.NickYM = dt.Rows[i]["NickYM"].ToString();
                if (dt.Columns.Contains("NickSky"))
                    obj.NickSky = dt.Rows[i]["NickSky"].ToString();
                if (dt.Columns.Contains("Area"))
                    obj.Area = dt.Rows[i]["Area"].ToString();
                if (dt.Columns.Contains("District"))
                    obj.District = dt.Rows[i]["District"].ToString();
                if (dt.Columns.Contains("Contry"))
                    obj.Contry = dt.Rows[i]["Contry"].ToString();
                if (dt.Columns.Contains("City"))
                    obj.City = dt.Rows[i]["City"].ToString();
                if (dt.Columns.Contains("BankAccount"))
                    obj.BankAccount = dt.Rows[i]["BankAccount"].ToString();
                if (dt.Columns.Contains("BankName"))
                    obj.BankName = dt.Rows[i]["BankName"].ToString();
                if (dt.Columns.Contains("CreditLimit"))
                    obj.CreditLimit = double.Parse(dt.Rows[i]["CreditLimit"].ToString());
                if (dt.Columns.Contains("Discount"))
                    obj.Discount = double.Parse(dt.Rows[i]["Discount"].ToString());
                /*if (dt.Columns.Contains("IsDebt"))
                    obj.IsDebt = bool.Parse(dt.Rows[i]["IsDebt"].ToString());
                if (dt.Columns.Contains("IsDebtDetail"))
                    obj.IsDebtDetail = bool.Parse(dt.Rows[i]["IsDebtDetail"].ToString());
                if (dt.Columns.Contains("IsProvider"))
                    obj.IsProvider = bool.Parse(dt.Rows[i]["IsProvider"].ToString());
                 */
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active = bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        /// <summary>
        /// Thêm nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int PROVIDER_Insert(PROVIDER obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_Insert",
                    obj.Customer_ID,
                    obj.OrderID,
                    obj.CustomerName,
                    obj.Customer_Type_ID,
                    obj.Customer_Group_ID,
                    obj.CustomerAddress,
                    obj.Birthday,
                    obj.Barcode,
                    obj.Tax,
                    obj.Tel,
                    obj.Fax,
                    obj.Email,
                    obj.Mobile,
                    obj.Website,
                    obj.Contact,
                    obj.Position,
                    obj.NickYM,
                    obj.NickSky,
                    obj.Area,
                    obj.District,
                    obj.Contry,
                    obj.City,
                    obj.BankAccount,
                    obj.BankName,
                    obj.CreditLimit,
                    obj.Discount,
                    obj.Description,
                    obj.Active
                );
            }
            catch(Exception ex)
            {
                throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// 
        /// </summary>
        /// <param name="Customer_ID"></param>
        /// <returns></returns>
        public int PROVIDER_Delete(string Customer_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_Delete", Customer_ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
        /// <summary>
        /// Lấy thông tin nhà cung cấp thông qua mã nhà cung cấp
        /// </summary>
        /// <param name="Customer_ID"></param>
        /// <returns></returns>
        public PROVIDER PROVIDER_Get(string Customer_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_Get", Customer_ID);
                return MapPROVIDER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public DataTable PROVIDER_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_GetList");
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy thông tin nhà cung cấp thông qua tên nhà cung cấp
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <returns></returns>
        public PROVIDER PROVIDER_GetByName(string CustomerName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_GetByName", CustomerName);
                return MapPROVIDER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Tìm nhà cung cấp thông qua mã, tên nhà cung cấp
        /// </summary>
        /// <param name="Customer_ID"></param>
        /// <param name="CustomerName"></param>
        /// <returns></returns>
        public List<PROVIDER> PROVIDER_Search(string Customer_ID, string CustomerName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_Search",Customer_ID, CustomerName);
                return MapPROVIDER(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cập nhật nhà cung cấp thông qua mã nhà cung cấp
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Customer_ID"></param>
        /// <returns></returns>
        public int PROVIDER_Update(PROVIDER obj, string Customer_ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "PROVIDER_Update",
                    Customer_ID ,
                    obj.OrderID,
                    obj.CustomerName,
                    obj.Customer_Type_ID,
                    obj.Customer_Group_ID,
                    obj.CustomerAddress,
                    obj.Birthday,
                    obj.Barcode,
                    obj.Tax,
                    obj.Tel,
                    obj.Fax,
                    obj.Email,
                    obj.Mobile,
                    obj.Website,
                    obj.Contact,
                    obj.Position,
                    obj.NickYM,
                    obj.NickSky,
                    obj.Area,
                    obj.District,
                    obj.Contry,
                    obj.City,
                    obj.BankAccount,
                    obj.BankName,
                    obj.CreditLimit,
                    obj.Discount,
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
        /// <summary>
        /// Lấy công nợ nhà cung cấp thông qua khu vực
        /// </summary>
        /// <param name="Customer_Group_ID"></param>
        /// <returns></returns>
        public DataTable ProviderDebtGetListInit(string Customer_Group_ID)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "ProviderDebtGetListInit", Customer_Group_ID);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PROVIDER PROVIDER_Top1()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "PROVIDER_Top1");
                return MapPROVIDER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
