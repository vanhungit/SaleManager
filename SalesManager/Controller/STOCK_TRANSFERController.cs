using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLiBanHang.Entity;
using MicrosoftHelper;
namespace QuanLiBanHang.Controller
{
    public class STOCK_TRANSFERController
    {
        private List<STOCK_TRANSFER> MapSTOCK_TRANSFER(DataTable dt)
        {
            List<STOCK_TRANSFER> rs = new List<STOCK_TRANSFER>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                STOCK_TRANSFER obj = new STOCK_TRANSFER();
                if (dt.Columns.Contains("ID"))
                    obj.ID = dt.Rows[i]["ID"].ToString();
                if (dt.Columns.Contains("RefDate"))
                    obj.RefDate = DateTime.Parse(dt.Rows[i]["RefDate"].ToString());
                if (dt.Columns.Contains("Ref_OrgNo"))
                    obj.Ref_OrgNo = dt.Rows[i]["Ref_OrgNo"].ToString();
                if (dt.Columns.Contains("RefType"))
                    obj.RefType = int.Parse(dt.Rows[i]["RefType"].ToString());
                if (dt.Columns.Contains("Department_ID"))
                    obj.Department_ID = dt.Rows[i]["Department_ID"].ToString();
                if (dt.Columns.Contains("Employee_ID"))
                    obj.Employee_ID = dt.Rows[i]["Employee_ID"].ToString();
                if (dt.Columns.Contains("FromStock_ID"))
                    obj.FromStock_ID = dt.Rows[i]["FromStock_ID"].ToString();
                if (dt.Columns.Contains("Sender_ID"))
                    obj.Sender_ID = dt.Rows[i]["Sender_ID"].ToString();
                if (dt.Columns.Contains("ToStock_ID"))
                    obj.ToStock_ID = dt.Rows[i]["ToStock_ID"].ToString();
                if (dt.Columns.Contains("Receiver_ID"))
                    obj.Receiver_ID = dt.Rows[i]["Receiver_ID"].ToString();
                if (dt.Columns.Contains("Branch_ID"))
                    obj.Branch_ID = dt.Rows[i]["Branch_ID"].ToString();
                if (dt.Columns.Contains("Contract_ID"))
                    obj.Contract_ID = dt.Rows[i]["Contract_ID"].ToString();
                if (dt.Columns.Contains("Currency_ID"))
                    obj.Currency_ID = dt.Rows[i]["Currency_ID"].ToString();
                //if (dt.Columns.Contains("ExchangeRate"))
                 //   obj.ExchangeRate = double.Parse(dt.Rows[i]["ExchangeRate"].ToString());
                if (dt.Columns.Contains("Barcode"))
                    obj.Barcode = dt.Rows[i]["Barcode"].ToString();
                if (dt.Columns.Contains("Amount"))
                    obj.Amount = double.Parse(dt.Rows[i]["Amount"].ToString());
                if (dt.Columns.Contains("IsReview"))
                    obj.IsReview = bool.Parse(dt.Rows[i]["IsReview"].ToString());
                if (dt.Columns.Contains("User_ID"))
                    obj.User_ID = dt.Rows[i]["User_ID"].ToString();
                if (dt.Columns.Contains("IsClose"))
                    obj.IsClose = bool.Parse(dt.Rows[i]["IsClose"].ToString());
                if (dt.Columns.Contains("Sorted"))
                    obj.Sorted = long.Parse(dt.Rows[i]["Sorted"].ToString());
                if (dt.Columns.Contains("Description"))
                    obj.Description = dt.Rows[i]["Description"].ToString();
                if (dt.Columns.Contains("Active"))
                    obj.Active =bool.Parse(dt.Rows[i]["Active"].ToString());

                rs.Add(obj);
            }
            return rs;
        }
        public int STOCK_TRANSFER_Insert(STOCK_TRANSFER obj)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_Insert",
                    obj.ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.FromStock_ID,
                    obj.Sender_ID,
                    obj.ToStock_ID,
                    obj.Receiver_ID,
                    obj.Barcode,
                    obj.Amount,
                    obj.IsReview,
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
        public STOCK_TRANSFER STOCK_TRANSFER_Get(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_Get", ID);
                return MapSTOCK_TRANSFER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public STOCK_TRANSFER Transfer_Search(string UserName)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "Transfer_Search", "%" + UserName+"%");
                return MapSTOCK_TRANSFER(dt)[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_TRANSFER> STOCK_INWARD_DETAIL_GetList()
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_GetList");
                return MapSTOCK_TRANSFER(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_GetList_ByDate(DateTime FromDate, DateTime ToDate, long MoneyType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_GetList_ByDate", FromDate, ToDate, MoneyType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_GetList_ByDate_Action(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_GetList_ByDate_Action", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable STOCK_TRANSFER_GetListByDate_STOCK(DateTime FromDate, DateTime ToDate, long MoneyType, int RefType)
        {
            DataTable dt = new DataTable();
            try
            { // lấy dsNV hien thi len luoi voi dieu kien DaXoa = false, TragThai != Nghi Viec
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_GetListByDate_STOCK", FromDate, ToDate, MoneyType, RefType);
                return (dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<STOCK_TRANSFER> STOCK_TRANSFER_GetSX(string Transfer_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_GetSX", Transfer_ID);
                return MapSTOCK_TRANSFER(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string STOCK_TRANSFER_Exist(string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString,dt, "STOCK_TRANSFER_Exist", ID);
                return MapSTOCK_TRANSFER(dt)[0].ID;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public List<STOCK_TRANSFER> STOCK_TRANSFER_Search(STOCK_TRANSFER obj)
        {
            DataTable dt = new DataTable();
            try
            {
                DataProvider.FillDataTable(DataProvider.ConnectionString, dt, "STOCK_TRANSFER_Search",
                    obj.RefDate ,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.Barcode,
                    obj.Amount,
                    obj.IsReview,
                    obj.IsClose,
                    obj.Description 
                    );
                return MapSTOCK_TRANSFER(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int STOCK_TRANSFER_Update(STOCK_TRANSFER obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_Update",
                    ID ,
                    obj.RefDate ,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.FromStock_ID,
                    obj.Sender_ID,
                    obj.ToStock_ID,
                    obj.Receiver_ID,
                    obj.Barcode,
                    obj.Amount,
                    obj.IsReview,
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
        public int STOCK_TRANSFER_UpdateById(STOCK_TRANSFER obj, string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_UpdateById",
                    ID,
                    obj.RefDate,
                    obj.Ref_OrgNo,
                    obj.RefType,
                    obj.FromStock_ID,
                    obj.Sender_ID,
                    obj.ToStock_ID,
                    obj.Receiver_ID,
                    obj.Barcode,
                    obj.Amount,
                    obj.IsReview,
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
        public int STOCK_TRANSFER_Delete(string ID)
        {
            try
            {
                return DataProvider.ExecuteNonquery(DataProvider.ConnectionString, "STOCK_TRANSFER_Delete", ID);
            }
            catch
            {
                //throw ex;
                return -1;
            }
        }
    }
}
